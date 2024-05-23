using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace DRRCore.Application.Main.CoreApplication
{
    public class QueryApplication : IQueryApplication
    {
        private readonly ILogger _logger;
        private IMapper _mapper;
        public QueryApplication(ILogger logger, IMapper mapper) 
        {
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<Response<List<GetQuery1_1ByMonthResponseDto>>> GetQuery1_1ByMonth(int month, int idSubscriber)
        {
            var response = new Response<List<GetQuery1_1ByMonthResponseDto>>();
            response.Data = new List<GetQuery1_1ByMonthResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoice = await context.SubscriberInvoices
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Where(x => x.IdSubscriber == idSubscriber && x.InvoiceEmitDate.Value.Month == month)
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
                        Country = item.IdCountryNavigation != null ? item.IdCountryNavigation.Name : "",
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

        public async Task<Response<GetQuery1_4ResponseDto>> GetQuery1_4(int idSubscriber, int year)
        {
            var response = new Response<GetQuery1_4ResponseDto>();
            var query4ByCountries = new List<GetQuery1_4ByCountryResponseDto>();
            var query4ByProcedureType = new GetQuery1_4ByProcedureTypeResponseDto();
            var query4ByReportType = new GetQuery1_4ByReportTypeResponseDto();
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
                        Country = item.IdCountryNavigation != null ? item.IdCountryNavigation.Name : "",
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
                    query4ByProcedureType = new GetQuery1_4ByProcedureTypeResponseDto
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
                        Total = tickets.Where(x => x.OrderDate.Year == year).ToList().Count,
                    };
                }

                //3
                var reportTypes = tickets.DistinctBy(x => x.ReportType);
                foreach (var item in reportTypes)
                {
                    query4ByReportType = new GetQuery1_4ByReportTypeResponseDto
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
                        Total = tickets.Where(x => x.OrderDate.Year == year).ToList().Count,
                    };
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
                    .Include(x => x.IdSubscriberNavigation)
                    .Include(x => x.IdCountryNavigation)
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

        public async Task<Response<List<GetQuery1_8ResponseDto>>> GetQuery1_8(int year, int month)
        {
            var response = new Response<List<GetQuery1_8ResponseDto>>();
            response.Data = new List<GetQuery1_8ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var invoicedTickets = await context.SubscriberInvoices
                    .Where(x => x.InvoiceEmitDate.Value.Year == year)
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
                foreach (var item in tickets)
                {
                    response.Data.Add(new GetQuery1_9ResponseDto
                    {
                        IdSubscriber = item.IdSubscriber,
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Quantity = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count(),
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
    }
}
