using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using System.Net.Http.Headers;

namespace DRRCore.Application.Main.CoreApplication
{
    public class ChartApplication : IChartApplication
    {
        private readonly ILogger _logger;
        private IMapper _mapper;
        private readonly IReportingDownload _reportingDownload;
        public ChartApplication(ILogger logger, IMapper mapper, IReportingDownload reportingDownload)
        {
            _logger = logger;
            _mapper = mapper;
            _reportingDownload = reportingDownload;

        }

        public async Task<Response<GetQuery5_1_1ResponseDto>> GetQuery5_1_1(string startDate, string endDate)
        {
            var response = new Response<GetQuery5_1_1ResponseDto>();
            response.Data.SubscribersList = new List<GetQuery5_1_1_Subscribers>();
            response.Data.CountriesList = new List<GetQuery5_1_1_Countries>();
            try
            {
                using var context = new SqlCoreContext();
                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);

                var tickets = await context.Tickets
                    .Where(x => x.OrderDate > startDateTime && x.OrderDate < endDateTime)
                    .Include(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                //1
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.SubscribersList.Add(new GetQuery5_1_1_Subscribers
                    {
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Country = item.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? "",
                        Quantity = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count()
                    });
                }

                //2
                var idCountries = tickets.DistinctBy(x => x.IdCountry);
                foreach (var item in idCountries)
                {
                    response.Data.CountriesList.Add(new GetQuery5_1_1_Countries
                    {
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        Quantity = tickets.Where(x => x.IdCountry == item.IdCountry).Count()
                    });
                }

                //3
                response.Data.ProcedureType = new GetQuery5_1_1Procedure
                {
                    T1 = tickets.Where(x => x.ProcedureType.Contains("T1")).Count(),
                    T2 = tickets.Where(x => x.ProcedureType.Contains("T2")).Count(),
                    T3 = tickets.Where(x => x.ProcedureType.Contains("T3")).Count(),
                };
                //4
                response.Data.ReportType = new GetQuery5_1_1Report
                {
                    OR = tickets.Where(x => x.ReportType.Contains("OR")).Count(),
                    RV = tickets.Where(x => x.ReportType.Contains("RV")).Count(),
                    EF = tickets.Where(x => x.ReportType.Contains("EF")).Count(),
                };
                //5
                response.Data.Currency = new GetQuery5_1_1Currency
                {
                    USD = tickets.Where(x => x.IdSubscriberNavigation.IdCurrency == 1).Count(),
                    PEN = tickets.Where(x => x.IdSubscriberNavigation.IdCurrency == 31).Count(),
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetQuery5_1_2ResponseDto>> GetQuery5_1_2(string startDate, string endDate)
        {
            var response = new Response<GetQuery5_1_2ResponseDto>();
            response.Data.SubscribersList = new List<GetQuery5_1_2_Subscribers>();
            response.Data.CountriesList = new List<GetQuery5_1_2_Countries>();
            try
            {
                using var context = new SqlCoreContext();
                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);
                var tickets = await context.Tickets
                    .Where(x => x.DispatchtDate > startDateTime && x.DispatchtDate < endDateTime && 
                    x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                //1
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.SubscribersList.Add(new GetQuery5_1_2_Subscribers
                    {
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Country = item.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? "",
                        Quantity = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count()
                    });
                }

                //2
                var idCountries = tickets.DistinctBy(x => x.IdCountry);
                foreach (var item in idCountries)
                {
                    response.Data.CountriesList.Add(new GetQuery5_1_2_Countries
                    {
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        Quantity = tickets.Where(x => x.IdCountry == item.IdCountry).Count()
                    });
                }

                //3
                response.Data.ProcedureType = new GetQuery5_1_2Procedure
                {
                    T1 = tickets.Where(x => x.ProcedureType.Contains("T1")).Count(),
                    T2 = tickets.Where(x => x.ProcedureType.Contains("T2")).Count(),
                    T3 = tickets.Where(x => x.ProcedureType.Contains("T3")).Count(),
                };
                //4
                response.Data.ReportType = new GetQuery5_1_2Report
                {
                    OR = tickets.Where(x => x.ReportType.Contains("OR")).Count(),
                    RV = tickets.Where(x => x.ReportType.Contains("RV")).Count(),
                    EF = tickets.Where(x => x.ReportType.Contains("EF")).Count(),
                };
                //5
                response.Data.Currency = new GetQuery5_1_2Currency
                {
                    USD = tickets.Where(x => x.IdSubscriberNavigation.IdCurrency == 1).Count(),
                    PEN = tickets.Where(x => x.IdSubscriberNavigation.IdCurrency == 31).Count(),
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<GetQuery5_1_3ResponseDto>>> GetQuery5_1_3(int month, int year)
        {
            var response = new Response<List<GetQuery5_1_3ResponseDto>>();
            response.Data = new List<GetQuery5_1_3ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.DispatchtDate.Value.Month == month && x.DispatchtDate.Value.Year == year && (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion))
                    .Include(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.Add(new GetQuery5_1_3ResponseDto
                    {
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Country = item.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? "",
                    });
                }
            } catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport5_1_3(string format,int month, int year)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_3";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_5_1_3", "", extension)
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

        public async Task<Response<List<GetQuery5_1_4ResponseDto>>> GetQuery5_1_4(int month, int year)
        {
            var response = new Response<List<GetQuery5_1_4ResponseDto>>();
            response.Data = new List<GetQuery5_1_4ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.DispatchtDate.Value.Month == month && x.DispatchtDate.Value.Year == year && (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion))
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.IdPersonNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                tickets.OrderBy(x => x.DispatchtDate);
                foreach (var item in tickets)
                {
                    response.Data.Add(new GetQuery5_1_4ResponseDto
                    {
                        Id = item.Id,
                        Ticket = item.Number.ToString("D6"),
                        OrderDate = StaticFunctions.DateTimeToString(item.OrderDate),
                        DispatchDate = StaticFunctions.DateTimeToString(item.DispatchtDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.ExpireDate),
                        RequestedName = item.RequestedName,
                        Country = item.About == "E" ? item.IdCompanyNavigation.IdCountryNavigation.Iso : item.IdPersonNavigation.IdCountryNavigation.Iso,
                        FlagCountry = item.About == "E" ? item.IdCompanyNavigation.IdCountryNavigation.FlagIso : item.IdPersonNavigation.IdCountryNavigation.FlagIso,
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
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<GetQuery5_1_5ResponseDto>>> GetQuery5_1_5()
        {
            var response = new Response<List<GetQuery5_1_5ResponseDto>>();
            response.Data = new List<GetQuery5_1_5ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscribers = await context.Subscribers.OrderBy(x => x.Code).Include(x => x.IdCountryNavigation).ToListAsync();
                foreach (var item in subscribers)
                {
                    response.Data.Add(new GetQuery5_1_5ResponseDto
                    {
                        Code = item.Code,
                        Name = item.Name,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport5_1_5(string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_5";
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
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_5_1_5", "", extension)
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
        public async Task<Response<List<GetQuery5_1_6ResponseDto>>> GetQuery5_1_6(int month, int year)
        {
            var response = new Response<List<GetQuery5_1_6ResponseDto>>();
            response.Data = new List<GetQuery5_1_6ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets.Where(x => (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion)
                 && x.DispatchtDate.Value.Month == month && x.DispatchtDate.Value.Year == year)
                    .Include(x => x.IdSubscriberNavigation)
                    .ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.Add(new GetQuery5_1_6ResponseDto
                    {
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Country = item.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? "",
                        Total = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count(),
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport5_1_7(string format, string orderBy)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_7";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "orderBy", orderBy },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_5_1_7", "", extension)
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

        public async Task<Response<GetFileResponseDto>> DownloadReport5_1_9(string format, int year)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_9";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_5_1_9", "", extension)
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

        public async Task<Response<List<GetQuery5_1_15ResponseDto>>> GetQuery5_1_15(int idCountry)
        {
            var response = new Response<List<GetQuery5_1_15ResponseDto>>();
            response.Data = new List<GetQuery5_1_15ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscribers = await context.Subscribers
                    .Where(x => x.Enable == true)
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                var idCountries = subscribers.DistinctBy(x => x.IdCountry);
                foreach (var item in idCountries)
                {
                    response.Data.Add(new GetQuery5_1_15ResponseDto
                    {
                        Country = item.IdCountryNavigation.Name ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
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

        public async Task<Response<List<GetQuery5_1_18ResponseDto>>> GetQuery5_1_18(int idCountry, int year)
        {
            var response = new Response<List<GetQuery5_1_18ResponseDto>>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets.Where(x => x.OrderDate.Year == year).ToListAsync();
                if(tickets.Count == 0)
                {
                    response.Message = "No se encontraron informes solicitados en este país.";
                }
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.Add(new GetQuery5_1_18ResponseDto
                    {
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        January = tickets.Where(x => x.OrderDate.Month == 1 && x.IdSubscriber == item.IdSubscriber).Count(),
                        February = tickets.Where(x => x.OrderDate.Month == 2 && x.IdSubscriber == item.IdSubscriber).Count(),
                        March = tickets.Where(x => x.OrderDate.Month == 3 && x.IdSubscriber == item.IdSubscriber).Count(),
                        April = tickets.Where(x => x.OrderDate.Month == 4 && x.IdSubscriber == item.IdSubscriber).Count(),
                        May = tickets.Where(x => x.OrderDate.Month == 5 && x.IdSubscriber == item.IdSubscriber).Count(),
                        June = tickets.Where(x => x.OrderDate.Month == 6 && x.IdSubscriber == item.IdSubscriber).Count(),
                        July = tickets.Where(x => x.OrderDate.Month == 7 && x.IdSubscriber == item.IdSubscriber).Count(),
                        August = tickets.Where(x => x.OrderDate.Month == 8 && x.IdSubscriber == item.IdSubscriber).Count(),
                        September = tickets.Where(x => x.OrderDate.Month == 9 && x.IdSubscriber == item.IdSubscriber).Count(),
                        October = tickets.Where(x => x.OrderDate.Month == 10 && x.IdSubscriber == item.IdSubscriber).Count(),
                        November = tickets.Where(x => x.OrderDate.Month == 11 && x.IdSubscriber == item.IdSubscriber).Count(),
                        December = tickets.Where(x => x.OrderDate.Month == 12 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Total = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count(),

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

        public async Task<Response<GetQuery5_1_19_1ResponseDto>> GetQuery5_1_19Subscriber(int month, int year)
        {
            var response = new Response<GetQuery5_1_19_1ResponseDto>();
            response.Data.Subscribers = new List<GetQuery5_1_19SubscribersResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.OrderDate.Month == month && x.OrderDate.Year == year && x.ProcedureType != "T4")
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    //1
                    response.Data.Subscribers.Add(new GetQuery5_1_19SubscribersResponseDto
                    {
                        IdSubcsriber = item.IdSubscriber,
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Day1 = tickets.Where(x => x.OrderDate.Day == 1 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day2 = tickets.Where(x => x.OrderDate.Day == 2 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day3 = tickets.Where(x => x.OrderDate.Day == 3 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day4 = tickets.Where(x => x.OrderDate.Day == 4 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day5 = tickets.Where(x => x.OrderDate.Day == 5 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day6 = tickets.Where(x => x.OrderDate.Day == 6 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day7 = tickets.Where(x => x.OrderDate.Day == 7 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day8 = tickets.Where(x => x.OrderDate.Day == 8 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day9 = tickets.Where(x => x.OrderDate.Day == 9 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day10 = tickets.Where(x => x.OrderDate.Day == 10 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day11 = tickets.Where(x => x.OrderDate.Day == 11 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day12 = tickets.Where(x => x.OrderDate.Day == 12 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day13 = tickets.Where(x => x.OrderDate.Day == 13 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day14 = tickets.Where(x => x.OrderDate.Day == 14 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day15 = tickets.Where(x => x.OrderDate.Day == 15 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day16 = tickets.Where(x => x.OrderDate.Day == 16 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day17 = tickets.Where(x => x.OrderDate.Day == 17 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day18 = tickets.Where(x => x.OrderDate.Day == 18 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day19 = tickets.Where(x => x.OrderDate.Day == 19 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day20 = tickets.Where(x => x.OrderDate.Day == 20 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day21 = tickets.Where(x => x.OrderDate.Day == 21 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day22 = tickets.Where(x => x.OrderDate.Day == 22 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day23 = tickets.Where(x => x.OrderDate.Day == 23 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day24 = tickets.Where(x => x.OrderDate.Day == 24 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day25 = tickets.Where(x => x.OrderDate.Day == 25 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day26 = tickets.Where(x => x.OrderDate.Day == 26 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day27 = tickets.Where(x => x.OrderDate.Day == 27 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day28 = tickets.Where(x => x.OrderDate.Day == 28 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day29 = tickets.Where(x => x.OrderDate.Day == 29 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day30 = tickets.Where(x => x.OrderDate.Day == 30 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Day31 = tickets.Where(x => x.OrderDate.Day == 31 && x.IdSubscriber == item.IdSubscriber).Count(),
                        Total = tickets.Where(x => x.IdCountry == item.IdSubscriber).Count()
                    });
                }
                //2
                response.Data.ProcedureType = new GetQueryProcedureType
                {
                    T1 = tickets.Where(x => x.ProcedureType == "T1").Count(),
                    T2 = tickets.Where(x => x.ProcedureType == "T2").Count(),
                    T3 = tickets.Where(x => x.ProcedureType == "T3").Count(),
                };
                //3
                response.Data.ReportType = new GetQueryReportType
                {
                    OR = tickets.Where(x => x.ReportType == "OR").Count(),
                    RV = tickets.Where(x => x.ReportType == "RV").Count(),
                    EF = tickets.Where(x => x.ReportType == "EF").Count(),
                    DF = tickets.Where(x => x.ReportType == "DF").Count(),
                };
                //4
                response.Data.Language = new GetQueryLanguage
                {
                    English = tickets.Where(x => x.Language == "I").Count(),
                    Spanish = tickets.Where(x => x.Language == "E").Count(),
                };
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetQuery5_1_19_2ResponseDto>> GetQuery5_1_19Countries(int month, int year)
        {
            var response = new Response<GetQuery5_1_19_2ResponseDto>();
            response.Data.Countries = new List<GetQuery5_1_19CountriesResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.OrderDate.Month == month && x.OrderDate.Year == year && x.ProcedureType != "T4")
                    .Include(x => x.IdCountryNavigation)
                    .ToListAsync();
                var idCountries = tickets.DistinctBy(x => x.IdCountry);
                foreach (var item in idCountries)
                {
                    //1
                    response.Data.Countries.Add(new GetQuery5_1_19CountriesResponseDto
                    {
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        Day1 = tickets.Where(x => x.OrderDate.Day == 1 && x.IdCountry == item.IdCountry).Count(),
                        Day2 = tickets.Where(x => x.OrderDate.Day == 2 && x.IdCountry == item.IdCountry).Count(),
                        Day3 = tickets.Where(x => x.OrderDate.Day == 3 && x.IdCountry == item.IdCountry).Count(),
                        Day4 = tickets.Where(x => x.OrderDate.Day == 4 && x.IdCountry == item.IdCountry).Count(),
                        Day5 = tickets.Where(x => x.OrderDate.Day == 5 && x.IdCountry == item.IdCountry).Count(),
                        Day6 = tickets.Where(x => x.OrderDate.Day == 6 && x.IdCountry == item.IdCountry).Count(),
                        Day7 = tickets.Where(x => x.OrderDate.Day == 7 && x.IdCountry == item.IdCountry).Count(),
                        Day8 = tickets.Where(x => x.OrderDate.Day == 8 && x.IdCountry == item.IdCountry).Count(),
                        Day9 = tickets.Where(x => x.OrderDate.Day == 9 && x.IdCountry  == item.IdCountry).Count(),
                        Day10 = tickets.Where(x => x.OrderDate.Day == 10 && x.IdCountry == item.IdCountry).Count(),
                        Day11 = tickets.Where(x => x.OrderDate.Day == 11 && x.IdCountry == item.IdCountry).Count(),
                        Day12 = tickets.Where(x => x.OrderDate.Day == 12 && x.IdCountry == item.IdCountry).Count(),
                        Day13 = tickets.Where(x => x.OrderDate.Day == 13 && x.IdCountry == item.IdCountry).Count(),
                        Day14 = tickets.Where(x => x.OrderDate.Day == 14 && x.IdCountry == item.IdCountry).Count(),
                        Day15 = tickets.Where(x => x.OrderDate.Day == 15 && x.IdCountry == item.IdCountry).Count(),
                        Day16 = tickets.Where(x => x.OrderDate.Day == 16 && x.IdCountry == item.IdCountry).Count(),
                        Day17 = tickets.Where(x => x.OrderDate.Day == 17 && x.IdCountry == item.IdCountry).Count(),
                        Day18 = tickets.Where(x => x.OrderDate.Day == 18 && x.IdCountry == item.IdCountry).Count(),
                        Day19 = tickets.Where(x => x.OrderDate.Day == 19 && x.IdCountry == item.IdCountry).Count(),
                        Day20 = tickets.Where(x => x.OrderDate.Day == 20 && x.IdCountry == item.IdCountry).Count(),
                        Day21 = tickets.Where(x => x.OrderDate.Day == 21 && x.IdCountry == item.IdCountry).Count(),
                        Day22 = tickets.Where(x => x.OrderDate.Day == 22 && x.IdCountry == item.IdCountry).Count(),
                        Day23 = tickets.Where(x => x.OrderDate.Day == 23 && x.IdCountry == item.IdCountry).Count(),
                        Day24 = tickets.Where(x => x.OrderDate.Day == 24 && x.IdCountry == item.IdCountry).Count(),
                        Day25 = tickets.Where(x => x.OrderDate.Day == 25 && x.IdCountry == item.IdCountry).Count(),
                        Day26 = tickets.Where(x => x.OrderDate.Day == 26 && x.IdCountry == item.IdCountry).Count(),
                        Day27 = tickets.Where(x => x.OrderDate.Day == 27 && x.IdCountry == item.IdCountry).Count(),
                        Day28 = tickets.Where(x => x.OrderDate.Day == 28 && x.IdCountry == item.IdCountry).Count(),
                        Day29 = tickets.Where(x => x.OrderDate.Day == 29 && x.IdCountry == item.IdCountry).Count(),
                        Day30 = tickets.Where(x => x.OrderDate.Day == 30 && x.IdCountry == item.IdCountry).Count(),
                        Day31 = tickets.Where(x => x.OrderDate.Day == 31 && x.IdCountry == item.IdCountry).Count(),
                        Total = tickets.Where(x => x.IdCountry == item.IdCountry).Count()
                    });
                }
                //2
                response.Data.ProcedureType = new GetQueryProcedureType
                {
                    T1 = tickets.Where(x => x.ProcedureType == "T1").Count(),
                    T2 = tickets.Where(x => x.ProcedureType == "T2").Count(),
                    T3 = tickets.Where(x => x.ProcedureType == "T3").Count(),
                };
                //3
                response.Data.ReportType = new GetQueryReportType
                {
                    OR = tickets.Where(x => x.ReportType == "OR").Count(),
                    RV = tickets.Where(x => x.ReportType == "RV").Count(),
                    EF = tickets.Where(x => x.ReportType == "EF").Count(),
                    DF = tickets.Where(x => x.ReportType == "DF").Count(),
                };
                //4
                response.Data.Language = new GetQueryLanguage
                {
                    English = tickets.Where(x => x.Language == "I").Count(),
                    Spanish = tickets.Where(x => x.Language == "E").Count(),
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

        public async Task<Response<GetQuery5_1_20ResponseDto>> GetQuery5_1_20Countries(int month, int year)
        {
            var response = new Response<GetQuery5_1_20ResponseDto>();
            response.Data.Subscribers = new List<GetQuery5_1_20SubscribersResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.DispatchtDate.Value.Month == month && x.DispatchtDate.Value.Year == year && x.ProcedureType != "T4")
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    //1
                    response.Data.Subscribers.Add(new GetQuery5_1_20SubscribersResponseDto
                    {
                        IdSubcsriber = item.IdSubscriber,
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Day1 = tickets.Where(x => x.DispatchtDate.Value.Day == 1 && x.IdCountry == item.IdCountry).Count(),
                        Day2 = tickets.Where(x => x.DispatchtDate.Value.Day == 2 && x.IdCountry == item.IdCountry).Count(),
                        Day3 = tickets.Where(x => x.DispatchtDate.Value.Day == 3 && x.IdCountry == item.IdCountry).Count(),
                        Day4 = tickets.Where(x => x.DispatchtDate.Value.Day == 4 && x.IdCountry == item.IdCountry).Count(),
                        Day5 = tickets.Where(x => x.DispatchtDate.Value.Day == 5 && x.IdCountry == item.IdCountry).Count(),
                        Day6 = tickets.Where(x => x.DispatchtDate.Value.Day == 6 && x.IdCountry == item.IdCountry).Count(),
                        Day7 = tickets.Where(x => x.DispatchtDate.Value.Day == 7 && x.IdCountry == item.IdCountry).Count(),
                        Day8 = tickets.Where(x => x.DispatchtDate.Value.Day == 8 && x.IdCountry == item.IdCountry).Count(),
                        Day9 = tickets.Where(x => x.DispatchtDate.Value.Day == 9 && x.IdCountry == item.IdCountry).Count(),
                        Day10 = tickets.Where(x => x.DispatchtDate.Value.Day == 10 && x.IdCountry == item.IdCountry).Count(),
                        Day11 = tickets.Where(x => x.DispatchtDate.Value.Day == 11 && x.IdCountry == item.IdCountry).Count(),
                        Day12 = tickets.Where(x => x.DispatchtDate.Value.Day == 12 && x.IdCountry == item.IdCountry).Count(),
                        Day13 = tickets.Where(x => x.DispatchtDate.Value.Day == 13 && x.IdCountry == item.IdCountry).Count(),
                        Day14 = tickets.Where(x => x.DispatchtDate.Value.Day == 14 && x.IdCountry == item.IdCountry).Count(),
                        Day15 = tickets.Where(x => x.DispatchtDate.Value.Day == 15 && x.IdCountry == item.IdCountry).Count(),
                        Day16 = tickets.Where(x => x.DispatchtDate.Value.Day == 16 && x.IdCountry == item.IdCountry).Count(),
                        Day17 = tickets.Where(x => x.DispatchtDate.Value.Day == 17 && x.IdCountry == item.IdCountry).Count(),
                        Day18 = tickets.Where(x => x.DispatchtDate.Value.Day == 18 && x.IdCountry == item.IdCountry).Count(),
                        Day19 = tickets.Where(x => x.DispatchtDate.Value.Day == 19 && x.IdCountry == item.IdCountry).Count(),
                        Day20 = tickets.Where(x => x.DispatchtDate.Value.Day == 20 && x.IdCountry == item.IdCountry).Count(),
                        Day21 = tickets.Where(x => x.DispatchtDate.Value.Day == 21 && x.IdCountry == item.IdCountry).Count(),
                        Day22 = tickets.Where(x => x.DispatchtDate.Value.Day == 22 && x.IdCountry == item.IdCountry).Count(),
                        Day23 = tickets.Where(x => x.DispatchtDate.Value.Day == 23 && x.IdCountry == item.IdCountry).Count(),
                        Day24 = tickets.Where(x => x.DispatchtDate.Value.Day == 24 && x.IdCountry == item.IdCountry).Count(),
                        Day25 = tickets.Where(x => x.DispatchtDate.Value.Day == 25 && x.IdCountry == item.IdCountry).Count(),
                        Day26 = tickets.Where(x => x.DispatchtDate.Value.Day == 26 && x.IdCountry == item.IdCountry).Count(),
                        Day27 = tickets.Where(x => x.DispatchtDate.Value.Day == 27 && x.IdCountry == item.IdCountry).Count(),
                        Day28 = tickets.Where(x => x.DispatchtDate.Value.Day == 28 && x.IdCountry == item.IdCountry).Count(),
                        Day29 = tickets.Where(x => x.DispatchtDate.Value.Day == 29 && x.IdCountry == item.IdCountry).Count(),
                        Day30 = tickets.Where(x => x.DispatchtDate.Value.Day == 30 && x.IdCountry == item.IdCountry).Count(),
                        Day31 = tickets.Where(x => x.DispatchtDate.Value.Day == 31 && x.IdCountry == item.IdCountry).Count(),
                        Total = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count()
                    });
                }
                //2
                response.Data.ProcedureType = new GetQueryProcedureType
                {
                    T1 = tickets.Where(x => x.ProcedureType == "T1").Count(),
                    T2 = tickets.Where(x => x.ProcedureType == "T2").Count(),
                    T3 = tickets.Where(x => x.ProcedureType == "T3").Count(),
                };
                //3
                response.Data.ReportType = new GetQueryReportType
                {
                    OR = tickets.Where(x => x.ReportType == "OR").Count(),
                    RV = tickets.Where(x => x.ReportType == "RV").Count(),
                    EF = tickets.Where(x => x.ReportType == "EF").Count(),
                    DF = tickets.Where(x => x.ReportType == "DF").Count(),
                };
                //4
                response.Data.Language = new GetQueryLanguage
                {
                    English = tickets.Where(x => x.Language == "I").Count(),
                    Spanish = tickets.Where(x => x.Language == "E").Count(),
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

        public async Task<Response<List<GetQuery5_1_21ResponseDto>>> GetQuery5_1_21(int month, int year)
        {
            var response = new Response<List<GetQuery5_1_21ResponseDto>>();
            response.Data = new List<GetQuery5_1_21ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets
                    .Where(x => x.DispatchtDate.Value.Month == month && x.DispatchtDate.Value.Year == year && x.ProcedureType != "T4")
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                var idSubscribers = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscribers)
                {
                    response.Data.Add(new GetQuery5_1_21ResponseDto
                    {
                        IdSubcsriber = item.IdSubscriber,
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Code = item.IdSubscriberNavigation.Code ?? "",

                        T1 = tickets.Where(x => x.ProcedureType == "T1").Count(),
                        T2 = tickets.Where(x => x.ProcedureType == "T2").Count(),
                        T3 = tickets.Where(x => x.ProcedureType == "T3").Count(),

                        OR = tickets.Where(x => x.ReportType == "OR").Count(),
                        RV = tickets.Where(x => x.ReportType == "RV").Count(),
                        EF = tickets.Where(x => x.ReportType == "EF").Count(),
                        DF = tickets.Where(x => x.ReportType == "DF").Count(),

                        QualityA = tickets.Where(x => x.Quality == "A").Count(),
                        QualityB = tickets.Where(x => x.Quality == "B").Count(),
                        QualityC = tickets.Where(x => x.Quality == "C").Count(),

                        Total = tickets.Count()
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

        public async Task<Response<List<GetQuery5_1_26ResponseDto>>> GetQuery5_1_26(int idCountry)
        {
            var response = new Response<List<GetQuery5_1_26ResponseDto>>();
            response.Data = new List<GetQuery5_1_26ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets.Where(x => x.IdCountry == idCountry && x.Quality != null && (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion)).OrderBy(x => x.DispatchtDate).ToListAsync();
                var years =  new List<int>();
                foreach (var item in tickets)
                {
                    years.Add(item.DispatchtDate.Value.Year);
                }
                foreach (var item in years.Distinct())
                {
                    response.Data.Add(new GetQuery5_1_26ResponseDto
                    {
                        Year = item,
                        QualityA = tickets.Where(x => x.DispatchtDate.Value.Year == item && x.Quality.Contains("A")).Count(),
                        QualityB = tickets.Where(x => x.DispatchtDate.Value.Year == item && x.Quality.Contains("B")).Count(),
                        QualityC = tickets.Where(x => x.DispatchtDate.Value.Year == item && x.Quality.Contains("C")).Count(),
                        Total = tickets.Where(x => x.DispatchtDate.Value.Year == item).Count()
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

        public async Task<Response<List<GetQuery5_1_27ResponseDto>>> GetQuery5_1_27(int year)
        {
            var response = new Response<List<GetQuery5_1_27ResponseDto>>();
            response.Data = new List<GetQuery5_1_27ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = await context.Tickets.Where(x => x.Quality != null && x.DispatchtDate.Value.Year == year
                && (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion))
                    .Include(x => x.IdCountryNavigation)
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                var idSubscriber = tickets.DistinctBy(x => x.IdSubscriber);
                foreach (var item in idSubscriber)
                {
                    response.Data.Add(new GetQuery5_1_27ResponseDto
                    {
                        IdSubscriber = item.IdSubscriber,
                        Code = item.IdSubscriberNavigation.Code ?? "",
                        Name = item.IdSubscriberNavigation.Name ?? "",
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        T1 = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.ProcedureType == "T1").Count(),
                        T2 = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.ProcedureType == "T2").Count(),
                        T3 = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.ProcedureType == "T3").Count(),
                        OR = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.ReportType == "OR").Count(),
                        RV = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.ReportType == "RV").Count(),
                        EF = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.ReportType == "EF").Count(),
                        DF = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.ReportType == "DF").Count(),
                        QualityA = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.Quality.Contains("A")).Count(),
                        QualityB = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.Quality.Contains("B")).Count(),
                        QualityC = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.Quality.Contains("C")).Count(),
                        English = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.Language == "I").Count(),
                        Spanish = tickets.Where(x => x.IdSubscriber == item.IdSubscriber && x.Language == "E").Count(),
                        Total = tickets.Where(x => x.IdSubscriber == item.IdSubscriber).Count()
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

        public async Task<Response<List<GetQuery5_2_1ResponseDto>>> GetQuery5_2_1(string startDate, string endDate, string reporter)
        {
            var response = new Response<List<GetQuery5_2_1ResponseDto>>();
            response.Data = new List<GetQuery5_2_1ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();

                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);

                var asignations = await context.TicketHistories.Where(x => x.StartDate > startDateTime && x.StartDate < endDateTime && x.AsignedTo.Contains(reporter) && x.AsignationType == "RP")
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                foreach (var item in asignations)
                {
                    response.Data.Add(new GetQuery5_2_1ResponseDto
                    {
                        IdTicket = item.IdTicket,
                        Ticket = item.IdTicketNavigation.Number.ToString("D6"),
                        OrderDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.OrderDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.ExpireDate),
                        ShippingDate = item.ShippingDate != null ? StaticFunctions.DateTimeToString(item.ShippingDate) : "",
                        RequestedName = item.IdTicketNavigation.RequestedName ?? "",
                        Country = item.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                        ProcedureType = item.IdTicketNavigation.ProcedureType ?? "",
                        ReportType = item.IdTicketNavigation.ReportType ?? "",
                        Subscriber = item.IdTicketNavigation.IdSubscriberNavigation.Code ?? "",
                        Price = 0
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

        public async Task<Response<List<GetQuery5_2_2ResponseDto>>> GetQuery5_2_2(string reporter)
        {
            var response = new Response<List<GetQuery5_2_2ResponseDto>>();
            response.Data = new List<GetQuery5_2_2ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var asignations = await context.TicketHistories.Where(x => x.Flag == false && x.AsignedTo.Contains(reporter) && x.AsignationType == "RP" && (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int?)TicketStatusEnum.Despachado_con_Observacion))
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in asignations)
                {
                    response.Data.Add(new GetQuery5_2_2ResponseDto
                    {
                        IdTicket = item.IdTicket,
                        RequestedName = item.IdTicketNavigation.RequestedName ?? "",
                        OrderDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.OrderDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.EndDate),
                        Country = item.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                        ProcedureType = item.IdTicketNavigation.ProcedureType ?? "",
                        ReportType = item.IdTicketNavigation.ReportType ?? "",
                        Subscriber = item.IdTicketNavigation.IdSubscriberNavigation.Code ?? ""  
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

        public async Task<Response<List<GetQuery5_2_3ResponseDto>>> GetQuery5_2_3(string startDate, string endDate, string reporter)
        {
            var response = new Response<List<GetQuery5_2_3ResponseDto>>();
            response.Data = new List<GetQuery5_2_3ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var asignations = await context.TicketHistories.Where(x => x.Flag == true && x.AsignedTo.Contains(reporter) && x.AsignationType == "RP" && x.ShippingDate != null)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in asignations)
                {
                    response.Data.Add(new GetQuery5_2_3ResponseDto
                    {
                        IdTicket = item.IdTicket,
                        IdTicketHistory = item.Id,
                        RequestedName = item.IdTicketNavigation.RequestedName ?? "",
                        Country = item.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                        Subscriber = item.IdTicketNavigation.IdSubscriberNavigation.Code ?? "",
                        OrderDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.OrderDate),
                        ShippingDate = StaticFunctions.DateTimeToString(item.ShippingDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.EndDate),
                        ProcedureType = item.IdTicketNavigation.ProcedureType ?? "",
                        ReportType = item.IdTicketNavigation.ReportType ?? "",
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

        public async Task<Response<List<GetQuery5_2_4ResponseDto>>> GetQuery5_2_4(int month, int year)
        {
            var response = new Response<List<GetQuery5_2_4ResponseDto>>();
            response.Data = new List<GetQuery5_2_4ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var asignations = await context.TicketHistories
                    .Where(x => x.Flag == true && x.ShippingDate != null && x.ShippingDate.Value.Month == month &&
                    x.ShippingDate.Value.Year == year && x.AsignedTo.Contains("R") && x.AsignedTo.Contains("C") == false && x.AsignationType == "RP")
                    .Include(x => x.IdTicketNavigation)
                    .ToListAsync();
                foreach (var item in asignations)
                {
                    var personal = await context.Personals.Where(x => x.Code.Contains(item.AsignedTo))
                        .Include(x => x.IdEmployeeNavigation)
                        .FirstOrDefaultAsync();
                    response.Data.Add(new GetQuery5_2_4ResponseDto
                    {
                        AsignedTo = item.AsignedTo,
                        Name = personal != null ? personal.IdEmployeeNavigation.FirstName : "",
                        T1 = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.ProcedureType.Contains("T1")).Count(),
                        T2 = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.ProcedureType.Contains("T2")).Count(),
                        T3 = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.ProcedureType.Contains("T3")).Count(),
                        OR = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.ReportType.Contains("OR")).Count(),
                        RV = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.ReportType.Contains("RV")).Count(),
                        EF = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.ReportType.Contains("EF")).Count(),
                        DF = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.ReportType.Contains("DF")).Count(),
                        QualityA = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.Quality.Contains("A")).Count(),
                        QualityB = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.Quality.Contains("B")).Count(),
                        QualityC = asignations.Where(x => x.AsignedTo == item.AsignedTo && x.IdTicketNavigation.Quality.Contains("C")).Count(),
                        Total = asignations.Where(x => x.AsignedTo == item.AsignedTo).Count(),
                    });
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

        public async Task<Response<List<GetQuery5_3_2ResponseDto>>> GetQuery5_3_2(string agent, string startDate, string endDate)
        {
            var response = new Response<List<GetQuery5_3_2ResponseDto>>();
            response.Data = new List<GetQuery5_3_2ResponseDto>();
            try
            {
                using var context = new SqlCoreContext();

                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);

                var ticketHistory = await context.TicketHistories
                    .Where(x => x.AsignationType == "AG" && x.AsignedTo.Contains(agent) && x.StartDate > startDateTime && x.EndDate < endDateTime)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                foreach (var item in ticketHistory)
                {
                    response.Data.Add(new GetQuery5_3_2ResponseDto
                    {
                        Id = item.Id,
                        OrderDate = StaticFunctions.DateTimeToString(item.StartDate),
                        ExpireDate = StaticFunctions.DateTimeToString(item.EndDate),
                        ShippingDate = StaticFunctions.DateTimeToString(item.ShippingDate),
                        RequestedName = item.IdTicketNavigation.RequestedName ?? "",
                        Country = item.IdTicketNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "",
                        ProcedureType = item.IdTicketNavigation.ProcedureType ?? "",
                        ReportType = item.IdTicketNavigation.ReportType ?? "",
                        Subscriber = item.IdTicketNavigation.IdSubscriberNavigation.Code ?? "",
                        Price = 0
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
    }
}
