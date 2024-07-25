using AspNetCore.Reporting;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Email;
using DRRCore.Application.DTO.Web;
using DRRCore.Application.Interfaces;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Google.Protobuf;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DRRCore.Application.Main
{
    public class WebDataApplication : IWebDataApplication
    {
        private readonly IMailFormatter _mailFormatter;
        private readonly IWebDataDomain _webDataDomain;
        private readonly IReportingDownload _reportingDownload;
        private readonly IEmailConfigurationDomain _emailConfigurationDomain;
        private readonly IMailSender _mailSender;
        private readonly IFileManager _fileManager;
        private readonly IEmailHistoryDomain _emailHistoryDomain;

        private readonly ILogger _logger;
        private IMapper _mapper { get; }
        public WebDataApplication(IMailFormatter mailFormatter,
                                  IEmailHistoryDomain emailHistoryDomain,
                                  IWebDataDomain webDataDomain,
                                  ILogger logger,
                                  IMapper mapper,
                                  IReportingDownload reportingDownload,
                                  IEmailConfigurationDomain emailConfigurationDomain,
                                  IMailSender mailSender,
                                  IFileManager fileManager)
        {
            _mailFormatter = mailFormatter;
            _emailConfigurationDomain = emailConfigurationDomain;
            _webDataDomain = webDataDomain;
            _logger = logger;
            _mapper = mapper;
            _reportingDownload = reportingDownload;
            _emailConfigurationDomain = emailConfigurationDomain;
            _mailSender = mailSender;
            _fileManager = fileManager;
            _emailHistoryDomain = emailHistoryDomain;
        }
        public async Task<Response<bool>> AddOrUpdateWebDataAsync()
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _webDataDomain.AddOrUpdateWebDataAsync();

            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, exception);
            }
            return response;
        }

        public async Task<Response<WebDataDto>> GetByCodeAsync(string code)
        {
            var response = new Response<WebDataDto>();

            try
            {
                var data = await _webDataDomain.GetByCodeAsync(code);
                if (data != null)
                {
                    response.Data = _mapper.Map<WebDataDto>(data);
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }


            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, exception);
            }
            return response;
        }

        public async Task<Response<List<WebDataDto>>> GetByParamAsync(string param, int page = 1)
        {
            var response = new Response<List<WebDataDto>>();
            if (string.IsNullOrEmpty(param))
            {
                response.IsSuccess = false;
                response.Message = Messages.WrongParameter;
                _logger.LogAdvertencia(response.Message);
                return response;

            }
            if (param.Trim().Length < 3)
            {
                response.IsSuccess = false;
                response.Message = Messages.ParameterIsNotTooLonger;
                _logger.LogAdvertencia(response.Message);
                return response;

            }
            try
            {
                var data = await _webDataDomain.GetByParamAsync(param.ToUpper(), page);
                response.Data = _mapper.Map<List<WebDataDto>>(data);

            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, exception);
            }
            return response;
        }

        public async Task<Response<List<WebDataDto>>> GetByCountryAndBranchAsync(int country, string branch, int page)
        {
            var response = new Response<List<WebDataDto>>();
            try
            {
                if (country > 0 && !string.IsNullOrEmpty(branch) && page > 0)
                {
                    var data = await _webDataDomain.GetByCountryAndBranchAsync(country, branch, page);
                    response.Data = _mapper.Map<List<WebDataDto>>(data);                   
                }
                else
                {
                    response.IsSuccess = false;
                    response.IsWarning = true;
                    response.Message = "Error al listar: parametros invalidos";
                    _logger.LogError(response.Message);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = "Error al listar: " + ex.Message;
                _logger.LogError(response.Message, ex);
                return response;
            }
        }

        public async Task<Response<List<WebDataDto>>> GetSimilarBrunchAsync(string code)
        {
            var response = new Response<List<WebDataDto>>();
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    var data = await _webDataDomain.GetSimilarBrunchAsync(code);
                    response.Data = _mapper.Map<List<WebDataDto>>(data);                  
                }
                else
                {
                    response.IsSuccess = false;
                    response.IsWarning = true;
                    response.Message = "Error al listar: parametros invalidos";
                    _logger.LogError(response.Message);
                }
                return response;
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = "Error al listar: " + ex.Message;
                _logger.LogError(response.Message, ex);
                return response;
            }
        }

        public async Task<Response<string>> GetOldCodeAsync(string code)
        {

            var response = new Response<string>();
            try
            {
                if (!string.IsNullOrEmpty(code) && code.Length==11)
                {
                    response.Data = await _webDataDomain.GetOldCodeAsync(code);                
                }
                else
                {
                    response.IsSuccess = false;
                    response.IsWarning = true;
                    response.Message = "Error al listar: parametro inválido";
                    _logger.LogError(response.Message);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = "Error al listar: " + ex.Message;
                _logger.LogError(response.Message, ex);
                return response;
            }
        }

        public async Task<Response<bool>> DispatchPDF(WebDTO obj)
        {
            var response = new Response<bool>();
            var fileDto = new GetFileResponseDto();
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.OldCode.Contains(obj.OldCode.Trim())).FirstOrDefaultAsync();

                var reportName = "";
                var language = obj.Language == "C" ? "E" : "I";

                if (obj.Language.Trim() == "C")
                {
                    if (obj.Quality.Trim() == "A")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-A-ES";
                    }
                    else if (obj.Quality.Trim() == "B")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-B-ES";
                    }
                    else if (obj.Quality.Trim() == "C")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-C-ES";
                    }
                }
                else if (obj.Language.Trim() == "I")
                {
                    if (obj.Quality.Trim() == "A")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-A-EN";
                    }
                    else if (obj.Quality.Trim() == "B")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-B-EN";
                    }
                    else if (obj.Quality.Trim() == "C")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-C-EN";
                    }
                }
                string fileFormat = "{0}-{1}-{2}{3}";
                var reportRenderType = StaticFunctions.GetReportRenderType("pdf");
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCompany", company.Id.ToString() },
                    { "language", language }
                };

                var file = await _reportingDownload.GenerateReportAsync(reportName, reportRenderType, dictionary);
                fileDto = new GetFileResponseDto
                {
                    File = file,
                    ContentType = contentType,
                    Name = string.Format(fileFormat, obj.TransactionCode, obj.RequestedName, obj.Quality,".pdf")
                };


                var emailDataDto = new EmailDataDTO();
                emailDataDto.To = new List<string>();
                emailDataDto.CC = new List<string>();

                emailDataDto.EmailKey = obj.Language == "C" ? "DRR_WORKFLOW_ESP_0060" : "DRR_WORKFLOW_ENG_0060";
                emailDataDto.BeAuthenticated = true;
                emailDataDto.From = "diego.rodriguez@del-risco.com";//info@del-risco.com;
                emailDataDto.UserName = "diego.rodriguez@del-risco.com"; //info@del-risco.com;
                emailDataDto.Password = "w*@JHCr7mH";  // gD@rQKC0xN;

                if (obj.UserEmail.Contains(';'))
                {
                    var emails = obj.UserEmail.Split(';');
                    foreach (var email in emails)
                    {
                        emailDataDto.To.Add(email);
                        emailDataDto.CC.Add(email);
                    }
                }
                else
                {
                    emailDataDto.To.Add(obj.UserEmail);
                    emailDataDto.CC.Add(obj.UserEmail);
                }

                emailDataDto.To = new List<string>
                {
                    "jfernandez@del-risco.com",
                };
                emailDataDto.CC = new List<string>
                {
                     "diego.rodriguez@del-risco.com",
                };

                var subjectName = (obj.Language == "C" ? "Pedido : " : "Order : ") + obj.TransactionCode + " - " + obj.RequestedName;
                emailDataDto.Subject = subjectName;
                emailDataDto.IsBodyHTML = true;
                emailDataDto.Parameters.Add(obj.User);
                emailDataDto.Parameters.Add(obj.Name);
                emailDataDto.Parameters.Add(obj.UserCountry);
                emailDataDto.Parameters.Add(obj.User);
                emailDataDto.Parameters.Add(obj.RequestedName);
                emailDataDto.Parameters.Add(obj.Quality);
                emailDataDto.Parameters.Add(obj.Price.ToString());
                emailDataDto.Parameters.Add("info@del-risco.com");
                emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));

                var attachment = new AttachmentDto();
                attachment.FileName = fileDto.Name;
                attachment.Content = Convert.ToBase64String(fileDto.File);
                attachment.Path = await UploadFile(attachment);
                emailDataDto.Attachments.Add(attachment);

                var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                emailHistory.Success = result;
                response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
                _logger.LogInformation(Messages.MailSuccessSend);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = ex.Message;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        private async Task<string> GetBodyHtml(EmailDataDTO emailDataDto)
        {
            var emailConfiguration = await _emailConfigurationDomain.GetByNameAsync(emailDataDto.EmailKey);

            var emailConfigurationFooter = await _emailConfigurationDomain.GetByNameAsync(Constants.DRR_WORKFLOW_FOOTER);
            var stringBody = await _mailFormatter.GetEmailBody(emailConfiguration.Name, emailConfiguration.Value, emailDataDto.Parameters, emailDataDto.Table);
            return stringBody.Replace(Constants.FOOTER, emailConfiguration.FlagFooter.Value ? emailConfigurationFooter.Value : string.Empty);

        }
        private async Task<string> UploadFile(AttachmentDto attachmentDto)
        {
            return await _fileManager.UploadFile(new MemoryStream(Convert.FromBase64String(attachmentDto.Content)), attachmentDto.FileName);
        }
    }
}
