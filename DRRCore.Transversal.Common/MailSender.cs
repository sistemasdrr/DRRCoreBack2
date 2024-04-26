using DRRCore.Transversal.Common.Interface;
using DRRCore.Transversal.Common.JsonReader;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace DRRCore.Transversal.Common
{
    public class EmailValues{
        public string FromEmail { get; set; }= string.Empty;
        public List<string> ToEmail { get; set; } = new List<string>();
        public List<string> CcEmail { get; set; } = new List<string>();
        public List<string> BccEmail { get; set; } = new List<string>();
        public string? Subject { get; set; } = string.Empty;
        public string DisplayName { get; set; }= string.Empty;
        public string? Body { get; set; } = string.Empty;
        public bool IsHtml { get; set; } = true;
        public List<Attachment> Attachments { get; set; }= new List<Attachment>();
        public string UserName { get; set; } = string.Empty;    
        public string Password { get; set; }=string.Empty;
        public bool BeAuthenticated { get; set; } 

     }
    public class Attachment
    {
        public string FileName { get; set; }=string.Empty;
        public string StreamBase64 { get; set; }= string.Empty;
    }
    public class MailSender : IMailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger _logger;
        public MailSender(IOptions<EmailSettings> options,ILogger logger)
        {
            _emailSettings = options.Value;
            _logger = logger;
        }
       
        public async Task<bool> SendMailAsync(EmailValues values)
        {
            bool response = false;
            if (!_emailSettings.IsDebugging) {

                if (_emailSettings.IsMultipleDomain)
                {
                    var client = smtpClient();
                    try
                    {
                        await client.SendMailAsync(mailMessage(values));
                        _logger.LogInformation(Messages.MailSuccessSend);
                        response = true;

                    }catch
                    {
                        for (var i = 0; i < _emailSettings?.OtherDomainsConfiguration.Count; i++)
                        {
                            client=smtpClient(i);
                            try
                            {
                                await client.SendMailAsync(mailMessage(values));
                                _logger.LogInformation(Messages.MailSuccessSend);
                                response = true;
                                break;
                            }
                            catch (Exception ex)
                            {
                                _logger.LogInformation(string.Format(Messages.ErrorMailSend,ex.Message));
                                continue;
                            }                            
                        }
                    }
                }else if (values.BeAuthenticated)
                {
                    var client = smtpClient(values.UserName,values.Password);
                    try
                    {
                        await client.SendMailAsync(mailMessage(values));
                        _logger.LogInformation(Messages.MailSuccessSend);
                        response = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation(string.Format(Messages.ErrorMailSend, ex.Message));
                        return false;
                    }
                }
                else
                {
                    var client = smtpClient();
                    try
                    {
                        await client.SendMailAsync(mailMessage(values));
                        _logger.LogInformation(Messages.MailSuccessSend);
                        response = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation(string.Format(Messages.ErrorMailSend, ex.Message));
                        return false;
                    }
                   
                }
               
            }
            return response;
        }
        private SmtpClient smtpClient(string user, string password)
        {
            return new SmtpClient()
            {
                Host = _emailSettings.PrincipalDomain.Host,
                //EnableSsl = _emailSettings.PrincipalDomain.EnableSsl,
                Port = _emailSettings.PrincipalDomain.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                // UseDefaultCredentials = _emailSettings.PrincipalDomain.UseDefaultCredentials,
                Credentials = new NetworkCredential(user,password)
            };

        }
        private SmtpClient smtpClient()
        {
              return new SmtpClient()
                {
                    Host= _emailSettings.PrincipalDomain.Host,
                    //EnableSsl = _emailSettings.PrincipalDomain.EnableSsl,
                    Port= _emailSettings.PrincipalDomain.Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                   // UseDefaultCredentials = _emailSettings.PrincipalDomain.UseDefaultCredentials,
                    Credentials = new NetworkCredential(_emailSettings.PrincipalDomain.Credential.Username, _emailSettings.PrincipalDomain.Credential.Password)
                };
          
        }
        private SmtpClient smtpClient(int index)
        {
            return new SmtpClient()
            {
                Host = _emailSettings.OtherDomainsConfiguration[index].Host,
                //EnableSsl = _emailSettings.OtherDomainsConfiguration[index].EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port= _emailSettings.OtherDomainsConfiguration[index].Port,
                UseDefaultCredentials = _emailSettings.OtherDomainsConfiguration[index].UseDefaultCredentials,
                Credentials = new NetworkCredential(_emailSettings.OtherDomainsConfiguration[index].Credential.Username,
                                                    _emailSettings.OtherDomainsConfiguration[index].Credential.Password)
            };

        }
        private MailMessage mailMessage(EmailValues values)
        {
            MailAddress from = new(values.FromEmail);
            
            MailAddress to = new(values.ToEmail[0],values.DisplayName);
           
            MailMessage message = new(from, to);           
            message.Subject = values.Subject;
            message.Body = values.Body;
            if (values.CcEmail.Count>0)
            {
                foreach (var item in values.CcEmail)
                {
                    if (item.Contains(';'))
                    {
                        var split = item.Split(';');
                        for (int i = 0; i < split.Length; i++)
                        {
                            message.CC.Add(split[i]);
                        }
                    }
                    else
                    {
                        message.CC.Add(item);
                    }
                    
                }
                
            }
            if (values.BccEmail.Count > 0)
            {
                foreach (var item in values.BccEmail)
                {
                    if (item.Contains(';'))
                    {
                        var split = item.Split(';');
                        for (int i = 0; i < split.Length; i++)
                        {
                            message.Bcc.Add(split[i]);
                        }
                    }
                    else
                    {
                        message.Bcc.Add(item);
                    }
                }
            }
           
            message.IsBodyHtml = values.IsHtml;
            if (values.Attachments!=null || values.Attachments?.Count>0)
            {
                foreach (var attachment in values.Attachments)
                {
                    var ms = new MemoryStream(Convert.FromBase64String(attachment.StreamBase64));
                    message.Attachments.Add(new System.Net.Mail.Attachment(ms,attachment.FileName));
                }
               
            }
          
            return message;
        }

        public Task<bool> ReSendMailAsync(EmailValues values)
        {
            throw new NotImplementedException();
        }
    }
}
