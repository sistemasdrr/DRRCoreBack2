using AutoMapper;
using DRRCore.Application.DTO.Email;
using DRRCore.Application.Interfaces.EmailApplication;
using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DRRCore.Application.Main
{
    public class EmailApplication : IEmailApplication
    {
        private readonly ILogger _logger;
        private readonly IMailFormatter _mailFormatter;
        private readonly IMailSender _mailSender;
        private readonly IFileManager _fileManager;
        private readonly IAttachmentsNotSendDomain _attachmentsNotSendDomain;
        private readonly IEmailConfigurationDomain _emailConfigurationDomain;
        private IMapper _mapper { get; }
        private IEmailHistoryDomain _emailHistoryDomain;

        public EmailApplication(ILogger logger, IMailSender mailSender, IMapper mapper,
            IEmailHistoryDomain emailHistoryDomain, IFileManager fileManager, 
            IAttachmentsNotSendDomain attachmentsNotSendDomain,
            IEmailConfigurationDomain emailConfigurationDomain, IMailFormatter mailFormatter)
        {
            _logger = logger;
            _mailSender = mailSender;
            _mapper = mapper;
            _emailHistoryDomain = emailHistoryDomain;
            _fileManager = fileManager;
            _attachmentsNotSendDomain = attachmentsNotSendDomain;
            _emailConfigurationDomain = emailConfigurationDomain;
            _mailFormatter = mailFormatter;
        }

        public async Task<Response<bool>> SendMailAsync(EmailDataDTO emailDataDto)
        {           
            var response = new Response<bool>();
            try
            {
                emailDataDto.BeAuthenticated = true;
                emailDataDto.UserName = emailDataDto.From;
              
                using (var context=new SqlCoreContext())
                {
                    var user = await context.Employees.Include(x=>x.UserLogins).Where(x => x.Email == emailDataDto.From).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        emailDataDto.Password = user.UserLogins.FirstOrDefault().EmailPassword;
                    }
                    else
                    {
                        throw new Exception("No existe el usuario");
                    }
                    
                }

                emailDataDto.BodyHTML = emailDataDto.IsBodyHTML? await GetBodyHtml(emailDataDto): emailDataDto.BodyHTML;
                _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));
                var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                if (!result)
                {
                    foreach (var item in emailDataDto.Attachments)
                    {
                        item.Path = await UploadFile(item);
                    }
                }
                var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);   
                emailHistory.Success = result;
                response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
               
                _logger.LogInformation(Messages.MailSuccessSend);
                response.IsSuccess = true;
                response.Data = result;


            }
            catch (Exception ex)
            {             
                response.IsSuccess = false;
                response.Message = string.Format(Messages.ExceptionMessage, ex.Message);
                _logger.LogError(response.Message);

            }
            return response;
        }

        private async Task<string> GetBodyHtml(EmailDataDTO emailDataDto)
        {
            var emailConfiguration = await _emailConfigurationDomain.GetByNameAsync(emailDataDto.EmailKey);
       
            var emailConfigurationFooter = await _emailConfigurationDomain.GetByNameAsync(Constants.DRR_WORKFLOW_FOOTER);
            var stringBody= await _mailFormatter.GetEmailBody(emailConfiguration.Name, emailConfiguration.Value, emailDataDto.Parameters, emailDataDto.Table);
            return stringBody.Replace(Constants.FOOTER,emailConfiguration.FlagFooter.Value? emailConfigurationFooter.Value : string.Empty);
            
        }

        /*Reenvio de mail*/
        public async Task<Response<bool>> ReSendMailAsync()
        {
            var response = new Response<bool>();
            List<Attachment> listAttachments;

            var mailsNotSend = await _emailHistoryDomain.GetEmailNotSendAsync();//obtiene la lista de los mails no enviados - success 0

            foreach (var mail in mailsNotSend)
            {
                try
                {
                    var attachmentsNotSend = await _attachmentsNotSendDomain.GetByEmailHistoryIdAsync(mail.IdEmailHistory);//obtiene el adjunto no enviado por medio del id
                    listAttachments = new List<Attachment>();
                    foreach (var attachment in attachmentsNotSend) //Recorre todos los adjuntos
                    {
                        var newAttachment= new Attachment { 
                         FileName = attachment.FileName
                        };
                        newAttachment.StreamBase64= await DownloadFile(attachment.FileName);
                        listAttachments.Add(newAttachment);
                    }
                    var emailRequest = _mapper.Map<EmailValues>(mail);
                    emailRequest.Attachments = listAttachments;
                    var result = await _mailSender.SendMailAsync(emailRequest);
                    if (result)
                    {
                        mail.Success = true;
                        await _emailHistoryDomain.UpdateAsync(mail);
                        foreach (var item in attachmentsNotSend)
                        {
                            await DeleteFile(item.FileName);
                        }
                    }                   
                }
                catch(Exception ex) 
                {
                    response.IsSuccess = false;
                    response.Message = string.Format(Messages.ExceptionMessage, ex.Message);
                    _logger.LogError(response.Message);
                    continue;
                }
            }            
            return response;
        }


        private async Task<string> UploadFile(AttachmentDto attachmentDto)
        {
            return await _fileManager.UploadFile(new MemoryStream(Convert.FromBase64String(attachmentDto.Content)), attachmentDto.FileName);
        }
        private async Task<string> DownloadFile(string remoteFilePath)
        {
            return await _fileManager.DownloadFile(remoteFilePath);
        }
        private async Task<bool> DeleteFile(string path)
        {
            return await _fileManager.DeleteFile(path);
        }

        public async Task<Response<string>> ConvertFileToBase64(string path)
        {
            var response = new Response<string>();
            try
            {
                byte[] archivoBytes = System.IO.File.ReadAllBytes(path);
                string archivoBase64 = Convert.ToBase64String(archivoBytes);
                response.Data = archivoBase64;
                response.IsWarning = false;
            }
            catch(Exception ex)
            {
                response.IsWarning = true;
                response.IsSuccess = false;
                response.Data = ex.Message;
            }
            return response;
        }
    }
}
