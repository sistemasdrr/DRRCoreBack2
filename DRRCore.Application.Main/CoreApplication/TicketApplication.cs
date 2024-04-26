using AspNetCore.Reporting;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using AutoMapper;
using AutoMapper.Execution;
using CoreFtp;
using DRRCore.Application.DTO.API;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Email;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Interfaces.EmailApplication;
using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using System.IO;
using System.ServiceModel.Channels;
using ZstdSharp.Unsafe;

namespace DRRCore.Application.Main.CoreApplication
{
    public class TicketApplication : ITicketApplication
    {
        private readonly IMailFormatter _mailFormatter;
        private readonly IAttachmentsNotSendDomain _attachmentsNotSendDomain;
        private readonly IEmailConfigurationDomain _emailConfigurationDomain;
        private readonly IMailSender _mailSender;
        private readonly IFileManager _fileManager;

        private readonly INumerationDomain _numerationDomain;
        private readonly ICountryDomain _countryDomain;
        private readonly ITicketDomain _ticketDomain;
        private readonly ITicketHistoryDomain _ticketHistoryDomain;
        private readonly ICompanyDomain _companyDomain;
        private readonly ITCuponDomain _tCuponDomain;
        private readonly ITicketAssignationDomain _ticketAssignationDomain;
        private readonly ITicketReceptorDomain _ticketReceptorDomain;
        private readonly IUserLoginDomain _userLoginDomain;
        private readonly IEmailApplication _emailApplication;
        private readonly IReportingDownload _reportingDownload;
        private readonly IEmployeeDomain _employeeDomain;
        private readonly IPersonDomain _personDomain;
        private readonly ISubscriberDomain _subscriberDomain;
        private readonly IPersonalDomain _personalDomain;
        private readonly IAgentDomain _agentDomain;
        private readonly ICompanyApplication _companyApplication;
        private IEmailHistoryDomain _emailHistoryDomain;
        private IMapper _mapper;
        private ILogger _logger;

        public TicketApplication(INumerationDomain numerationDomain, ITicketAssignationDomain ticketAssignationDomain, IEmployeeDomain employeeDomain,
            ITCuponDomain tCuponDomain, ITicketDomain ticketDomain, IPersonalDomain personalDomain, IAgentDomain agentDomain,
            ITicketReceptorDomain ticketReceptorDomain, ITicketHistoryDomain ticketHistoryDomain, ICountryDomain countryDomain,
            ICompanyDomain companyDomain, IMapper mapper, ILogger logger, IReportingDownload reportingDownload, IMailFormatter mailFormatter, IEmailConfigurationDomain emailConfigurationDomain,
            IEmailApplication emailApplication, IUserLoginDomain userLoginDomain, IPersonDomain personDomain, ISubscriberDomain subscriberDomain, ICompanyApplication companyApplication,
            IMailSender mailSender, IFileManager fileManager, IEmailHistoryDomain emailHistoryDomain)
        {
            _numerationDomain = numerationDomain;
            _companyApplication = companyApplication;
            _ticketDomain = ticketDomain;
            _ticketHistoryDomain = ticketHistoryDomain;
            _mapper = mapper;
            _companyDomain = companyDomain;
            _tCuponDomain = tCuponDomain;
            _ticketReceptorDomain = ticketReceptorDomain;
            _logger = logger;
            _userLoginDomain = userLoginDomain;
            _emailApplication = emailApplication;
            _reportingDownload = reportingDownload;
            _subscriberDomain = subscriberDomain;
            _personDomain = personDomain;
            _ticketAssignationDomain = ticketAssignationDomain;
            _personalDomain = personalDomain;
            _agentDomain = agentDomain;
            _countryDomain = countryDomain;
            _employeeDomain = employeeDomain;
            _mailFormatter = mailFormatter;
            _emailConfigurationDomain = emailConfigurationDomain;
            _fileManager = fileManager;
            _mailSender = mailSender;
            _emailHistoryDomain = emailHistoryDomain;
        }
        public async Task<Response<List<GetTicketFileResponseDto>>> GetTicketFilesByIdTicket(int idTicket)
        {
            var response = new Response<List<GetTicketFileResponseDto>>();
            try
            {
                var ticketFiles = await _ticketDomain.GetFilesByIdTicket(idTicket);
                response.Data = _mapper.Map<List<GetTicketFileResponseDto>>(ticketFiles);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<GetFileDto>> DownloadFileByPath(string path)
        {
            var response = new Response<GetFileDto>();
            MemoryStream ms = new MemoryStream();
            try
            {
                var file = await _ticketDomain.GetFileByPath(path);
                if (file != null)
                {
                    ms.Position = 0;
                    ms = await DescargarArchivo(path);
                    var documentDto = new GetFileDto();
                    documentDto.File = ms;
                    documentDto.ContentType = GetContentType(file.Extension);
                    documentDto.FileName = file.Name;
                    response.Data = documentDto;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
            }
            return response;
        }

        private string GetContentType(string extension)
        {
            switch (extension.ToLower())
            {
                case ".pdf":
                    return "application/pdf";
                case ".doc":
                case ".docx":
                    return "application/msword";
                case ".xls":
                case ".xlsx":
                    return "application/vnd.ms-excel";
                case ".txt":
                    return "text/plain";
                case ".zip":
                    return "application/zip";
                case ".rar":
                    return "application/x-rar-compressed";
                case ".xml":
                    return "application/xml";
                case ".json":
                    return "application/json";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return "application/octet-stream";
            }
        }
        private async Task<MemoryStream> DescargarArchivo(string? path)
        {
            using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
            {
                await ftpClient.LoginAsync();

                using (var ftpReadStream = await ftpClient.OpenFileReadStreamAsync(path))
                {
                    using (var stream = new MemoryStream())
                    {
                        await ftpReadStream.CopyToAsync(stream);
                        return stream;
                    }
                }
            }
        }


        public async Task<Response<bool>> AddTicketAsync(AddOrUpdateTicketRequestDto request)
        {
            var response = new Response<bool>();
            try
            {
                if (request == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (request.Id == 0)
                {
                    var newTicket = _mapper.Map<Ticket>(request);
                    newTicket.IdStatusTicket = (int?)TicketStatusEnum.Pendiente;
                    newTicket.TicketHistories.Add(new TicketHistory
                    {
                        IdStatusTicket = (int?)TicketStatusEnum.Pendiente,
                        UserFrom = request.UserFrom
                    });
                    var idEmployee = await GetReceptorDefault(request.IdCountry ?? 0, request.ReportType, request.IdSubscriber);
                    using var context = new SqlCoreContext();
                    var userLogin = await context.UserLogins
                        .Include(x => x.IdEmployeeNavigation).Where(x => x.IdEmployeeNavigation.Id == idEmployee).FirstOrDefaultAsync();
                    newTicket.TicketAssignation = new TicketAssignation
                    {
                        //IdEmployee = idEmployee,
                        IdUserLogin = userLogin.Id
                    };

                    if (await _ticketDomain.AddAsync(newTicket))
                    {
                     
                        await _numerationDomain.UpdateTicketNumberAsync();
                        if (request.About == "E" && newTicket.IdCompany == null)
                        {
                            var company = await _companyDomain.AddCompanyAsync(new Company
                            {
                                Name = request.RequestedName ?? string.Empty,
                                Language = request.Language

                            });
                            var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                            ticket.IdCompany = company;
                            await _ticketDomain.UpdateAsync(ticket);


                        }
                        if (request.About == "P" && newTicket.IdPerson == null)
                        {
                            var person = await _personDomain.AddPersonAsync(new Person
                            {
                                Fullname = request.RequestedName ?? string.Empty,
                                Language = request.Language
                            });
                            var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                            ticket.IdPerson = person;
                            await _ticketDomain.UpdateAsync(ticket);
                        }
                        if (request.About == "E" && request.ReportType != "OR")
                        {
                            var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                            var doc= await _companyApplication.DownloadF1(ticket.IdCompany??0, "ESP", "pdf");
                            if(doc!=null && doc.Data != null)
                            {
                                var data = doc.Data;
                                var path = await UploadF1(ticket.Id, "RV_" + ticket.RequestedName, data.File);

                                await context.TicketFiles.AddAsync(new TicketFile
                                {
                                    IdTicket = ticket.Id,
                                    Path = path,
                                    Name = "RV_" + DateTime.Now.ToString("ddMMyy") + "_" + request.Number.ToString("D6"),
                                    Extension = ".pdf"
                                });
                                await context.SaveChangesAsync();
                            }
                        }
                        response.Data = true;
                    }
                }
                else
                {
                    var existingTicket = await _ticketDomain.GetByIdAsync(request.Id);
                    if (existingTicket == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingTicket = _mapper.Map(request, existingTicket);

                    existingTicket.UpdateDate = DateTime.Now;
                    await _ticketDomain.UpdateAsync(existingTicket);
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;

        }

        private async Task<int?> GetReceptorDefault(int idCountry, string reportType, int? idSubscriber)
        {
            var getReceptor = new TicketReceptor();
            var subscriber = await _subscriberDomain.GetSubscriberById(idSubscriber ?? 0);
            if ((subscriber != null && subscriber.Code == "0107") || reportType == "BC")
            {
                return 42;
            }
            if (reportType == "DF")
            {
                getReceptor = await _ticketReceptorDomain.GetReceptorDoubleDate(idCountry);
                return getReceptor.IdEmployee ?? null;
            }
            if (reportType == "EF")
            {
                getReceptor = await _ticketReceptorDomain.GetReceptorInDate(idCountry);
                return getReceptor.IdEmployee ?? null;
            }
            getReceptor = await _ticketReceptorDomain.GetReceptorOtherCase(idCountry);
            return getReceptor.IdEmployee ?? null;
        }

        public async Task<Response<bool>> DeleteTicket(int id)
        {
            var response = new Response<bool>();
            try
            {
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = await _ticketDomain.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<GetExistingTicketResponseDto>> GetReportType(int id, string type)
        {
            var response = new Response<GetExistingTicketResponseDto>();
            var getExist = new GetExistingTicketResponseDto();
            var list = new List<GetListSameSearchedReportResponseDto>();
            try
            {
                if (type == "E")
                {
                    var company = await _companyDomain.GetByIdAsync(id);
                    if (company == null)
                    {
                        throw new Exception(Messages.MessageNoDataFound);
                    }
                    var newBd = await _ticketDomain.GetTicketByCompany(company.Id);

                    if (newBd != null && newBd.Any())
                    {
                        list.AddRange(_mapper.Map<List<GetListSameSearchedReportResponseDto>>(newBd));
                    }

                    if (company.OldCode != null && company.OldCode.StartsWith("E"))
                    {
                        var oldBd = await _ticketDomain.GetOldTicketByCompany(company.OldCode);
                        if (oldBd != null && oldBd.Any())
                        {
                            list.AddRange(_mapper.Map<List<GetListSameSearchedReportResponseDto>>(oldBd));
                        }
                    }

                    if (list.Any())
                    {
                        getExist.TypeReport = "RV";
                        list = list.OrderByDescending(x => x.DispatchtDate).ToList();

                        var firstTicket = list.FirstOrDefault();

                        if (firstTicket.IsPending)
                        {
                            getExist.TypeReport = "DF";
                        }
                        else
                        {
                            if ((DateTime.Now - firstTicket.DispatchtDate).TotalDays <= 90)
                            {
                                getExist.TypeReport ="EF";
                            }
                        }

                       
                        getExist.LastSearchedDate = firstTicket.DispatchtDate.ToShortDateString();
                    }
                    getExist.ListSameSearched = list.ToList();
                    response.Data = getExist;

                }
                else if (type == "P")
                {
                    var person = await _personDomain.GetByIdAsync(id);
                    if (person == null)
                    {
                        throw new Exception(Messages.MessageNoDataFound);
                    }
                    var newBd = await _ticketDomain.GetTicketByPerson(person.Id);

                    if (newBd != null && newBd.Any())
                    {
                        list.AddRange(_mapper.Map<List<GetListSameSearchedReportResponseDto>>(newBd));
                    }

                    if (person.OldCode != null && person.OldCode.StartsWith("P"))
                    {
                        var oldBd = await _ticketDomain.GetOldTicketByPerson(person.OldCode);
                        if (oldBd != null && oldBd.Any())
                        {
                            list.AddRange(_mapper.Map<List<GetListSameSearchedReportResponseDto>>(oldBd));
                        }
                    }

                    if (list.Any())
                    {
                        getExist.TypeReport = "RV";
                        list = list.OrderByDescending(x => x.DispatchtDate).ToList();

                        var firstTicket = list.FirstOrDefault();
                        if (firstTicket.IsPending)
                        {
                            getExist.TypeReport = "DF";
                        }
                        else
                        {
                            if ((DateTime.Now - firstTicket.DispatchtDate).TotalDays <= 90)
                            {
                                getExist.TypeReport = "EF";
                            }
                        }
                        getExist.LastSearchedDate = firstTicket.DispatchtDate.ToShortDateString();
                    }
                    getExist.ListSameSearched = list.ToList();
                    response.Data = getExist;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListTicketResponseDto>>> GetTicketListAsync()
        {
            var response = new Response<List<GetListTicketResponseDto>>();
            try
            {
                var list = await _ticketDomain.GetAllAsync();
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetListTicketResponseDto>>(list);
                }
                else
                {
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListTicketResponseDto>>> GetTicketListPendingAsync()
        {
            var response = new Response<List<GetListTicketResponseDto>>();
            try
            {
                var tickets = await _ticketDomain.GetAllPendingTickets();
                response.Data = _mapper.Map<List<GetListTicketResponseDto>>(tickets);

                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetNumerationResponseDto>> GetTicketNumberAsync()
        {
            var response = new Response<GetNumerationResponseDto>();
            try
            {
                var number = await _numerationDomain.GetTicketNumberAsync();
                if (number == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                int currentNumber = number.Number + 1 ?? 0;
                response.Data = new GetNumerationResponseDto
                {
                    IntValue = currentNumber,
                    StrValue = currentNumber.ToString("D6")
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetTicketRequestDto>> GetTicketRequestAsync(int id)
        {
            var response = new Response<GetTicketRequestDto>();
            try
            {
                var ticket = await _ticketDomain.GetByIdAsync(id);
                if (ticket != null)
                {
                    response.Data = _mapper.Map<GetTicketRequestDto>(ticket);
                }
                else
                {
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        private async Task<string> UploadF1(int idTicket, string fileName, byte[] byteArray)
        {
            try
            {
                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                var path = "/cupones/" + ticket.Number.ToString("D6") + "/" + fileName + ".pdf";
                using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
                {
                    await ftpClient.LoginAsync();

                    MemoryStream memoryStream = new MemoryStream(byteArray);
                    memoryStream.Position = 0;

                    using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(path))
                    {
                        await memoryStream.CopyToAsync(writeStream);
                    }


                }
                return path;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Messages.ExceptionMessage, ex.Message));
            }
        }
        private async Task<string> UploadDispatchReport(int idTicket, string fileName, byte[] byteArray)
        {
            try
            {

                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                var path = "/cupones/" + ticket.Number.ToString("D6") + "/" + fileName + ".pdf";
                    using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
                    {
                        await ftpClient.LoginAsync();

                        MemoryStream memoryStream = new MemoryStream(byteArray);
                        memoryStream.Position = 0;

                        using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(path))
                        {
                            await memoryStream.CopyToAsync(writeStream);
                        }
                    }
                    return path;
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Messages.ExceptionMessage, ex.Message));
            }
        }
        private async Task<string> CopyReportForm(int ticket)
        {
            try
            {
                var path = "/cupones/" + ticket.ToString("D6") + "/" + ticket.ToString("D6") + "_Planilla_Reportero.doc";
                using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
                {
                    await ftpClient.LoginAsync();

                    using (var ftpReadStream = await ftpClient.OpenFileReadStreamAsync("/plantillas/Planilla_Reportero.doc"))
                    {

                        using (var stream = new MemoryStream())
                        {
                            await ftpReadStream.CopyToAsync(stream);
                            stream.Position = 0;

                            using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(path))
                            {
                                await stream.CopyToAsync(writeStream);
                            }
                        }
                    }
                }
                return path;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Messages.ExceptionMessage, ex.Message));
            }
        }
        private async Task<string> CopyReportPerson(int ticket)
        {
            try
            {
                var path = "/cupones/" + ticket.ToString("D6") + "/" + ticket.ToString("D6") + "_Planilla_Negocios_Personales.doc";
                using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
                {
                    await ftpClient.LoginAsync();

                    using (var ftpReadStream = await ftpClient.OpenFileReadStreamAsync("/plantillas/Planilla_Negocios_Personales.doc"))
                    {

                        using (var stream = new MemoryStream())
                        {
                            await ftpReadStream.CopyToAsync(stream);
                            stream.Position = 0;

                            using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(path))
                            {
                                await stream.CopyToAsync(writeStream);
                            }
                        }
                    }
                }
                return path;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Messages.ExceptionMessage, ex.Message));
            }
        }
        private FtpClientConfiguration GetFtpClientConfiguration()
        {
            return new FtpClientConfiguration
            {
                Host = "win5248.site4now.net",
                Port = 21,
                Username = "drrcore2024",
                Password = "drrti2023"
            };
        }

        public async Task<Response<List<GetListTicketResponseDto>>> GetTicketListByAsync(string ticket, string name, string subscriber, string type, string procedure)
        {
            var response = new Response<List<GetListTicketResponseDto>>();
            try
            {
                var list = await _ticketDomain.GetAllByAsync(ticket, name, subscriber, type, procedure);
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetListTicketResponseDto>>(list);
                }
                else
                {
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetTicketQueryResponseDto>> GetTicketQuery(int idTicket)
        {
            var response = new Response<GetTicketQueryResponseDto>();
            try
            {
                var query = await _ticketDomain.GetTicketQuery(idTicket);


                if (query == null)
                {
                    var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                    response.Data = new GetTicketQueryResponseDto
                    {
                        IdTicket = ticket.Id,
                        QueryDate = DateTime.Now,
                        IdSubscriber = ticket.IdSubscriber,
                        Report = ticket.RequestedName ?? string.Empty,
                        Email = ticket.IdSubscriberNavigation.Email,
                        Language = ticket.Language,
                        SubscriberName = ticket.IdSubscriberNavigation == null ? string.Empty : ticket.IdSubscriberNavigation.Code + "||" + ticket.IdSubscriberNavigation.Name ?? string.Empty

                    };
                }
                else {
                    response.Data = _mapper.Map<GetTicketQueryResponseDto>(query);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AnswerTicket(int idTicket, string subscriberResponse)
        {
            var response = new Response<bool>();
            try
            {
                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                ticket.IdStatusTicket = (int?)TicketStatusEnum.Pendiente;
                await _ticketDomain.UpdateAsync(ticket);

                response.Data = await _ticketDomain.TicketQueryAnswered(idTicket, subscriberResponse);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> SendTicketQuery(SendTicketQueryRequestDto request)
        {
            var listEmailTo = new List<string>();
            var listEmailCC = new List<string>();
            var response = new Response<bool>();
            try
            {
                var query = _mapper.Map<TicketQuery>(request);
                query.IdEmployee = 1;
                response.Data = await _ticketDomain.AddTicketQuery(query);

                var user = await _userLoginDomain.GetByIdAsync(int.Parse(request.User));

                var ticket = await _ticketDomain.GetByIdAsync(request.IdTicket);

                listEmailTo.AddRange(request.Email.Split(';'));
                listEmailCC.Add(user.IdEmployeeNavigation.Email);

                string subject;
                if (request.Language == "I")
                {
                    subject = "Requirement query : " + ticket.RequestedName + "| Order Date : " + ticket.OrderDate;
                }
                else
                {
                    subject = "Consulta al requerimiento : " + ticket.RequestedName + "| Fecha : " + ticket.OrderDate.ToString("dd/MM/yyyy");
                }
                var responseEmail = await _emailApplication.SendMailAsync(new DTO.Email.EmailDataDTO
                {
                    BeAuthenticated = true,
                    UserName = user.IdEmployeeNavigation.Email,
                    Password = user.EmailPassword,
                    EmailKey = request.Language == "I" ? Constants.DRR_EECORE_ENG_QUERYTICKET : Constants.DRR_EECORE_ESP_QUERYTICKET,
                    From = user.IdEmployeeNavigation.Email,
                    To = listEmailTo,
                    DisplayName = user.IdEmployeeNavigation.FirstName + ' ' + user.IdEmployeeNavigation.LastName,
                    User = request.User,
                    CC = listEmailCC,
                    IsBodyHTML = true,
                    Subject = subject,
                    Parameters = new List<string>
                    {
                        ticket.IdSubscriberNavigation.Name,
                        ticket.RequestedName,
                        ticket.OrderDate.ToString("dd/MM/yyyy"),
                        request.Language=="I"? ticket.IdCountryNavigation.EnglishName:ticket.IdCountryNavigation.Name,
                        ticket.ReferenceNumber,
                        request.Message,
                        user.IdEmployeeNavigation.Email
                    }
                });
                if (responseEmail.Data)
                {
                    ticket.IdStatusTicket = (int?)TicketStatusEnum.En_Consulta;
                    await _ticketDomain.UpdateAsync(ticket);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<byte[]>> DownloadReport()
        {
            var response = new Response<byte[]>();
            try
            {
                response.Data = await _reportingDownload.GenerateReportAsync("reporteTicket", ReportRenderType.Excel, null);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> SavePreAsignTicket(List<SavePreAsignTicketDto> lista)
        {
            var response = new Response<bool>();
            try
            {
                foreach (var item in lista)
                {
                    var ticketAssignation = await _ticketAssignationDomain.GetByIdAsync(item.Id);
                    if (ticketAssignation != null)
                    {
                        ticketAssignation.Commentary = item.Commentary;
                        //ticketAssignation.IdEmployee = item.IdReceptor;
                        ticketAssignation.IdUserLogin = item.IdReceptor;
                        await _ticketAssignationDomain.UpdateAsync(ticketAssignation);
                    }
                }
                response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Data = false;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> SendPreAsignTicket(List<SavePreAsignTicketDto> lista)
        {
            using var context = new SqlCoreContext();
            var response = new Response<bool>();
            try
            {
                foreach (var item in lista)
                {
                    var ticket = await _ticketDomain.GetByIdAsync(item.Id);
                    var ticketAssignation = await _ticketAssignationDomain.GetByIdAsync(item.Id);
                    if (ticket != null)
                    {
                        ticket.IdStatusTicket = 12;
                        await _ticketDomain.UpdateAsync(ticket);
                        var listTicketHistory = await _ticketHistoryDomain.GetAllByIdTicket(item.Id);
                        foreach (var item1 in listTicketHistory)
                        {
                            item1.Flag = true;
                            await _ticketHistoryDomain.UpdateAsync(item1);
                        }
                        var assignetTo = item.IdReceptor == 21 ? "PA1" : item.IdReceptor == 33 ? "PA2" : item.IdReceptor == 37 ? "PA3" :
                            item.IdReceptor == 38 ? "PA4" : item.IdReceptor == 42 ? "PA5" : item.IdReceptor == 50 ? "PA6" : item.IdReceptor == 23 ? "PA7" : "";
                        string nameAssignedTo = "PRE_ASSIGN_" + assignetTo;
                        string descriptionAssignedTo = "Pre-Asinación " + assignetTo;
                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                        int? number = 1;
                        if (numeration == null)
                        {
                            await context.Numerations.AddAsync(new Numeration
                            {
                                Name = nameAssignedTo,
                                Description = descriptionAssignedTo,
                                Number = 1
                            }) ;
                        }
                        else
                        {
                            number = numeration.Number + 1;
                            numeration.Number++;
                            numeration.UpdateDate = DateTime.Now;
                            context.Numerations.Update(numeration);
                        }
                        var newTicketHistory = new TicketHistory
                        {
                            IdTicket = item.Id,
                            UserFrom = item.IdEmisor.ToString(),
                            UserTo = item.IdReceptor.ToString(),
                            AsignedTo = assignetTo,
                            IdStatusTicket = ticket.IdStatusTicket,
                            NumberAssign=number,
                            Flag=false
                        };
                        await _ticketHistoryDomain.AddAsync(newTicketHistory);
                        
                       
                        if (ticketAssignation != null)
                        {
                            ticketAssignation.Commentary = item.Commentary;
                            ticketAssignation.IdEmployee = item.IdReceptor;
                            await _ticketAssignationDomain.UpdateAsync(ticketAssignation);

                        }
                        await context.SaveChangesAsync();
                    }

                }
                response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Data = false;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetListTicketResponseDto2>>> GetTicketsToUser(string userTo)
        {
            var response = new Response<List<GetListTicketResponseDto2>>();
            try
            {
                using var context = new SqlCoreContext();
                var user = await context.UserLogins
                    .Include(x => x.IdEmployeeNavigation)
                    .Include(x => x.IdEmployeeNavigation.Personals)
                    .Where(x => x.Id == int.Parse(userTo)).FirstOrDefaultAsync();
                var list = await _ticketHistoryDomain.GetTicketsPreAssignedToUser(userTo);
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetListTicketResponseDto2>>(list);
                    foreach (var item in response.Data)
                    {
                        item.OtherUserCode = new List<UserCode>();
                        var otherCodes = new List<UserCode>();
                        foreach (var item1 in user.IdEmployeeNavigation.Personals)
                        {
                            if(item1.Code.Trim() != item.AsignedTo.Trim())
                            {
                                item.OtherUserCode.Add(new UserCode
                                {
                                    Code = item1.Code,
                                    Active = false
                                });
                            }
                            else
                            {
                                item.OtherUserCode.Add(new UserCode
                                {
                                    Code = item1.Code,
                                    Active = true
                                });
                            }
                        }
                    }

                }
                else
                {
                    response.Data = null;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetPersonalAssignationResponseDto>>> GetPersonalAssignation()
        {
            var response = new Response<List<GetPersonalAssignationResponseDto>>();
            try
            {
                var list = await _personalDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetPersonalAssignationResponseDto>>(list);
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetPersonalAssignationResponseDto>>> GetAgentAssignation()
        {
            var response = new Response<List<GetPersonalAssignationResponseDto>>();
            try
            {
                var list = await _agentDomain.GetAllAgentsAsync("", "", "A");
                response.Data = _mapper.Map<List<GetPersonalAssignationResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> UploadFile(int idTicket, string numCupon, IFormFile file)
        {
            var response = new Response<bool>();
            try
            {
                using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
                {
                    await ftpClient.LoginAsync();
                    string filePath = "/cupones/" + numCupon + "/" + file.FileName;
                    using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(filePath))
                    {
                        file.CopyTo(writeStream);
                    }
                    response.Data = true;
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (response.Data == true)
                    {
                        await _ticketDomain.AddTicketFile(new TicketFile
                        {
                            Id = 0,
                            IdTicket = idTicket,
                            Name = file.FileName,
                            Path = filePath,
                            Extension = fileExtension
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                throw new Exception(ex.Message);
            }
            return response;
        }

        public async Task<Response<bool?>> DeleteFile(int id)
        {
            var response = new Response<bool?>();
            try
            {
                var ticketFile = await _ticketDomain.GetTicketFileById(id);
                response.Data = await _ticketDomain.DeleteTicketFile(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                throw new Exception(ex.Message);
            }
            return response;
        }
        private async Task<bool> EliminarArchivo(string path)
        {
            using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
            {
                await ftpClient.LoginAsync();

                try
                {
                    await ftpClient.DeleteFileAsync(path);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<Response<bool>> AddTicketHistory(List<AddOrUpdateAssignationsRequestDto> obj)
        {
            var response = new Response<bool>();
            try
            {
                foreach (var item in obj)
                {
                    if (item.Type == "PA")
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<string?>> GetNumCuponById(int idTicket)
        {
            var response = new Response<string?>();
            try
            {
                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                if (ticket != null)
                {
                    response.Data = ticket.Number.ToString("D6");
                }
            } catch (Exception ex)
            {
                response.Data = "";
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListTicketResponseDto>>> GetTicketsByIdSubscriber(int idSubscriber, string? company, DateTime from, DateTime until, int idCountry)
        {
            var response = new Response<List<GetListTicketResponseDto>>();
            try
            {
                var tickets = await _ticketDomain.GetTicketsByIdSubscriber(idSubscriber, company, from, until, idCountry);
                if (tickets.Count > 0)
                {
                    response.Data = _mapper.Map<List<GetListTicketResponseDto>>(tickets);
                }
                else
                {
                    response.Data = null;
                    response.IsSuccess = false;
                }
            } catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                _logger?.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddTicketByWeb(AddOrUpdateTicketRequestDto request)
        {
            var response = new Response<bool>();
            try
            {
                if (request == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }

                var newTicket = _mapper.Map<Ticket>(request);
                newTicket.Web = true;
                var country = await _countryDomain.GetByIdAsync((int)newTicket.IdCountry);
                if (country != null)
                {
                    newTicket.IdContinent = country.IdContinent;
                    newTicket.TaxType = country.TaxTypeName;
                }
                newTicket.ReportType = "OR";
                newTicket.About = "E";
                var number = await _numerationDomain.GetTicketNumberAsync();
                int currentNumber = number.Number + 1 ?? 0;
                newTicket.Number = currentNumber;
                newTicket.IdStatusTicket = (int?)TicketStatusEnum.Pendiente;
                newTicket.TicketHistories.Add(new TicketHistory
                {
                    IdStatusTicket = (int?)TicketStatusEnum.Pendiente,
                    UserFrom = "1"
                });
                var idEmployee = await GetReceptorDefault(request.IdCountry ?? 0, request.ReportType, request.IdSubscriber);
                using var context = new SqlCoreContext();
                var userLogin = await context.UserLogins
                    .Include(x => x.IdEmployeeNavigation).Where(x => x.IdEmployeeNavigation.Id == idEmployee).FirstOrDefaultAsync();
                newTicket.TicketAssignation = new TicketAssignation
                {
                    IdEmployee = idEmployee,
                    IdUserLogin = userLogin.Id
                };


                if (await _ticketDomain.AddAsync(newTicket))
                {
                    //  await CopyReportForm(request.Number);
                    // await CopyReportPerson(request.Number);
                    await _numerationDomain.UpdateTicketNumberAsync();
                    if (request.About == "E" && newTicket.IdCompany == null)
                    {
                        var company = await _companyDomain.AddCompanyAsync(new Company
                        {
                            Name = request.RequestedName ?? string.Empty,
                            Language = request.Language,
                            TaxTypeCode = request.TaxCode,
                            IdCountry = request.IdCountry,
                            Address = request.Address,
                            Place = request.City
                        });
                        var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                        ticket.IdCompany = company;
                        await _ticketDomain.UpdateAsync(ticket);
                    }
                    if (request.About == "P" && newTicket.IdPerson == null)
                    {
                        var person = await _personDomain.AddPersonAsync(new Person
                        {
                            Fullname = request.RequestedName ?? string.Empty,
                            Language = request.Language
                        });
                        var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                        ticket.IdPerson = person;
                        await _ticketDomain.UpdateAsync(ticket);
                    }
                    if (request.About == "E" && request.ReportType != "OR")
                    {
                        var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                        var doc = await _companyApplication.DownloadF8(ticket.IdCompany ?? 0, "ESP", "pdf");
                        if (doc != null && doc.Data != null)
                        {
                            var data = doc.Data;
                            var path = await UploadF1(ticket.Id, "RV_" + ticket.RequestedName, data.File);

                            await context.TicketFiles.AddAsync(new TicketFile
                            {
                                IdTicket = ticket.Id,
                                Path = path,
                                Name = "RV_" + DateTime.Now.ToString("ddMMyy") + "_" + request.Number.ToString("D6"),
                                Extension = ".pdf"
                            });
                            await context.SaveChangesAsync();
                        }
                    }
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddTicketOnline(AddOrUpdateTicketRequestDto request, string rubro, string sendTo)
        {

            var response = new Response<bool>();
            try
            {
                if (request == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }

                var newTicket = _mapper.Map<Ticket>(request);
                newTicket.Web = true;
                var country = await _countryDomain.GetByIdAsync((int)newTicket.IdCountry);
                if (country != null)
                {
                    newTicket.IdContinent = country.IdContinent;
                }
                var number = await _numerationDomain.GetTicketNumberAsync();
                int currentNumber = number.Number + 1 ?? 0;
                newTicket.Number = currentNumber;
                newTicket.IdStatusTicket = (int?)TicketStatusEnum.Despachado;
                newTicket.DispatchtDate = DateTime.Now;

                response.Data = await _ticketDomain.AddAsync(newTicket);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetTicketHistorySubscriberResponseDto>>> GetTicketHistoryByIdSubscriber(int idSubscriber, string? name, DateTime? from, DateTime? until, int? idCountry)
        {
            var response = new Response<List<GetTicketHistorySubscriberResponseDto>>();
            try
            {
                var tickets = await _ticketDomain.GetTicketHistoryByIdSubscriber(idSubscriber, name, from, until, idCountry);
                if (tickets != null)
                {
                    response.Data = _mapper.Map<List<GetTicketHistorySubscriberResponseDto>>(tickets);
                }
                else
                {
                    response.Data = null;
                    response.IsSuccess = false;
                    response.Message = Messages.BadQuery;
                }
            } catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetSearchSituationResponseDto>>> GetSearchSituation(string about, string typeSearch, string? search, int? idCountry)
        {
            var response = new Response<List<GetSearchSituationResponseDto>>();
            var listCompanies = new List<Company>();
            var listPersons = new List<Person>();
            try
            {
                if (about == "E")
                {
                    var companies = await _companyDomain.GetCompanySituation(typeSearch, search, idCountry);
                    if (companies != null)
                    {
                        listCompanies = companies;
                    }
                    var searchTickets = await _ticketDomain.GetTicketSituation(about, typeSearch, search, idCountry);
                    foreach (var item in searchTickets)
                    {
                        if(item.IdCompany != null)
                        {
                            bool idCompanyExistente = listCompanies.Any(company => company.Id == item.IdCompany);
                            if (!idCompanyExistente)
                            {
                                var company = await _companyDomain.GetByIdAsync((int)item.IdCompany);
                                listCompanies.Add(company);
                            }
                        }
                    }
                    response.Data = _mapper.Map<List<GetSearchSituationResponseDto>>(listCompanies);
                }
                else if (about == "P")
                {
                    var persons = await _personDomain.GetPersonSituation(typeSearch, search, idCountry);
                    if (persons != null)
                    {
                        listPersons = persons;
                    }
                    var searchTickets = await _ticketDomain.GetTicketSituation(about, typeSearch, search, idCountry);
                    foreach (var item in searchTickets)
                    {
                        if(item.IdPerson != null)
                        {
                            bool idPersonExistente = listPersons.Any(person => person.Id == item.IdPerson);
                            if (!idPersonExistente)
                            {
                                var person = await _personDomain.GetByIdAsync((int)item.IdPerson);
                                listPersons.Add(person);
                            }
                        }
                    }
                    response.Data = _mapper.Map<List<GetSearchSituationResponseDto>>(listPersons);
                }
            } catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetTicketsByCompanyOrPersonResponseDto>>> GetTicketsByCompanyOrPerson(string about, int id, string oldCode)
        {
            var response = new Response<List<GetTicketsByCompanyOrPersonResponseDto>>();

            try
            {
                var tickets = await _ticketDomain.GetTicketByCompanyOrPerson(about, id);
                if (tickets != null)
                {
                    response.Data = _mapper.Map<List<GetTicketsByCompanyOrPersonResponseDto>>(tickets);
                }
                var oldTickets = await _ticketDomain.GetOldTicketByCompany(oldCode);
                if (oldTickets != null)
                {
                    foreach (var item in oldTickets)
                    {
                        response.Data.Add(new GetTicketsByCompanyOrPersonResponseDto
                        {
                            Id = 0,
                            Ticket = "A-" + item.Cupcodigo.ToString().PadLeft(6, '0'),
                            IdStatusTicket = 0,
                            Status = "DESPACHADO",
                            Color = "label-success",
                            RequestedName = item.NombreSolicitado,
                            SubscriberCode = item.Abonado,
                            ProcedureType = item.Tramite,
                            ReportType = item.TipoInforme,
                            Language = item.Idioma,
                            Web = true,
                            OrderDate = StaticFunctions.DateTimeToString(item.FechaPedido),
                            EndDate = StaticFunctions.DateTimeToString(item.FechaVencimiento),
                            DispatchDate = StaticFunctions.DateTimeToString(item.FechaDespacho)
                        });
                    }
                }
            } catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetTimeLineTicketHistoryResponseDto>>> GetTimeLineTicketHistory(int idTicket)
        {
            var response = new Response<List<GetTimeLineTicketHistoryResponseDto>>();
            response.Data = new List<GetTimeLineTicketHistoryResponseDto>();
            try
            {
                var ticketHistory = await _ticketDomain.GetTicketHistoryByIdTicket(idTicket);
                if (ticketHistory != null)
                {
                    foreach (var item in ticketHistory)
                    {
                        var assignedToName = "";
                        if (item.AsignedTo != null && item.AsignedTo.Contains("PA"))
                        {
                            assignedToName = item.AsignedTo == "PA1" ? "KATIA BUSTAMANTE" : item.AsignedTo == "PA2" ? "MARIELA ACOSTA" : item.AsignedTo == "PA3" ? "MONICA YEPEZ" :
                                item.AsignedTo == "PA4" ? "RAFAEL DEL RISCO" : item.AsignedTo == "PA5" ? "CECILIA RODRIGUEZ" : item.AsignedTo == "PA6" ? "JESSICA LIAU" :
                                item.AsignedTo == "PA7" ? "CECILIA SAYAS" : "";
                        }
                        else if (item.AsignedTo != null && item.AsignedTo.Contains("D") || item.AsignedTo != null && item.AsignedTo.Contains("T")
                            || item.AsignedTo != null && item.AsignedTo.Contains("R") || item.AsignedTo != null && item.AsignedTo.Contains("RC") || item.AsignedTo != null && item.AsignedTo.Contains("S"))
                        {
                            var employee = await _employeeDomain.FindByPersonalCode(item.AsignedTo);
                            assignedToName = employee != null ? employee.FirstName + " " + employee.LastName : string.Empty;
                        }
                        else if (item.AsignedTo == null)
                        {
                            using var context = new SqlCoreContext();
                            var user = await context.UserLogins
                                .Include(x => x.IdEmployeeNavigation)
                                .Where(x => x.Id == int.Parse(item.UserFrom)).FirstOrDefaultAsync();
                            assignedToName = user.IdEmployeeNavigation != null ? user.IdEmployeeNavigation.FirstName + " " + user.IdEmployeeNavigation.LastName : "";
                        }
                        else
                        {
                            using var context = new SqlCoreContext();
                            var agent = await context.Agents.Where(x => x.Code == item.AsignedTo).FirstOrDefaultAsync();
                            assignedToName = agent != null ? agent.Name : "";
                        }


                        var newTimeLine = new GetTimeLineTicketHistoryResponseDto();

                        newTimeLine.Id = item.Id;
                        newTimeLine.AssignedTo = item.AsignedTo;
                        newTimeLine.AssignedToName = assignedToName;
                        newTimeLine.Date = StaticFunctions.DateTimeToString(item.CreationDate);
                        newTimeLine.Time = item.CreationDate.Hour.ToString("00") + ":" + item.CreationDate.Minute.ToString("00");
                        newTimeLine.IdStatusTicket = item.IdStatusTicket;
                        newTimeLine.Status = item.IdStatusTicket == 1 && item.UserTo == null && item.AsignedTo == null ? "Creación del Pedido" : item.IdStatusTicketNavigation.Description;
                        newTimeLine.Color = item.IdStatusTicket == 1 && item.UserTo == null && item.AsignedTo == null ? "label-success" : item.IdStatusTicketNavigation.Color;

                        response.Data.Add(newTimeLine);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(response.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<GetTicketObservationsResponseDto>> GetTicketObservations(int idTicket)
        {
            var response = new Response<GetTicketObservationsResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets
                    .Where(x => x.Id == idTicket)
                    .Include(x => x.IdSubscriberNavigation)
                    .Include(x => x.TicketHistories)
                    .FirstOrDefaultAsync();
                if (ticket != null)
                {
                    var latestSupervisor = ticket.TicketHistories
                        .Where(x => x.AsignedTo != null && x.AsignedTo.Contains("S"))
                        .OrderByDescending(x => x.CreationDate)
                        .FirstOrDefault();

                    if (latestSupervisor != null)
                    {
                        var personal = await context.Personals
                            .Include(x => x.IdEmployeeNavigation)
                            .Where(x => x.Code == latestSupervisor.AsignedTo).FirstOrDefaultAsync();
                        response.Data = new GetTicketObservationsResponseDto
                        {
                            ReportName = ticket.BusineesName,
                            SubscriberCode = ticket.IdSubscriberNavigation.Code,
                            Supervisor = latestSupervisor.AsignedTo,
                            NameSupervisor = personal.IdEmployeeNavigation.FirstName + " " + personal.IdEmployeeNavigation.LastName
                        };
                    }
                    else
                    {
                        response.Data = null;
                    }
                }
                else
                {
                    response.Data = null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(response.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> AddTicketObservations(int idTicket, string observations, string userFrom)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                if (ticket != null)
                {
                    ticket.IdStatusTicket = (int?)TicketStatusEnum.Observado;
                }
                context.Tickets.Update(ticket);
                await context.TicketHistories.AddAsync(new TicketHistory
                {
                    IdTicket = (int?)idTicket,
                    UserFrom = userFrom,
                    IdStatusTicket = (int?)TicketStatusEnum.Observado,
                });
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(response.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool?>> AssignTicket(NewAsignationDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using (var context = new SqlCoreContext())
                {
                    if(obj.OtherUserCode.Count > 0)
                    {
                        var ticketHistory = await context.TicketHistories.Where(x => x.Id == obj.IdTicketHistory).FirstOrDefaultAsync();
                        if (ticketHistory != null)
                        {
                            foreach (var item in obj.OtherUserCode)
                            {
                                if (item.Code.Trim() != obj.AsignedTo.Trim() && item.Active)
                                {
                                    var newTicketHistory = new TicketHistory();
                                    newTicketHistory.Id = 0;
                                    newTicketHistory.AsignedTo = item.Code;
                                    newTicketHistory.IdTicket = ticketHistory.IdTicket;
                                    newTicketHistory.UserFrom = ticketHistory.UserFrom;
                                    newTicketHistory.UserTo = ticketHistory.UserTo;
                                    newTicketHistory.CreationDate = ticketHistory.CreationDate;
                                    newTicketHistory.UpdateDate = ticketHistory.UpdateDate;
                                    newTicketHistory.DeleteDate = ticketHistory.DeleteDate;
                                    newTicketHistory.Enable = ticketHistory.Enable;
                                    newTicketHistory.IdStatusTicket = item.Code.Contains("RC") ? (int)TicketStatusEnum.Asig_Referencista : item.Code.Contains("A") ? (int)TicketStatusEnum.Asig_Agente:
                                        item.Code.Contains("D") ? (int)TicketStatusEnum.Asig_Digitidor : item.Code.Contains("R") ? (int)TicketStatusEnum.Asig_Reportero : item.Code.Contains("T") ? (int)TicketStatusEnum.Asig_Traductor :
                                        item.Code.Contains("S") ? (int)TicketStatusEnum.Asig_Supervisor : null;
                                    newTicketHistory.AsignedTo = item.Code;
                                    newTicketHistory.Flag = ticketHistory.Flag;
                                    newTicketHistory.NumberAssign = ticketHistory.NumberAssign;
                                    newTicketHistory.Balance = ticketHistory.Balance;
                                    newTicketHistory.References = ticketHistory.References;
                                    newTicketHistory.Observations = ticketHistory.Observations;
                                    newTicketHistory.StartDate = ticketHistory.StartDate;
                                    newTicketHistory.EndDate = ticketHistory.EndDate;

                                    await context.TicketHistories.AddAsync(newTicketHistory);
                                }
                            }
                        }
                    }
                    if (obj.Asignacion.Count > 0) {
                        
                        foreach (var item in obj.Asignacion)
                        {
                            var history = await context.TicketHistories.Where(x => x.IdTicket == item.IdTicket && x.AsignedTo == item.AssignedFromCode && x.NumberAssign==item.NumberAssign).FirstOrDefaultAsync();

                            if (history != null)
                            {
                                var ticket = await context.Tickets.Include(x=>x.TicketHistories).Where(x => x.Id == history.IdTicket).FirstOrDefaultAsync();
                                if (ticket != null)
                                {
                                    foreach (var item3 in obj.OtherUserCode)
                                    {
                                        if (item3.Code.Contains("S") && item3.Active == true)
                                        {
                                            ticket.Quality = item.Quality;
                                            ticket.UpdateDate = DateTime.Now;
                                        }
                                    }
                                    if (item.AssignedFromCode.Contains("SU"))
                                    {
                                        ticket.Quality = item.Quality;
                                        ticket.UpdateDate = DateTime.Now;
                                    }
                                    if (item.Type == "PA")
                                    {
                                       string nameAssignedTo = "PRE_ASSIGN_" + item.AssignedToCode;
                                        string descriptionAssignedTo = "Pre-Asignación " + item.AssignedToCode;
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            await context.Numerations.AddAsync(new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            });
                                        }
                                        else
                                        {
                                            number = numeration.Number + 1;
                                            numeration.Number++;
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }


                                        ticket.UpdateDate = DateTime.Now;
                                        ticket.IdStatusTicket = (int)TicketStatusEnum.Pre_Asignacion;
                                        history.Flag = true;
                                        history.UpdateDate = DateTime.Now;

                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        var newTicketHistory = new TicketHistory
                                        {
                                            IdTicket = ticket.Id,
                                            UserFrom = item.UserFrom,
                                            UserTo = item.UserTo,
                                            AsignedTo = item.AssignedToCode,
                                            IdStatusTicket = (int)TicketStatusEnum.Pre_Asignacion,
                                            NumberAssign = number,
                                            Flag = false,
                                            StartDate = DateTime.Parse(item.StartDate),
                                            EndDate = DateTime.Parse(item.EndDate),
                                            Observations=item.Observations,
                                            Balance=item.Balance,
                                            

                                        };
                                        await context.TicketHistories.AddAsync(newTicketHistory);

                                        await context.SaveChangesAsync();

                                    }
                                    if (item.Type == "RP")
                                    {
                                        string nameAssignedTo = "REPORTERO_" + item.AssignedToCode;
                                        string descriptionAssignedTo = "Reportero " + item.AssignedToCode;
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            await context.Numerations.AddAsync(new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            });
                                        }
                                        else
                                        {
                                            number = numeration.Number + 1;
                                            numeration.Number++;
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }


                                        ticket.UpdateDate = DateTime.Now;
                                        ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Reportero;
                                        history.Flag = true;
                                        history.UpdateDate = DateTime.Now;

                                      

                                        if (item.Internal)
                                        {
                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Reportero;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserTo,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Reportero,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        else
                                        {
                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Reportero_Espera;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserFrom,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Reportero_Espera,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        if (item.References)
                                        {
                                            string nameAssignedToRef = "REFERENCIA_CR1";
                                            string descriptionAssignedToRef = "Por Referencia ";
                                            var numerationRef = await context.Numerations.Where(x => x.Name == nameAssignedToRef).FirstOrDefaultAsync();
                                            int? numberRef = 1;
                                            if (numerationRef == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedToRef,
                                                    Description = descriptionAssignedToRef,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                numberRef = numerationRef.Number + 1;
                                                numerationRef.Number++;
                                                numerationRef.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numerationRef);
                                            }
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = "42",
                                                AsignedTo = "CR1",
                                                IdStatusTicket = (int)TicketStatusEnum.Por_Referencia,
                                                NumberAssign = numberRef,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);
                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "AG")
                                    {
                                        string nameAssignedTo = "AGENTE_" + item.AssignedToCode;
                                        string descriptionAssignedTo = "Agente " + item.AssignedToCode;
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            await context.Numerations.AddAsync(new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            });
                                        }
                                        else
                                        {
                                            number = numeration.Number + 1;
                                            numeration.Number++;
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }

                                       
                                        ticket.UpdateDate = DateTime.Now;
                                        history.Flag = true;
                                        history.UpdateDate = DateTime.Now;

                                       
                                        if (item.Internal)
                                        {
                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Agente;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserTo,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Agente,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        else
                                        {
                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Agente_Espera;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserFrom,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Agente_Espera,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        if (item.References)
                                        {
                                            string nameAssignedToRef = "REFERENCIA_CR2";
                                            string descriptionAssignedToRef = "Por Referencia ";
                                            var numerationRef = await context.Numerations.Where(x => x.Name == nameAssignedToRef).FirstOrDefaultAsync();
                                            int? numberRef = 1;
                                            if (numerationRef == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedToRef,
                                                    Description = descriptionAssignedToRef,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                numberRef = numerationRef.Number + 1;
                                                numerationRef.Number++;
                                                numerationRef.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numerationRef);
                                            }
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = "42",
                                                AsignedTo = "CR2",
                                                IdStatusTicket = (int)TicketStatusEnum.Por_Referencia,
                                                NumberAssign = numberRef,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "RF")
                                    {
                                        string nameAssignedTo = "REFERENCISTA_" + item.AssignedToCode;
                                        string descriptionAssignedTo = "Referencia " + item.AssignedToCode;
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            await context.Numerations.AddAsync(new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            });
                                        }
                                        else
                                        {
                                            number = numeration.Number + 1;
                                            numeration.Number++;
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }


                                        ticket.UpdateDate = DateTime.Now;
                                        history.Flag = true;
                                        history.UpdateDate = DateTime.Now;


                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Referencista;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserTo,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Referencista,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        
                                       
                                       
                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "DI")
                                    {
                                        if (item.AssignedToCode=="D15")
                                        {

                                            string nameAssignedToRef = "PORDIGITAR_CR4";
                                            string descriptionAssignedToRef = "Por Digitar ";
                                            var numerationRef = await context.Numerations.Where(x => x.Name == nameAssignedToRef).FirstOrDefaultAsync();
                                            int? numberRef = 1;
                                            if (numerationRef == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedToRef,
                                                    Description = descriptionAssignedToRef,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                numberRef = numerationRef.Number + 1;
                                                numerationRef.Number++;
                                                numerationRef.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numerationRef);
                                            }
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = "42",
                                                AsignedTo = "CR4",
                                                IdStatusTicket = (int)TicketStatusEnum.Por_Digitar,
                                                NumberAssign = numberRef,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                        }
                                        else
                                        {
                                            string nameAssignedTo = "DIGITADOR" + item.AssignedToCode;
                                            string descriptionAssignedTo = "Digitador " + item.AssignedToCode;
                                            var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                            int? number = 1;
                                            if (numeration == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedTo,
                                                    Description = descriptionAssignedTo,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                number = numeration.Number + 1;
                                                numeration.Number++;
                                                numeration.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numeration);
                                            }


                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.UpdateDate = DateTime.Now;


                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Digitidor;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserTo,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Digitidor,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);


                                        }

                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "TR")
                                    {
                                        if (item.AssignedToCode == "T14")
                                        {

                                            string nameAssignedToRef = "PORTRADUCIR_CR5";
                                            string descriptionAssignedToRef = "Por Digitar ";
                                            var numerationRef = await context.Numerations.Where(x => x.Name == nameAssignedToRef).FirstOrDefaultAsync();
                                            int? numberRef = 1;
                                            if (numerationRef == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedToRef,
                                                    Description = descriptionAssignedToRef,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                numberRef = numerationRef.Number + 1;
                                                numerationRef.Number++;
                                                numerationRef.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numerationRef);
                                            }
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = "42",
                                                AsignedTo = "CR5",
                                                IdStatusTicket = (int)TicketStatusEnum.Por_Traducir,
                                                NumberAssign = numberRef,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                        }
                                        else
                                        {
                                            string nameAssignedTo = "TRADUCTOR" + item.AssignedToCode;
                                            string descriptionAssignedTo = "Traductor " + item.AssignedToCode;
                                            var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                            int? number = 1;
                                            if (numeration == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedTo,
                                                    Description = descriptionAssignedTo,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                number = numeration.Number + 1;
                                                numeration.Number++;
                                                numeration.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numeration);
                                            }


                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.UpdateDate = DateTime.Now;


                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Traductor;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserTo,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Traductor,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                        }

                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "SU")
                                    {
                                        if (ticket.TicketHistories.Any(x =>x.AsignedTo!=null && x.AsignedTo.Contains("RC") && x.Flag == false))
                                        {

                                            string nameAssignedToRef = "SUPERVISAR_CR3";
                                            string descriptionAssignedToRef = "Por Supervisar ";
                                            var numerationRef = await context.Numerations.Where(x => x.Name == nameAssignedToRef).FirstOrDefaultAsync();
                                            int? numberRef = 1;
                                            if (numerationRef == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedToRef,
                                                    Description = descriptionAssignedToRef,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                numberRef = numerationRef.Number + 1;
                                                numerationRef.Number++;
                                                numerationRef.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numerationRef);
                                            }
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = "42",
                                                AsignedTo = "CR3",
                                                IdStatusTicket = (int)TicketStatusEnum.Por_Supervisar,
                                                NumberAssign = numberRef,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                        }
                                        else
                                        {
                                            string nameAssignedTo = "SUPERVISOR" + item.AssignedToCode;
                                            string descriptionAssignedTo = "Supervisor " + item.AssignedToCode;
                                            var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                            int? number = 1;
                                            if (numeration == null)
                                            {
                                                await context.Numerations.AddAsync(new Numeration
                                                {
                                                    Name = nameAssignedTo,
                                                    Description = descriptionAssignedTo,
                                                    Number = 1
                                                });
                                            }
                                            else
                                            {
                                                number = numeration.Number + 1;
                                                numeration.Number++;
                                                numeration.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numeration);
                                            }


                                            history.Flag = true;
                                            history.UpdateDate = DateTime.Now;


                                            ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Supervisor;
                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = item.UserTo,
                                                AsignedTo = item.AssignedToCode,
                                                IdStatusTicket = (int)TicketStatusEnum.Asig_Supervisor,
                                                NumberAssign = number,
                                                Flag = false,
                                                StartDate = DateTime.Parse(item.StartDate),
                                                EndDate = DateTime.Parse(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                        }

                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }


                                }
                            }

                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return new Response<bool?>();
        }

        public async Task<Response<List<GetListTicketResponseDto>>> GetTicketListToDispatchAsync()
        {
            var response = new Response<List<GetListTicketResponseDto>>();
            try
            {
                var list = await _ticketDomain.GetTicketsToDispatch();
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetListTicketResponseDto>>(list);
                }
                else
                {
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DispatchTicket(int idTicket, int idUser)
        {
            var response = new Response<bool>();
            try
            {
                var emailDataDto = new EmailDataDTO();

                using var context = new SqlCoreContext();
                var ticket = await context.Tickets
                    .Include(x => x.IdSubscriberNavigation)
                    .Include(x => x.IdCompanyNavigation)
                    .Include(x => x.IdPersonNavigation)
                    .Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                var userLogin = await context.UserLogins.Include(x => x.IdEmployeeNavigation).Where(x => x.Id == idUser).FirstOrDefaultAsync(); ;
                if (ticket != null && userLogin != null)
                {
                    var ticketHistory = await context.TicketHistories.Where(x => x.IdTicket == idTicket).ToListAsync();
                    foreach (var item in ticketHistory)
                    {
                        item.Flag = false;
                        context.TicketHistories.Update(item);
                    }
                    var history = new TicketHistory();
                    history.IdTicket = idTicket;
                    history.UserFrom = idUser + "";
                    history.IdStatusTicket = (int?)TicketStatusEnum.Despachado;
                    history.Flag = true;
                    history.NumberAssign = ticketHistory.Last().NumberAssign + 1;
                    await context.TicketHistories.AddAsync(history);
                    

                    emailDataDto.EmailKey = ticket.Language == "E" ? "DRR_WORKFLOW_ESP_0027" : "DRR_WORKFLOW_ENG_0027";
                    emailDataDto.BeAuthenticated = true;
                    emailDataDto.From = userLogin.IdEmployeeNavigation.Email;
                    emailDataDto.UserName = emailDataDto.From;
                    emailDataDto.Password = userLogin.EmailPassword;
                    emailDataDto.To = new List<string>
                    {
                        "jfernandez@del-risco.com"//ticket.IdSubscriberNavigation.SendReportToEmail,
                    };
                    emailDataDto.CCO = new List<string>
                    {
                        "jfernandez@del-risco.com"//"crc@del-risco.com"
                    };
                    emailDataDto.Subject = (ticket.About == "E" ? ticket.IdCompanyNavigation.Name : ticket.IdPersonNavigation.Fullname) + "_" + ticket.ReportType + "_" + DateTime.Now.ToString("dd-MM-yyyy");
                    emailDataDto.IsBodyHTML = true;
                    emailDataDto.Parameters.Add(ticket.IdSubscriberNavigation.Name);
                    emailDataDto.Parameters.Add(userLogin.IdEmployeeNavigation.FirstName + " " + userLogin.IdEmployeeNavigation.LastName);
                    emailDataDto.Parameters.Add(userLogin.IdEmployeeNavigation.Email);
                    emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                    _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));

                    byte[] fileArray = DownloadF8((int)ticket.IdCompany, ticket.Language, "pdf").Result.Data.File;
                    var attachment = new AttachmentDto();
                    attachment.FileName = emailDataDto.Subject+".pdf";
                    attachment.Content = Convert.ToBase64String(fileArray);
                    attachment.Path = await UploadFile(attachment);
                    emailDataDto.Attachments.Add(attachment);

                    string path = await UploadDispatchReport(idTicket, emailDataDto.Subject, fileArray);
                    await context.TicketFiles.AddAsync(new TicketFile
                    {
                        IdTicket = idTicket,
                        Path = path,
                        Name = emailDataDto.Subject,
                        Extension = ".pdf"
                    });

                   

                    var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                    var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                    emailHistory.Success = result;
                    response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
                    _logger.LogInformation(Messages.MailSuccessSend);

                    ticket.IdStatusTicket = (int?)TicketStatusEnum.Despachado;
                    ticket.DispatchtDate = DateTime.Now;
                    ticket.DispatchedName = emailDataDto.Subject;
                    context.Tickets.Update(ticket);
                    await context.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Data = result;
                }
                else
                {
                    response.Data = false;
                    response.IsSuccess = false;
                }
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
            var stringBody = await _mailFormatter.GetEmailBody(emailConfiguration.Name, emailConfiguration.Value, emailDataDto.Parameters, emailDataDto.Table);
            return stringBody.Replace(Constants.FOOTER, emailConfiguration.FlagFooter.Value ? emailConfigurationFooter.Value : string.Empty);

        }
        private async Task<string> UploadFile(AttachmentDto attachmentDto)
        {
            return await _fileManager.UploadFile(new MemoryStream(Convert.FromBase64String(attachmentDto.Content)), attachmentDto.FileName);
        }
        public async Task<Response<GetFileResponseDto>> DownloadF8(int idCompany, string language, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                var company = await _companyDomain.GetByIdAsync(idCompany);

                string companyCode = company.OldCode ?? "N" + company.Id.ToString("D6");
                string languageFileName = language == "I" ? "ENG" : "ESP";
                string fileFormat = "{0}_{1}{2}";
                string report = language == "I" ? "F8-EMPRESAS-EN" : "F8-EMPRESAS-ES";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCompany", idCompany.ToString() },
                 };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, companyCode, languageFileName, extension)
                };

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteTicketHistory(int idTicket, string? assignedTo, int? numberAssign)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories.Where(x => x.IdTicket == idTicket && x.AsignedTo == assignedTo && x.NumberAssign == numberAssign).FirstOrDefaultAsync();
                if(ticketHistory != null)
                {
                    if (assignedTo.Contains("RC") == false && assignedTo.Contains("CR") == false)
                    {
                        context.TicketHistories.Remove(ticketHistory);
                        await context.SaveChangesAsync();
                        response.Data = true;
                    }
                    else
                    {
                        context.TicketHistories.Remove(ticketHistory);
                        var lastTicketHistory = await context.TicketHistories.Where(x => x.IdTicket == idTicket).OrderByDescending(x => x.CreationDate).FirstOrDefaultAsync();
                        var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                        if (lastTicketHistory != null && ticket != null)
                        {
                            lastTicketHistory.Flag = false;
                            context.TicketHistories.Update(lastTicketHistory);
                            ticket.IdStatusTicket = lastTicketHistory.IdStatusTicket;
                            context.Tickets.Update(ticket);
                            await context.SaveChangesAsync();
                            response.Data = true;
                        }
                        else
                        {
                            response.Data = false;
                            response.IsSuccess = false;
                        }
                    }
                    
                }
                else
                {
                    response.Data = false;
                    response.IsSuccess = false;
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = false;
            }
            return response;
        }

        public async Task<Response<bool>> FinishWork(AssignTicketRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var history = await context.TicketHistories.Where(x => x.IdTicket == obj.IdTicket && x.AsignedTo == obj.AssignedFromCode && x.NumberAssign == obj.NumberAssign).FirstOrDefaultAsync();
                    if (history != null)
                    {
                        var ticket = await context.Tickets.Include(x => x.TicketHistories).Where(x => x.Id == history.IdTicket).FirstOrDefaultAsync();
                        if (ticket != null)
                        {
                            if (obj.AssignedFromCode.Contains("D"))
                            {
                               
                                    string nameAssignedToRef = "SUPERVISAR_CR3";
                                    string descriptionAssignedToRef = "Por Supervisar ";
                                    var numerationRef = await context.Numerations.Where(x => x.Name == nameAssignedToRef).FirstOrDefaultAsync();
                                    int? numberRef = 1;
                                    if (numerationRef == null)
                                    {
                                        await context.Numerations.AddAsync(new Numeration
                                        {
                                            Name = nameAssignedToRef,
                                            Description = descriptionAssignedToRef,
                                            Number = 1
                                        });
                                    }
                                    else
                                    {
                                        numberRef = numerationRef.Number + 1;
                                        numerationRef.Number++;
                                        numerationRef.UpdateDate = DateTime.Now;
                                        context.Numerations.Update(numerationRef);
                                    }
                                    var newTicketHistory = new TicketHistory
                                    {
                                        IdTicket = ticket.Id,
                                        UserFrom = obj.UserFrom,
                                        UserTo = "42",
                                        AsignedTo = "CR3",
                                        IdStatusTicket = (int)TicketStatusEnum.Por_Supervisar,
                                        NumberAssign = numberRef,
                                        Flag = false,
                                        StartDate = DateTime.Parse(obj.StartDate),
                                        EndDate = DateTime.Parse(obj.EndDate),
                                        Observations = obj.Observations,
                                        Balance = obj.Balance,

                                    };
                                    await context.TicketHistories.AddAsync(newTicketHistory);

                                }
                               

                        }
                        if (obj.AssignedFromCode.Contains("T"))
                            {
                                string nameAssignedTo = "DESPACHO_D1";
                                string descriptionAssignedTo = "Despacho";
                                var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                int? number = 1;
                                if (numeration == null)
                                {
                                    await context.Numerations.AddAsync(new Numeration
                                    {
                                        Name = nameAssignedTo,
                                        Description = descriptionAssignedTo,
                                        Number = 1
                                    });
                                }
                                else
                                {
                                    number = numeration.Number + 1;
                                    numeration.Number++;
                                    numeration.UpdateDate = DateTime.Now;
                                    context.Numerations.Update(numeration);
                                }


                                ticket.UpdateDate = DateTime.Now;
                                ticket.IdStatusTicket = (int)TicketStatusEnum.Por_Despachar;
                                history.Flag = true;
                                history.UpdateDate = DateTime.Now;

                                context.Tickets.Update(ticket);
                                context.TicketHistories.Update(history);

                                var newTicketHistory = new TicketHistory
                                {
                                    IdTicket = ticket.Id,
                                    UserFrom = obj.UserFrom,
                                    UserTo = null,
                                    AsignedTo = null,
                                    IdStatusTicket = (int)TicketStatusEnum.Por_Despachar,
                                    NumberAssign = number,
                                    Flag = false,
                                    StartDate = DateTime.Parse(obj.StartDate),
                                    EndDate = DateTime.Parse(obj.EndDate),
                                    Observations = obj.Observations,
                                    Balance = obj.Balance,


                                };
                                await context.TicketHistories.AddAsync(newTicketHistory);

                                await context.SaveChangesAsync();
                            }
                        }
                    }
                return new Response<bool>();

            }
            catch (Exception ex)
            {

            }
            return new Response<bool>();
        }

        public async Task<Response<List<GetShortProviderByTicket>>> GetProvidersByIdTicket(int idTicket)
        {
            var response = new Response<List<GetShortProviderByTicket>>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.FindAsync(idTicket);
                if(ticket != null)
                {
                    var providers = new List<Domain.Entities.SqlCoreContext.Provider>();
                    if(ticket.About == "E")
                    {
                        providers = await context.Providers
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => x.IdCompany == ticket.IdCompany && x.Flag == true).ToListAsync();
                    }
                    else
                    {
                        providers = await context.Providers
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => x.IdPerson== ticket.IdPerson && x.Flag == true).ToListAsync();
                    }
                    response.Data = _mapper.Map<List<GetShortProviderByTicket>>(providers);
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = null;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> TicketToDispacth(int idTicket)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetTicketPendingObservationsResponseDto>>> GetTicketPendingObservations(int idTicket)
        {
            var response = new Response<List<GetTicketPendingObservationsResponseDto>>();
            response.Data = new List<GetTicketPendingObservationsResponseDto> ();
            try
            {
                using var context = new SqlCoreContext();
                var ticketObservations = await context.DetailsTicketObservations
                    .Include(x => x.IdTicketObservationsNavigation).Include(x => x.IdTicketObservationsNavigation.IdReasonNavigation)
                    .Where(x => x.IdTicketObservationsNavigation.IdTicket == idTicket ).ToListAsync();
                foreach (var item in ticketObservations.DistinctBy(x => x.IdTicketObservations).ToList())
                {
                    var list = new List<GetEmployeeObservated>();
                    foreach (var item1 in ticketObservations.Where(x => x.IdTicketObservations == item.IdTicketObservations))
                    {
                        if (item1.AssignedTo.Contains("A"))
                        {
                            var agent = await context.Agents.Where(x => x.Code == item1.AssignedTo).FirstOrDefaultAsync();
                            list.Add(new GetEmployeeObservated
                            {
                                Id = 0,
                                Code = item1.AssignedTo,
                                Name = agent != null ? agent.Name : null,
                            });
                        }
                        else
                        {
                            var personal = await context.Personals.Include(x => x.IdEmployeeNavigation).Where(x => x.Code == item1.AssignedTo).FirstOrDefaultAsync();
                            list.Add(new GetEmployeeObservated
                            {
                                Id = 0,
                                Code = item1.AssignedTo,
                                Name = personal.IdEmployeeNavigation != null ? personal.IdEmployeeNavigation.FirstName + " " + personal.IdEmployeeNavigation.LastName : null,
                            });
                        }
                       
                    }
                    response.Data.Add(new GetTicketPendingObservationsResponseDto
                    {
                        Id = (int)item.IdTicketObservations,
                        About = item.IdTicketObservationsNavigation.About,
                        IdCompany = item.IdTicketObservationsNavigation.IdCompany,
                        IdPerson = item.IdTicketObservationsNavigation.IdPerson,
                        IdSubscriber = item.IdTicketObservationsNavigation.IdSubscriber,
                        IdReason = item.IdTicketObservationsNavigation.IdReason,
                        IdStatusTicketObservation = item.IdTicketObservationsNavigation.IdStatusTicketObservations,
                        Message = item.IdTicketObservationsNavigation.Message,
                        Cc = item.IdTicketObservationsNavigation.Cc,
                        Conclusion = item.IdTicketObservationsNavigation.Conclusion,
                        ObservationDate = item.IdTicketObservationsNavigation.CreationDate,
                        AsignedDate = item.IdTicketObservationsNavigation.AsignedDate,
                        EndDate = item.IdTicketObservationsNavigation.EndDate,
                        SolutionDate = item.IdTicketObservationsNavigation.SolutionDate,
                        EmployeesObservated = new List<GetEmployeeObservated>(list)
                    });


                }

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess=false;
            }
            return response;
        }

        public async Task<Response<List<GetEmployeeAssignated>>> GetEmployeesAssignatedToTicket(int idTicket)
        {
            var response = new Response<List<GetEmployeeAssignated>>();
            response.Data = new List<GetEmployeeAssignated>();
            var list = new List<string>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistories = await context.TicketHistories.Where(x => x.IdTicket == idTicket && x.AsignedTo != null && x.AsignedTo != "")
                    .ToListAsync();
                foreach (var item in ticketHistories)
                {
                    if(item.AsignedTo.Contains("PA") == false && item.AsignedTo.Contains("CR") == false)
                    {
                        if (item.AsignedTo.Contains("A"))
                        {
                            var agent = await context.Agents.Where(x => x.Code == item.AsignedTo).FirstOrDefaultAsync();
                            response.Data.Add(new GetEmployeeAssignated
                            {
                                Id = item.Id,
                                UserTo = item.UserTo,
                                Code = item.AsignedTo,
                                Name = agent != null ? agent.Name : ""
                            });
                        }
                        else
                        {
                            var personal = await context.Personals.Where(x => x.Code == item.AsignedTo).Include(x => x.IdEmployeeNavigation).FirstOrDefaultAsync();
                            response.Data.Add(new GetEmployeeAssignated
                            {
                                Id = item.Id,
                                UserTo = item.UserTo,
                                Code = item.AsignedTo,
                                Name = personal != null ? personal.IdEmployeeNavigation.FirstName + " " + personal.IdEmployeeNavigation.LastName : ""
                            });
                        }
                       
                    }
                   
                }
                //response.Data = _mapper.Map<List<GetEmployeeAssignated>>(ticketHistories);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = null;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateTicketPendingObservations(AddOrUpdateTicketPendingObservationsResponseDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                if(obj.Id == 0)
                {
                    var details = new List<DetailsTicketObservation>();
                    foreach (var item in obj.EmployeesObservated)
                    {
                        details.Add(new DetailsTicketObservation
                        {
                            AssignedTo = item.Code,
                        });
                    }
                    var insert = new TicketObservation
                    {
                        About = obj.About,
                        IdCompany = obj.IdCompany == 0 ? null : obj.IdCompany,
                        IdPerson = obj.IdPerson == 0 ? null : obj.IdPerson,
                        IdSubscriber = obj.IdSubscriber == 0 ? null : obj.IdSubscriber,
                        IdReason = obj.IdReason == 0 ? null : obj.IdReason,
                        IdTicket = obj.IdTicket == 0 ? null : obj.IdTicket,
                        Message = obj.Message,
                        Conclusion = obj.Conclusion,
                        IdStatusTicketObservations = Constants.OS_Pendiente,
                        Cc = obj.Cc,
                        AsignedDate = obj.AsignedDate,
                        EndDate = obj.EndDate,
                        SolutionDate =  null,
                        DetailsTicketObservations = details
                    };
                    await context.TicketObservations.AddAsync(insert);
                   
                    await context.SaveChangesAsync();
                    response.Data = true;
                }
                else
                {
                    var existingTicketObservations = await context.TicketObservations.Where(x => x.Id == obj.Id).FirstOrDefaultAsync();
                    if(existingTicketObservations != null)
                    {
                        existingTicketObservations.About = obj.About;
                        existingTicketObservations.IdCompany = obj.IdCompany;
                        existingTicketObservations.IdPerson = obj.IdPerson;
                        existingTicketObservations.IdSubscriber = obj.IdSubscriber;
                        existingTicketObservations.IdReason = obj.IdReason;
                        existingTicketObservations.Message = obj.Message;
                        existingTicketObservations.Conclusion = obj.Conclusion;
                        existingTicketObservations.IdStatusTicketObservations = obj.IdStatusTicketObservation;
                        existingTicketObservations.Cc = obj.Cc;
                        existingTicketObservations.AsignedDate = obj.AsignedDate;
                        existingTicketObservations.EndDate = obj.EndDate;
                        existingTicketObservations.SolutionDate = obj.SolutionDate;
                        context.TicketObservations.Update(existingTicketObservations);
                    }
                    await context.SaveChangesAsync();
                    response.Data = true;
                }
              
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> FinishTicketObservation(int idTicketObservation, string? conclusion, bool dr, bool ag, bool cl)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketObservation = await context.TicketObservations.Where(x => x.Id == idTicketObservation).FirstOrDefaultAsync();
                if(ticketObservation != null)
                {
                    ticketObservation.Conclusion = conclusion;
                    ticketObservation.RespDrr = dr;
                    ticketObservation.RespAg = ag;
                    ticketObservation.RespCl = cl;
                    ticketObservation.SolutionDate = DateTime.Now;
                    ticketObservation.IdStatusTicketObservations = Constants.OS_Resuelto;
                    context.TicketObservations.Update(ticketObservation);
                    await context.SaveChangesAsync();
                }
                else
                {
                    response.IsSuccess = false;
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<string>>> GetOtherUserCode(int idUser)
        {
            var response = new Response<List<string>>();
            response.Data = new List<string>();
            try
            {
                using var context = new SqlCoreContext();
                var user = await context.UserLogins
                    .Include(x => x.IdEmployeeNavigation)
                    .Include(x => x.IdEmployeeNavigation.Personals)
                    .Where(x => x.Id == idUser).FirstOrDefaultAsync();
                foreach (var item in user.IdEmployeeNavigation.Personals)
                {
                    response.Data.Add(item.Code);
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
    }

}
