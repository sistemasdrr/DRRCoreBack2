using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Email;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static iTextSharp.text.pdf.AcroFields;

namespace DRRCore.Application.Main.CoreApplication
{
    public class QueryApplication : IQueryApplication
    {
        private readonly IMailFormatter _mailFormatter;
        private readonly ILogger _logger;
        private readonly IReportingDownload _reportingDownload;
        private readonly IEmailConfigurationDomain _emailConfigurationDomain;
        private readonly IMailSender _mailSender;
        private IMapper _mapper;
        public QueryApplication(ILogger logger, IMapper mapper, IReportingDownload reportingDownload, 
            IEmailConfigurationDomain emailConfigurationDomain, IMailSender mailSender, IMailFormatter mailFormatter) 
        {
            _logger = logger;
            _mapper = mapper;
            _reportingDownload = reportingDownload;
            _emailConfigurationDomain = emailConfigurationDomain;
            _mailSender = mailSender;
            _mailFormatter = mailFormatter;
        }


        public async Task<Response<List<GetQuery1_1ByMonthResponseDto>>> GetQuery1_1ByMonth(int year,int month, int idSubscriber)
        {
            var response = new Response<List<GetQuery1_1ByMonthResponseDto>>();
            response.Data = new List<GetQuery1_1ByMonthResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoice = await context.SubscriberInvoices
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Where(x => x.IdSubscriber == idSubscriber && x.InvoiceEmitDate.Value.Year == year && x.InvoiceEmitDate.Value.Month == month)
                    .ToListAsync();
                foreach (var item in subscriberInvoice)
                {
                    foreach (var item1 in item.SubscriberInvoiceDetails)
                    {
                        response.Data.Add(new GetQuery1_1ByMonthResponseDto
                        {
                            Id = item1.IdTicketNavigation.Id,
                            RequestedName = item1.IdTicketNavigation.RequestedName,
                            IdCountry = item1.IdTicketNavigation.IdCountry != null ? item1.IdTicketNavigation.IdCountry : 0,
                            Country = item1.IdTicketNavigation.IdCountry != null ? item1.IdTicketNavigation.IdCountryNavigation.Iso : "",
                            FlagCountry = item1.IdTicketNavigation.IdCountry != null ? item1.IdTicketNavigation.IdCountryNavigation.FlagIso : "",
                            OrderDate = StaticFunctions.DateTimeToString(item1.IdTicketNavigation.OrderDate),
                            DispatchDate = StaticFunctions.DateTimeToString(item1.IdTicketNavigation.DispatchtDate),
                            ProcedureType = item1.IdTicketNavigation.ProcedureType,
                            ReportType = item1.IdTicketNavigation.ReportType,
                            Price = item1.IdTicketNavigation.Price,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_1ResponseDto>>> GetQuery1_1ByYear(int year)
        {
            var response = new Response<List<GetQuery1_1ResponseDto>>();
            response.Data = new List<GetQuery1_1ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoiceDetails
                    .Include(x => x.IdSubscriberInvoiceNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Year == year).ToListAsync();

                var idsSubscriber = subscriberInvoices.DistinctBy(x => x.IdSubscriberInvoiceNavigation.IdSubscriber);
                foreach (var item in idsSubscriber)
                {
                    response.Data.Add(new GetQuery1_1ResponseDto
                    {
                        IdSubscriber = item.IdSubscriberInvoiceNavigation.IdSubscriber,
                        SubscriberCode = item.IdSubscriberInvoiceNavigation.IdSubscriberNavigation.Code,
                        SubscriberName = item.IdSubscriberInvoiceNavigation.IdSubscriberNavigation.Name,
                        January = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 1 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        February = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 2 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        March = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 3 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        April = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 4 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        May = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 5 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        June = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 6 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        July = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 7 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        August = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 8 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        September = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 9 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        October = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 10 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        November = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 11 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        December = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Month == 12 && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                        Total = subscriberInvoices.Where(x => x.IdSubscriberInvoiceNavigation.InvoiceEmitDate.Value.Year == year && x.IdSubscriberInvoiceNavigation.IdSubscriber == item.IdSubscriberInvoiceNavigation.IdSubscriber).ToList().Count,
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<List<GetQuery1_2ByYearResponseDto>>> GetQuery1_2ByYear(int year)
        {
            var response = new Response<List<GetQuery1_2ByYearResponseDto>>();
            response.Data = new List<GetQuery1_2ByYearResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.DispatchtDate != null && x.DispatchtDate.Value.Year == year
                    && (x.IdStatusTicket == (int?)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion))
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                var idsCountries = tickets.DistinctBy(x => x.IdCountry);
                foreach (var item in idsCountries)
                {
                    response.Data.Add(new GetQuery1_2ByYearResponseDto
                    {
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation != null ? item.IdCountryNavigation.Iso : "",
                        FlagCountry = item.IdCountryNavigation != null ? item.IdCountryNavigation.FlagIso : "",
                        January = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 1 && x.IdCountry == item.IdCountry).ToList().Count,
                        February = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 2 && x.IdCountry == item.IdCountry).ToList().Count,
                        March = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 3 && x.IdCountry == item.IdCountry).ToList().Count,
                        April = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 4 && x.IdCountry == item.IdCountry).ToList().Count,
                        May = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 5 && x.IdCountry == item.IdCountry).ToList().Count,
                        June = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 6 && x.IdCountry == item.IdCountry).ToList().Count,
                        July = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 7 && x.IdCountry == item.IdCountry).ToList().Count,
                        August = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 8 && x.IdCountry == item.IdCountry).ToList().Count,
                        September = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 9 && x.IdCountry == item.IdCountry).ToList().Count,
                        October = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 10 && x.IdCountry == item.IdCountry).ToList().Count,
                        November = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 11 && x.IdCountry == item.IdCountry).ToList().Count,
                        December = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == 12 && x.IdCountry == item.IdCountry).ToList().Count,
                        Total = tickets.Where(x => x.DispatchtDate.Value.Year == year && x.IdCountry == item.IdCountry).ToList().Count,
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_3BySubscriberResponseDto>>> GetQuery1_3BySubscriber(int idSubscriber, int year)
        {
            var response = new Response<List<GetQuery1_3BySubscriberResponseDto>>();
            response.Data = new List<GetQuery1_3BySubscriberResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.OrderDate.Year == year && x.IdSubscriber == idSubscriber)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                var idsCountries = tickets.DistinctBy(x => x.IdCountry);
                foreach (var item in idsCountries)
                {
                    response.Data.Add(new GetQuery1_3BySubscriberResponseDto
                    {
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation != null ? item.IdCountryNavigation.Name : "",
                        FlagCountry = item.IdCountryNavigation != null ? item.IdCountryNavigation.FlagIso : "",
                        January = tickets.Where(x => x.OrderDate.Month == 1 && x.IdCountry == item.IdCountry).ToList().Count,
                        February = tickets.Where(x => x.OrderDate.Month == 2 && x.IdCountry == item.IdCountry).ToList().Count,
                        March = tickets.Where(x => x.OrderDate.Month == 3 && x.IdCountry == item.IdCountry).ToList().Count,
                        April = tickets.Where(x => x.OrderDate.Month == 4 && x.IdCountry == item.IdCountry).ToList().Count,
                        May = tickets.Where(x => x.OrderDate.Month == 5 && x.IdCountry == item.IdCountry).ToList().Count,
                        June = tickets.Where(x => x.OrderDate.Month == 6 && x.IdCountry == item.IdCountry).ToList().Count,
                        July = tickets.Where(x => x.OrderDate.Month == 7 && x.IdCountry == item.IdCountry).ToList().Count,
                        August = tickets.Where(x => x.OrderDate.Month == 8 && x.IdCountry == item.IdCountry).ToList().Count,
                        September = tickets.Where(x => x.OrderDate.Month == 9 && x.IdCountry == item.IdCountry).ToList().Count,
                        October = tickets.Where(x => x.OrderDate.Month == 10 && x.IdCountry == item.IdCountry).ToList().Count,
                        November = tickets.Where(x => x.OrderDate.Month == 11 && x.IdCountry == item.IdCountry).ToList().Count,
                        December = tickets.Where(x => x.OrderDate.Month == 12 && x.IdCountry == item.IdCountry).ToList().Count,
                        Total = tickets.Where(x => x.IdCountry == item.IdCountry).ToList().Count,
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<List<GetQuery1_4SubscriberResponseDto>>> GetQuery1_4Subscribers()
        {
            var response = new Response<List<GetQuery1_4SubscriberResponseDto>>();
            response.Data = new List<GetQuery1_4SubscriberResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoices
                    .Include(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();

                var idSubscribers = subscriberInvoices.DistinctBy(x => x.IdSubscriber).ToList();
                foreach (var item in idSubscribers)
                {
                    response.Data.Add(new GetQuery1_4SubscriberResponseDto
                    {
                        IdSubscriber = item.IdSubscriber,
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        IdCountry = item.IdSubscriberNavigation.IdCountry,
                        Country = item.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdSubscriberNavigation.IdCountryNavigation.FlagIso,
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<GetQuery1_4ResponseDto>> GetQuery1_4(int idSubscriber, int year)
        {
            var response = new Response<GetQuery1_4ResponseDto>();
            var query4ByCountries = new List<GetQuery1_4ByCountryResponseDto>();
            var query4ByProcedureType = new List<GetQuery1_4ByProcedureTypeResponseDto>();
            var query4ByReportType = new List<GetQuery1_4ByReportTypeResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var invoicedTickets = await context.SubscriberInvoices
                    .Where(x => x.IdSubscriber == idSubscriber && x.InvoiceEmitDate.Value.Year == year)
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                var tickets = new List<Ticket>();
                foreach (var item in invoicedTickets)
                {
                    foreach (var item1 in item.SubscriberInvoiceDetails)
                    {
                        tickets.Add(item1.IdTicketNavigation);
                    }
                }

                //1
                var idsCountries = tickets.DistinctBy(x => x.IdCountry);
                foreach (var item in idsCountries)
                {
                    query4ByCountries.Add(new GetQuery1_4ByCountryResponseDto
                    {
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation != null ? item.IdCountryNavigation.Iso : "",
                        FlagCountry = item.IdCountryNavigation != null ? item.IdCountryNavigation.FlagIso : "",
                        January = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 1 && x.IdCountry == item.IdCountry).ToList().Count,
                        February = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 2 && x.IdCountry == item.IdCountry).ToList().Count,
                        March = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 3 && x.IdCountry == item.IdCountry).ToList().Count,
                        April = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 4 && x.IdCountry == item.IdCountry).ToList().Count,
                        May = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 5 && x.IdCountry == item.IdCountry).ToList().Count,
                        June = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 6 && x.IdCountry == item.IdCountry).ToList().Count,
                        July = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 7 && x.IdCountry == item.IdCountry).ToList().Count,
                        August = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 8 && x.IdCountry == item.IdCountry).ToList().Count,
                        September = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 9 && x.IdCountry == item.IdCountry).ToList().Count,
                        October = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 10 && x.IdCountry == item.IdCountry).ToList().Count,
                        November = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 11 && x.IdCountry == item.IdCountry).ToList().Count,
                        December = tickets.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == 12 && x.IdCountry == item.IdCountry).ToList().Count,
                        Total = tickets.Where(x => x.OrderDate.Year == year && x.IdCountry == item.IdCountry).ToList().Count,
                    });
                }

                //2

                var procedureTypes = tickets.DistinctBy(x => x.ProcedureType);
                foreach (var item in procedureTypes)
                {
                    query4ByProcedureType.Add(new GetQuery1_4ByProcedureTypeResponseDto
                    {
                        ProcedureType = item.ProcedureType,
                        January = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 1).ToList().Count,
                        February = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 2).ToList().Count,
                        March = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 3).ToList().Count,
                        April = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 4).ToList().Count,
                        May = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 5).ToList().Count,
                        June = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 6).ToList().Count,
                        July = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 7).ToList().Count,
                        August = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 8).ToList().Count,
                        September = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 9).ToList().Count,
                        October = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 10).ToList().Count,
                        November = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 11).ToList().Count,
                        December = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Month == 12).ToList().Count,
                        Total = tickets.Where(x => x.ProcedureType == item.ProcedureType && x.OrderDate.Year == year).ToList().Count,
                    });
                }

                //3
                var reportTypes = tickets.DistinctBy(x => x.ReportType);
                foreach (var item in reportTypes)
                {
                    query4ByReportType.Add(new GetQuery1_4ByReportTypeResponseDto
                    {
                        ReportType = item.ReportType,
                        January = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 1).ToList().Count,
                        February = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 2).ToList().Count,
                        March = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 3).ToList().Count,
                        April = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 4).ToList().Count,
                        May = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 5).ToList().Count,
                        June = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 6).ToList().Count,
                        July = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 7).ToList().Count,
                        August = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 8).ToList().Count,
                        September = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 9).ToList().Count,
                        October = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 10).ToList().Count,
                        November = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 11).ToList().Count,
                        December = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Month == 12).ToList().Count,
                        Total = tickets.Where(x => x.ReportType == item.ReportType && x.OrderDate.Year == year).ToList().Count,
                    });
                }

                response.Data = new GetQuery1_4ResponseDto
                {
                    Query1_4ByCountries = query4ByCountries,
                    Query1_4ByProcedureType = query4ByProcedureType,
                    Query1_4ByReportType = query4ByReportType,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_5ResponseDto>>> GetQuery1_5(string startDate, string endDate)
        {
            var response = new Response<List<GetQuery1_5ResponseDto>>();
            response.Data = new List<GetQuery1_5ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();

                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);

                var tickets = await context.Tickets
                    .Where(x => x.OrderDate > startDateTime && x.OrderDate <= endDateTime 
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Despachado_con_Observacion 
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Despachado && x.IdStatusTicket != (int?)TicketStatusEnum.Rechazado)
                    .Include(x => x.IdSubscriberNavigation)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in tickets)
                {
                    response.Data.Add(new GetQuery1_5ResponseDto
                    {
                        IdTicket = item.Id,
                        OrderDate = StaticFunctions.DateTimeToString(item.OrderDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.ExpireDate),
                        RequestedName = item.RequestedName,
                        BusinessName = item.BusineesName,
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        ProcedureType = item.ProcedureType,
                        ReportType = item.ReportType,
                        IdSubscriber = item.IdSubscriber,
                        SubscriberName = item.IdSubscriberNavigation.Name ?? "",
                        SubscriberCode = item.IdSubscriberNavigation.Code ?? "",
                        Price = item.Price
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<List<GetQuery1_6ResponseDto>>> GetQuery1_6()
        {
            var response = new Response<List<GetQuery1_6ResponseDto>>();
            response.Data = new List<GetQuery1_6ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.IdStatusTicket != (int?)TicketStatusEnum.Despachado_con_Observacion
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Despachado && x.IdStatusTicket != (int?)TicketStatusEnum.Rechazado)
                    .Include(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                if(tickets.Count > 0)
                {
                    var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                    foreach (var item in idSubscribers)
                    {
                        response.Data.Add(new GetQuery1_6ResponseDto
                        {
                            IdSubscriber = item.IdSubscriber,
                            Name = item.IdSubscriberNavigation.Name ?? "",
                            Code = item.IdSubscriberNavigation.Code ?? "",
                            IdCountry = item.IdSubscriberNavigation.IdCountry,
                            Country = item.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                            FlagCountry = item.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? ""
                        });
                    }
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<List<GetQuery1_6BySubscriberResponseDto>>> GetQuery1_6BySubscriber()
        {
            var response = new Response<List<GetQuery1_6BySubscriberResponseDto>>();
            response.Data = new List<GetQuery1_6BySubscriberResponseDto>();
            try
            {
                using var context = new SqlCoreContext();

                var tickets = await context.Tickets
                    .Where(x => x.IdStatusTicket != (int?)TicketStatusEnum.Despachado_con_Observacion
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Despachado && x.IdStatusTicket != (int?)TicketStatusEnum.Rechazado)
                    .Include(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.IdCountryNavigation)
                    .OrderBy(x => x.OrderDate)
                    .ToListAsync();
                foreach (var item in tickets)
                {
                    response.Data.Add(new GetQuery1_6BySubscriberResponseDto
                    {
                        IdTicket = item.Id,
                        OrderDate = StaticFunctions.DateTimeToString(item.OrderDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.ExpireDate),
                        RequestedName = item.RequestedName,
                        BusinessName = item.BusineesName,
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        ProcedureType = item.ProcedureType,
                        ReportType = item.ReportType,
                        IdSubscriber = item.IdSubscriber,
                        SubscriberName = item.IdSubscriberNavigation.Name ?? "",
                        SubscriberCode = item.IdSubscriberNavigation.Code ?? "",
                        SubscriberCountry = item.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                        SubscriberFlagCountry = item.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? "",
                        Price = item.Price
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

      
        public async Task<Response<List<GetQuery1_7SubscriberResponseDto>>> GetQuery1_7Subscriber()
        {
            var response = new Response<List<GetQuery1_7SubscriberResponseDto>>();
            response.Data = new List<GetQuery1_7SubscriberResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscribers = await context.Subscribers
                    .Where(x => x.Enable == true)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in subscribers)
                {
                    response.Data.Add(new GetQuery1_7SubscriberResponseDto
                    {
                        IdSubscriber = item.Id,
                        Code = item.Code,
                        Name = item.Name,
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation != null ? item.IdCountryNavigation.Iso : "",
                        FlagCountry = item.IdCountryNavigation != null ? item.IdCountryNavigation.FlagIso : "",
                        Contact = item.PrincipalContact,
                        Email = item.SendReportToEmail,
                        BillingType = item.FacturationType
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<List<GetQuery1_7TicketsReponseDto>>> GetQuery1_7Tickets(int year, int month, int idSubscriber)
        {
            var response = new Response<List<GetQuery1_7TicketsReponseDto>>();
            response.Data = new List<GetQuery1_7TicketsReponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.OrderDate.Year == year && x.OrderDate.Month == month && x.IdSubscriber == idSubscriber)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in tickets)
                {
                    response.Data.Add(new GetQuery1_7TicketsReponseDto
                    {
                        IdTicket = item.Id,
                        OrderDate = StaticFunctions.DateTimeToString(item.OrderDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.ExpireDate),
                        RequestedName = item.RequestedName,
                        ReferenceCode = item.ReferenceNumber,
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        ProcedureType = item.ProcedureType,
                        ReportType = item.ReportType
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_8ResponseDto>>> GetQuery1_8(int year, int month)
        {
            var response = new Response<List<GetQuery1_8ResponseDto>>();
            response.Data = new List<GetQuery1_8ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var invoicedTickets = await context.SubscriberInvoices
                    .Where(x => x.InvoiceEmitDate.Value.Year == year && x.InvoiceEmitDate.Value.Month == month)
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                var tickets = new List<Ticket>();
                foreach (var item in invoicedTickets)
                {
                    foreach (var item1 in item.SubscriberInvoiceDetails)
                    {
                        tickets.Add(item1.IdTicketNavigation);
                    }
                }

                //1
                var idsCountries = tickets.DistinctBy(x => x.IdCountry);
                foreach (var item in idsCountries)
                {
                    response.Data.Add(new GetQuery1_8ResponseDto
                    {
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        Quantity = tickets.Where(x => x.IdCountry == item.IdCountry).ToList().Count()
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_9ResponseDto>>> GetQuery1_9(int year, int month)
        {
            var response = new Response<List<GetQuery1_9ResponseDto>>();
            response.Data = new List<GetQuery1_9ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => (x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado) &&
                    x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == month)
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.Add(new GetQuery1_9ResponseDto
                    {
                        IdSubscriber = item.IdSubscriber,
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Quantity = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count(),
                    });
                }
                response.Data.OrderByDescending(x => x.Quantity);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_10ResponseDto>>> GetQuery1_10(int idSubscriber, string startDate, string endDate)
        {
            var response = new Response<List<GetQuery1_10ResponseDto>>();
            response.Data = new List<GetQuery1_10ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();

                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);

                var tickets = await context.Tickets
                    .Where(x => x.IdSubscriber == idSubscriber && x.OrderDate > startDateTime && x.OrderDate < endDateTime)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in tickets)
                {
                    response.Data.Add(new GetQuery1_10ResponseDto
                    {
                        IdTicket = item.Id,
                        OrderDate = StaticFunctions.DateTimeToString(item.OrderDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.ExpireDate),
                        DispatchDate = StaticFunctions.DateTimeToString(item.DispatchtDate),
                        RequestedName = item.RequestedName,
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        ProcedureType = item.ProcedureType,
                        ReportType = item.ReportType,
                        Price = item.Price,
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_11SubscribersResponseDto>>> GetQuery1_11Subscriber(int year)
        {

            var response = new Response<List<GetQuery1_11SubscribersResponseDto>>();
            response.Data = new List<GetQuery1_11SubscribersResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.DispatchtDate.Value.Year == year && (x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado))
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                var idsSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idsSubscribers)
                {
                    response.Data.Add(new GetQuery1_11SubscribersResponseDto
                    {
                        IdSubscriber = item.IdSubscriber,
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        January = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 1).ToList().Count,
                        February = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 2).ToList().Count,
                        March = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 3).ToList().Count,
                        April = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 4).ToList().Count,
                        May = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 5).ToList().Count,
                        June = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 6).ToList().Count,
                        July = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 7).ToList().Count,
                        August = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 8).ToList().Count,
                        September = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 9).ToList().Count,
                        October = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 10).ToList().Count,
                        November = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 11).ToList().Count,
                        December = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Month == 12).ToList().Count,
                        Total = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.DispatchtDate.Value.Year == year).ToList().Count,
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery1_11BySubscriberResponseDto>>> GetQuery1_11BySubscriber(int idSubscriber,int year, int month)
        {
            var response = new Response<List<GetQuery1_11BySubscriberResponseDto>>();
            response.Data = new List<GetQuery1_11BySubscriberResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.IdSubscriber == idSubscriber && (x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado)
                    && x.DispatchtDate.Value.Year == year && x.DispatchtDate.Value.Month == month)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in tickets)
                {
                    response.Data.Add(new GetQuery1_11BySubscriberResponseDto
                    {
                        IdTicket = item.Id,
                        RequestedName = item.RequestedName,
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        OrderDate = StaticFunctions.DateTimeToString(item.OrderDate),
                        DispatchDate = StaticFunctions.DateTimeToString(item.DispatchtDate),
                        ProcedureType = item.ProcedureType,
                        ReportType = item.ReportType,
                        Price = item.Price
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery2_1ByYearResponseDto>>> GetQuery2_1ByYear(int year)
        {
            var response = new Response<List<GetQuery2_1ByYearResponseDto>>();
            response.Data = new List<GetQuery2_1ByYearResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistories = await context.TicketHistories
                    .Include(x => x.IdTicketNavigation)
                    .Where(x => x.IdTicketNavigation.OrderDate.Year == year && (x.IdTicketNavigation.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion || x.IdTicketNavigation.IdStatusTicket == (int?)TicketStatusEnum.Despachado) &&
                    x.AsignedTo.Contains("CR") == false && x.AsignedTo.Contains("RC") == false && x.AsignedTo.Contains("R"))
                    .ToListAsync();
                var reporteros = ticketHistories.DistinctBy(x => x.AsignedTo);
                foreach (var item in reporteros)
                {
                    var employee = await context.Personals
                        .Include(x => x.IdEmployeeNavigation)
                        .Where(x => x.Code == item.AsignedTo.Trim()).FirstOrDefaultAsync();
                    response.Data.Add(new GetQuery2_1ByYearResponseDto
                    {
                        IdEmployee = employee.IdEmployee,
                        Name = employee.IdEmployeeNavigation.FirstName ?? "",
                        Code = item.AsignedTo,
                        January = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 1 && x.AsignedTo == item.AsignedTo).Count(),
                        February = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 2 && x.AsignedTo == item.AsignedTo).Count(),
                        March = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 3 && x.AsignedTo == item.AsignedTo).Count(),
                        April = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 4 && x.AsignedTo == item.AsignedTo).Count(),
                        May = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 5 && x.AsignedTo == item.AsignedTo).Count(),
                        June = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 6 && x.AsignedTo == item.AsignedTo).Count(),
                        July = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 7 && x.AsignedTo == item.AsignedTo).Count(),
                        August = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 8 && x.AsignedTo == item.AsignedTo).Count(),
                        September = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 9 && x.AsignedTo == item.AsignedTo).Count(),
                        October = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 10 && x.AsignedTo == item.AsignedTo).Count(),
                        November = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 11 && x.AsignedTo == item.AsignedTo).Count(),
                        December = ticketHistories.Where(x => x.IdTicketNavigation.OrderDate.Month == 12 && x.AsignedTo == item.AsignedTo).Count(),
                        Total = ticketHistories.Where(x => x.AsignedTo == item.AsignedTo).Count(),

                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetReportersResponseDto>>> GetReporters()
        {
            var response = new Response<List<GetReportersResponseDto>>();
            response.Data = new List<GetReportersResponseDto>();
            try
            {

                using var context = new SqlCoreContext();
                var personals = await context.Personals
                    .Where(x => x.Code.Contains("RC") == false && x.Code.Contains("R") && x.Enable == true)
                    .Include(x => x.IdEmployeeNavigation)
                    .OrderBy(x => x.Code)
                    .ToListAsync();
                foreach (var item in personals)
                {
                    response.Data.Add(new GetReportersResponseDto
                    {
                        AsignedTo = item.Code,
                        Name = item.IdEmployeeNavigation != null ? item.IdEmployeeNavigation.FirstName : ""
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<List<GetQuery2_1ByMonthResponseDto>>> GetQuery2_1ByMonth(int year, int month, string asignedTo)
        {
            var response = new Response<List<GetQuery2_1ByMonthResponseDto>>();
            response.Data = new List<GetQuery2_1ByMonthResponseDto>();
            try{
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .Where(x => x.AsignedTo.Contains(asignedTo) && x.IdTicketNavigation.OrderDate.Month == month &&
                     (x.IdTicketNavigation.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion || x.IdTicketNavigation.IdStatusTicket == (int?)TicketStatusEnum.Despachado)
                    && x.IdTicketNavigation.OrderDate.Year == year)
                    .ToListAsync();
                foreach (var item in ticketHistory)
                {
                    response.Data.Add(new GetQuery2_1ByMonthResponseDto
                    {
                        Id = item.IdTicket,
                        RequestedName = item.IdTicketNavigation.RequestedName ?? "",
                        IdCountry = item.IdTicketNavigation.IdCountry,
                        Country = item.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                        IdSubscriber = item.IdTicketNavigation.IdSubscriber,
                        SubscriberName = item.IdTicketNavigation.IdSubscriberNavigation.Name ?? "",
                        SubscriberCode = item.IdTicketNavigation.IdSubscriberNavigation.Code ?? "",
                        OrderDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.OrderDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.ExpireDate),
                        ShippingDate = StaticFunctions.DateTimeToString(item.ShippingDate),
                        ProcedureType = item.IdTicketNavigation.ProcedureType,
                        ReportType = item.IdTicketNavigation.ReportType,
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public GetQuery2_2ByMonthResponseDto TicketToDto(int month, int? idCountry, List<TicketHistory> list, TicketHistory obj)
        {
            var monthDto = new GetQuery2_2ByMonthResponseDto
            {
                IdCountry = obj.IdTicketNavigation.IdCountry,
                Country = obj.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                FlagCountry = obj.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                Day1 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 1 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day2 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 2 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day3 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 3 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day4 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 4 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day5 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 5 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day6 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 6 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day7 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 7 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day8 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 8 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day9 = list.Where(x => x.ShippingDate.Value.Month == month  && x.ShippingDate.Value.Day == 9 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day10 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 10 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day11 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 11 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day12 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 12 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day13 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 13 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day14 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 14 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day15 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 15 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day16 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 16 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day17 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 17 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day18 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 18 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day19 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 19 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day20 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 20 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day21 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 21 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day22 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 22 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day23 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 23 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day24 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 24 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day25 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 25 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day26 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 26 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day27 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 27 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day28 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 28 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day29 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 29 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day30 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 30 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
                Day31 = list.Where(x => x.ShippingDate.Value.Month == month && x.ShippingDate.Value.Day == 31 && x.IdTicketNavigation.IdCountry == idCountry).Count(),
            };
            return monthDto;
        }
        public async Task<Response<List<GetQuery2_2ByYearResponseDto>>> GetQuery2_2ByYear(int year, string asignedTo)
        {
            var response = new Response<List<GetQuery2_2ByYearResponseDto>>();
            response.Data = new List<GetQuery2_2ByYearResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistories = await context.TicketHistories
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Where(x => x.AsignedTo.Contains(asignedTo.Trim()) && x.ShippingDate.Value.Year == year)
                    .ToListAsync();
                var idCountries = ticketHistories.DistinctBy(x => x.IdTicketNavigation.IdCountry);
                foreach (var item in idCountries)
                {
                    response.Data.Add(new GetQuery2_2ByYearResponseDto
                    {
                        IdCountry = item.IdTicketNavigation.IdCountry,
                        Country = item.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                        January = ticketHistories.Where(x => x.ShippingDate.Value.Month == 1 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month1 = TicketToDto(1, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        February = ticketHistories.Where(x => x.ShippingDate.Value.Month == 2 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month2 = TicketToDto(2, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        March = ticketHistories.Where(x => x.ShippingDate.Value.Month == 3 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month3 = TicketToDto(3, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        April = ticketHistories.Where(x => x.ShippingDate.Value.Month == 4 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month4 = TicketToDto(4, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        May = ticketHistories.Where(x => x.ShippingDate.Value.Month == 5 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month5 = TicketToDto(5, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        June = ticketHistories.Where(x => x.ShippingDate.Value.Month == 6 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month6 = TicketToDto(6, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        July = ticketHistories.Where(x => x.ShippingDate.Value.Month == 7 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month7 = TicketToDto(7, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        August = ticketHistories.Where(x => x.ShippingDate.Value.Month == 8 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month8 = TicketToDto(8, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        September = ticketHistories.Where(x => x.ShippingDate.Value.Month == 9 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month9 = TicketToDto(9, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        October = ticketHistories.Where(x => x.ShippingDate.Value.Month == 10 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month10 = TicketToDto(10, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        November = ticketHistories.Where(x => x.ShippingDate.Value.Month == 11 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month11 = TicketToDto(11, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        December = ticketHistories.Where(x => x.ShippingDate.Value.Month == 12 && x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count(),
                        Month12 = TicketToDto(12, item.IdTicketNavigation.IdCountry, ticketHistories, item),
                        Total = ticketHistories.Where(x => x.IdTicketNavigation.IdCountry == item.IdTicketNavigation.IdCountry).Count()
                    });
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery3_1ByYearResponseDto>>> GetQuery3_1ByYear(int year)
        {
            var response = new Response<List<GetQuery3_1ByYearResponseDto>>();
            response.Data = new List<GetQuery3_1ByYearResponseDto>();
            try 
            {
                using var context = new SqlCoreContext();
                var agentInvoice = await context.AgentInvoices
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation).ThenInclude(x => x.IdTicketNavigation)
                    .Where(X => X.InvoiceEmitDate.Value.Year == year)
                    .ToListAsync();
                var asignedTo = agentInvoice.DistinctBy(x => x.AgentCode);
                foreach (var item in asignedTo)
                {
                    var agent1 = new Personal();
                    var agent2 = new Agent();
                    agent1 = await context.Personals.Include(x => x.IdEmployeeNavigation).Where(x => x.Code.Contains(item.AgentCode.Trim())).FirstOrDefaultAsync();
                    if(agent1 == null)
                    {
                        agent2 = await context.Agents.Where(x => x.Code.Contains(item.AgentCode.Trim())).FirstOrDefaultAsync();
                    }
                    response.Data.Add(new GetQuery3_1ByYearResponseDto
                    {
                        AsignedTo = item.AgentCode,
                        Name = agent1 == null ? agent2.Name : agent1.IdEmployeeNavigation.FirstName,
                        January = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 1 && x.AgentCode == item.AgentCode).ToList().Count(),
                        February = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 2 && x.AgentCode == item.AgentCode).ToList().Count(),
                        March = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 3 && x.AgentCode == item.AgentCode).ToList().Count(),
                        April = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 4 && x.AgentCode == item.AgentCode).ToList().Count(),
                        May = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 5 && x.AgentCode == item.AgentCode).ToList().Count(),
                        June = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 6 && x.AgentCode == item.AgentCode).ToList().Count(),
                        July = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 7 && x.AgentCode == item.AgentCode).ToList().Count(),
                        August = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 8 && x.AgentCode == item.AgentCode).ToList().Count(),
                        September = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 9 && x.AgentCode == item.AgentCode).ToList().Count(),
                        October = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 10 && x.AgentCode == item.AgentCode).ToList().Count(),
                        November = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 11 && x.AgentCode == item.AgentCode).ToList().Count(),
                        December = agentInvoice.Where(x => x.InvoiceEmitDate.Value.Month == 12 && x.AgentCode == item.AgentCode).ToList().Count(),
                        Total = agentInvoice.Where(x => x.AgentCode == item.AgentCode).ToList().Count(),
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetQuery3_1ByMonthResponseDto>>> GetQuery3_1ByMonth(string asignedTo, int year, int month)
        {
            var response = new Response<List<GetQuery3_1ByMonthResponseDto>>();
            response.Data = new List<GetQuery3_1ByMonthResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var agentInvoice = await context.AgentInvoices
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Where(x => x.InvoiceEmitDate.Value.Year == year && x.InvoiceEmitDate.Value.Month == month && x.AgentCode.Trim() == asignedTo.Trim())
                    .ToListAsync();
                foreach (var item in agentInvoice)
                {
                    foreach (var item1 in item.AgentInvoiceDetails)
                    {
                        response.Data.Add(new GetQuery3_1ByMonthResponseDto
                        {
                            RequestedName = item1.IdTicketHistoryNavigation.IdTicketNavigation.RequestedName,
                            IdCountry = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountry,
                            Country = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                            FlagCountry = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                            EmitInvoiceDate = StaticFunctions.DateTimeToString(item.InvoiceEmitDate),
                            OrderDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.IdTicketNavigation.OrderDate),
                            DispatchDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.IdTicketNavigation.DispatchtDate),
                            ExpireDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.IdTicketNavigation.ExpireDate),
                            ProcedureType = item1.IdTicketHistoryNavigation.IdTicketNavigation.ProcedureType,
                            ReportType = item1.IdTicketHistoryNavigation.IdTicketNavigation.ReportType,
                            Price = item1.Amount,
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadQuery_Fact_ByBill(string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "FACTURACION/ABONADOS/CONSULTA_FACT_PORCOBRAR_ABONADO";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                 };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "CONSULTA_FACT_PORCOBRAR_ABONADO", ".", extension)
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

        public async Task<Response<List<GetQuery4_1ResponseDto>>> GetQuery4_1()
        {
            var response = new Response<List<GetQuery4_1ResponseDto>>();
            response.Data = new List<GetQuery4_1ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoice = await context.SubscriberInvoices.Where(x => x.IdInvoiceState == 2).Include(x => x.IdSubscriberNavigation).ToListAsync();
                var idSubscribers = subscriberInvoice.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.Add(new GetQuery4_1ResponseDto
                    {
                        IdSubscriber = item.IdSubscriber,
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Code = item.IdSubscriberNavigation.Code ?? "",
                    });
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<bool>> SendMailQuery4_1_1_Fact_ByBill(string to, int idSubscriber, int idUser)
        {
            var response = new Response<bool>();
            var emailDataDto = new EmailDataDTO();
            emailDataDto.EmailKey = "DRR_WORKFLOW_ESP_0041";
            try
            {
                using var context = new SqlCoreContext();
                var userLogin = await context.UserLogins.Where(x => x.Id == idUser).Include(x => x.IdEmployeeNavigation).FirstOrDefaultAsync();
                emailDataDto.BeAuthenticated = true;
                //emailDataDto.From = userLogin.IdEmployeeNavigation.Email;
                //emailDataDto.UserName = userLogin.IdEmployeeNavigation.Email;
                //emailDataDto.Password = userLogin.EmailPassword;
                emailDataDto.From = "diego.rodriguez@del-risco.com";
                emailDataDto.UserName = "diego.rodriguez@del-risco.com";
                emailDataDto.Password = "w*@JHCr7mH"; 
                emailDataDto.IsBodyHTML = true;

                if (to == "all")
                {
                    var subscriberInvoices = await context.SubscriberInvoices
                        .Where(x => x.IdInvoiceState == 2)
                        .Include(x => x.IdSubscriberNavigation)
                        .ToListAsync();
                    var idSubscribers = subscriberInvoices.DistinctBy(x => x.IdSubscriber);
                    foreach (var item in idSubscribers)
                    {
                        emailDataDto.Parameters = new List<string>();
                        var subscriber = await context.Subscribers
                        .Where(x => x.Id == item.IdSubscriber)
                        .Include(x => x.IdAgentNavigation)
                        .FirstOrDefaultAsync();
                        if (subscriber != null)
                        {
                            emailDataDto.To = new List<string>
                        {
                            "jfernandez@del-risco.com",
                            "diego.rodriguez@del-risco.com",
                             //item.IdSubscriberNavigation.SendReportToEmail,
                        };
                            emailDataDto.Table = new List<List<string>>();
                            var tbl = new List<string>();
                            var subscriberInvoice = await context.SubscriberInvoices
                                .Where(x => x.IdInvoiceState == 2 && x.IdSubscriber == item.IdSubscriber)
                                .Include(x => x.IdCurrencyNavigation)
                                .ToListAsync();
                            decimal? totalAmount = 0;
                            string totalAmountSymbol = "";
                            foreach (var item1 in subscriberInvoice)
                            {
                                totalAmountSymbol = item1.IdCurrencyNavigation.Symbol;
                                tbl.Add(item1.InvoiceCode);
                                tbl.Add(StaticFunctions.DateTimeToString(item1.InvoiceEmitDate));
                                tbl.Add(item1.IdCurrencyNavigation.Symbol);
                                tbl.Add(item1.TotalAmount.ToString());
                                totalAmount += item.TotalAmount;
                                emailDataDto.Table.Add(tbl);
                            }

                            emailDataDto.Parameters.Add(subscriber.Name);
                            emailDataDto.Parameters.Add(totalAmount.ToString() + " " + totalAmountSymbol);
                            decimal? discount = 0;
                            string discountSymbol = "";
                            var discounts = new List<AgentInvoice>();
                            if (subscriber.SubscriberType.Contains("CA"))
                            {
                                discounts = await context.AgentInvoices
                                    .Where(x => x.IdInvoiceState == 2 && x.AgentCode.Contains(subscriber.IdAgentNavigation.Code.Trim()))
                                    .Include(x => x.IdCurrencyNavigation)
                                    .ToListAsync();
                                if (discounts != null)
                                {
                                    foreach (var item2 in discounts)
                                    {
                                        discountSymbol = item2.IdCurrencyNavigation.Symbol;
                                        discount += item2.TotalAmount;
                                    }
                                }
                            }
                            emailDataDto.Parameters.Add(discount.ToString() + " " + discountSymbol);
                            emailDataDto.Parameters.Add((totalAmount - discount).ToString() + " " + totalAmountSymbol);
                            emailDataDto.Parameters.Add(userLogin.IdEmployeeNavigation.FirstName + " " + userLogin.IdEmployeeNavigation.LastName);

                            emailDataDto.Subject = "Facturas Pendientes de Cobro - " + subscriber.Code;
                            emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                            _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));
                            await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));
                        }
                    }
                }
                else
                {
                    var subscriber = await context.Subscribers
                        .Where(x => x.Id == idSubscriber)
                        .Include(x => x.IdAgentNavigation)
                        .FirstOrDefaultAsync();
                    if(subscriber != null)
                    {
                        emailDataDto.To = new List<string>
                        {
                            "jfernandez@del-risco.com",
                            "diego.rodriguez@del-risco.com",
                             //item.IdSubscriberNavigation.SendReportToEmail,
                        };
                        emailDataDto.Table = new List<List<string>>();
                        var tbl = new List<string>();
                        var subscriberInvoice = await context.SubscriberInvoices
                            .Where(x => x.IdInvoiceState == 2 && x.IdSubscriber == idSubscriber)
                            .Include(x => x.IdCurrencyNavigation)
                            .ToListAsync();
                        decimal? totalAmount = 0;
                        string totalAmountSymbol = "";
                        foreach (var item in subscriberInvoice)
                        {
                            totalAmountSymbol = item.IdCurrencyNavigation.Symbol;
                            tbl.Add(item.InvoiceCode);
                            tbl.Add(StaticFunctions.DateTimeToString(item.InvoiceEmitDate));
                            tbl.Add(item.IdCurrencyNavigation.Symbol);
                            tbl.Add(item.TotalAmount.ToString());
                            totalAmount += item.TotalAmount;
                            emailDataDto.Table.Add(tbl);
                        }

                        emailDataDto.Parameters.Add(subscriber.Name);
                        emailDataDto.Parameters.Add(totalAmount.ToString() + " " + totalAmountSymbol);
                        decimal? discount = 0;
                        string discountSymbol = "";
                        var discounts = new List<AgentInvoice>();
                        if (subscriber.SubscriberType.Contains("CA"))
                        {
                            discounts = await context.AgentInvoices
                                .Where(x => x.IdInvoiceState == 2 && x.AgentCode.Contains(subscriber.IdAgentNavigation.Code.Trim()))
                                .Include(x => x.IdCurrencyNavigation)
                                .ToListAsync();
                            if(discounts != null)
                            {
                                foreach (var item in discounts)
                                {
                                    discountSymbol = item.IdCurrencyNavigation.Symbol;
                                    discount += item.TotalAmount;
                                }
                            }
                        }
                        emailDataDto.Parameters.Add(discount.ToString() + " " + discountSymbol);
                        emailDataDto.Parameters.Add((totalAmount - discount).ToString() + " " + totalAmountSymbol);
                        emailDataDto.Parameters.Add(userLogin.IdEmployeeNavigation.FirstName + " " + userLogin.IdEmployeeNavigation.LastName);

                        emailDataDto.Subject = "Facturas Pendientes de Cobro - " + subscriber.Code;
                        emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                        _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));
                        await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));
                    }
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

    }
}
