using AspNetCore.Reporting;
using AutoMapper;
using CoreFtp;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Email;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Interfaces.EmailApplication;
using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using DRRCore.Transversal.Common.JsonReader;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Writers;
using SpreadsheetLight;
using System.IO;

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
        private readonly IXmlApplication _xmlApplication;
        private readonly IPersonApplication _personApplication;
        private IEmailHistoryDomain _emailHistoryDomain;
        private IMapper _mapper;
        private ILogger _logger;
        private readonly TicketPath _path;
        public TicketApplication(INumerationDomain numerationDomain, ITicketAssignationDomain ticketAssignationDomain, IEmployeeDomain employeeDomain, IXmlApplication xmlApplication,
            ITCuponDomain tCuponDomain, ITicketDomain ticketDomain, IPersonalDomain personalDomain, IAgentDomain agentDomain, IPersonApplication personApplication,
            ITicketReceptorDomain ticketReceptorDomain, ITicketHistoryDomain ticketHistoryDomain, ICountryDomain countryDomain,
            ICompanyDomain companyDomain, IMapper mapper, ILogger logger, IReportingDownload reportingDownload, IMailFormatter mailFormatter, IEmailConfigurationDomain emailConfigurationDomain,
            IEmailApplication emailApplication, IUserLoginDomain userLoginDomain, IPersonDomain personDomain, ISubscriberDomain subscriberDomain, ICompanyApplication companyApplication,
            IMailSender mailSender, IFileManager fileManager, IEmailHistoryDomain emailHistoryDomain  ,IOptions<TicketPath> path)
        {
            _xmlApplication = xmlApplication;
            _path = path.Value;
            _personApplication = personApplication;
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
        public async Task<Response<GetFileDto>> DownloadFileById(int id)
        {
            var response = new Response<GetFileDto>();
            MemoryStream ms = new MemoryStream();
            try
            {
                using var context = new SqlCoreContext();
                var file = await context.TicketFiles.Where(x => x.Id == id).FirstOrDefaultAsync();

               
                if (file != null)
                {
                    ms.Position = 0;
                    ms = await DescargarArchivo(file.Path);
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
        public async Task<Response<GetFileDto>> DownloadZipByIdTicket(int idTicket)
        {
            var response = new Response<GetFileDto>();
            MemoryStream ms = new MemoryStream();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                if(ticket != null)
                {
                    var directoryPath = System.IO.Path.Combine(_path.Path, "cupones", ticket.Number.ToString("D6"));
                    var memoryStream = new MemoryStream();
                    using (var archive = ZipArchive.Create())
                    {
                        archive.AddAllFromDirectory(directoryPath);
                        archive.SaveTo(memoryStream, new WriterOptions(CompressionType.Deflate)
                        {
                            LeaveStreamOpen = true
                        });
                    }
                    
                    var documentDto = new GetFileDto();
                    documentDto.File = memoryStream;
                    documentDto.ContentType = GetContentType(".zip");
                    documentDto.FileName = ticket.Number.ToString("D6");
                    response.Data = documentDto;
                    memoryStream.Position = 0;

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
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The file path cannot be null or empty.", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The specified file does not exist.", path);
            }

            MemoryStream memoryStream = new MemoryStream();

            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }

                memoryStream.Position = 0; // Reset the position to the beginning of the stream
                return memoryStream;
            }
            catch (Exception ex)
            {
                memoryStream.Dispose(); // Dispose the MemoryStream in case of an error
                throw new Exception($"An error occurred while downloading the file: {ex.Message}", ex);
            }
        }


        public async Task<Response<int?>> AddTicketAsync(AddOrUpdateTicketRequestDto request)
        {
            var response = new Response<int?>();
            try
            {
                using var context = new SqlCoreContext();

                var code = "CP_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Year;
                var productionClosure = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                if (productionClosure == null)
                {

                    DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                    await context.ProductionClosures.AddAsync(new Domain.Entities.SqlCoreContext.ProductionClosure
                    {
                        EndDate = lastDayOfCurrentMonth,
                        Code = code,
                        Title = "Cierre de Producción " + DateTime.Now.Month.ToString("D2") + " - " + DateTime.Now.Year,
                        Observations = ""
                    });
                }
                else
                {
                    if (productionClosure.EndDate < DateTime.Now)
                    {
                        if (DateTime.Now.Month == 12)
                        {
                            code = "CP_" + (1).ToString("D2") + "_" + (DateTime.Now.Year + 1);
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year + 1, 1, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = code,
                                    Title = "Cierre de Producción " + (1).ToString("D2") + " - " + DateTime.Today.Year + 1,
                                    Observations = ""
                                });
                            }
                        }
                        else
                        {
                            code = "CP_" + (DateTime.Now.Month + 1).ToString("D2") + "_" + DateTime.Now.Year;
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = code,
                                    Title = "Cierre de Producción " + (DateTime.Now.Month + 1).ToString("D2") + " - " + DateTime.Now.Year,
                                    Observations = ""
                                });
                            }
                        }
                    }
                }

                if (request == null && request.RequestedName.IsNullOrEmpty() == false)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (request.Id == 0)
                {
                    request.RequestedName = request.RequestedName.Trim();
                    request.RequestedName = request.RequestedName.Replace("?", "");
                    var newTicket = _mapper.Map<Ticket>(request);
                    newTicket.HasBalance = false;
                    newTicket.IdStatusTicket = (int?)TicketStatusEnum.Pendiente;
                    newTicket.TicketHistories.Add(new TicketHistory
                    {
                        IdStatusTicket = (int?)TicketStatusEnum.Pendiente,
                        UserFrom = request.UserFrom,
                        Cycle = code
                    });
                    var idEmployee = await GetReceptorDefault(request.IdCountry ?? 0, request.ReportType, request.IdSubscriber);
                    var userLogin = await context.UserLogins
                        .Include(x => x.IdEmployeeNavigation).Where(x => x.IdEmployeeNavigation.Id == idEmployee).FirstOrDefaultAsync();
                    newTicket.TicketAssignation = new TicketAssignation
                    {
                        IdEmployee = idEmployee,
                        IdUserLogin = userLogin.Id,
                        Commentary = request.Commentary
                    };

                    if (await _ticketDomain.AddAsync(newTicket))
                    {
                     
                        await _numerationDomain.UpdateTicketNumberAsync();
                        var traduction = new List<Domain.Entities.SqlCoreContext.Traduction>();
                        if (request.About == "E" && newTicket.IdCompany == null)
                        {
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "L_E_COMIDE",
                                LargeValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "S_E_DURATION",
                                ShortValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "L_E_REPUTATION",
                                LargeValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "L_E_NEW",
                                LargeValue = ""
                            });
                            var financial = new List<CompanyFinancialInformation>();
                            financial.Add(new CompanyFinancialInformation
                            {
                                IdFinancialSituacion = null
                            });
                            var company = await _companyDomain.AddCompanyAsync(new Domain.Entities.SqlCoreContext.Company
                            {
                                Name = request.RequestedName ?? string.Empty,
                                LastSearched = DateTime.Now,
                                Language = request.Language,
                                IdCountry = request.IdCountry ?? 0,
                                Place = request.City,
                                TaxTypeName = request.TaxType,
                                TaxTypeCode = request.TaxCode,
                                Email = request.Email,
                                Telephone = request.Telephone,
                                Address = request.Address,
                                Traductions = traduction,
                                CompanyFinancialInformations = financial
                            });
                            var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                            ticket.IdCompany = company;
                            await _ticketDomain.UpdateAsync(ticket);
                        }
                        if (request.About == "P" && newTicket.IdPerson == null)
                        {
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "S_P_NACIONALITY",
                                ShortValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "S_P_BIRTHPLACE",
                                ShortValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "S_P_MARRIEDTO",
                                ShortValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "S_P_PROFESSION",
                                ShortValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "L_P_NEWSCOMM",
                                LargeValue = ""
                            });
                            traduction.Add(new Domain.Entities.SqlCoreContext.Traduction
                            {
                                Identifier = "L_P_REPUTATION",
                                LargeValue = ""
                            });
                            var person = await _personDomain.AddPersonAsync(new Domain.Entities.SqlCoreContext.Person
                            {
                                Fullname = request.RequestedName ?? string.Empty,
                                Language = request.Language,
                                IdCountry = request.IdCountry ?? 0,
                                City = request.City,
                                TaxTypeName = request.TaxType,
                                TaxTypeCode = request.TaxCode,
                                Email = request.Email,
                                Cellphone = request.Telephone,
                                Address = request.Address,
                                Traductions = traduction
                            });
                            var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                            ticket.IdPerson = person;
                            await _ticketDomain.UpdateAsync(ticket);
                        }
                       
                        response.Data = newTicket.Id;
                    }
                }
                else
                {
                    var existingTicket = await _ticketDomain.GetByIdAsync(request.Id);
                    existingTicket.TicketAssignation.Commentary = request.Commentary;
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

                    response.Data = existingTicket.Id;
                }
                await context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<bool>> SaveTicketAsignations(int idTicket, string commentary)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var asignation = await context.Tickets.Where(x => x.Id == idTicket).Include(x => x.TicketAssignation).FirstOrDefaultAsync();
                if(asignation != null)
                {
                    asignation.TicketAssignation.Commentary = commentary;
                }
                context.Tickets.Update(asignation);
                await context.SaveChangesAsync();
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<bool>> DownloadAndUploadF1(int idTicket)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await  context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                if(ticket != null )
                {
                    var doc = ticket.About == "E" ? await _companyApplication.DownloadF1((int)ticket.IdCompany, "ESP", "pdf") : await _personApplication.DownloadF1((int)ticket.IdPerson, "ESP", "pdf");
                    if (doc != null && doc.Data != null)
                    {
                        var data = doc.Data;
                        var path = await UploadF1(ticket.Id, data.File);

                        var fileName = ticket.RequestedName;
                        foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                        {
                            if (fileName.Contains(c))
                            {
                                fileName = fileName.Replace(c, ' ');
                            }
                        }

                        await context.TicketFiles.AddAsync(new TicketFile
                        {
                            IdTicket = ticket.Id,
                            Path = path,
                            Name = ticket.ReportType + "_" + fileName + ".pdf",
                            Extension = ".pdf"
                        });
                        await context.SaveChangesAsync();
                    }
                }
            }catch (Exception ex)
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
                return getReceptor.IdEmployee ?? 38;
            }
            if (reportType == "EF")
            {
                getReceptor = await _ticketReceptorDomain.GetReceptorInDate(idCountry);
                return getReceptor.IdEmployee ?? 38;
            }
            getReceptor = await _ticketReceptorDomain.GetReceptorOtherCase(idCountry);
            return getReceptor.IdEmployee ?? 38;
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
                        list = list.OrderBy(x => x.DispatchtDate).ToList();

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


                        getExist.LastSearchedDate = StaticFunctions.DateTimeToString(company.LastSearched);
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
        private async Task<string> UploadF1(int idTicket, byte[] byteArray)
        {
            try
            {
                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                var fileName = ticket.RequestedName;
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    if (fileName.Contains(c))
                    {
                        fileName = fileName.Replace(c, ' ');
                    }
                }
                var ticketPath = _path.Path;
                var directoryPath = System.IO.Path.Combine(ticketPath, "cupones", ticket.Number.ToString("D6"));
                var filePath = System.IO.Path.Combine(directoryPath, $"{ticket.ReportType}_{fileName}.pdf");

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                await File.WriteAllBytesAsync(filePath, byteArray);

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Messages.ExceptionMessage, ex.Message));
            }
        }
        private async Task<string> UploadDispatchReport(int idTicket, string fileName, byte[] byteArray, string format)
        {
            try
            {

                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                var directoryPath = _path.Path + "/cupones/" + ticket.Number.ToString("D6");

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    if (fileName.Contains(c))
                    {
                        fileName = fileName.Replace(c, ' ');
                    }
                }

                var filePath = System.IO.Path.Combine(directoryPath, fileName + format);
                await File.WriteAllBytesAsync(filePath, byteArray);

                return filePath;

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
        public async Task<Response<bool>> TicketToDispatchById(int idTicket, bool hasObs)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                if(ticket != null)
                {
                    if(hasObs == true)
                    {
                        ticket.IdStatusTicket = (int)TicketStatusEnum.Por_Despachar_Con_Observaciones;
                    }
                    else
                    {
                        ticket.IdStatusTicket = (int)TicketStatusEnum.Por_Despachar;
                    }
                    context.Tickets.Update(ticket);
                    await context.SaveChangesAsync();
                    response.Data = true;
                }
                else
                {
                    response.Data = false;
                }
               
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response;
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
                response.Message = ex.Message;
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
                            item1.ShippingDate = DateTime.Today;
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
                            Flag=false,
                            AsignationType = "PA"
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
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<GetListTicketResponseDto2>>> GetTicketsToUser(string userTo)
        {
            var response = new Response<List<GetListTicketResponseDto2>>();
            response.Data = new List<GetListTicketResponseDto2>();
            try
            {
                using var context = new SqlCoreContext();
                var user = await context.UserLogins
                    .Include(x => x.IdEmployeeNavigation)
                    .Include(x => x.IdEmployeeNavigation.Personals)
                    .Where(x => x.Id == int.Parse(userTo)).FirstOrDefaultAsync();

                   var  list = await context.TicketHistories
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdTicketComplementNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdContinentNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCompanyNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.IdCountryNavigation).ThenInclude(x => x.IdContinentNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.IdCountryNavigation).ThenInclude(x => x.IdContinentNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.TicketAssignation).ThenInclude(x => x.IdEmployeeNavigation).ThenInclude(x => x.UserLogins)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdStatusTicketNavigation)
                       .Include(x => x.IdStatusTicketNavigation)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.TicketQuery)
                       .Include(x => x.IdTicketNavigation).ThenInclude(x => x.TicketFiles)
                       .Include(x => x.IdTicketNavigation.TicketHistories.OrderByDescending(x => x.Id)).Where(x => x.Enable == true)
                       .OrderByDescending(x => x.IdTicketNavigation.OrderDate)
                       .Where(x => x.UserTo == userTo && x.Flag == false && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Despachado && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Observado && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Rechazado)
                           .ToListAsync();
                
                if (list != null)
                {
                   
                    response.Data = _mapper.Map<List<GetListTicketResponseDto2>>(list);
                    foreach (var item in response.Data)
                    {

                        if (item.IsAgent)
                        {
                            var getIdAgent =await context.Agents.Where(x => x.Code == item.AgentFrom).FirstOrDefaultAsync();

                            var specialPriceAgents = await context.SpecialAgentBalancePrices.Where(x => x.IdAgent == getIdAgent.Id).ToListAsync();
                            foreach (var specialPriceAgent in specialPriceAgents)
                            {
                                item.SpecialAgentBalancePrices.Add(new DTO.Core.Response.SpecialAgentBalancePrice
                                {
                                    Id=specialPriceAgent.Id,
                                    Description=specialPriceAgent.Description
                                });
                            }
                        }


                        item.OtherUserCode = new List<UserCode>();
                        var otherCodes = new List<UserCode>();
                        foreach (var item1 in user.IdEmployeeNavigation.Personals)
                        {
                            if(item1.Code.Trim() != item.AsignedTo.Trim())
                            {
                                item.OtherUserCode.Add(new UserCode
                                {
                                    Code = item1.Code,
                                    Type = item1.Type,
                                    Active = false
                                });
                            }
                            else
                            {
                                item.OtherUserCode.Add(new UserCode
                                {
                                    Code = item1.Code,
                                    Type = item1.Type,
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
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();

                //string filePath = "/cupones/" + ticket.Number.ToString("D6") + "/" + file.FileName;

                var ticketPath = _path.Path;

                var directoryPath = System.IO.Path.Combine(ticketPath, "cupones", ticket.Number.ToString("D6"));
                string name = file.FileName;
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    if (name.Contains(c))
                    {
                        name = name.Replace(c, ' ');
                    }
                }

                var filePath = System.IO.Path.Combine(directoryPath, name);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                response.Data = true;
                string fileExtension = System.IO.Path.GetExtension(file.FileName);
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
                using var context = new SqlCoreContext();
                var ticketFile = await context.TicketFiles.Include(x => x.IdTicketNavigation).Where(x => x.Id == id).FirstOrDefaultAsync();
                if(ticketFile != null)
                {
                    ticketFile.DeleteDate = DateTime.Now;
                    ticketFile.Enable = false;
                    var path = ticketFile.Path;

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    context.TicketFiles.Update(ticketFile);
                    await context.SaveChangesAsync();
                }
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
                response.Message = ex.Message;
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
                var numeration = await context.Numerations.Where(x => x.Id == 1).FirstOrDefaultAsync();
                numeration.Number++;

                if (await _ticketDomain.AddAsync(newTicket))
                {
                    //  await CopyReportForm(request.Number);
                    // await CopyReportPerson(request.Number);
                    await _numerationDomain.UpdateTicketNumberAsync();
                    if (request.About == "E" && newTicket.IdCompany == null)
                    {
                        var company = await _companyDomain.AddCompanyAsync(new Domain.Entities.SqlCoreContext.Company
                        {
                            Name = request.RequestedName ?? string.Empty,
                            LastSearched = DateTime.Now,
                            Language = request.Language,
                            IdCountry = request.IdCountry ?? 0,
                            Place = request.City,
                            TaxTypeName = request.TaxType,
                            TaxTypeCode = request.TaxCode,
                            Email = request.Email,
                            Telephone = request.Telephone,
                            Address = request.Address
                        });
                        var ticket = await _ticketDomain.GetByIdAsync(newTicket.Id);
                        ticket.IdCompany = company;
                        await _ticketDomain.UpdateAsync(ticket);
                    }
                    if (request.About == "P" && newTicket.IdPerson == null)
                    {
                        var person = await _personDomain.AddPersonAsync(new Domain.Entities.SqlCoreContext.Person
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
                            var path = await UploadF1(ticket.Id, data.File);

                            await context.TicketFiles.AddAsync(new TicketFile
                            {
                                IdTicket = ticket.Id,
                                Path = path,
                                Name = ticket.ReportType + "_" + ticket.RequestedName + ".pdf",
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
                var context = new SqlCoreContext();

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


                var subscriber = await context.Subscribers.FindAsync(request.IdSubscriber);
                if(subscriber != null & subscriber.FacturationType == "CC")
                {
                    var couponBilling = await context.CouponBillingSubscribers.Where(x => x.IdSubscriber == request.IdSubscriber).FirstOrDefaultAsync();
                    var couponBillingHistory = new CouponBillingSubscriberHistory();
                    couponBillingHistory.PurchaseDate = DateTime.Now;
                    couponBillingHistory.Type = "E";
                    var lastHistory = await context.CouponBillingSubscriberHistories.Where(x => x.IdCouponBilling == couponBilling.Id).FirstOrDefaultAsync();

                    decimal? decimalDiscount = couponBilling.PriceT1;

                    switch (request.ProcedureType)
                    {
                        case "T2":
                            decimalDiscount = couponBilling.PriceT2;
                            break;
                        case "T3":
                            decimalDiscount = couponBilling.PriceT3;
                            break;
                        default:
                            decimalDiscount = couponBilling.PriceT1;
                            break;
                    }
                    couponBilling.NumCoupon = couponBilling.NumCoupon - decimalDiscount;
                    //Ese cuponAmount hay q convertir en decimal 
                    //continua
                    couponBillingHistory.CouponAmount = decimalDiscount;
                    couponBillingHistory.CouponUnitPrice = lastHistory.CouponUnitPrice;
                    couponBillingHistory.TotalPrice = couponBillingHistory.CouponAmount * couponBillingHistory.CouponUnitPrice;
                    couponBillingHistory.IdTicket = newTicket.Id;
                    couponBilling.CouponBillingSubscriberHistories.Add(couponBillingHistory);

                    context.CouponBillingSubscribers.Update(couponBilling);
                }


                await context.SaveChangesAsync();
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
            var listCompanies = new List<Domain.Entities.SqlCoreContext.Company> ();
            var listPersons = new List<Domain.Entities.SqlCoreContext.Person>();
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
                using var context = new SqlCoreContext();
                var tickets = new List<Ticket>();
                if (about == "E")
                {
                    tickets = await context.Tickets.Where(x => x.About == "E" && x.IdCompany == id && x.IdStatusTicket != 11)
                        .Include(x => x.IdSubscriberNavigation)
                        .Include(x => x.IdStatusTicketNavigation)
                        .ToListAsync();
                }
                else
                {
                    tickets = await context.Tickets.Where(x => x.About == "P" && x.IdPerson == id && x.IdStatusTicket != 11)
                        .Include(x => x.IdSubscriberNavigation)
                        .Include(x => x.IdStatusTicketNavigation)
                        .ToListAsync();

                }
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
                using var context = new SqlCoreContext();
                
                var ticketHistory = await context.TicketHistories
                    .Include(x => x.IdStatusTicketNavigation)
                    .Include(x => x.IdTicketNavigation)
                    .Where(x => x.IdTicket == idTicket && x.Enable == true)
                    .ToListAsync();
                if(ticketHistory.Count > 0 && ticketHistory.First().IdTicketNavigation.IsComplement == true && ticketHistory.First().IdTicketNavigation.IdTicketComplement != null)
                {
                    

                    var ticketHistoryFirst = await context.TicketHistories
                    .Include(x => x.IdStatusTicketNavigation)
                    .Include(x => x.IdTicketNavigation)
                    .Where(x => x.IdTicket == ticketHistory.First().IdTicketNavigation.IdTicketComplement && x.Enable == true)
                    .ToListAsync();
                    foreach (var item in ticketHistoryFirst)
                    {
                        var assignedToName = "";
                        if (item.AsignedTo != null && item.AsignedTo.Contains("PA"))
                        {
                            assignedToName = item.AsignedTo.Trim() == "PA1" ? "KATIA BUSTAMANTE" : item.AsignedTo.Trim() == "PA2" ? "MARIELA ACOSTA" : item.AsignedTo.Trim() == "PA3" ? "MONICA YEPEZ" :
                                item.AsignedTo.Trim() == "PA4" ? "RAFAEL DEL RISCO" : item.AsignedTo.Trim() == "PA5" ? "CECILIA RODRIGUEZ" : item.AsignedTo.Trim() == "PA6" ? "JESSICA LIAU" :
                                item.AsignedTo.Trim() == "PA7" ? "CECILIA SAYAS" : "";
                        }
                        else if (item.AsignedTo != null && item.AsignedTo.Contains("CR"))
                        {
                            assignedToName = "CECILIA RODRIGUEZ";
                        }
                        else if (item.AsignedTo != null && item.AsignedTo.Contains("D") || item.AsignedTo != null && item.AsignedTo.Contains("T")
                            || item.AsignedTo != null && item.AsignedTo.Contains("R") || item.AsignedTo != null && item.AsignedTo.Contains("RC") || item.AsignedTo != null && item.AsignedTo.Contains("S"))
                        {
                            var employee = await _employeeDomain.FindByPersonalCode(item.AsignedTo);
                            assignedToName = employee != null ? employee.FirstName + " " + employee.LastName : string.Empty;
                        }

                        else if (item.AsignedTo == null)
                        {
                            var user = await context.UserLogins
                                .Include(x => x.IdEmployeeNavigation)
                                .Where(x => x.Id == int.Parse(item.UserFrom)).FirstOrDefaultAsync();
                            assignedToName = user.IdEmployeeNavigation != null ? user.IdEmployeeNavigation.FirstName + " " + user.IdEmployeeNavigation.LastName : "";
                        }
                        else
                        {
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
                        newTimeLine.Flag = item.Flag;
                        response.Data.Add(newTimeLine);
                    }
                    var newTimeLineFirst = new GetTimeLineTicketHistoryResponseDto();

                    newTimeLineFirst.Id = 0;
                    newTimeLineFirst.AssignedTo = "";
                    newTimeLineFirst.AssignedToName = "";
                    newTimeLineFirst.Date = "";
                    newTimeLineFirst.Time = "";
                    newTimeLineFirst.IdStatusTicket = 0;
                    newTimeLineFirst.Status = "Complemento del Pedido";
                    newTimeLineFirst.Color = "label-success";


                    response.Data.Add(newTimeLineFirst);
                }
                if (ticketHistory != null)
                {

                    foreach (var item in ticketHistory)
                    {
                        var assignedToName = "";
                        if (item.AsignedTo != null && item.AsignedTo.Contains("PA"))
                        {
                            assignedToName = item.AsignedTo.Trim() == "PA1" ? "KATIA BUSTAMANTE" : item.AsignedTo.Trim() == "PA2" ? "MARIELA ACOSTA" : item.AsignedTo.Trim() == "PA3" ? "MONICA YEPEZ" :
                                item.AsignedTo.Trim() == "PA4" ? "RAFAEL DEL RISCO" : item.AsignedTo.Trim() == "PA5" ? "CECILIA RODRIGUEZ" : item.AsignedTo.Trim() == "PA6" ? "JESSICA LIAU" :
                                item.AsignedTo.Trim() == "PA7" ? "CECILIA SAYAS" : "";
                        }
                        else if (item.AsignedTo != null && item.AsignedTo.Contains("CR"))
                        {
                            assignedToName = "CECILIA RODRIGUEZ";
                        }
                        else if (item.AsignedTo != null && item.AsignedTo.Contains("D") || item.AsignedTo != null && item.AsignedTo.Contains("T")
                            || item.AsignedTo != null && item.AsignedTo.Contains("R") || item.AsignedTo != null && item.AsignedTo.Contains("RC") || item.AsignedTo != null && item.AsignedTo.Contains("S"))
                        {
                            var employee = await _employeeDomain.FindByPersonalCode(item.AsignedTo);
                            assignedToName = employee != null ? employee.FirstName + " " + employee.LastName : string.Empty;
                        }
                        
                        else if (item.AsignedTo == null)
                        {
                            var user = await context.UserLogins
                                .Include(x => x.IdEmployeeNavigation)
                                .Where(x => x.Id == int.Parse(item.UserFrom)).FirstOrDefaultAsync();
                            assignedToName = user.IdEmployeeNavigation != null ? user.IdEmployeeNavigation.FirstName + " " + user.IdEmployeeNavigation.LastName : "";
                        }
                        else
                        {
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
                        newTimeLine.Flag = item.Flag;
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
                    var code = "CP_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Year;
                    var productionClosure = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                    if (productionClosure == null)
                    {

                        DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                        await context.ProductionClosures.AddAsync(new ProductionClosure
                        {
                            EndDate = lastDayOfCurrentMonth,
                            Code = code,
                            Title = "Cierre de Producción " + DateTime.Now.Month.ToString("D2") + " - " + DateTime.Now.Year,
                            Observations = ""
                        });
                    }
                    else
                    {
                        if (productionClosure.EndDate < DateTime.Now)
                        {
                            if (DateTime.Now.Month == 12)
                            {
                                code = "CP_" + (1).ToString("D2") + "_" + (DateTime.Now.Year + 1);
                                var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                                if(nextProductionClosureExistent == null)
                                {
                                    DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year + 1, 1, 1).AddMonths(1).AddDays(-1);
                                    await context.ProductionClosures.AddAsync(new ProductionClosure
                                    {
                                        EndDate = lastDayOfCurrentMonth,
                                        Code = code,
                                        Title = "Cierre de Producción " + (1).ToString("D2") + " - " + DateTime.Today.Year + 1,
                                        Observations = ""
                                    });
                                }
                            }
                            else
                            {
                                code = "CP_" + (DateTime.Now.Month + 1).ToString("D2") + "_" + DateTime.Now.Year;
                                var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                                if (nextProductionClosureExistent == null)
                                {
                                    DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, (DateTime.Today.Month + 1), 1).AddMonths(1).AddDays(-1);
                                    await context.ProductionClosures.AddAsync(new ProductionClosure
                                    {
                                        EndDate = lastDayOfCurrentMonth,
                                        Code = code,
                                        Title = "Cierre de Producción " + (DateTime.Now.Month + 1).ToString("D2") + " - " + DateTime.Now.Year,
                                        Observations = ""
                                    });
                                }
                                
                            }

                        }
                    }

                    if (obj.OtherUserCode.Count > 0)
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
                                    newTicketHistory.Flag = true;
                                    newTicketHistory.NumberAssign = ticketHistory.NumberAssign;
                                    newTicketHistory.Balance = ticketHistory.Balance;
                                    newTicketHistory.References = ticketHistory.References;
                                    newTicketHistory.Observations = ticketHistory.Observations;
                                    newTicketHistory.StartDate = ticketHistory.StartDate;
                                    newTicketHistory.EndDate = ticketHistory.EndDate;
                                    newTicketHistory.AsignationType = ticketHistory.AsignationType;
                                    newTicketHistory.Cycle = "";

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
                                            ticket.QualityTypist = item.QualityTypist;
                                            ticket.QualityTranslator = item.QualityTranslator;
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
                                       string nameAssignedTo = "PRE_ASSIGN_" + item.AssignedToCode.Trim();
                                        string descriptionAssignedTo = "Pre-Asignación " + item.AssignedToCode.Trim();
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            numeration = new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            };
                                            await context.Numerations.AddAsync(numeration);
                                        }
                                        else
                                        {
                                            number = numeration.Number + 1;
                                            numeration.Number++;
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }

                                        ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                        ticket.UpdateDate = DateTime.Now;
                                        ticket.IdStatusTicket = (int)TicketStatusEnum.Pre_Asignacion;
                                        history.Flag = true;
                                        history.Cycle = code;
                                        history.ShippingDate = DateTime.Now;
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
                                            StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                            EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                            Observations=item.Observations,
                                            Balance=item.Balance,
                                            AsignationType = item.Type,
                                            Cycle = ""
                                        };
                                        await context.TicketHistories.AddAsync(newTicketHistory);

                                        await context.SaveChangesAsync();

                                    }
                                    if (item.Type == "RP")
                                    {
                                        string nameAssignedTo = "REPORTERO_" + item.AssignedToCode.Trim();
                                        string descriptionAssignedTo = "Reportero " + item.AssignedToCode.Trim();
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            numeration = new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            };
                                            await context.Numerations.AddAsync(numeration);
                                        }
                                        else
                                        {
                                            number = numeration.Number + 1;
                                            numeration.Number++;
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }



                                        ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                        ticket.UpdateDate = DateTime.Now;
                                        ticket.IdStatusTicket = (int)TicketStatusEnum.Asig_Reportero;
                                        history.Flag = true;
                                        history.Cycle = code;
                                        history.ShippingDate = DateTime.Now;
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = item.Type,
                                                Cycle = "",
                                                References = item.References
                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                            
                                            var emailDataDto = new EmailDataDTO();
                                            emailDataDto.Parameters = new List<string>();
                                            //ENVIAR CORREO
                                            var userFrom = await context.UserLogins
                                                .Include(x => x.IdEmployeeNavigation)
                                                .Where(x => x.Id == int.Parse(item.UserFrom)).FirstOrDefaultAsync();

                                            if (item.Internal)
                                            {
                                                var user = await context.UserLogins.Include(x => x.IdEmployeeNavigation).Where(x => x.Id == int.Parse(item.UserTo)).FirstOrDefaultAsync();

                                                if (userFrom != null && user != null)
                                                {
                                                    emailDataDto.EmailKey = "DRR_WORKFLOW_ESP_0061";
                                                    emailDataDto.BeAuthenticated = true;
                                                    var debug = await context.Parameters.Where(x => x.Key == "DEBUG").FirstOrDefaultAsync();
                                                    if(debug != null && debug.Flag == true)
                                                    {
                                                        emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.Password = userFrom.EmailPassword;
                                                        emailDataDto.To = new List<string>
                                                        {
                                                            user.IdEmployeeNavigation.Email
                                                        };
                                                        emailDataDto.CC = new List<string>
                                                        {
                                                            "prueba.sistemas@del-risco.com",
                                                            userFrom.IdEmployeeNavigation.Email
                                                           
                                                        };
                                                        emailDataDto.Subject = "PRUEBA_" + ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                    }
                                                    else
                                                    {
                                                        emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.Password = userFrom.EmailPassword;
                                                        emailDataDto.To = new List<string>
                                                        {
                                                            user.IdEmployeeNavigation.Email
                                                        };
                                                        emailDataDto.CC = new List<string>
                                                        {
                                                            "prueba.sistemas@del-risco.com",
                                                            userFrom.IdEmployeeNavigation.Email,
                                                           
                                                        };
                                                        emailDataDto.Subject = ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                    }

                                                    emailDataDto.IsBodyHTML = true;
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.FirstName + " " + userFrom.IdEmployeeNavigation.LastName); 
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.Email);
                                                    emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                                                    _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));

                                                    var file = DownloadAssignReporter((int)ticket.Id, item.AssignedToCode, item.StartDate, item.EndDate, numeration.Number ?? 1, item.Observations).Result.Data;
                                                    var attachment = new AttachmentDto();
                                                    attachment.FileName = file.Name + ".pdf";
                                                    attachment.Content = Convert.ToBase64String(file.File);
                                                    string path = await UploadDispatchReport(ticket.Id, file.Name, file.File, ".pdf");
                                                    emailDataDto.Attachments.Add(attachment);


                                                    if (item.AttachmentRefCom == true)
                                                    {
                                                        var providersFile = DownloadListProviders(ticket.About.Trim(), ticket.About.Trim() == "E" ? (int)ticket.IdCompany : (int)ticket.IdPerson).Result.Data;
                                                        var attachmentProviders = new AttachmentDto();
                                                        attachmentProviders.FileName = providersFile.Name + ".xlsx";
                                                        attachmentProviders.Content = Convert.ToBase64String(providersFile.File);
                                                        string pathProvider = await UploadDispatchReport(ticket.Id, providersFile.Name, providersFile.File, ".xlsx");
                                                        emailDataDto.Attachments.Add(attachmentProviders);
                                                    }

                                                    await context.TicketFiles.AddAsync(new TicketFile
                                                    {
                                                        IdTicket = ticket.Id,
                                                        Path = path,
                                                        Name = file.Name+".pdf",
                                                        Extension = ".pdf"
                                                    });


                                                    var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                                                    var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                                                    emailHistory.Success = result;
                                                    response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
                                                    _logger.LogInformation(Messages.MailSuccessSend);
                                                }
                                            }
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = item.Type,
                                                Cycle = "",
                                                References = item.References

                                            };

                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                            var emailDataDto = new EmailDataDTO();
                                            emailDataDto.Parameters = new List<string>();
                                            //ENVIAR CORREO
                                            var userFrom = await context.UserLogins
                                                .Include(x => x.IdEmployeeNavigation)
                                                .Where(x => x.Id == int.Parse(item.UserFrom)).FirstOrDefaultAsync();

                                                var user = await context.Agents.Where(x => x.Code.Contains(item.AssignedToCode.Trim())).FirstOrDefaultAsync();

                                                if (userFrom != null && user != null)
                                                {
                                                    emailDataDto.EmailKey = "DRR_WORKFLOW_ESP_0061";
                                                    emailDataDto.BeAuthenticated = true;
                                                    var debug = await context.Parameters.Where(x => x.Key == "DEBUG").FirstOrDefaultAsync();
                                                    if (debug != null && debug.Flag == true)
                                                    {
                                                        emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.Password = userFrom.EmailPassword;
                                                        emailDataDto.To = new List<string>
                                                        {                                                           
                                                            user.Email
                                                        };
                                                        emailDataDto.CC = new List<string>
                                                        {
                                                            "prueba.sistemas@del-risco.com",
                                                            userFrom.IdEmployeeNavigation.Email,
                                                           
                                                        };
                                                        emailDataDto.Subject = "PRUEBA_" + ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                    }
                                                    else
                                                    {
                                                        emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                        emailDataDto.Password = userFrom.EmailPassword;
                                                        emailDataDto.To = new List<string>
                                                        {                                                          
                                                            user.Email
                                                        };
                                                        emailDataDto.CC = new List<string>
                                                        {
                                                            "prueba.sistemas@del-risco.com",
                                                            userFrom.IdEmployeeNavigation.Email,
                                                           
                                                        };
                                                        emailDataDto.Subject = ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                    }

                                                    emailDataDto.IsBodyHTML = true;
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.FirstName + " " + userFrom.IdEmployeeNavigation.LastName); 
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.Email);
                                                    emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                                                    _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));

                                                    var file = DownloadAssignReporter((int)ticket.Id, item.AssignedToCode, item.StartDate, item.EndDate, numeration.Number ?? 1, item.Observations).Result.Data;
                                                    var attachment = new AttachmentDto();
                                                    attachment.FileName = file.Name + ".pdf";
                                                    attachment.Content = Convert.ToBase64String(file.File);
                                                    string path = await UploadDispatchReport(ticket.Id, file.Name, file.File, ".pdf");
                                                    emailDataDto.Attachments.Add(attachment);

                                                    if (item.AttachmentRefCom == true)
                                                    {
                                                        var providersFile = DownloadListProviders(ticket.About.Trim(), ticket.About.Trim() == "E" ? (int)ticket.IdCompany : (int)ticket.IdPerson).Result.Data;
                                                        var attachmentProviders = new AttachmentDto();
                                                        attachmentProviders.FileName = providersFile.Name + ".xlsx";
                                                        attachmentProviders.Content = Convert.ToBase64String(providersFile.File);
                                                        string pathProvider = await UploadDispatchReport(ticket.Id, providersFile.Name, providersFile.File, ".xlsx");
                                                        emailDataDto.Attachments.Add(attachmentProviders);
                                                    }

                                                    await context.TicketFiles.AddAsync(new TicketFile
                                                    {
                                                        IdTicket = ticket.Id,
                                                        Path = path,
                                                        Name = emailDataDto.Subject,
                                                        Extension = ".pdf"
                                                    });


                                                    var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                                                    var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                                                    emailHistory.Success = result;
                                                    response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
                                                    _logger.LogInformation(Messages.MailSuccessSend);
                                                }
                                            
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = item.Type,
                                                Cycle = "",
                                                References = item.References
                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);
                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "AG")
                                    {
                                        string nameAssignedTo = "AGENTE_" + item.AssignedToCode.Trim();
                                        string descriptionAssignedTo = "Agente " + item.AssignedToCode.Trim();
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            numeration = new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            };
                                            await context.Numerations.AddAsync(numeration);
                                        }
                                        else
                                        {
                                            number = numeration.Number++;                                           
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }


                                        ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                        ticket.UpdateDate = DateTime.Now;
                                        history.Flag = true;
                                        history.Cycle = code;
                                        history.ShippingDate = DateTime.Now;
                                        history.UpdateDate = DateTime.Now;


                                        if (item.Internal)
                                        {
                                            if (item.AssignedToCode.Trim() == "A30") item.UserTo = "45";
                                            if (item.AssignedToCode.Trim() == "A17") item.UserTo = "56";
                                            if (item.AssignedToCode.Trim() == "A60") item.UserTo = "55";
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                AsignationType = item.Type,
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                References = item.References,
                                                Cycle = ""

                                            };
                                            ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.Cycle = code;
                                            history.ShippingDate = DateTime.Now;
                                            history.UpdateDate = DateTime.Now;

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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                References = item.References,
                                                AsignationType = item.Type,
                                                Cycle = ""
                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }

                                        // Declara emailDataDto fuera de los bloques if/else
                                        EmailDataDTO emailDataDto = null;

                                        //ENVIAR CORREO
                                        var userFrom = await context.UserLogins
                                            .Include(x => x.IdEmployeeNavigation)
                                            .Where(x => x.Id == int.Parse(item.UserFrom)).FirstOrDefaultAsync();

                                        if (item.Internal)
                                        {
                                            emailDataDto = new EmailDataDTO();
                                            var user = await context.UserLogins.Include(x => x.IdEmployeeNavigation).Where(x => x.Id == int.Parse(item.UserTo)).FirstOrDefaultAsync();
                                            
                                            if (userFrom != null && user != null)
                                            {
                                                emailDataDto.EmailKey = "DRR_WORKFLOW_ESP_0023";
                                                emailDataDto.BeAuthenticated = true;

                                                var debug = await context.Parameters.Where(x => x.Key == "DEBUG").FirstOrDefaultAsync();
                                                if (debug != null && debug.Flag == true)
                                                {
                                                    emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.Password =userFrom.EmailPassword;
                                                    emailDataDto.To = new List<string>
                                                    {
                                                        user.IdEmployeeNavigation.Email                                                      
                                                    };
                                                    emailDataDto.CC = new List<string>
                                                    {
                                                        "prueba.sistemas@del-risco.com",
                                                        userFrom.IdEmployeeNavigation.Email,
                                                      
                                                    };
                                                    emailDataDto.Subject = "PRUEBA_" + ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                }
                                                else
                                                {
                                                    emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.Password = userFrom.EmailPassword;
                                                    emailDataDto.To = new List<string>
                                                        {
                                                            user.IdEmployeeNavigation.Email
                                                        };
                                                    emailDataDto.CC = new List<string>
                                                        {
                                                            "prueba.sistemas@del-risco.com",
                                                            userFrom.IdEmployeeNavigation.Email                                                           
                                                        };
                                                    emailDataDto.Subject = ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                }


                                                emailDataDto.IsBodyHTML = true;
                                                emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.FirstName + " " + userFrom.IdEmployeeNavigation.LastName); 
                                                emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.Email);
                                                emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                                                _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));

                                                var file = DownloadAssignAgent((int)ticket.Id, item.AssignedToCode,item.StartDate,item.EndDate, numeration.Number ?? 1, item.Observations).Result.Data;
                                                var attachment = new AttachmentDto();
                                                attachment.FileName = file.Name + ".pdf";
                                                attachment.Content = Convert.ToBase64String(file.File);
                                                string path = await UploadDispatchReport(ticket.Id, file.Name, file.File, ".pdf");

                                                if (item.AttachmentRefCom == true)
                                                {
                                                    var providersFile = DownloadListProviders(ticket.About.Trim(), ticket.About.Trim() == "E" ? (int)ticket.IdCompany : (int)ticket.IdPerson).Result.Data;
                                                    var attachmentProviders = new AttachmentDto();
                                                    attachmentProviders.FileName = providersFile.Name + ".xlsx";
                                                    attachmentProviders.Content = Convert.ToBase64String(providersFile.File);
                                                    string pathProvider = await UploadDispatchReport(ticket.Id, providersFile.Name, providersFile.File, ".xlsx");
                                                    emailDataDto.Attachments.Add(attachmentProviders);
                                                }

                                                await context.TicketFiles.AddAsync(new TicketFile
                                                {
                                                    IdTicket = ticket.Id,
                                                    Path = path,
                                                    Name = file.Name,
                                                    Extension = ".pdf"
                                                });
                                                emailDataDto.Attachments.Add(attachment);
                                                if (item.SendZip == true)
                                                {
                                                    var zip = DownloadZipByIdTicket((int)ticket.Id).Result.Data;
                                                    var attachment2 = new AttachmentDto();
                                                    attachment2.FileName = ticket.Number.ToString("D6") + ".zip";
                                                    attachment2.Content = Convert.ToBase64String(zip.File.ToArray());
                                                    emailDataDto.Attachments.Add(attachment2);
                                                }
                                                var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));
                                                var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                                                emailHistory.Success = result;
                                                response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
                                                _logger.LogInformation(Messages.MailSuccessSend);
                                            }
                                        }
                                        else
                                        {
                                            var agent = await context.Agents.Where(x => x.Code.Contains(item.AssignedToCode)).FirstOrDefaultAsync();
                                            var emailAgents = agent.Email.Split(";");
                                            if (userFrom != null && agent != null)
                                            {
                                                emailDataDto = new EmailDataDTO();
                                                emailDataDto.EmailKey = "DRR_WORKFLOW_ESP_0023";
                                                emailDataDto.BeAuthenticated = true;
                                                var debug = await context.Parameters.Where(x => x.Key == "DEBUG").FirstOrDefaultAsync();
                                                if (debug != null && debug.Flag == true)
                                                {
                                                    emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.Password = userFrom.EmailPassword;
                                                    emailDataDto.To = new List<string>();

                                                    emailDataDto.To.Add(userFrom.IdEmployeeNavigation.Email);
                                                   
                                                    emailDataDto.CC = new List<string>
                                                    {
                                                        "prueba.sistemas@del-risco.com",                                                       
                                                    };
                                                    emailDataDto.Subject = "PRUEBA_" + ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.FirstName + " " + userFrom.IdEmployeeNavigation.LastName);
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.Email);
                                                }
                                                else
                                                {
                                                    emailDataDto.From = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.UserName = userFrom.IdEmployeeNavigation.Email;
                                                    emailDataDto.Password = userFrom.EmailPassword;
                                                    emailDataDto.To = new List<string>();
                                                    foreach(var email in emailAgents)
                                                    {
                                                        emailDataDto.To.Add(email);
                                                    }
                                                    emailDataDto.CC = new List<string>
                                                    {
                                                        "prueba.sistemas@del-risco.com",
                                                        userFrom.IdEmployeeNavigation.Email
                                                    };
                                                    emailDataDto.Subject = ticket.ReportType + ": " + (numeration != null ? numeration.Number : 1) + " / " + ticket.RequestedName + " / Trámite : " + ticket.ProcedureType + " /F.vencimiento : " + item.EndDate + DateTime.Now.ToString("t");
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.FirstName + " " + userFrom.IdEmployeeNavigation.LastName); 
                                                    emailDataDto.Parameters.Add(userFrom.IdEmployeeNavigation.Email);
                                                }
                                                emailDataDto.IsBodyHTML = true;
                                               
                                                emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                                                //_logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));

                                                var file = DownloadAssignAgent((int)ticket.Id, item.AssignedToCode, item.StartDate, item.EndDate, numeration.Number ?? 1, item.Observations).Result.Data;
                                                var attachment = new AttachmentDto();
                                                attachment.FileName = file.Name + ".pdf";
                                                attachment.Content = Convert.ToBase64String(file.File);
                                                string path = await UploadDispatchReport(ticket.Id, file.Name, file.File, ".pdf");
                                                await context.TicketFiles.AddAsync(new TicketFile
                                                {
                                                    IdTicket = ticket.Id,
                                                    Path = path,
                                                    Name = file.Name,
                                                    Extension = ".pdf"
                                                });

                                                if (item.AttachmentRefCom == true)
                                                {
                                                    var providersFile = DownloadListProviders(ticket.About.Trim(), ticket.About.Trim() == "E" ? (int)ticket.IdCompany : (int)ticket.IdPerson).Result.Data;
                                                    var attachmentProviders = new AttachmentDto();
                                                    attachmentProviders.FileName = providersFile.Name + ".xlsx";
                                                    attachmentProviders.Content = Convert.ToBase64String(providersFile.File);
                                                    string pathProvider = await UploadDispatchReport(ticket.Id, providersFile.Name, providersFile.File, ".xlsx");
                                                    emailDataDto.Attachments.Add(attachmentProviders);
                                                }

                                                emailDataDto.Attachments.Add(attachment);
                                                if (item.SendZip == true)
                                                {
                                                    var zip = DownloadZipByIdTicket((int)ticket.Id).Result.Data;
                                                    var attachment2 = new AttachmentDto();
                                                    attachment2.FileName = ticket.Number.ToString("D6") + ".zip";
                                                    attachment2.Content = Convert.ToBase64String(zip.File.ToArray());
                                                    emailDataDto.Attachments.Add(attachment2);
                                                }
                                                var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                                                var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                                                emailHistory.Success = result;
                                                response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
                                                _logger.LogInformation(Messages.MailSuccessSend);
                                            }
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                References = item.References,
                                                AsignationType = item.Type,
                                                Cycle = ""
                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }
                                        ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                        ticket.UpdateDate = DateTime.Now;
                                        history.Flag = true;
                                        history.Cycle = code;
                                        history.ShippingDate = DateTime.Now;
                                        history.UpdateDate = DateTime.Now;

                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "RF")
                                    {
                                        string nameAssignedTo = "REFERENCISTA_" + item.AssignedToCode.Trim();
                                        string descriptionAssignedTo = "Referencia " + item.AssignedToCode.Trim();
                                        var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                        int? number = 1;
                                        if (numeration == null)
                                        {
                                            numeration = new Numeration
                                            {
                                                Name = nameAssignedTo,
                                                Description = descriptionAssignedTo,
                                                Number = 1
                                            };
                                            await context.Numerations.AddAsync(numeration);
                                        }
                                        else
                                        {
                                            number = numeration.Number + 1;
                                            numeration.Number++;
                                            numeration.UpdateDate = DateTime.Now;
                                            context.Numerations.Update(numeration);
                                        }

                                        ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                        ticket.UpdateDate = DateTime.Now;
                                        history.Flag = true;
                                        history.Cycle = code;
                                        history.ShippingDate = DateTime.Now;
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = "RF",
                                                Cycle = "",
                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        
                                       
                                       
                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "DI")
                                    {
                                        if (item.AssignedToCode.Trim() == "D15")
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = "DI",
                                                Cycle = ""
                                            };
                                            ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.Cycle = code;
                                            history.ShippingDate = DateTime.Now;
                                            history.UpdateDate = DateTime.Now;
                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                        }
                                        else
                                        {
                                            string nameAssignedTo = "DIGITADOR" + item.AssignedToCode.Trim();
                                            string descriptionAssignedTo = "Digitador " + item.AssignedToCode.Trim();
                                            var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                            int? number = 1;
                                            if (numeration == null)
                                            {
                                                numeration = new Numeration
                                                {
                                                    Name = nameAssignedTo,
                                                    Description = descriptionAssignedTo,
                                                    Number = 1
                                                };
                                                await context.Numerations.AddAsync(numeration);
                                            }
                                            else
                                            {
                                                number = numeration.Number + 1;
                                                numeration.Number++;
                                                numeration.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numeration);
                                            }


                                            ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.Cycle = code;
                                            history.ShippingDate = DateTime.Now;
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = item.Type,
                                                Cycle = ""
                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }

                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "TR")
                                    {
                                        if (item.AssignedToCode.Trim() == "T14")
                                        {

                                            string nameAssignedToRef = "PORTRADUCIR_CR5";
                                            string descriptionAssignedToRef = "Por Traducir ";
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = "TR",
                                                Cycle = ""
                                            };
                                            ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.Cycle = code;
                                            history.ShippingDate = DateTime.Now;
                                            history.UpdateDate = DateTime.Now;
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
                                                numeration = new Numeration
                                                {
                                                    Name = nameAssignedTo,
                                                    Description = descriptionAssignedTo,
                                                    Number = 1
                                                };
                                                await context.Numerations.AddAsync(numeration);
                                            }
                                            else
                                            {
                                                number = numeration.Number + 1;
                                                numeration.Number++;
                                                numeration.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numeration);
                                            }

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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = "TR",
                                                Cycle = ""

                                            };
                                            await context.TicketHistories.AddAsync(newTicketHistory);
                                        }

                                        ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                        ticket.UpdateDate = DateTime.Now;
                                        history.Flag = true;
                                        history.Cycle = code;
                                        history.ShippingDate = DateTime.Now;
                                        history.UpdateDate = DateTime.Now;

                                        context.Tickets.Update(ticket);
                                        context.TicketHistories.Update(history);

                                        await context.SaveChangesAsync();
                                    }
                                    if (item.Type == "SU")
                                    {
                                        if (ticket.TicketHistories.Any(x =>x.AsignedTo!=null && x.AsignedTo.Contains("RC") && x.Flag == false) && !item.ForceSupervisor)
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
                                            //CONDICIONAL SI EL TICKET TIENE REFERENCIAS O NO


                                            var newTicketHistory = new TicketHistory
                                            {
                                                IdTicket = ticket.Id,
                                                UserFrom = item.UserFrom,
                                                UserTo = "42",
                                                AsignedTo = "CR3",
                                                IdStatusTicket = (int)TicketStatusEnum.Por_Supervisar,
                                                NumberAssign = numberRef,
                                                Flag = false,
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = "SU",
                                                Cycle = ""
                                            };
                                            ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.Cycle = code;
                                            history.ShippingDate = DateTime.Now;
                                            history.UpdateDate = DateTime.Now;
                                            await context.TicketHistories.AddAsync(newTicketHistory);

                                        }
                                        else
                                        {
                                            string nameAssignedTo = "SUPERVISOR" + item.AssignedToCode.Trim();
                                            string descriptionAssignedTo = "Supervisor " + item.AssignedToCode.Trim();
                                            var numeration = await context.Numerations.Where(x => x.Name == nameAssignedTo).FirstOrDefaultAsync();
                                            int? number = 1;
                                            if (numeration == null)
                                            {
                                                numeration = new Numeration
                                                {
                                                    Name = nameAssignedTo,
                                                    Description = descriptionAssignedTo,
                                                    Number = 1
                                                };
                                                await context.Numerations.AddAsync(numeration);
                                            }
                                            else
                                            {
                                                number = numeration.Number + 1;
                                                numeration.Number++;
                                                numeration.UpdateDate = DateTime.Now;
                                                context.Numerations.Update(numeration);
                                            }

                                            ticket.HasBalance = item.HasBalance == null ? ticket.HasBalance : item.HasBalance;
                                            ticket.UpdateDate = DateTime.Now;
                                            history.Flag = true;
                                            history.Cycle = code;
                                            history.ShippingDate = DateTime.Now;
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
                                                StartDate = StaticFunctions.VerifyDate(item.StartDate),
                                                EndDate = StaticFunctions.VerifyDate(item.EndDate),
                                                Observations = item.Observations,
                                                Balance = item.Balance,
                                                AsignationType = "SU",
                                                Cycle = ""
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
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
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

        public async Task<Response<bool>> DispatchTicket(int idTicket, int idUser, List<int> idTicketFiles)
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
                        item.Flag = true;
                        context.TicketHistories.Update(item);
                    }
                    var history = new TicketHistory();
                    history.IdTicket = idTicket;
                    history.UserFrom = idUser + "";
                    history.IdStatusTicket = (int?)TicketStatusEnum.Despachado;
                    history.Flag = true;
                    history.ShippingDate = DateTime.Today;
                    history.NumberAssign = ticketHistory.Last().NumberAssign + 1;
                    await context.TicketHistories.AddAsync(history);

                    var debug = await context.Parameters.Where(x => x.Key == "DEBUG").FirstOrDefaultAsync();
                    if(debug != null)
                    {
                        if(debug.Flag == true)
                        {
                            emailDataDto.Subject = ticket.IsComplement == true ? "UPDATED - " : "" + "PRUEBA_DESPACHO_" + ticket.ReferenceNumber +"_" + ticket.RequestedName + "_" + ticket.ReportType + "_" + DateTime.Now.ToString("dd-MM-yyyy");
                            emailDataDto.From =  userLogin.IdEmployeeNavigation.Email;
                            emailDataDto.UserName = emailDataDto.From;
                            emailDataDto.Password = userLogin.EmailPassword;
                            emailDataDto.To = new List<string>
                            {
                                userLogin.IdEmployeeNavigation.Email
                                //ticket.IdSubscriberNavigation.SendReportToEmail,
                            };
                            emailDataDto.CC = new List<string>
                            {
                                "diego.rodriguez@del-risco.com",
                                "myepez@del-risco.com"
                            };
                        }
                        else
                        {
                            emailDataDto.Subject = ticket.IsComplement == true ? "UPDATED - " : "" + ticket.ReferenceNumber+"_"+ticket.RequestedName + "_" + ticket.ReportType + "_" + DateTime.Now.ToString("dd-MM-yyyy");

                            emailDataDto.From = userLogin.IdEmployeeNavigation.Email;
                            emailDataDto.UserName = emailDataDto.From;
                            emailDataDto.Password =userLogin.EmailPassword;
                            emailDataDto.To = new List<string>
                            {                              
                                ticket.IdSubscriberNavigation.SendReportToEmail,
                            };
                            emailDataDto.CC = new List<string>
                            {
                                "despacho@del-risco.com",
                                "myepez@del-risco.com"
                            };
                        }
                    }
                    emailDataDto.EmailKey = ticket.IdSubscriberNavigation.Language == "E" ? "DRR_WORKFLOW_ESP_0027" : "DRR_WORKFLOW_ENG_0027";
                    emailDataDto.BeAuthenticated = true;
                    
                    emailDataDto.IsBodyHTML = true;
                    emailDataDto.Parameters.Add(ticket.IdSubscriberNavigation.Name);
                    emailDataDto.Parameters.Add(ticket.RequestedName);
                    emailDataDto.Parameters.Add(userLogin.IdEmployeeNavigation.FirstName + " " + userLogin.IdEmployeeNavigation.LastName);
                    emailDataDto.Parameters.Add(userLogin.IdEmployeeNavigation.Email);
                    emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                    _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));

                    //ADJUNTOS
                    //DESPACHO PDF
                    if (ticket.IdSubscriberNavigation.ReportInPdf != null && ticket.IdSubscriberNavigation.ReportInPdf == true)
                    {
                        byte[] fileArray = DownloadF8((int)ticket.Id, ticket.Language, "pdf").Result.Data.File;
                        var attachment = new AttachmentDto();
                        attachment.FileName = emailDataDto.Subject + ".pdf";
                        attachment.Content = Convert.ToBase64String(fileArray);
                        emailDataDto.Attachments.Add(attachment);

                        string path = await UploadDispatchReport(idTicket, emailDataDto.Subject, fileArray, ".pdf");
                        await context.TicketFiles.AddAsync(new TicketFile
                        {
                            IdTicket = idTicket,
                            Path = path,
                            Name = emailDataDto.Subject,
                            Extension = ".pdf"
                        });
                    }
                    //DESPACHO word
                    if (ticket.IdSubscriberNavigation.ReportInWord != null && ticket.IdSubscriberNavigation.ReportInWord == true)
                    {
                        byte[] fileArrayWord = DownloadF8((int)ticket.Id, ticket.Language, "word").Result.Data.File;
                        
                        var attachmentWord = new AttachmentDto();
                        attachmentWord.FileName = emailDataDto.Subject + ".docx";
                        attachmentWord.Content = Convert.ToBase64String(fileArrayWord);
                        emailDataDto.Attachments.Add(attachmentWord);

                        string pathWord = await UploadDispatchReport(idTicket, emailDataDto.Subject, fileArrayWord, ".docx");
                        await context.TicketFiles.AddAsync(new TicketFile
                        {
                            IdTicket = idTicket,
                            Path = pathWord,
                            Name = emailDataDto.Subject + ".docx",
                            Extension = ".docx"
                        });
                    }
                    //DESPACHO XML
                    if (ticket.IdSubscriberNavigation.ReportInXml != null && ticket.IdSubscriberNavigation.ReportInXml == true)
                    {
                        byte[] fileArrayXml = _xmlApplication.GetXmlAtradiusAsync(idTicket).Result.Data.File;
                        var attachmentXml = new AttachmentDto();
                        attachmentXml.FileName = emailDataDto.Subject + ".xml";
                        attachmentXml.Content = Convert.ToBase64String(fileArrayXml);
                        emailDataDto.Attachments.Add(attachmentXml);

                        string pathXml = await UploadDispatchReport(idTicket, emailDataDto.Subject, fileArrayXml, ".xml");
                        await context.TicketFiles.AddAsync(new TicketFile
                        {
                            IdTicket = idTicket,
                            Path = pathXml,
                            Name = emailDataDto.Subject + ".xml",
                            Extension = ".xml"
                        });
                    }
                    //DESPACHO XML CREDENDO
                    if (ticket.IdSubscriberNavigation.ReportInXmlCredendo != null && ticket.IdSubscriberNavigation.ReportInXmlCredendo == true)
                    {
                        byte[] fileArrayXmlCred = _xmlApplication.GetXmlCredendoAsync(idTicket).Result.Data.File;
                        var attachmentXmlCred = new AttachmentDto();
                        attachmentXmlCred.FileName = emailDataDto.Subject + "_Credendo.xml";
                        attachmentXmlCred.Content = Convert.ToBase64String(fileArrayXmlCred);
                        emailDataDto.Attachments.Add(attachmentXmlCred);

                        string pathXmlCred = await UploadDispatchReport(idTicket, emailDataDto.Subject+ "_Credendo", fileArrayXmlCred, ".xml");
                        await context.TicketFiles.AddAsync(new TicketFile
                        {
                            IdTicket = idTicket,
                            Path = pathXmlCred,
                            Name = emailDataDto.Subject + "_Credendo.xml",
                            Extension = ".xml"
                        });
                    }
                    //DESPACHO EXCEL KSURE
                    if (ticket.IdSubscriberNavigation.ReportInExcel != null && ticket.IdSubscriberNavigation.ReportInExcel == true)
                    {
                        byte[] fileArrayExcel = GetExcel(idTicket).Result.Data.File;
                        var attachmentExcel = new AttachmentDto();
                        attachmentExcel.FileName = emailDataDto.Subject + ".xlsx";
                        attachmentExcel.Content = Convert.ToBase64String(fileArrayExcel);
                        emailDataDto.Attachments.Add(attachmentExcel);

                        string pathXmlCred = await UploadDispatchReport(idTicket, emailDataDto.Subject, fileArrayExcel, ".xlsx");
                        await context.TicketFiles.AddAsync(new TicketFile
                        {
                            IdTicket = idTicket,
                            Path = pathXmlCred,
                            Name = emailDataDto.Subject + ".xlsx",
                            Extension = ".xlsx"
                        });
                    }
                    if (idTicketFiles.Count > 0)
                    {
                        var directoryPath = System.IO.Path.Combine(_path.Path, "cupones", ticket.Number.ToString("D6"));
                        var memoryStream = new MemoryStream();

                        using (var archive = ZipArchive.Create())
                        {
                            var filesToAdd = new List<string>();

                            foreach (var idTicketFile in idTicketFiles)
                            {
                                var ticketFile = await context.TicketFiles
                                    .Where(x => x.Id == idTicketFile)
                                    .FirstOrDefaultAsync();

                                if (File.Exists(ticketFile.Path))
                                {
                                    filesToAdd.Add(ticketFile.Path);
                                }
                            }

                            foreach (var filePath in filesToAdd)
                            {
                                var fileName = System.IO.Path.GetFileName(filePath);
                                archive.AddEntry(fileName, filePath);
                            }

                            archive.SaveTo(memoryStream, new WriterOptions(CompressionType.Deflate)
                            {
                                LeaveStreamOpen = true
                            });
                        }

                        var documentDto = new GetFileDto
                        {
                            File = memoryStream,
                            ContentType = GetContentType(".zip"),
                            FileName = ticket.Number.ToString("D6") + ".zip" 
                        };

                        byte[] fileBytes;
                        documentDto.File.CopyTo(memoryStream);
                        fileBytes = memoryStream.ToArray();
                     

                        memoryStream.Position = 0;

                        var attachmentsSelected= new AttachmentDto();
                        attachmentsSelected.FileName = documentDto.FileName;
                        attachmentsSelected.Content = Convert.ToBase64String(fileBytes);
                        emailDataDto.Attachments.Add(attachmentsSelected);
                    }

                    if(ticket.About == "E")
                    {
                        ticket.IdCompanyNavigation.LastSearched = DateTime.Now;
                    }
                    else
                    {

                        ticket.IdPersonNavigation.LastSearched = DateTime.Now;
                    }


                    ticket.IdStatusTicket = (int?)TicketStatusEnum.Despachado;
                    ticket.DispatchtDate = DateTime.Now;
                    ticket.DispatchedName = ticket.About=="E"?ticket.IdCompanyNavigation.Name:ticket.IdPersonNavigation.Fullname;
                    context.Tickets.Update(ticket);

                    if (ticket.IdSubscriberNavigation.FacturationType == "CC")
                    {
                        var couponBilling = await context.CouponBillingSubscribers.Where(x => x.IdSubscriber == ticket.IdSubscriber).FirstOrDefaultAsync();
                        var couponBillingHistory = new CouponBillingSubscriberHistory();
                        couponBillingHistory.PurchaseDate = DateTime.Now;
                        couponBillingHistory.Type = "E";
                        var lastHistory = await context.CouponBillingSubscriberHistories.Where(x => x.IdCouponBilling == couponBilling.Id).FirstOrDefaultAsync();
                        if (lastHistory == null)
                        {
                            throw new Exception("El abonado no tiene historial de cupon. Por favor contactar con Sistemas.");
                        }
                        decimal? decimalDiscount = couponBilling.PriceT1;

                        switch (ticket.ProcedureType)
                        {
                            case "T2":
                                decimalDiscount = couponBilling.PriceT2;
                                break;
                            case "T3":
                                decimalDiscount = couponBilling.PriceT3;
                                break;
                            default:
                                decimalDiscount = couponBilling.PriceT1;
                                break;
                        }
                        couponBilling.NumCoupon = couponBilling.NumCoupon - decimalDiscount;
                        //Ese cuponAmount hay q convertir en decimal 
                        //continua
                        couponBillingHistory.CouponAmount = decimalDiscount;
                        couponBillingHistory.CouponUnitPrice = lastHistory.CouponUnitPrice;
                        couponBillingHistory.TotalPrice = couponBillingHistory.CouponAmount * couponBillingHistory.CouponUnitPrice;
                        couponBillingHistory.IdTicket = ticket.Id;
                        couponBilling.CouponBillingSubscriberHistories.Add(couponBillingHistory);

                        context.CouponBillingSubscribers.Update(couponBilling);
                    }

                  
                    var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                    var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                    emailHistory.Success = result;
                    response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
                      await context.SaveChangesAsync();
                    _logger.LogInformation(Messages.MailSuccessSend);
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
        private async Task<string> UploadFileToTicket(int idTicket, string fileName, byte[] byteArray)
        {
            try
            {
                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                var ticketPath = _path.Path;
                var directoryPath = System.IO.Path.Combine(ticketPath, "cupones", ticket.Number.ToString("D6"));
                var filePath = System.IO.Path.Combine(directoryPath, fileName);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                await File.WriteAllBytesAsync(filePath, byteArray);

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Messages.ExceptionMessage, ex.Message));
            }
        }



        public async Task<Response<GetFileResponseDto>> DownloadAssignAgent(int idTicket, string assignedTo, string startDate, string endDate, int number, string observations)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                
                if (ticket != null)
                {
                    string fileFormat = "{0}_{1}{2}";
                    string report = "SOLICITUD_INFORME_AGENTE";
                    var reportRenderType = StaticFunctions.GetReportRenderType("pdf");
                    var extension = StaticFunctions.FileExtension(reportRenderType);
                    var contentType = StaticFunctions.GetContentType(reportRenderType);
                    var dictionary = new Dictionary<string, string>
                        {
                            { "idTicket", ticket.Id.ToString() },
                            { "codeAgent", assignedTo },
                            { "startDate", startDate },
                            { "endDate", endDate },
                            { "number", number.ToString() },
                            { "observations", observations },
                         };
                    response.Data = new GetFileResponseDto
                    {
                        File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                        ContentType = contentType,
                        Name = "PED_AGE_" + number
                    };
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadListProviders(string about, int id)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                string fileFormat = "{0}_{1}{2}";
                string report = "LISTA_PROVEEDORES";
                var reportRenderType = StaticFunctions.GetReportRenderType("excel");
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);
                var dictionary = new Dictionary<string, string>
                {
                            { "id", id.ToString()},
                            { "about", about.Trim() },
                 };
                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = "LISTA_PROVEEDORES"
                };
            }
            catch(Exception ex)
            {

            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadAssignReporter(int idTicket, string assignedTo, string startDate, string endDate, int number, string observations)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();

                if (ticket != null)
                {
                    string fileFormat = "{0}_{1}{2}";
                    string report = "SOLICITUD_INFORME_REPORTERO";
                    var reportRenderType = StaticFunctions.GetReportRenderType("pdf");
                    var extension = StaticFunctions.FileExtension(reportRenderType);
                    var contentType = StaticFunctions.GetContentType(reportRenderType);
                    var dictionary = new Dictionary<string, string>
                        {
                            { "idTicket", ticket.Id.ToString() },
                            { "codeReporter", assignedTo.Trim() },
                            { "startDate", startDate },
                            { "endDate", endDate },
                            { "number", number.ToString() },
                            { "observations", observations == "" ? " " : observations },
                         };
                    response.Data = new GetFileResponseDto
                    {
                        File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                        ContentType = contentType,
                        Name = "PED_REP_" + number
                    };
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
        public string? GetReportName(string language, string about, string format)
        {
            string result = "";
            if (language == "I")
            {
                if(about == "E")
                {
                    switch (format.ToLower())
                    {
                        case "pdf": result = "EMPRESAS/F8-EMPRESAS-EN"; break;
                        case "word": result = "EMPRESAS/F8-EMPRESAS-WORD-EN"; break;
                    }
                }
                else
                {
                    switch (format.ToLower())
                    {
                        case "pdf": result = "PERSONAS/F8-PERSONAS-EN"; break;
                        case "word": result = "PERSONAS/F8-PERSONAS-WORD-EN"; break;
                    }
                }
            }
            else
            {
                if (about == "E")
                {
                    switch (format.ToLower())
                    {
                        case "pdf": result = "EMPRESAS/F8-EMPRESAS-ES"; break;
                        case "word": result = "EMPRESAS/F8-EMPRESAS-WORD-ES"; break;
                    }
                }
                else
                {
                    switch (format.ToLower())
                    {
                        case "pdf": result = "PERSONAS/F8-PERSONAS-ES"; break;
                        case "word": result = "PERSONAS/F8-PERSONAS-WORD-ES"; break;
                    }
                }
            }
            return result;
        }

        public async Task<Response<GetFileResponseDto>> GetExcel(int idTicket)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.IdLegalPersonTypeNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.IdLegalRegisterSituationNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.IdPaymentPolicyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.CompanyBackgrounds)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.CompanyBackgrounds).ThenInclude(x => x.CurrentPaidCapitalCurrencyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.CompanyBranches).ThenInclude(x => x.IdBranchSectorNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.CompanyBranches).ThenInclude(x => x.IdBusinessBranchNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.FinancialBalances)
                    .FirstOrDefaultAsync();
                if (ticket != null)
                {
                    var directoryPath = System.IO.Path.Combine(_path.Path, "cupones", ticket.Number.ToString("D6")); // => "C:\\Debug_EIECORE\\cupones\\000162"
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    var filePath = System.IO.Path.Combine(directoryPath, ticket.IdCompanyNavigation.Name + ".xlsx");
                    using var memoryStream = new MemoryStream();
                    using var sLDocument = new SLDocument();
                    

                        sLDocument.SetCellValue("A1", "FIELD_NM");
                        sLDocument.SetCellValue("B1", "DATA");

                        sLDocument.SetCellValue("A2", "KSURE_REFERENCE");
                        sLDocument.SetCellValue("B2", ticket.ReferenceNumber.PadLeft(10));

                        sLDocument.SetCellValue("A3", "TRGTPSN_NM");
                        sLDocument.SetCellValue("B3", ticket.IdCompanyNavigation.Name);

                        sLDocument.SetCellValue("A4", "TRGTPSN_ABBR_NM");
                        sLDocument.SetCellValue("B4", ticket.IdCompanyNavigation.SocialName ?? "");

                        sLDocument.SetCellValue("A5", "TRGTPSN_ENG_NM");
                        sLDocument.SetCellValue("B5", ticket.IdCompanyNavigation.Name);

                        sLDocument.SetCellValue("A6", "TRGTPSN_ENG_ABBR_NM");
                        sLDocument.SetCellValue("B6", ticket.IdCompanyNavigation.SocialName ?? "");

                        sLDocument.SetCellValue("A7", "TRGTPSN_TELNO");
                        sLDocument.SetCellValue("B7", ticket.IdCompanyNavigation.SubTelephone + " " + ticket.IdCompanyNavigation.Telephone);

                        sLDocument.SetCellValue("A8", "TRGTPSN_FAX_NO");
                        sLDocument.SetCellValue("B8", "-");

                        sLDocument.SetCellValue("A9", "EMAIL_ADDR");
                        sLDocument.SetCellValue("B9", ticket.IdCompanyNavigation.Email ?? "");

                        sLDocument.SetCellValue("A10", "HMPG_ADDR");
                        sLDocument.SetCellValue("B10", ticket.IdCompanyNavigation.WebPage ?? "");

                        sLDocument.SetCellValue("A11", "EXPR_PRVD_TELNO");
                        sLDocument.SetCellValue("B11", "");

                        sLDocument.SetCellValue("A12", "EXPR_PRVD_FAX_NO");
                        sLDocument.SetCellValue("B12", "");

                        sLDocument.SetCellValue("A13", "EXPR_PRVD_EMAIL_ADDR");
                        sLDocument.SetCellValue("B13", "");

                        sLDocument.SetCellValue("A14", "TRGTPSN_1_ADDR");
                        sLDocument.SetCellValue("B14", ticket.IdCompanyNavigation.Address ?? "");

                        sLDocument.SetCellValue("A15", "TRGTPSN_2_ADDR");
                        sLDocument.SetCellValue("B15", ticket.IdCompanyNavigation.TraductionCompanies.FirstOrDefault()?.TRotherLocals ?? "");

                        sLDocument.SetCellValue("A16", "RPRSNT_1_DSCRM_NO");
                        sLDocument.SetCellValue("B16", "");

                        sLDocument.SetCellValue("A17", "RPRSNT_1_NM");
                        sLDocument.SetCellValue("B17", "");

                        sLDocument.SetCellValue("A18", "RPRSNT_1_DTL_CTNT");
                        sLDocument.SetCellValue("B18", "");

                        sLDocument.SetCellValue("A19", "RPRSNT_2_DSCRM_NO");
                        sLDocument.SetCellValue("B19", "");

                        sLDocument.SetCellValue("A20", "RPRSNT_2_NM");
                        sLDocument.SetCellValue("B20", "");

                        sLDocument.SetCellValue("A21", "RPRSNT_2_DTL_CTNT");
                        sLDocument.SetCellValue("B21", "");

                        sLDocument.SetCellValue("A22", "TRGTPSN_1_EMP_CNT");
                        sLDocument.SetCellValue("B22", ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault()?.WorkerNumber.ToString() ?? "");

                        sLDocument.SetCellValue("A23", "BIZTYP_1_NO");
                        sLDocument.SetCellValue("B23", ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault()?.IdBranchSectorNavigation.OldCode ?? "");

                        sLDocument.SetCellValue("A24", "BIZTYP_1_EXPL_CTNT");
                        sLDocument.SetCellValue("B24", ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault()?.IdBranchSectorNavigation.EnglishName ?? "");

                        sLDocument.SetCellValue("A25", "BIZTYP_2_NO");
                        sLDocument.SetCellValue("B25", ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault()?.IdBusinessBranchNavigation.OldCode.ToString() ?? "");

                        sLDocument.SetCellValue("A26", "BIZTYP_2_EXPL_CTNT");
                        sLDocument.SetCellValue("B26", ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault()?.IdBusinessBranchNavigation.EnglishName ?? "");

                        sLDocument.SetCellValue("A27", "RMK_CTNT");
                        sLDocument.SetCellValue("B27", "");

                        sLDocument.SetCellValue("A28", "STL_CND_CTNT");
                        sLDocument.SetCellValue("B28", "");

                        sLDocument.SetCellValue("A29", "ABRD_ENTPR_REG_NO");
                        sLDocument.SetCellValue("B29", ticket.IdCompanyNavigation.CompanyBackgrounds.FirstOrDefault().PublicRegister ?? ""); //ticket.IdCompanyNavigation.TraductionCompanies.FirstOrDefault()?.TBpublicRegis ?? ""

                        sLDocument.SetCellValue("A30", "TAXPAY_NO");
                        sLDocument.SetCellValue("B30", ticket.IdCompanyNavigation.TaxTypeCode ?? "");

                        sLDocument.SetCellValue("A31", "OVRS_CRD_RSRCH_ORG_ENTPR_NO");
                        sLDocument.SetCellValue("B31", "");

                        sLDocument.SetCellValue("A32", "FUND_DD");
                        sLDocument.SetCellValue("B32", ticket.IdCompanyNavigation.CompanyBackgrounds.FirstOrDefault()?.ConstitutionDate ?? "");

                        sLDocument.SetCellValue("A33", "PROD_1_NM");
                        sLDocument.SetCellValue("B33", "");

                        sLDocument.SetCellValue("A34", "PROD_2_NM");
                        sLDocument.SetCellValue("B34", "");

                        sLDocument.SetCellValue("A35", "PROD_3_NM");
                        sLDocument.SetCellValue("B35", "");

                        sLDocument.SetCellValue("A36", "KOREAN_PRINCIPAL_YN");
                        sLDocument.SetCellValue("B36", "");

                        sLDocument.SetCellValue("A37", "STATUS");
                        sLDocument.SetCellValue("B37", ticket.IdCompanyNavigation?.IdLegalRegisterSituationNavigation?.EnglishName ?? "");

                        sLDocument.SetCellValue("A38", "BRANCH_YN");
                        sLDocument.SetCellValue("B38", "");

                        sLDocument.SetCellValue("A39", "EST_FS_YN");
                        sLDocument.SetCellValue("B39", "");

                        sLDocument.SetCellValue("A40", "LSTD_ENTPR_YN");
                        sLDocument.SetCellValue("B40", ticket.IdCompanyNavigation.CompanyBackgrounds.FirstOrDefault()?.Traded != null && ticket.IdCompanyNavigation.CompanyBackgrounds.FirstOrDefault()?.Traded == "Si" ? "Y" : "N");

                        sLDocument.SetCellValue("A41", "STLACC_YYMM");
                        sLDocument.SetCellValue("B41", "");

                        sLDocument.SetCellValue("A42", "RSRCH_ORG_GRD_NM");
                        sLDocument.SetCellValue("B42", "");

                        sLDocument.SetCellValue("A43", "PUBENTPR_YN");
                        sLDocument.SetCellValue("B43", "");

                        sLDocument.SetCellValue("A44", "INTRNT_ORG_YN");
                        sLDocument.SetCellValue("B44", "");

                        sLDocument.SetCellValue("A45", "STL_STAT_SPEC_CTNT");
                        sLDocument.SetCellValue("B45", ticket.IdCompanyNavigation.IdPaymentPolicyNavigation?.EnglishName ?? "");

                        string data = "";
                        int i = 1;
                        var companyRelations = await context.CompanyRelations
                            .Include(x => x.IdCompanyRelationNavigation).ThenInclude(x => x.IdCountryNavigation)
                            .Where(x => x.IdCompany == ticket.IdCompany)
                            .OrderBy(x => x.IdCompanyRelationNavigation.Name)
                            .ToListAsync();
                        var companyShareholder = await context.CompanyShareHolders
                            .Include(x => x.IdCompanyShareHolderNavigation).ThenInclude(x => x.IdCountryNavigation)
                            .Where(x => x.IdCompany == ticket.IdCompany)
                            .OrderBy(x => x.IdCompanyShareHolderNavigation.Name)
                            .ToListAsync();
                        foreach (var cr in companyRelations)
                        {
                        var countryRelation = cr.IdCompanyRelationNavigation.IdCountryNavigation == null ? string.Empty : cr.IdCompanyRelationNavigation.IdCountryNavigation.Name;
                            data = data + i + ". " + cr.IdCompanyRelationNavigation.Name + " (" + countryRelation + " / " + cr.IdCompanyRelationNavigation.TaxTypeCode + " / " + cr.RelationEng + " )   ";
                            i++;
                        }
                        foreach (var cs in companyShareholder)
                        {
                            data = data + i + ". " + cs.IdCompanyShareHolderNavigation.Name + " (" + cs.IdCompanyShareHolderNavigation.IdCountryNavigation.Name + " / " + cs.IdCompanyShareHolderNavigation.TaxTypeCode + " / " + cs.RelationEng + " )   ";
                            i++;
                        }

                        sLDocument.SetCellValue("A46", "RSRCH_ORG_GRD_NM");
                        sLDocument.SetCellValue("B46", data);
                        sLDocument.SetCellValue("A47", "DAL_BANK_NM");
                        sLDocument.SetCellValue("B47", "");
                        sLDocument.SetCellValue("A48", "PCLR_MTR_CTNT");
                        sLDocument.SetCellValue("B48", ticket.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFanalistCom ?? "");

                        sLDocument.SetCellValue("A49", "ENTRST_NO");
                        sLDocument.SetCellValue("B49", "");
                        string dataPartners = "";
                        i = 1;
                        var partners = await context.CompanyPartners
                            .Where(x => x.IdCompany == ticket.IdCompany && x.Enable == true)
                            .Include(x => x.IdPersonNavigation).ThenInclude(x => x.TraductionPeople)
                            .ToListAsync();
                        foreach (var partner in partners)
                        {
                            dataPartners = dataPartners + i + ". " + partner.IdPersonNavigation.Fullname + " ( " + partner.ProfessionEng + " / " + partner.IdPersonNavigation.TraductionPeople.FirstOrDefault().TPnacionality + " )       ";
                            i++;
                        }
                        sLDocument.SetCellValue("A50", "SHR_STCKHLDR_NM");
                        sLDocument.SetCellValue("B50", dataPartners);

                        string dataImports = "";
                        var imports = await context.ImportsAndExports.Where(x => x.IdCompany == ticket.IdCompany && x.Type == "I" && x.Enable == true).ToListAsync();
                        foreach (var import in imports)
                        {
                            if (dataImports == "")
                            {
                                if (ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault().CountriesImportEng.IsNullOrEmpty() == false)
                                {
                                    dataImports = ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault().CountriesImportEng + " | " + import.Year + " US$ FOB " + import.Amount;
                                }
                                else
                                {
                                    dataImports = import.Year + " US$ FOB " + import.Amount;
                                }
                            }
                            else
                            {
                                dataImports = dataImports + " | " + import.Year + " US$ FOB " + import.Amount;
                            }
                        }

                        string dataExports = "";
                        var exports = await context.ImportsAndExports.Where(x => x.IdCompany == ticket.IdCompany && x.Type == "E" && x.Enable == true).ToListAsync();
                        foreach (var export in exports)
                        {
                            if (dataExports == "")
                            {
                                if (ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault().CountriesExportEng.IsNullOrEmpty() == false)
                                {
                                    dataExports = ticket.IdCompanyNavigation.CompanyBranches.FirstOrDefault().CountriesExportEng + " | " + export.Year + " US$ FOB " + export.Amount;
                                }
                                else
                                {
                                    dataExports = export.Year + " US$ FOB " + export.Amount;
                                }
                            }
                            else
                            {
                                dataExports = dataExports + " | " + export.Year + " US$ FOB " + export.Amount;
                            }
                        }
                        string dataImportsAndExports = "";
                        if (imports.Count > 0)
                        {
                            dataImportsAndExports = "Import : " + dataImports;
                            if (exports.Count > 0)
                            {
                                dataImportsAndExports = " / Export : " + dataExports;
                            }
                        }
                        if (exports.Count > 0)
                        {
                            dataImportsAndExports = "Export : " + dataExports;
                        }

                        sLDocument.SetCellValue("A51", "IMPEXP_DAL_CTNT");
                        sLDocument.SetCellValue("B51", dataImportsAndExports);
                        sLDocument.SetCellValue("A52", "LCL_RPUT_CTNT");
                        sLDocument.SetCellValue("B52", ticket.IdCompanyNavigation?.TraductionCompanies?.FirstOrDefault().TEnew ?? "");

                        sLDocument.SetCellValue("A53", "SKIL_ITM_CTNT");
                        sLDocument.SetCellValue("B53", "");
                        sLDocument.SetCellValue("A54", "INTVW_CNNT");
                        sLDocument.SetCellValue("B54", ticket.IdCompanyNavigation?.TraductionCompanies?.FirstOrDefault().TFcomment ?? "");
                        sLDocument.SetCellValue("A55", "FUND_HIST_CTNT");
                        sLDocument.SetCellValue("B55", ticket.IdCompanyNavigation?.TraductionCompanies?.FirstOrDefault().TBlegalBack ?? "");
                        sLDocument.SetCellValue("A56", "PBLC_INFO_CTNT");
                        sLDocument.SetCellValue("B56", ticket.IdCompanyNavigation?.TraductionCompanies?.FirstOrDefault().TSlitig ?? "");

                        var balance = await context.FinancialBalances
                            .Where(x => x.IdCompany == ticket.IdCompany && x.BalanceType == "GENERAL" && x.Enable == true)
                            .Include(x => x.IdCurrencyNavigation)
                            .OrderByDescending(x => x.Date).Take(2)
                            .ToListAsync();
                        if (balance != null && balance.Count>0)
                        {
                            sLDocument.SetCellValue("A57", "CURR_NM");
                            sLDocument.SetCellValue("B57", balance[0].IdCurrencyNavigation.Abreviation);
                            sLDocument.SetCellValue("A58", "AL_AST_AMT");
                            sLDocument.SetCellValue("B58", balance[0].TotalAssets ?? 0);
                            sLDocument.SetCellValue("A59", "AL_LIAB_AMT");
                            sLDocument.SetCellValue("B59", balance[0].TotalLliabilities ?? 0);
                            sLDocument.SetCellValue("A60", "AL_LIAB_CPT_AMT");
                            sLDocument.SetCellValue("B60", balance[0].TotalLiabilitiesPatrimony ?? 0);
                            sLDocument.SetCellValue("A61", "BS_BASE_YYMM");
                            sLDocument.SetCellValue("B61", balance[0].Date.Value.ToString("yyyyMM"));
                            sLDocument.SetCellValue("A62", "PAYCPT_AMT_CURR_NM");
                            sLDocument.SetCellValue("B62", balance[0].IdCurrencyNavigation.Abreviation);

                            //string currentCapital = (ticket.IdCompanyNavigation?.CompanyBackgrounds?.FirstOrDefault().CurrentPaidCapitalCurrencyNavigation?.Abreviation ?? "" )+
                            //    " | " + ticket.IdCompanyNavigation?.CompanyBackgrounds?.FirstOrDefault().CurrentPaidCapital + " | " + (ticket.IdCompanyNavigation?.TraductionCompanies?.FirstOrDefault().TBpaidCapital ?? "");
                            string currentCapital = ticket.IdCompanyNavigation?.CompanyBackgrounds?.FirstOrDefault().CurrentPaidCapital.ToString();

                            sLDocument.SetCellValue("A63", "PAYCPT_AMT");
                            sLDocument.SetCellValue("B63", currentCapital);
                            sLDocument.SetCellValue("A64", "DFR_AST_AMT");
                            sLDocument.SetCellValue("B64", balance[0].AOtherCurrentAssets ?? 0);
                            sLDocument.SetCellValue("A65", "ETC_LIAB_AMT");
                            sLDocument.SetCellValue("B65", balance[0].LOtherCurrentLiabilities ?? 0);
                            sLDocument.SetCellValue("A66", "FIX_AST_AMT");
                            sLDocument.SetCellValue("B66", balance[0].AFixed ?? 0);
                            sLDocument.SetCellValue("A67", "FIX_LIAB_AMT");
                            sLDocument.SetCellValue("B67", balance[0].LLongTerm ?? 0);
                            sLDocument.SetCellValue("A68", "INVNT_AST_AMT");
                            sLDocument.SetCellValue("B68", balance[0].AInventory ?? 0);
                            sLDocument.SetCellValue("A69", "INVST_ETC_AST_AMT");
                            sLDocument.SetCellValue("B69", "");
                            sLDocument.SetCellValue("A70", "LQID_AST_AMT");
                            sLDocument.SetCellValue("B70", balance[0].TotalCurrentAssets ?? 0);
                            sLDocument.SetCellValue("A71", "LQID_LIAB_AMT");
                            sLDocument.SetCellValue("B71", balance[0].TotalCurrentLiabilities ?? 0);
                            sLDocument.SetCellValue("A72", "NET_PRFT_AMT");
                            sLDocument.SetCellValue("B72", balance[0].Utilities ?? 0);
                            sLDocument.SetCellValue("A73", "NETAST_AMT");
                            sLDocument.SetCellValue("B73", (balance[0].PCapital ?? 0) + (balance[0].PStockPile ?? 0) + (balance[0].PUtilities ?? 0) + (balance[0].POther ?? 0));
                            sLDocument.SetCellValue("A74", "PRFLOS_BIL_BASE_YYMM");
                            sLDocument.SetCellValue("B74", balance[0].Date.Value.ToString("yyyyMM"));
                            sLDocument.SetCellValue("A75", "PRFT_SRPLS_AMT");
                            sLDocument.SetCellValue("B75", balance[0].POther ?? 0);
                            sLDocument.SetCellValue("A76", "PRVYY_AL_AST_AMT");
                            sLDocument.SetCellValue("B76", balance[0].TotalAssets ?? 0);
                            sLDocument.SetCellValue("A77", "PRVYY_BS_BASE_YYMM");
                            sLDocument.SetCellValue("B77", balance[0].Date.Value.ToString("yyyyMM"));
                            sLDocument.SetCellValue("A78", "PRVYY_NET_PRFT_AMT");
                            sLDocument.SetCellValue("B78", balance[0].Utilities ?? 0);
                            sLDocument.SetCellValue("A79", "PRVYY_PRFLOS_BIL_BASE_YYMM");
                            sLDocument.SetCellValue("B79", balance[0].Date.Value.ToString("yyyyMM"));
                            sLDocument.SetCellValue("A80", "PRVYY_SALE_AMT");
                            sLDocument.SetCellValue("B80", balance[0].Sales ?? 0);
                            sLDocument.SetCellValue("A81", "SALE_AMT");
                            sLDocument.SetCellValue("B81", balance[0].Sales ?? 0);
                        }
                        else
                        {
                            sLDocument.SetCellValue("A57", "CURR_NM");
                            sLDocument.SetCellValue("B57", "");
                            sLDocument.SetCellValue("A58", "AL_AST_AMT");
                            sLDocument.SetCellValue("B58", "");
                            sLDocument.SetCellValue("A59", "AL_LIAB_AMT");
                            sLDocument.SetCellValue("B59", "");
                            sLDocument.SetCellValue("A60", "AL_LIAB_CPT_AMT");
                            sLDocument.SetCellValue("B60", "");
                            sLDocument.SetCellValue("A61", "BS_BASE_YYMM");
                            sLDocument.SetCellValue("B61", "");
                            sLDocument.SetCellValue("A62", "PAYCPT_AMT_CURR_NM");
                            sLDocument.SetCellValue("B62", "");
                            sLDocument.SetCellValue("A63", "PAYCPT_AMT");
                            sLDocument.SetCellValue("B63", "");
                            sLDocument.SetCellValue("A64", "DFR_AST_AMT");
                            sLDocument.SetCellValue("B64", "");
                            sLDocument.SetCellValue("A65", "ETC_LIAB_AMT");
                            sLDocument.SetCellValue("B65", "");
                            sLDocument.SetCellValue("A66", "FIX_AST_AMT");
                            sLDocument.SetCellValue("B66", "");
                            sLDocument.SetCellValue("A67", "FIX_LIAB_AMT");
                            sLDocument.SetCellValue("B67", "");
                            sLDocument.SetCellValue("A68", "INVNT_AST_AMT");
                            sLDocument.SetCellValue("B68", "");
                            sLDocument.SetCellValue("A69", "INVST_ETC_AST_AMT");
                            sLDocument.SetCellValue("B69", "");
                            sLDocument.SetCellValue("A70", "LQID_AST_AMT");
                            sLDocument.SetCellValue("B70", "");
                            sLDocument.SetCellValue("A71", "LQID_LIAB_AMT");
                            sLDocument.SetCellValue("B71", "");
                            sLDocument.SetCellValue("A72", "NET_PRFT_AMT");
                            sLDocument.SetCellValue("B72", "");
                            sLDocument.SetCellValue("A73", "NETAST_AMT");
                            sLDocument.SetCellValue("B73", "");
                            sLDocument.SetCellValue("A74", "PRFLOS_BIL_BASE_YYMM");
                            sLDocument.SetCellValue("B74", "");
                            sLDocument.SetCellValue("A75", "PRFT_SRPLS_AMT");
                            sLDocument.SetCellValue("B75", "");
                            sLDocument.SetCellValue("A76", "PRVYY_AL_AST_AMT");
                            sLDocument.SetCellValue("B76", "");
                            sLDocument.SetCellValue("A77", "PRVYY_BS_BASE_YYMM");
                            sLDocument.SetCellValue("B77", "");
                            sLDocument.SetCellValue("A78", "PRVYY_NET_PRFT_AMT");
                            sLDocument.SetCellValue("B78", "");
                            sLDocument.SetCellValue("A79", "PRVYY_PRFLOS_BIL_BASE_YYMM");
                            sLDocument.SetCellValue("B79", "");
                            sLDocument.SetCellValue("A80", "PRVYY_SALE_AMT");
                            sLDocument.SetCellValue("B80", "");
                            sLDocument.SetCellValue("A81", "SALE_AMT");
                            sLDocument.SetCellValue("B81", "");
                        }
                        sLDocument.SetColumnWidth(1, 30);
                        sLDocument.SetColumnWidth(2, 150);

                        SLStyle style = new SLStyle();
                        style.Alignment.Horizontal = DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left;

                        sLDocument.SetColumnStyle(2, style);
                    memoryStream.Position = 0;
                        sLDocument.SaveAs(memoryStream);

                    byte[] fileBytes = memoryStream.ToArray();
                    response.Data = new GetFileResponseDto
                    {
                        Name = $"{ticket.IdCompanyNavigation.Name}.xlsx",
                        File = fileBytes,
                        ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    };
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

        public async Task<Response<GetFileResponseDto>> DownloadF8(int idTicket, string language, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets
                    .Where(x => x.Id == idTicket)
                    .Include(x => x.IdCompanyNavigation)
                    .Include(x => x.IdPersonNavigation)
                    .FirstOrDefaultAsync();
                if (ticket != null)
                {
                    if(ticket.About == "E")
                    {
                        var company = await _companyDomain.GetByIdAsync((int)ticket.IdCompany);

                        string companyCode = company.OldCode ?? "N" + company.Id.ToString("D6");
                        string languageFileName = language == "I" ? "ENG" : "ESP";
                        string fileFormat = "{0}_{1}{2}";
                        string report = GetReportName(language, ticket.About, format);
                        var reportRenderType = StaticFunctions.GetReportRenderType(format);
                        var extension = StaticFunctions.FileExtension(reportRenderType);
                        var contentType = StaticFunctions.GetContentType(reportRenderType);

                        var dictionary = new Dictionary<string, string>
                        {
                            { "idCompany", ticket.IdCompany.ToString() },
                            { "idTicket", ticket.Id.ToString() },
                            { "language", language },
                         };

                        response.Data = new GetFileResponseDto
                        {
                            File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                            ContentType = contentType,
                            Name = string.Format(fileFormat, companyCode, languageFileName, extension)
                        };
                    }
                    else
                    {
                        var person = await context.People.Where(x => x.Id == ticket.IdPerson).FirstOrDefaultAsync();
                        string personCode = person.OldCode ?? "N" + person.Id.ToString("D6");
                        string languageFileName = language == "I" ? "ENG" : "ESP";
                        string fileFormat = "{0}_{1}{2}";
                        string report = GetReportName(language, ticket.About, format);
                        var reportRenderType = StaticFunctions.GetReportRenderType(format);
                        var extension = StaticFunctions.FileExtension(reportRenderType);
                        var contentType = StaticFunctions.GetContentType(reportRenderType);

                        var dictionary = new Dictionary<string, string>
                        {
                            { "idPerson", ticket.IdPerson.ToString() },
                            { "idTicket", ticket.Id.ToString() },
                            { "language", language },
                         };

                        response.Data = new GetFileResponseDto
                        {
                            File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                            ContentType = contentType,
                            Name = string.Format(fileFormat, personCode, languageFileName, extension)
                        };
                    }
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

        public async Task<Response<bool>> DeleteTicketHistory(int idTicket, string? assignedTo, int? numberAssign, string? returnMessage)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories.Where(x => x.IdTicket == idTicket && x.AsignedTo == assignedTo && x.NumberAssign == numberAssign).FirstOrDefaultAsync();
                if(ticketHistory != null)
                {
                   
                    if (assignedTo.Contains("RC") == true || assignedTo.Contains("CR") == true)
                    {
                        context.TicketHistories.Remove(ticketHistory);
                        await context.SaveChangesAsync();
                        response.Data = true;
                    }
                    else
                    {
                        context.TicketHistories.Remove(ticketHistory);
                        var lastTicketHistory = await context.TicketHistories.Where(x => x.IdTicket == idTicket && x.IdStatusTicket != (int)TicketStatusEnum.Asig_Referencista && x.IdStatusTicket != (int)TicketStatusEnum.Por_Referencia).OrderBy(x => x.CreationDate).ToListAsync();
                        var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                        if (lastTicketHistory != null && ticket != null)
                        {
                            lastTicketHistory.ElementAt(lastTicketHistory.Count - 2).Flag = false;
                            lastTicketHistory.ElementAt(lastTicketHistory.Count - 2).ReturnMessage = returnMessage;
                            lastTicketHistory.ElementAt(lastTicketHistory.Count - 2).ShippingDate = null;
                            context.TicketHistories.Update(lastTicketHistory.ElementAt(lastTicketHistory.Count - 2));
                            ticket.IdStatusTicket = lastTicketHistory.ElementAt(lastTicketHistory.Count - 2).IdStatusTicket;
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
                        var code = "CP_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Year;
                        var productionClosure = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                        if (productionClosure == null)
                        {

                            DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                            await context.ProductionClosures.AddAsync(new ProductionClosure
                            {
                                EndDate = lastDayOfCurrentMonth,
                                Code = code,
                                Title = "Cierre de Producción " + DateTime.Now.Month.ToString("D2") + " - " + DateTime.Now.Year,
                                Observations = ""
                            });
                        }
                        else
                        {
                            if (productionClosure.EndDate > DateTime.Now)
                            {
                                if (DateTime.Now.Month == 12)
                                {
                                    code = "CP_" + (1).ToString("D2") + "_" + (DateTime.Now.Year + 1);
                                    var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                                    if (nextProductionClosureExistent == null)
                                    {
                                        DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year + 1, 1, 1).AddMonths(1).AddDays(-1);
                                        await context.ProductionClosures.AddAsync(new ProductionClosure
                                        {
                                            EndDate = lastDayOfCurrentMonth,
                                            Code = code,
                                            Title = "Cierre de Producción " + (1).ToString("D2") + " - " + DateTime.Today.Year + 1,
                                            Observations = ""
                                        });
                                    }
                                }
                                else
                                {
                                    code = "CP_" + (DateTime.Now.Month + 1).ToString("D2") + "_" + DateTime.Now.Year;
                                    var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                                    if (nextProductionClosureExistent == null)
                                    {
                                        DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                                        await context.ProductionClosures.AddAsync(new ProductionClosure
                                        {
                                            EndDate = lastDayOfCurrentMonth,
                                            Code = code,
                                            Title = "Cierre de Producción " + (DateTime.Now.Month + 1).ToString("D2") + " - " + DateTime.Now.Year,
                                            Observations = ""
                                        });
                                    }

                                }

                            }
                        }

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
                                        StartDate = StaticFunctions.VerifyDate(obj.StartDate),
                                        EndDate = StaticFunctions.VerifyDate(obj.EndDate),
                                        Observations = obj.Observations,
                                        Balance = obj.Balance,
                                        AsignationType = obj.Type,
                                        Cycle = code
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
                                history.ShippingDate = DateTime.Today;
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
                                    AsignationType = obj.Type,
                                    Cycle = code
                                };
                                await context.TicketHistories.AddAsync(newTicketHistory);

                                await context.SaveChangesAsync();
                            }
                        }
                    }
                

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                response.Data = false;
                response.IsSuccess = false;
            }
            return response;
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
                        DetailsTicketObservations = details,
                    };
                    var ticket = await context.Tickets.Where(x => x.Id == obj.IdTicket).FirstOrDefaultAsync();
                    if (ticket != null)
                    {
                        ticket.IdStatusTicket = (int)TicketStatusEnum.En_Observacion;
                    }
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

        public async Task<Response<List<GetTicketHistoryResponseDto>>> getCountAsignation()
        {
            var response = new Response<List<GetTicketHistoryResponseDto>>();
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.TicketHistories.Include(x => x.IdTicketNavigation).Where(x => x.IdTicketNavigation.IdStatusTicket != 9 && x.Flag == false && x.AsignedTo != null).ToListAsync();
                response.Data = _mapper.Map<List<GetTicketHistoryResponseDto>>(list);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = null;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> TicketToDispatch(int idTicketHistory,int idTicket,string quality,string qualityTranslator,string qualityTypist, List<UserCode> otherUsers)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();

                var code = "CP_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Year;
                var productionClosure = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                if (productionClosure == null)
                {

                    DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                    await context.ProductionClosures.AddAsync(new Domain.Entities.SqlCoreContext.ProductionClosure
                    {
                        EndDate = lastDayOfCurrentMonth,
                        Code = code,
                        Title = "Cierre de Producción " + DateTime.Now.Month.ToString("D2") + " - " + DateTime.Now.Year,
                        Observations = ""
                    });
                }
                else
                {
                    if (productionClosure.EndDate < DateTime.Now)
                    {
                        if (DateTime.Now.Month == 12)
                        {
                            code = "CP_" + (1).ToString("D2") + "_" + (DateTime.Now.Year + 1);
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year + 1, 1, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = code,
                                    Title = "Cierre de Producción " + (1).ToString("D2") + " - " + DateTime.Today.Year + 1,
                                    Observations = ""
                                });
                            }
                        }
                        else
                        {
                            code = "CP_" + (DateTime.Now.Month + 1).ToString("D2") + "_" + DateTime.Now.Year;
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = code,
                                    Title = "Cierre de Producción " + (DateTime.Now.Month + 1).ToString("D2") + " - " + DateTime.Now.Year,
                                    Observations = ""
                                });
                            }
                        }
                    }
                }

                var ticket = await context.Tickets.Where(x => x.Id == idTicket).Include(x => x.TicketHistories).FirstOrDefaultAsync();
                if(ticket != null)
                {
                    ticket.IdStatusTicket = 18;
                    ticket.Quality =quality;
                    ticket.QualityTranslator = qualityTranslator;
                    ticket.QualityTypist = qualityTypist;

                    ticket.TicketHistories.Where(x => x.Id == idTicketHistory).FirstOrDefault().Flag = true;
                    ticket.TicketHistories.Where(x => x.Id == idTicketHistory).FirstOrDefault().ShippingDate = DateTime.Today;

                    foreach (var item in otherUsers.Where(x => x.Active == true).ToList())
                    {
                        var personal = await context.Personals.Where(x => x.Code == item.Code).Include(x => x.IdEmployeeNavigation).ThenInclude(x => x.UserLogins).FirstOrDefaultAsync();
                        ticket.TicketHistories.Add(new TicketHistory{
                            IdTicket =idTicket,
                            UserFrom = personal.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id + "",
                            UserTo = personal.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id + "",
                            AsignationType = item.Type,
                            AsignedTo = item.Code,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now,
                            ShippingDate = DateTime.Now,
                            FlagInvoice = false,
                            Flag = true,
                            Cycle = code,
                            IdStatusTicket = GetIdStatusTicket(item.Type)
                        });
                    }

                }
                context.Tickets.Update(ticket);
                await context.SaveChangesAsync();
                response.Data = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
        public int? GetIdStatusTicket(string type)
        {
            if(type == "AG")
            {
                return (int)TicketStatusEnum.Asig_Agente;
            }
            else if (type == "DI")
            {
                return (int)TicketStatusEnum.Asig_Digitidor;
            }
            else if (type == "PA")
            {
                return (int)TicketStatusEnum.Pre_Asignacion;
            }
            else if (type == "RF")
            {
                return (int)TicketStatusEnum.Asig_Referencista;
            }
            else if (type == "RP")
            {
                return (int)TicketStatusEnum.Asig_Reportero;
            }
            else if (type == "SU")
            {
                return (int)TicketStatusEnum.Asig_Supervisor;
            }
            else if (type == "TR")
            {
                return (int)TicketStatusEnum.Asig_Traductor;
            }
            else
            {
                return null;
            }
        }
        public async Task<Response<string>> GetSupervisorTicket(int idTicket)
        {
            var response = new Response<string>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories.Where(x => x.IdTicket == idTicket && x.AsignationType == "SU" && x.AsignedTo.Contains("S")).FirstOrDefaultAsync();
                if(ticketHistory != null)
                {
                    var user = await context.UserLogins.Where(x => x.Id == int.Parse(ticketHistory.UserTo)).Include(x => x.IdEmployeeNavigation).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        response.Data = ticketHistory.AsignedTo + " - " + user.IdEmployeeNavigation.FirstName + " " + user.IdEmployeeNavigation.LastName;
                    }
                }
            }catch  (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<string>> GetSupervisorCodeTicket(int idTicket)
        {
            var response = new Response<string>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories.Where(x => x.IdTicket == idTicket && x.AsignationType == "SU" && x.AsignedTo.Contains("S") && x.Flag == true ).FirstOrDefaultAsync();
                if (ticketHistory != null)
                {
                    var user = await context.UserLogins.Where(x => x.Id == int.Parse(ticketHistory.UserTo)).Include(x => x.IdEmployeeNavigation).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        response.Data = ticketHistory.AsignedTo;
                    }
                }
                else
                {
                    response.Data = "";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteTicketHistoryById(int idTicketHistory)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories.Where(x => x.Id == idTicketHistory).FirstOrDefaultAsync();
                if(ticketHistory != null)
                {
                    ticketHistory.Flag = true;
                    ticketHistory.ShippingDate = DateTime.Now;
                    ticketHistory.UpdateDate = DateTime.Now;
                    context.TicketHistories.Update(ticketHistory);
                    await context.SaveChangesAsync();
                }

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetShortProviderByTicket>>> GetProvidersHistoryByIdTicket(int idTicket)
        {
            var response = new Response<List<GetShortProviderByTicket>>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.FindAsync(idTicket);
                if (ticket != null)
                {
                    var providers = new List<Domain.Entities.SqlCoreContext.Provider>();
                    if (ticket.About == "E")
                    {
                        providers = await context.Providers
                            .Where(x => x.IdTicket == idTicket && x.IdCompany == ticket.IdCompany && x.Qualification == "Dió referencia")
                            .Include(x => x.IdCountryNavigation)
                            .ToListAsync();
                    }
                    else
                    {
                        providers = await context.Providers
                            .Where(x => x.IdTicket == idTicket && x.IdPerson == ticket.IdPerson && x.Qualification == "Dió referencia")
                            .Include(x => x.IdCountryNavigation)
                            .ToListAsync();
                    }
                    response.Data = _mapper.Map<List<GetShortProviderByTicket>>(providers.DistinctBy(x => x.Name));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = null;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<string>>> GetUsersInTicket(int idTicket)
        {
            var response = new Response<List<string>>();
            response.Data = new List<string>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistories = await context.TicketHistories
                    .Where(x => x.IdTicket == idTicket && x.AsignedTo != null && x.AsignedTo != "" && x.AsignedTo.Contains("CR") == false)
                    .ToListAsync();
                foreach(var item in ticketHistories)
                {
                    response.Data.Add(item.AsignedTo);
                }
            }catch(Exception ex)
            {

            }
            return response;
        }
        public async Task<Response<bool>> SendComplement(int idTicket, int idUser, bool digited, bool file, string observations, string asignedTo)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var cycle = "CP_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Year;
                var productionClosure = await context.ProductionClosures.Where(x => x.Code.Contains(cycle)).FirstOrDefaultAsync();
                if (productionClosure == null)
                {
                    DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                    await context.ProductionClosures.AddAsync(new ProductionClosure
                    {
                        EndDate = lastDayOfCurrentMonth,
                        Code = cycle,
                        Title = "Cierre de Producción " + DateTime.Now.Month.ToString("D2") + " - " + DateTime.Now.Year,
                        Observations = ""
                    });
                }
                else
                {
                    if (productionClosure.EndDate < DateTime.Now)
                    {
                        if (DateTime.Now.Month == 12)
                        {
                            cycle = "CP_" + (1).ToString("D2") + "_" + (DateTime.Now.Year + 1);
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(cycle)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year + 1, 1, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = cycle,
                                    Title = "Cierre de Producción " + (1).ToString("D2") + " - " + DateTime.Today.Year + 1,
                                    Observations = ""
                                });
                            }
                        }
                        else
                        {
                            cycle = "CP_" + (DateTime.Now.Month + 1).ToString("D2") + "_" + DateTime.Now.Year;
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(cycle)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, (DateTime.Today.Month + 1), 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = cycle,
                                    Title = "Cierre de Producción " + (DateTime.Now.Month + 1).ToString("D2") + " - " + DateTime.Now.Year,
                                    Observations = ""
                                });
                            }
                        }
                    }
                }
                var ticket = await context.Tickets.Where(x => x.Id == idTicket)
                    .Include(x => x.TicketFiles)
                    .FirstOrDefaultAsync();
                var user = await context.UserLogins.Where(x => x.Id == idUser)
                    .Include(x => x.IdEmployeeNavigation).ThenInclude(x => x.Personals)
                    .FirstOrDefaultAsync();
                var ticketHistory = await context.TicketHistories
                    .Where(x => x.IdTicket == idTicket && x.AsignationType == "SU" && x.AsignedTo.Contains("S"))
                    .FirstOrDefaultAsync();

                if (ticket == null || user == null || ticketHistory == null) 
                {
                    throw new Exception("Ticket, Usuario o Supervisor no encontrados");
                }
                var ticketFiles = new List<TicketFile>();
                foreach(var ticketFile in ticket.TicketFiles)
                {
                    ticketFile.IdTicket = null;
                    ticketFiles.Add(ticketFile);
                }
                var newTicket = new Ticket{ 
                    Number = ticket.Number,
                    IdSubscriber = ticket.IdSubscriber,
                    IdCompany = ticket.IdCompany,
                    IdPerson = ticket.IdPerson,
                    RevealName = ticket.RevealName,
                    NameRevealed = ticket.NameRevealed,
                    ReferenceNumber = ticket.ReferenceNumber,
                    Language = ticket.Language,
                    QueryCredit = ticket.QueryCredit,
                    TimeLimit = ticket.TimeLimit,
                    AditionalData = ticket.AditionalData,
                    About = ticket.About,
                    OrderDate = ticket.OrderDate,
                    ExpireDate = ticket.ExpireDate,
                    RealExpireDate = ticket.RealExpireDate,
                    Address = ticket.Address,
                    Price = ticket.Price,
                    City = ticket.City,
                    BusineesName = ticket.BusineesName,
                    ComercialName = ticket.ComercialName,
                    Email = ticket.Email,
                    IdContinent = ticket.IdContinent,
                    IdCountry = ticket.IdCountry,
                    IdStatusTicket = (int)TicketStatusEnum.Pre_Asignacion,
                    ProcedureType = ticket.ProcedureType,
                    ReportType = ticket.ReportType,
                    RequestedName = ticket.RequestedName,
                    SubscriberIndications = ticket.SubscriberIndications,
                    TaxCode = ticket.TaxCode,
                    TaxType = ticket.TaxType,
                    Telephone = ticket.Telephone,
                    WebPage = ticket.WebPage,
                    TicketFiles = ticketFiles,


                    IsComplement = true,
                    IdTicketComplement = ticket.Id,
                    NumberTicketComplement = ticket.Number.ToString("D6") + "*"
                };
                
                var ticketHistory1 = new TicketHistory { 
                    IdTicket = newTicket.Id,
                    UserFrom = user.Id.ToString(),
                    UserTo = user.Id.ToString(),
                    AsignedTo = asignedTo,
                    IdStatusTicket = (int)TicketStatusEnum.Pendiente,
                    ShippingDate = DateTime.Now,
                    Flag = true,
                    Cycle = cycle
                };
                var ticketHistory2 = new TicketHistory
                {
                    IdTicket = newTicket.Id,
                    UserFrom = user.Id.ToString(),
                    UserTo = ticketHistory.UserTo,
                    AsignedTo = ticketHistory.AsignedTo,
                    AsignationType = ticketHistory.AsignationType,
                    IdStatusTicket = (int)TicketStatusEnum.Asig_Supervisor,
                    ShippingDate = DateTime.Now,
                    Flag = false,
                    Observations = observations,
                    Cycle = "",
                    StartDate = DateTime.Now,
                };
                newTicket.TicketHistories.Add(ticketHistory1);
                newTicket.TicketHistories.Add(ticketHistory2);
                await context.Tickets.AddAsync(newTicket);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = false;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> SaveTicketCommentary(int idTicket, string commentary)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketAsssignations = await context.TicketAssignations.Where(x => x.IdTicket == idTicket).FirstOrDefaultAsync();
                if(ticketAsssignations == null)
                {
                    throw new Exception("No se encontro la asignación con el IdTicket : " + idTicket);
                }
                ticketAsssignations.Commentary = commentary;
                ticketAsssignations.UpdateDate = DateTime.Now;
                context.TicketAssignations.Update(ticketAsssignations);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadF8ByIdTicket(int idTicket, string language, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets
                    .Where(x => x.Id == idTicket)
                    .Include(x => x.IdCompanyNavigation)
                    .Include(x => x.IdPersonNavigation)
                    .FirstOrDefaultAsync();
                if(ticket != null)
                {
                    if(ticket.About == "E")
                    {
                        var company = await context.Companies.Where(x => x.Id == ticket.IdCompany).FirstOrDefaultAsync();

                        string companyCode = company.OldCode ?? "N" + company.Id.ToString("D6");
                        string languageFileName = language == "I" ? "ENG" : "ESP";
                        string fileFormat = "{0}_{1}{2}";
                        //string report = language == "I" ? "EMPRESAS/F8-EMPRESAS-EN" : "EMPRESAS/F8-EMPRESAS-ES";
                        string report = GetReportName(language, ticket.About, format);
                        var reportRenderType = StaticFunctions.GetReportRenderType(format);
                        var extension = StaticFunctions.FileExtension(reportRenderType);
                        var contentType = StaticFunctions.GetContentType(reportRenderType);

                        var dictionary = new Dictionary<string, string>
                        {
                            { "idCompany", ticket.IdCompany.ToString() },
                            { "idTicket", ticket.Id.ToString() },
                            { "language", language }
                         };

                        var file = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary);
                        response.Data = new GetFileResponseDto
                        {
                            File = file,
                            ContentType = contentType,
                            Name = string.Format(fileFormat, companyCode, languageFileName, extension)
                        };
                    }
                    else
                    {
                        var person = await context.People.Where(x => x.Id == ticket.IdPerson).FirstOrDefaultAsync();

                        string companyCode = person.OldCode ?? "N" + person.Id.ToString("D6");
                        string languageFileName = language == "I" ? "ENG" : "ESP";
                        string fileFormat = "{0}_{1}{2}";
                        //string report = language == "I" ? "EMPRESAS/F8-EMPRESAS-EN" : "EMPRESAS/F8-EMPRESAS-ES";
                        string report = GetReportName( language, ticket.About, format);
                        var reportRenderType = StaticFunctions.GetReportRenderType(format);
                        var extension = StaticFunctions.FileExtension(reportRenderType);
                        var contentType = StaticFunctions.GetContentType(reportRenderType);

                        var dictionary = new Dictionary<string, string>
                        {
                            { "idPerson", ticket.IdPerson.ToString() },
                            { "idTicket", ticket.Id.ToString() },
                            { "language", language }
                         };

                        var file = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary);
                        response.Data = new GetFileResponseDto
                        {
                            File = file,
                            ContentType = contentType,
                            Name = string.Format(fileFormat, companyCode, languageFileName, extension)
                        };
                    }
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

        public async Task<Response<bool>> FinishWorkById(int idTicketHistory)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var cycle = "CP_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Year;
                var productionClosure = await context.ProductionClosures.Where(x => x.Code.Contains(cycle)).FirstOrDefaultAsync();
                if (productionClosure == null)
                {
                    DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                    await context.ProductionClosures.AddAsync(new ProductionClosure
                    {
                        EndDate = lastDayOfCurrentMonth,
                        Code = cycle,
                        Title = "Cierre de Producción " + DateTime.Now.Month.ToString("D2") + " - " + DateTime.Now.Year,
                        Observations = ""
                    });
                }
                else
                {
                    if (productionClosure.EndDate < DateTime.Now)
                    {
                        if (DateTime.Now.Month == 12)
                        {
                            cycle = "CP_" + (1).ToString("D2") + "_" + (DateTime.Now.Year + 1);
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(cycle)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year + 1, 1, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = cycle,
                                    Title = "Cierre de Producción " + (1).ToString("D2") + " - " + DateTime.Today.Year + 1,
                                    Observations = ""
                                });
                            }
                        }
                        else
                        {
                            cycle = "CP_" + (DateTime.Now.Month + 1).ToString("D2") + "_" + DateTime.Now.Year;
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(cycle)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, (DateTime.Today.Month + 1), 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = cycle,
                                    Title = "Cierre de Producción " + (DateTime.Now.Month + 1).ToString("D2") + " - " + DateTime.Now.Year,
                                    Observations = ""
                                });
                            }
                        }
                    }
                }


                var ticketHistory = await context.TicketHistories.Where(x => x.Id == idTicketHistory)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.Providers)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.Providers)
                    .FirstOrDefaultAsync();
                if(ticketHistory != null)
                {
                    if(ticketHistory.IdTicketNavigation.About == "E")
                    {
                        await context.ReferencesHistories.AddAsync(new ReferencesHistory
                        {
                            IdUser = int.Parse(ticketHistory.UserTo),
                            Code = ticketHistory.AsignedTo,
                            IdTicket = ticketHistory.IdTicket,
                            IsComplement = false,
                            ValidReferences = ticketHistory.IdTicketNavigation.IdCompanyNavigation.Providers.Where(x => x.IdTicket == ticketHistory.IdTicket && x.Qualification == "Dió referencia" && x.Flag == true).Count(),
                            Cycle = cycle
                        });
                    }
                    else
                    {
                        await context.ReferencesHistories.AddAsync(new ReferencesHistory
                        {
                            IdUser = int.Parse(ticketHistory.UserTo),
                            Code = ticketHistory.AsignedTo,
                            IdTicket = ticketHistory.IdTicket,
                            IsComplement = false,
                            ValidReferences = ticketHistory.IdTicketNavigation.IdPersonNavigation.Providers.Where(x => x.IdTicket == ticketHistory.IdTicket && x.Qualification == "Dió referencia" && x.Flag == true).Count(),
                            Cycle = cycle
                        });
                    }

                    ticketHistory.Flag = true;
                    ticketHistory.ShippingDate = DateTime.Now;
                    context.TicketHistories.Update(ticketHistory);
                    await context.SaveChangesAsync();
                }

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<string>> GetNumerationRefCom()
        {
            var response = new Response<string>();
            try
            {
                using var context = new SqlCoreContext();
                var numeration = await context.Numerations.Where(x => x.Name == "NUM_COMP_REFCOM").FirstOrDefaultAsync();
                if(numeration == null)
                {
                    throw new Exception("No se encontro la numeración ");
                }
                response.Data = numeration.Number?.ToString("D6");
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> SendComplementRefCom(int idUser, int idTicket,string asignedTo, string numOrder, string message)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var user = await context.UserLogins.Where(x => x.Id == idUser).Include(x => x.IdEmployeeNavigation).FirstOrDefaultAsync();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                if(user != null && ticket != null)
                {
                    var emailDataDto = new EmailDataDTO();
                    emailDataDto.Parameters = new List<string>();

                    emailDataDto.EmailKey = "DRR_WORKFLOW_ESP_0062";

                    var debug = await context.Parameters.Where(x => x.Key == "DEBUG").FirstOrDefaultAsync();
                    if (debug != null && debug.Flag == true)
                    {
                        emailDataDto.From = "diego.rodriguez@del-risco.com";//user.IdEmployeeNavigation.Email;
                        emailDataDto.UserName = "diego.rodriguez@del-risco.com";//user.IdEmployeeNavigation.Email;
                        emailDataDto.Password = "w*@JHCr7mH";// user.EmailPassword;
                        emailDataDto.To = new List<string>
                        {
                            //"crodriguez@del-risco.com",
                            "jfernandez@del-risco.com"
                        };
                        emailDataDto.CC = new List<string>
                        {
                            "diego.rodriguez@del-risco.com",
                             //user.IdEmployeeNavigation.Email,
                            // "crc@del-risco.com"
                        };
                        emailDataDto.Subject = "PRUEBA_COMPLEMENTO_" + ticket.Number.ToString("D6");
                    }
                    else
                    {
                        emailDataDto.From = user.IdEmployeeNavigation.Email;
                        emailDataDto.UserName = user.IdEmployeeNavigation.Email;
                        emailDataDto.Password = user.EmailPassword;
                        emailDataDto.To = new List<string>
                        {
                            "crodriguez@del-risco.com"
                        };
                        emailDataDto.CC = new List<string>
                        {
                             user.IdEmployeeNavigation.Email,
                            // "crc@del-risco.com"
                        };
                        emailDataDto.Subject = "COMPLEMENTO_" + ticket.Number.ToString("D6");
                    }

                    emailDataDto.IsBodyHTML = true;
                    emailDataDto.Parameters.Add(ticket.Number.ToString("D6")); //userFrom.IdEmployeeNavigation.FirstName + " " + userFrom.IdEmployeeNavigation.LastName
                    emailDataDto.Parameters.Add(asignedTo);
                    emailDataDto.Parameters.Add(user.IdEmployeeNavigation.FirstName + " " + user.IdEmployeeNavigation.LastName);
                    emailDataDto.Parameters.Add(numOrder);
                    emailDataDto.Parameters.Add(message);
                    emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                    _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));
                    var numeration = await context.Numerations.Where(x => x.Name == "NUM_COMP_REFCOM").FirstOrDefaultAsync();
                    numeration.Number++;
                    context.Numerations.Update(numeration);
                    await context.SaveChangesAsync();
                    var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                    var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                    emailHistory.Success = result;
                    response.Data = await _emailHistoryDomain.AddAsync(emailHistory);

                }
            }
            catch(Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<bool>?> ConfirmAgentHistory(int idTicketHistory)
        {
            var response = new Response<bool>();
            using var context = new SqlCoreContext();
            try
            {
                var ticketHistory = await context.TicketHistories.FindAsync(idTicketHistory);

                if (ticketHistory != null)
                {
                    ticketHistory.Flag = true;
                    ticketHistory.UpdateDate = DateTime.Now;
                    ticketHistory.ShippingDate = DateTime.Now;

                    context.TicketHistories.Update(ticketHistory);
                    await context.SaveChangesAsync();
                    response.Data = true;
                    response.IsSuccess = true;
                }
                else
                {
                    throw new Exception("No se encontro en el historia del cupón");
                }
            }
            catch ( Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            
            }
            return response;
        }

        public async Task<Response<List<GetSearchSituationResponseDto>>> GetNewSearchSituation(string about, string name, string form, int idCountry, bool haveReport, string filterBy)
        {
            var response = new Response<List<GetSearchSituationResponseDto>>();
            try
            {
                using var context = new SqlCoreContext();
                if(about == "E")
                {
                    var companies = await _companyDomain.GetByNameAsync(name, form, idCountry, haveReport, filterBy);
                    response.Data = _mapper.Map<List<GetSearchSituationResponseDto>>(companies);
                }
                else
                {
                    var peoples = await _personDomain.GetAllByAsync(name, form, idCountry, haveReport, filterBy); ;
                    response.Data = _mapper.Map<List<GetSearchSituationResponseDto>>(peoples);
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<GetTicketUserResponseDto>>> GetTicketAssignedValidation(int idTicket)
        {
            var response = new Response<List<GetTicketUserResponseDto>>();
            response.Data = new List<GetTicketUserResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistories = await context.TicketHistories.Where(x => x.IdTicket == idTicket && 
                ((x.AsignedTo.Contains("R")) || (x.AsignedTo.Contains("A")) || (x.AsignedTo.Contains("RC")) || (x.AsignedTo.Contains("D")) || (x.AsignedTo.Contains("T")))  && (!x.AsignedTo.Contains("CR") && !x.AsignedTo.Contains("PA") && !x.AsignedTo.Contains("S")) && x.AsignationType != null && x.AsignationType != "" ).ToListAsync();
                if(ticketHistories == null)
                {
                    throw new Exception("No se encontro el ticket");
                }
                foreach(var ticketHistory in ticketHistories)
                {
                    var asignation = new GetTicketUserResponseDto();
                    asignation.Code = ticketHistory.AsignedTo;
                    asignation.Type = ticketHistory.AsignationType;
                    asignation.Flag = ticketHistory.Flag;
                    response.Data.Add(asignation);
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> deleteTicketComplement(int idTicket)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Include(x => x.TicketFiles).Include(x => x.TicketHistories).Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                context.Tickets.Remove(ticket);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<int>> ValidateQuality(int idTicket)
        {
            var response = new Response<int>();
            response.Data = 0;
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets
                    .Where(x => x.Id == idTicket)
                    .Include(x => x.IdCompanyNavigation)
                    .Include(x => x.IdPersonNavigation)
                    .FirstOrDefaultAsync();
                if(ticket == null)
                {
                    response.IsSuccess = true;
                    response.Message = "No se encontro el ticket";
                    _logger.LogError("No se encontro el ticket");
                    return response;
                }
                //0 no mostrara mensaje
                //1 mostrara mensaje
                switch(ticket.About)
                {
                    case "E":
                        if (ticket.IdCompanyNavigation.Quality.Trim().IsNullOrEmpty())
                        {
                            response.Data = 1; 
                        }
                        break;
                    case "P":
                        if (ticket.IdPersonNavigation.Quality.Trim().IsNullOrEmpty())
                        {
                            response.Data = 1; 
                        }
                        break;
                }

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<GetListTicketResponseDto>>> GetTicketObservedByIdEmployee(int idEmployee)
        {
            var response = new Response<List<GetListTicketResponseDto>>();
            response.Data = new List<GetListTicketResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var listTicket = new List<Ticket>();
                var personal = await context.Personals.Where(x => x.IdEmployee == idEmployee).ToListAsync();
                foreach (var item in personal)
                {
                    var listTicketObservations = await context.DetailsTicketObservations
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCompanyNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdTicketComplementNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdContinentNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.IdCountryNavigation).ThenInclude(x => x.IdContinentNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.IdCountryNavigation).ThenInclude(x => x.IdContinentNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdStatusTicketNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.TicketAssignation).ThenInclude(x => x.IdEmployeeNavigation)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.TicketQuery)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.TicketFiles)
                        .Include(x => x.IdTicketObservationsNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.TicketHistories.OrderByDescending(x => x.Id)).Where(x => x.Enable == true)
                        .Where(x => x.AssignedTo.Contains(item.Code) && x.IdTicketObservationsNavigation.IdStatusTicketObservations == 1).ToListAsync();
                    foreach(var ticket in listTicketObservations)
                    {
                        listTicket.Add(ticket.IdTicketObservationsNavigation.IdTicketNavigation);
                    }
                }

                response.Data = _mapper.Map<List<GetListTicketResponseDto>>(listTicket);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = true;
            }
            return response;
        }
    }

}
