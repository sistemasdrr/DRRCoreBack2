
using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Email;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using DRRCore.Transversal.Common.JsonReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DRRCore.Application.Main.CoreApplication
{
    public class InvoiceApplication : IInvoiceApplication
    {
        private readonly List<Transversal.Common.JsonReader.SpecialPriceAgent> _specialPriceAgent;
        private IEmailHistoryDomain _emailHistoryDomain;
        private readonly IMailFormatter _mailFormatter;
        private readonly IAttachmentsNotSendDomain _attachmentsNotSendDomain;
        private readonly IEmailConfigurationDomain _emailConfigurationDomain;
        private readonly IMailSender _mailSender;
        private readonly IReportingDownload _reportingDownload;
        private readonly ILogger _logger;
        private IMapper _mapper;
        public InvoiceApplication(ILogger logger, IMapper mapper, IOptions<List<Transversal.Common.JsonReader.SpecialPriceAgent>> specialPriceAgent, IEmailConfigurationDomain emailConfigurationDomain,
            IReportingDownload reportingDownload, IMailSender mailSender, IEmailHistoryDomain emailHistoryDomain, IMailFormatter mailFormatter, IAttachmentsNotSendDomain attachmentsNotSendDomain)
        {
            _logger = logger;
            _mapper = mapper;
            _specialPriceAgent = specialPriceAgent.Value;
            _reportingDownload = reportingDownload;
            _mailSender = mailSender;
            _emailHistoryDomain = emailHistoryDomain;
            _mailFormatter = mailFormatter;
            _attachmentsNotSendDomain = attachmentsNotSendDomain;
            _emailConfigurationDomain = emailConfigurationDomain;
        }
        private decimal? GetAgentPrice(string about, string procedureType, string quality, int? idCountry, Agent agent)
        {
            if(agent.SpecialPrice == false)
            {
                var agentPrice = new AgentPrice();
                if (procedureType == "T1")
                {
                    agentPrice = agent.AgentPrices.Where(x => x.IdCountry == idCountry).FirstOrDefault();
                    return agentPrice != null ? agentPrice.PriceT1 : 0;
                }
                else if (procedureType == "T2")
                {
                    agentPrice = agent.AgentPrices.Where(x => x.IdCountry == idCountry).FirstOrDefault();
                    return agentPrice != null ? agentPrice.PriceT2 : 0;
                }
                else if (procedureType == "T3")
                {
                    agentPrice = agent.AgentPrices.Where(x => x.IdCountry == idCountry).FirstOrDefault();
                    return agentPrice != null ? agentPrice.PriceT3 : 0;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if(quality != null && _specialPriceAgent.Where(x => x.CodeAgent == agent.Code).FirstOrDefault()?.QualityAgent?.Where(x => x.Quality == quality.Trim()).FirstOrDefault()?.Price != null)
                {
                    var price = _specialPriceAgent.Where(x => x.CodeAgent == agent.Code).FirstOrDefault().QualityAgent.Where(x => x.Quality == quality.Trim()).FirstOrDefault().Price;
                    return procedureType == "T1" ? price.T1 : procedureType == "T2" ? price.T2 : procedureType == "T3" ? price.T3 : 0;
                }
                else
                {
                    return 0;
                }  
            }
        }

        public async Task<Response<List<GetInvoiceAgentListResponseDto>>> GetByBillInvoiceAgentList(string startDate, string endDate)
        {
            var response = new Response<List<GetInvoiceAgentListResponseDto>>();
            response.Data = new List<GetInvoiceAgentListResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = new List<TicketHistory>();
                
                    var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                    var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);

                    ticketHistory = await context.TicketHistories
                        .Include(x => x.IdTicketNavigation)
                        .Include(x => x.IdTicketNavigation.IdCountryNavigation)
                        .Include(x => x.IdTicketNavigation.IdCompanyNavigation)
                        .Include(x => x.IdTicketNavigation.IdPersonNavigation)
                        .Where(x => x.ShippingDate >= startDateTime && x.ShippingDate <= endDateTime && x.Flag == true && x.FlagInvoice == false && !x.AsignedTo.Contains("P") && x.AsignedTo.Contains("A") && x.IdTicketNavigation.Quality != null && x.IdTicketNavigation.Quality != "")
                        .ToListAsync();
                    foreach (var item in ticketHistory)
                    {
                        var agent1 = new Agent();
                        var agent2 = new Domain.Entities.SqlCoreContext.Personal();
                        agent1 = await context.Agents
                            .Include(x => x.AgentPrices)
                            .Where(x => x.Code == item.AsignedTo.Trim()).FirstOrDefaultAsync();
                        if(agent1 != null)
                        {
                            response.Data.Add(new GetInvoiceAgentListResponseDto
                            {
                                IdTicket = item.IdTicket,
                                IdTicketHistory = item.Id,
                                Number = item.IdTicketNavigation.Number.ToString("D6"),
                                RequestedName = item.IdTicketNavigation.RequestedName.IsNullOrEmpty() == false ? item.IdTicketNavigation.RequestedName : item.IdTicketNavigation.BusineesName,
                                DispatchedName = item.IdTicketNavigation.DispatchedName,
                                OrderDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.OrderDate),
                                ExpireDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.ExpireDate),
                                ShippingDate = StaticFunctions.DateTimeToString(item.ShippingDate),
                                ProcedureType = item.IdTicketNavigation.ProcedureType,
                                ReportType = item.IdTicketNavigation.ReportType,
                                IdCountry = item.IdTicketNavigation.IdCountry,
                                Country = item.IdTicketNavigation.IdCountry != null ? item.IdTicketNavigation.IdCountryNavigation.Iso : "",
                                FlagCountry = item.IdTicketNavigation.IdCountry != null ? item.IdTicketNavigation.IdCountryNavigation.FlagIso : "",
                                IdAgent = agent1.Id,
                                AgentName = agent1.Name,
                                AgentCode = item.AsignedTo,
                                Quality = item.IdTicketNavigation.Quality ?? "",
                                Price = item.IdTicketNavigation.About == "E" ? GetAgentPrice(item.IdTicketNavigation.About,item.IdTicketNavigation.ProcedureType,item.IdTicketNavigation.Quality,item.IdTicketNavigation.IdCompanyNavigation.IdCountry,agent1) 
                                : GetAgentPrice(item.IdTicketNavigation.About, item.IdTicketNavigation.ProcedureType, item.IdTicketNavigation.Quality, item.IdTicketNavigation.IdPersonNavigation.IdCountry, agent1),
                            });
                        }
                        else
                        {
                            agent2 = await context.Personals.Where(x => x.Code == item.AsignedTo.Trim())
                                .Include(x => x.IdEmployeeNavigation)
                                .Include(x => x.IdEmployeeNavigation.UserLogins).FirstOrDefaultAsync();
                            if(agent2 != null)
                            {
                                response.Data.Add(new GetInvoiceAgentListResponseDto
                                {
                                    IdTicket = item.IdTicket,
                                    IdTicketHistory = item.Id,
                                    Number = item.IdTicketNavigation.Number.ToString("D6"),
                                    RequestedName = item.IdTicketNavigation.RequestedName.IsNullOrEmpty() == false ? item.IdTicketNavigation.RequestedName : item.IdTicketNavigation.BusineesName,
                                    DispatchedName = item.IdTicketNavigation.DispatchedName,
                                    OrderDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.OrderDate),
                                    ExpireDate = StaticFunctions.DateTimeToString(item.IdTicketNavigation.ExpireDate),
                                    ShippingDate = StaticFunctions.DateTimeToString(item.ShippingDate),
                                    ProcedureType = item.IdTicketNavigation.ProcedureType,
                                    ReportType = item.IdTicketNavigation.ReportType,
                                    IdCountry = item.IdTicketNavigation.IdCountry,
                                    Country = item.IdTicketNavigation.IdCountry != null ? item.IdTicketNavigation.IdCountryNavigation.Name : "",
                                    FlagCountry = item.IdTicketNavigation.IdCountry != null ? item.IdTicketNavigation.IdCountryNavigation.FlagIso : "",
                                    IdAgent = agent2.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id,
                                    AgentName = item.AsignedTo,
                                    AgentCode = item.AsignedTo,
                                });
                            }
                        }
                        //response.Data = _mapper.Map<List<GetInvoiceAgentListResponseDto>>(ticketHistory);
                    }
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        

        public async Task<Response<bool>> UpdateAgentTicket(int idTicketHistory, string requestedName, string procedureType,  string shippingDate, string quality, bool hasBalance, int? idSpecialPrice)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories
                    .Where(x => x.Id == idTicketHistory)
                    .Include(x => x.IdTicketNavigation)
                    .FirstOrDefaultAsync();
                if(ticketHistory != null)
                {
                    if(hasBalance == true && idSpecialPrice != null)
                    {
                        ticketHistory.IdTicketNavigation.IdSpecialAgentBalancePrice = idSpecialPrice != 0 ? idSpecialPrice : null;
                    }
                    if(ticketHistory.IdTicketNavigation.Quality.Trim() != quality.Trim())
                    {
                        ticketHistory.IdTicketNavigation.Quality = quality.Trim();
                    }
                    ticketHistory.IdTicketNavigation.RequestedName = requestedName;
                    ticketHistory.IdTicketNavigation.ProcedureType = procedureType;
                    ticketHistory.IdTicketNavigation.UpdateDate = DateTime.Now;
                    ticketHistory.ShippingDate = StaticFunctions.VerifyDate(shippingDate);
                    ticketHistory.UpdateDate = DateTime.Now;
                    //precio
                    context.TicketHistories.Update(ticketHistory);
                    await context.SaveChangesAsync();
                }
                else
                {
                    response.IsSuccess = false;
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> SaveAgentInvoice(AddOrUpdateAgentInvoiceRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var invoiceAgentDetails = new List<AgentInvoiceDetail>();
                decimal? totalAmount = 0;
                foreach (var item in obj.InvoiceAgentList)
                {
                    totalAmount += item.Price;
                    invoiceAgentDetails.Add(new AgentInvoiceDetail
                    {
                        Id = 0,
                        IdTicketHistory = item.IdTicketHistory,
                        Amount = item.Price,
                    });
                    var ticketHistory = await context.TicketHistories.Where(x => x.Id == item.IdTicketHistory).FirstOrDefaultAsync();
                    if(ticketHistory != null)
                    {
                        ticketHistory.FlagInvoice = true;
                        context.TicketHistories.Update(ticketHistory);
                    }
                }
                await context.AgentInvoices.AddAsync(new AgentInvoice
                {
                    IdInvoiceState = 2,
                    InvoiceCode = obj.InvoiceCode,
                    InvoiceEmitDate = obj.InvoiceDate,
                    IdAgent = obj.IdAgent,
                    AgentCode = obj.AgentCode,
                    IdCurrency = obj.IdCurrency,
                    Quantity = obj.InvoiceAgentList.Count(),
                    TotalAmount = totalAmount,
                    AgentInvoiceDetails = invoiceAgentDetails
                });
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<List<GetAgentInvoiceListResponseDto>>> GetToCollectInvoiceAgentList(string startDate, string endDate)
        {
            var response = new Response<List<GetAgentInvoiceListResponseDto>>();
            response.Data = new List<GetAgentInvoiceListResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);
                var agentInvoice = await context.AgentInvoices
                    .Include(x => x.IdAgentNavigation)
                    .Include(x => x.AgentInvoiceDetails)
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation)
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation).ThenInclude(x => x.IdTicketNavigation)
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Where(x => x.InvoiceEmitDate > startDateTime && x.InvoiceEmitDate < endDateTime && x.IdInvoiceState == 2).ToListAsync();
                foreach (var item in agentInvoice)
                {
                    var details = new List<AgentInvoiceDetailsDto>();
                    foreach (var item1 in item.AgentInvoiceDetails)
                    {
                        details.Add(new AgentInvoiceDetailsDto
                        {
                            Id = item1.Id,
                            IdAgentInvoice = item1.IdAgentInvoice,
                            RequestedName = item1.IdTicketHistoryNavigation.IdTicketNavigation.RequestedName,
                            BusinessName = item1.IdTicketHistoryNavigation.IdTicketNavigation.BusineesName,
                            OrderDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.StartDate),
                            ShippingDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.ShippingDate),
                            ExpireDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.EndDate),
                            IdCountry = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountry,
                            Country = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountryNavigation.Iso,
                            FlagCountry = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountryNavigation.FlagIso,
                            ProcedureType = item1.IdTicketHistoryNavigation.IdTicketNavigation.ProcedureType,
                            Quality = item1.IdTicketHistoryNavigation.IdTicketNavigation.Quality,
                            Price = item1.Amount
                        });
                    }
                    response.Data.Add(new GetAgentInvoiceListResponseDto
                    {
                        Id = item.Id,
                        InvoiceCode = item.InvoiceCode,
                        IdAgent = item.IdAgent,
                        AgentCode = item.IdAgentNavigation.Code,
                        AgentName = item.IdAgentNavigation.Name,
                        IdCurrency = item.IdCurrency,
                        Details = details
                    });
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<List<GetAgentInvoiceListResponseDto>>> GetPaidsInvoiceAgentList(string startDate, string endDate)
        {
            var response = new Response<List<GetAgentInvoiceListResponseDto>>();
            response.Data = new List<GetAgentInvoiceListResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);
                var agentInvoice = await context.AgentInvoices
                    .Include(x => x.IdAgentNavigation)
                    .Include(x => x.AgentInvoiceDetails)
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation)
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation).ThenInclude(x => x.IdTicketNavigation)
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(x => x.IdTicketHistoryNavigation).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Where(x => x.InvoiceEmitDate > startDateTime && x.InvoiceEmitDate < endDateTime && x.IdInvoiceState == 3).ToListAsync();
                foreach (var item in agentInvoice)
                {
                    var details = new List<AgentInvoiceDetailsDto>();
                    foreach (var item1 in item.AgentInvoiceDetails)
                    {
                        details.Add(new AgentInvoiceDetailsDto
                        {
                            Id = item1.Id,
                            IdAgentInvoice = item1.IdAgentInvoice,
                            RequestedName = item1.IdTicketHistoryNavigation.IdTicketNavigation.RequestedName,
                            BusinessName = item1.IdTicketHistoryNavigation.IdTicketNavigation.BusineesName,
                            OrderDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.StartDate),
                            ShippingDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.ShippingDate),
                            ExpireDate = StaticFunctions.DateTimeToString(item1.IdTicketHistoryNavigation.EndDate),
                            IdCountry = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountry,
                            Country = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountryNavigation.Iso,
                            FlagCountry = item1.IdTicketHistoryNavigation.IdTicketNavigation.IdCountryNavigation.FlagIso,
                            ProcedureType = item1.IdTicketHistoryNavigation.IdTicketNavigation.ProcedureType,
                            Quality = item1.IdTicketHistoryNavigation.IdTicketNavigation.Quality,
                            Price = item1.Amount
                        });
                    }
                    response.Data.Add(new GetAgentInvoiceListResponseDto
                    {
                        Id = item.Id,
                        InvoiceCode = item.InvoiceCode,
                        IdAgent = item.IdAgent,
                        AgentCode = item.IdAgentNavigation.Code,
                        AgentName = item.IdAgentNavigation.Name,
                        IdCurrency = item.IdCurrency,
                        Details = details
                    });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> UpdateInvoiceToCollect(int idAgentInvoice, int idAgentInvoiceDetails, string requestedName, string procedureType, string shippingDate, decimal price)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var agentInvoice = await context.AgentInvoices
                    .Where(w => w.Id == idAgentInvoice)
                    .Include(x => x.AgentInvoiceDetails).ThenInclude(y => y.IdTicketHistoryNavigation).ThenInclude(z => z.IdTicketNavigation)
                    .FirstOrDefaultAsync();
                if (agentInvoice != null)
                {
                    decimal? newTotalPrice = 0;
                    agentInvoice.AgentInvoiceDetails.Where(x => x.Id == idAgentInvoiceDetails).FirstOrDefault().Amount = price;
                    agentInvoice.AgentInvoiceDetails.Where(x => x.Id == idAgentInvoiceDetails).FirstOrDefault().IdTicketHistoryNavigation.ShippingDate = StaticFunctions.VerifyDate(shippingDate);
                    agentInvoice.AgentInvoiceDetails.Where(x => x.Id == idAgentInvoiceDetails).FirstOrDefault().IdTicketHistoryNavigation.IdTicketNavigation.RequestedName = requestedName;
                    agentInvoice.AgentInvoiceDetails.Where(x => x.Id == idAgentInvoiceDetails).FirstOrDefault().IdTicketHistoryNavigation.IdTicketNavigation.ProcedureType = procedureType;
                    foreach (var item in agentInvoice.AgentInvoiceDetails)
                    {
                        newTotalPrice += item.Amount;
                    }
                    agentInvoice.TotalAmount = newTotalPrice;
                    agentInvoice.UpdateDate = DateTime.Now;
                    //precio
                    context.AgentInvoices.Update(agentInvoice);
                    await context.SaveChangesAsync();
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> CancelAgentInvoiceToCollect(int idAgentInvoice, string cancelDate)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var agentInvoice = await context.AgentInvoices.Where(x => x.Id == idAgentInvoice).FirstOrDefaultAsync();
                if(agentInvoice != null)
                {
                    agentInvoice.IdInvoiceState = 3;
                    agentInvoice.InvoiceCancelDate = StaticFunctions.VerifyDate(cancelDate);
                    agentInvoice.UpdateDate = DateTime.Now;
                    context.AgentInvoices.Update(agentInvoice);
                    await context.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetInvoiceSubscriberListByBillResponseDto>>> GetInvoiceSubscriberListByBill(string startDate, string endDate)
        {
            var response = new Response<List<GetInvoiceSubscriberListByBillResponseDto>>();
            try
            {
                using var context = new SqlCoreContext();
                var tickets = new List<Ticket>();
                
                    var startDateTime = StaticFunctions.VerifyDate(startDate)?.Date.AddTicks(-1);
                    var endDateTime = StaticFunctions.VerifyDate(endDate)?.Date.AddDays(1).AddTicks(-1);

                    tickets = await context.Tickets
                        .Include(x => x.IdSubscriberNavigation)
                        .Include(x => x.IdCountryNavigation)
                        .Where(x => x.DispatchtDate >= startDateTime && x.DispatchtDate <= endDateTime && x.IdInvoiceState == 1 && x.IdSubscriberNavigation.FacturationType == "FM" &&
                                    (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int)TicketStatusEnum.Despachado_con_Observacion))
                        .ToListAsync();
                if (tickets != null && tickets.Any())
                {
                    response.Data = _mapper.Map<List<GetInvoiceSubscriberListByBillResponseDto>>(tickets);
                }
                else
                {
                    response.Message = "No se encontraron pedidos";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<List<GetInvoiceSubscriberCCListByBillResponseDto>>> GetInvoiceSubscriberCCListByBill(int month, int year)
        {
            var response = new Response<List<GetInvoiceSubscriberCCListByBillResponseDto>>();
            response.Data = new List<GetInvoiceSubscriberCCListByBillResponseDto>();
            try
            {
                using var context = new SqlCoreContext();

                var subscribers = await context.CouponBillingSubscribers
                    .Include(x => x.CouponBillingSubscriberHistories)
                    .Include(x => x.IdSubscriberNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Where(x => x.CouponBillingSubscriberHistories.Any(x => x.Type == "I" && x.PurchaseDate.Value.Month == month && x.PurchaseDate.Value.Year == year && x.State == "PF"))
                    .ToListAsync();

                foreach (var subscriber in subscribers)
                {
                    var list = new List<InvoiceSubscriberCCHistory>();
                    foreach(var history in subscriber.CouponBillingSubscriberHistories)
                    {
                        if(history.Type == "I" && history.PurchaseDate.Value.Month == month && history.PurchaseDate.Value.Year == year && history.State == "PF")
                        {
                            list.Add(new InvoiceSubscriberCCHistory
                            {
                                Id = history.Id,
                                CouponAmount = history.CouponAmount,
                                UnitPrice = history.TotalPrice / history.CouponAmount,
                                TotalPrice = history.TotalPrice,
                                PurchaseDate = StaticFunctions.DateTimeToString(history.PurchaseDate)
                            });

                        }
                      
                    }
                    response.Data.Add(new GetInvoiceSubscriberCCListByBillResponseDto
                    {
                        IdSubscriber = subscriber.IdSubscriber,
                        Name = subscriber.IdSubscriberNavigation.Name,
                        Code = subscriber.IdSubscriberNavigation.Code,
                        Country = subscriber.IdSubscriberNavigation.IdCountryNavigation.Iso ?? "",
                        FlagCountry = subscriber.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? "",
                        History = list
                    });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<List<GetInvoiceSubscriberListToCollectResponseDto>>> GetInvoiceSubscriberListToCollect(int month, int year)
        {
            var response = new Response<List<GetInvoiceSubscriberListToCollectResponseDto>>();
            response.Data = new List<GetInvoiceSubscriberListToCollectResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoices
                    .Where(x => x.InvoiceEmitDate.Value.Month == month && x.InvoiceEmitDate.Value.Year == year && x.IdInvoiceState == 2 && x.Type == "FM")
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in subscriberInvoices)
                {
                    var details = new List<GetInvoiceDetailsSubscriberListResponseDto>();
                    foreach (var item1 in item.SubscriberInvoiceDetails)
                    {
                        details.Add(new GetInvoiceDetailsSubscriberListResponseDto
                        {
                            IdSubscriberInvoiceDetails = item1.Id,
                            IdSubscriberInvoice = item.Id,
                            IdTicket = item1.IdTicket,
                            Number = item1.IdTicketNavigation.Number.ToString("D6"),
                            RequestedName = item1.IdTicketNavigation.RequestedName,
                            OrderDate = StaticFunctions.DateTimeToString(item1.IdTicketNavigation.OrderDate),
                            DispatchDate = StaticFunctions.DateTimeToString(item1.IdTicketNavigation.DispatchtDate),
                            ReferenceNUmber = item1.IdTicketNavigation.ReferenceNumber,
                            IdCountry = item1.IdTicketNavigation.IdCountry,
                            Country = item1.IdTicketNavigation.IdCountryNavigation.Iso,
                            FlagCountry = item1.IdTicketNavigation.IdCountryNavigation.FlagIso,
                            ProcedureType = item1.IdTicketNavigation.ProcedureType,
                            ReportType = item1.IdTicketNavigation.ReportType,
                            Price = item1.Amount

                        });
                    }
                    response.Data.Add(new GetInvoiceSubscriberListToCollectResponseDto
                    {
                        Id = item.Id,
                        InvoiceCode = item.InvoiceCode,
                        IdSubscriber = item.IdSubscriber,
                        SubscriberName = item.IdSubscriberNavigation.Name,
                        SubscriberCode = item.IdSubscriberNavigation.Code,
                        IdCurrency = item.IdCurrency,
                        InvoiceEmitDate = item.InvoiceEmitDate,
                        Details = details
                    });
                }

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<List<GetInvoiceSubscriberCCListToCollectResponseDto>>> GetInvoiceSubscriberCCListToCollect(int month, int year)
        {
            var response = new Response<List<GetInvoiceSubscriberCCListToCollectResponseDto>>();
            response.Data = new List<GetInvoiceSubscriberCCListToCollectResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoices
                    .Where(x => x.InvoiceEmitDate.Value.Month == month && x.InvoiceEmitDate.Value.Year == year && x.IdInvoiceState == 2 && x.Type == "CC")
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                foreach (var subscriber in subscriberInvoices)
                {
                    response.Data.Add(new GetInvoiceSubscriberCCListToCollectResponseDto
                    {
                        Id = subscriber.Id,
                        IdCurrency = subscriber.IdCurrency,
                        IdSubscriber = subscriber.IdSubscriber,
                        InvoiceCode = subscriber.InvoiceCode,
                        SubscriberCode = subscriber.IdSubscriberNavigation.Code,
                        SubscriberName = subscriber.IdSubscriberNavigation.Name,
                        InvoiceEmitDate = subscriber.InvoiceEmitDate,
                        Quantity = subscriber.Quantity,
                        TotalPrice = subscriber.TotalAmount
                    });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<List<GetInvoiceSubscriberListPaidsResponseDto>>> GetInvoiceSubscriberListPaids(int month, int year)
        {
            var response = new Response<List<GetInvoiceSubscriberListPaidsResponseDto>>();
            response.Data = new List<GetInvoiceSubscriberListPaidsResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoices
                    .Where(x => x.InvoiceCancelDate.Value.Month == month && x.InvoiceCancelDate.Value.Year == year && x.IdInvoiceState == 3 && x.Type == "FM")
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdSubscriberNavigation)
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .ToListAsync();
                foreach (var item in subscriberInvoices)
                {
                    var details = new List<GetInvoiceDetailsSubscriberListResponseDto>();
                    foreach (var item1 in item.SubscriberInvoiceDetails)
                    {
                        details.Add(new GetInvoiceDetailsSubscriberListResponseDto
                        {
                            IdTicket = item1.IdTicket,
                            Number = item1.IdTicketNavigation.Number.ToString("D6"),
                            RequestedName = item1.IdTicketNavigation.RequestedName,
                            OrderDate = StaticFunctions.DateTimeToString(item1.IdTicketNavigation.OrderDate),
                            DispatchDate = StaticFunctions.DateTimeToString(item1.IdTicketNavigation.DispatchtDate),
                            ReferenceNUmber = item1.IdTicketNavigation.ReferenceNumber,
                            IdCountry = item1.IdTicketNavigation.IdCountry,
                            Country = item1.IdTicketNavigation.IdCountryNavigation.Iso,
                            FlagCountry = item1.IdTicketNavigation.IdCountryNavigation.FlagIso,
                            ProcedureType = item1.IdTicketNavigation.ProcedureType,
                            ReportType = item1.IdTicketNavigation.ReportType,
                            Price = item1.Amount

                        });
                    }
                    response.Data.Add(new GetInvoiceSubscriberListPaidsResponseDto
                    {
                        Id = item.Id,
                        InvoiceCode = item.InvoiceCode,
                        IdSubscriber = item.IdSubscriber,
                        SubscriberName = item.IdSubscriberNavigation.Name,
                        SubscriberCode = item.IdSubscriberNavigation.Code,
                        IdCurrency = item.IdCurrency,
                        InvoiceEmitDate = item.InvoiceEmitDate,
                        Details = details
                    });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<List<GetInvoiceSubscriberccListPaidsResponseDto>>> GetInvoiceSubscriberCCListPaids(int month, int year)
        {
            var response = new Response<List<GetInvoiceSubscriberccListPaidsResponseDto>>();
            response.Data = new List<GetInvoiceSubscriberccListPaidsResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoices
                    .Where(x => x.InvoiceEmitDate.Value.Month == month && x.InvoiceEmitDate.Value.Year == year && x.IdInvoiceState == 3 && x.Type == "CC")
                    .Include(x => x.IdSubscriberNavigation)
                    .ToListAsync();
                foreach (var subscriber in subscriberInvoices)
                {
                    response.Data.Add(new GetInvoiceSubscriberccListPaidsResponseDto
                    {
                        Id = subscriber.Id,
                        IdCurrency = subscriber.IdCurrency,
                        IdSubscriber = subscriber.IdSubscriber,
                        InvoiceCode = subscriber.InvoiceCode,
                        SubscriberCode = subscriber.IdSubscriberNavigation.Code,
                        SubscriberName = subscriber.IdSubscriberNavigation.Name,
                        InvoiceEmitDate = subscriber.InvoiceEmitDate,
                        InvoiceCancelDate = subscriber.InvoiceCancelDate,
                        Quantity = subscriber.Quantity,
                        TotalPrice = subscriber.TotalAmount
                    });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

       
      
        public async Task<Response<bool>> UpdateSubscriberTicket(int idTicket, string requestedName, string procedureType, string dispatchDate,decimal price)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets
                    .Where(x => x.Id == idTicket)
                    .FirstOrDefaultAsync();
                if (ticket != null)
                {
                    ticket.RequestedName = requestedName;
                    ticket.ProcedureType = procedureType;
                    ticket.Price = price;
                    ticket.UpdateDate = DateTime.Now;
                    ticket.DispatchtDate = StaticFunctions.VerifyDate(dispatchDate);
                    ticket.UpdateDate = DateTime.Now;
                    //precio
                    context.Tickets.Update(ticket);
                    await context.SaveChangesAsync();
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> UpdateSubscriberInvoiceToCollect(int idSubscriberInvoice, int idSubscriberInvoiceDetails, string requestedName, string procedureType, string dispatchDate, decimal price)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoice = await context.SubscriberInvoices
                    .Where(w => w.Id == idSubscriberInvoice)
                    .Include(x => x.SubscriberInvoiceDetails).ThenInclude(y => y.IdTicketNavigation)
                    .FirstOrDefaultAsync();
                if (subscriberInvoice != null)
                {
                    decimal? newTotalPrice = 0;
                    subscriberInvoice.SubscriberInvoiceDetails.Where(x => x.Id == idSubscriberInvoiceDetails).FirstOrDefault().Amount = price;
                    subscriberInvoice.SubscriberInvoiceDetails.Where(x => x.Id == idSubscriberInvoiceDetails).FirstOrDefault().IdTicketNavigation.DispatchtDate = StaticFunctions.VerifyDate(dispatchDate);
                    subscriberInvoice.SubscriberInvoiceDetails.Where(x => x.Id == idSubscriberInvoiceDetails).FirstOrDefault().IdTicketNavigation.RequestedName = requestedName;
                    subscriberInvoice.SubscriberInvoiceDetails.Where(x => x.Id == idSubscriberInvoiceDetails).FirstOrDefault().IdTicketNavigation.ProcedureType = procedureType;
                    foreach (var item in subscriberInvoice.SubscriberInvoiceDetails)
                    {
                        newTotalPrice += item.Amount;
                    }
                    subscriberInvoice.TotalAmount = newTotalPrice;
                    subscriberInvoice.UpdateDate = DateTime.Now;
                    //precio
                    context.SubscriberInvoices.Update(subscriberInvoice);
                    await context.SaveChangesAsync();
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> CancelSubscriberInvoiceToCollect(int idSubscriberInvoice, string cancelDate)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoice = await context.SubscriberInvoices.Where(x => x.Id == idSubscriberInvoice).FirstOrDefaultAsync();
                if (subscriberInvoice != null)
                {
                    subscriberInvoice.IdInvoiceState = 3;
                    subscriberInvoice.InvoiceCancelDate = StaticFunctions.VerifyDate(cancelDate);
                    subscriberInvoice.UpdateDate = DateTime.Now;
                    context.SubscriberInvoices.Update(subscriberInvoice);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<bool>> CancelSubscriberInvoiceCCToCollect(int idSubscriberInvoice, string cancelDate)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoice = await context.SubscriberInvoices.Where(x => x.Id == idSubscriberInvoice).FirstOrDefaultAsync();
                if (subscriberInvoice != null)
                {
                    subscriberInvoice.IdInvoiceState = 3;
                    subscriberInvoice.InvoiceCancelDate = StaticFunctions.VerifyDate(cancelDate);
                    subscriberInvoice.UpdateDate = DateTime.Now;
                    context.SubscriberInvoices.Update(subscriberInvoice);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetPersonalResponseDto>>> GetPersonalToInvoice()
        {
            var response = new Response<List<GetPersonalResponseDto>>();
            response.Data = new List<GetPersonalResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var personal = await context.Personals
                    .Where(x => x.Enable == true && (x.Type == "RP" || x.Type == "DI" || x.Type == "TR" || x.Type == "RF"))
                    .Include(x => x.IdEmployeeNavigation).ThenInclude(x => x.UserLogins)
                    .ToListAsync();
                foreach (var item in personal)
                {
                    var country = "";
                    var flagCountry = "";
                    if(item.IdEmployeeNavigation.IdCountry != 0 && item.IdEmployeeNavigation.IdCountry != null)
                    {
                        var c = await context.Countries.Where(x => x.Id == item.IdEmployeeNavigation.IdCountry).FirstOrDefaultAsync();
                        country = c.Iso ?? "";
                        flagCountry = c.FlagIso ?? "";
                    }
                    response.Data.Add(new GetPersonalResponseDto
                    {
                        IdUser = item.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id,
                        IdEmployee = item.IdEmployee,
                        Type = item.Type.Trim(),
                        Code = item.Code.Trim(),
                        FirstName = item.IdEmployeeNavigation.FirstName,
                        LastName = item.IdEmployeeNavigation.LastName,
                        IdCountry = item.IdEmployeeNavigation.IdCountry,
                        Country = country,
                        FlagCountry = flagCountry,
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> SaveInternalInvoice(string type, string code, string currentCycle, decimal totalPrice, List<GetQueryTicket5_1_2ResponseDto>? tickets)
        {
            var response = new Response<bool>();            
            try
            {
                using var context = new SqlCoreContext();
                var cycleCode = "CP_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Year;
                var productionClosure = await context.ProductionClosures.Where(x => x.Code.Contains(cycleCode)).FirstOrDefaultAsync();
                if (productionClosure == null)
                {

                    DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                    await context.ProductionClosures.AddAsync(new ProductionClosure
                    {
                        EndDate = lastDayOfCurrentMonth,
                        Code = cycleCode,
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
                            cycleCode = "CP_" + (1).ToString("D2") + "_" + (DateTime.Now.Year + 1);
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year + 1, 1, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = cycleCode,
                                    Title = "Cierre de Producción " + (1).ToString("D2") + " - " + DateTime.Today.Year + 1,
                                    Observations = ""
                                });
                            }
                        }
                        else
                        {
                            cycleCode = "CP_" + (DateTime.Now.Month + 1).ToString("D2") + "_" + DateTime.Now.Year;
                            var nextProductionClosureExistent = await context.ProductionClosures.Where(x => x.Code.Contains(code)).FirstOrDefaultAsync();
                            if (nextProductionClosureExistent == null)
                            {
                                DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                                await context.ProductionClosures.AddAsync(new ProductionClosure
                                {
                                    EndDate = lastDayOfCurrentMonth,
                                    Code = cycleCode,
                                    Title = "Cierre de Producción " + (DateTime.Now.Month + 1).ToString("D2") + " - " + DateTime.Now.Year,
                                    Observations = ""
                                });
                            }
                        }
                    }
                }

                var internalInvoice = await context.InternalInvoices
                    .Where(x => x.Code == code && x.Cycle == currentCycle && x.Type == type)
                    //.Include(x => x.InternalInvoiceDetails)
                    .FirstOrDefaultAsync();
                decimal? totalPrice1 = 0;
                if (internalInvoice != null) { 

                    var internalInvoiceDetails = await context.InternalInvoiceDetails.Where(x => x.IdInternalInvoice == internalInvoice.Id).ToListAsync();

                    context.InternalInvoiceDetails.RemoveRange(internalInvoiceDetails);
                    
                   var listDetails = new List<InternalInvoiceDetail>();
                    foreach (var ticket in tickets)
                    {
                        totalPrice1 += ticket.Price;
                        var t = await context.Tickets.Where(x => x.Id == ticket.IdTicket).FirstOrDefaultAsync();
                        var quality = "";
                        switch (type.Trim())
                        {
                            case "RP": quality = t.Quality; break;
                            case "DI": quality = t.QualityTypist; break;
                            case "TR": quality = t.QualityTranslator; break;
                            case "RF": quality = t.Quality; break;
                        }                       
                        listDetails.Add(new InternalInvoiceDetail
                        {
                            IdTicketHistory = ticket.Id,
                            IsComplement = ticket.IsComplement,
                            Quality = quality,
                            Price = ticket.Price,
                        });
                    }
                    internalInvoice.TotalPrice = totalPrice1;
                    internalInvoice.InternalInvoiceDetails = listDetails;
                    context.InternalInvoices.Update(internalInvoice);
                }
                else
                {
                    var newInternalInvoice = new InternalInvoice();
                    var listDetails = new List<InternalInvoiceDetail>();
                    newInternalInvoice.Code = code.Trim();
                    newInternalInvoice.Cycle = currentCycle;
                    newInternalInvoice.Type = type;
                    newInternalInvoice.Sended = false;
                    foreach (var ticket in tickets)
                    {
                        totalPrice1 += ticket.Price;
                        var t = await context.Tickets.Where(x => x.Id == ticket.IdTicket).FirstOrDefaultAsync();
                        var quality = "";
                        switch (type.Trim())
                        {
                            case "RP": quality = t.Quality; break;
                            case "DI": quality = t.QualityTypist; break;
                            case "TR": quality = t.QualityTranslator; break;
                            case "RF": quality = t.Quality; break;
                        }
                       
                        listDetails.Add(new InternalInvoiceDetail
                        {
                            IdTicketHistory = ticket.Id,
                            IsComplement = ticket.IsComplement,
                            Quality = quality,
                            Price = ticket.Price,
                        });
                    }

                    newInternalInvoice.TotalPrice = totalPrice1;
                    newInternalInvoice.InternalInvoiceDetails = listDetails;
                    await context.InternalInvoices.AddAsync(newInternalInvoice);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                //response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        private int GetFlagDate(DateTime? expireDate)
        {
            if (!expireDate.HasValue)
            {
                throw new ArgumentNullException(nameof(expireDate), "expireDate es null");
            }

            DateTime currentDate = DateTime.Now.Date;
            DateTime targetDate = expireDate.Value.Date;

            int difference = (targetDate - currentDate).Days;

            if (difference > 2)
            {
                return 0;
            }
            else if (difference >= 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public async Task<Response<bool>> ReportEmployee(int idUser, string code, string type, string cycle)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var user = await context.UserLogins.Where(x => x.Id == idUser).Include(x => x.IdEmployeeNavigation).FirstOrDefaultAsync();
                var employee = await context.Personals
                    .Where(x => x.Type == type && x.Code == code)
                    .Include(x => x.IdEmployeeNavigation)
                    .FirstOrDefaultAsync();
                if(user != null && employee != null)
                {
                    var emailDataDto = new EmailDataDTO();
                    emailDataDto.Parameters = new List<string>();
                    emailDataDto.Attachments = new List<AttachmentDto>();
                    var name = "";
                    var typeStr = "";
                    emailDataDto.EmailKey = "DRR_WORKFLOW_ESP_0063";
                    switch (type)
                    {
                        case "RP": typeStr = "Reportero"; break;
                        case "DI": typeStr = "Digitador"; break;
                        case "TR": typeStr = "Traductor"; break;
                        case "RF": typeStr = "Referencista"; break;
                    }
                    name = code + " || " + employee.IdEmployeeNavigation.FirstName + " " + employee.IdEmployeeNavigation.LastName;
                    emailDataDto.Subject = "PRUEBA_Vale de Comisión " + typeStr + " " + name + " | " + cycle;

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
                            "crodriguez@del-risco.com"
                             //user.IdEmployeeNavigation.Email,
                            // "crc@del-risco.com"
                        };

                    }
                    else
                    {
                        emailDataDto.From = user.IdEmployeeNavigation.Email;
                        emailDataDto.UserName = user.IdEmployeeNavigation.Email;
                        emailDataDto.Password = user.EmailPassword;
                        emailDataDto.To = new List<string>
                        {
                            employee.IdEmployeeNavigation.Email
                            
                        };
                        emailDataDto.CC = new List<string>
                        {
                            "crodriguez@del-risco.com",
                            "eduardo.delacruz@del-risco.com"
                        };
                    }

                    string fileFormat = "{0}_{1}.{2}";
                    //string report = language == "I" ? "EMPRESAS/F8-EMPRESAS-EN" : "EMPRESAS/F8-EMPRESAS-ES";
                    string report = "COMISION_EMPLEADOS";
                    var reportRenderType = StaticFunctions.GetReportRenderType("excel");
                    var extension = StaticFunctions.FileExtension(reportRenderType);
                    var contentType = StaticFunctions.GetContentType(reportRenderType);

                    var dictionary = new Dictionary<string, string>
                {
                     { "code", code },
                     { "type", type },
                     { "cycle", cycle },
                };

                    var file = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary);
                    var fileDto = new GetFileResponseDto
                    {
                        File = file,
                        ContentType = contentType,
                        Name = string.Format(fileFormat, code, (employee.IdEmployeeNavigation.FirstName + " " + employee.IdEmployeeNavigation.LastName), extension)
                    };
                    var attachment = new AttachmentDto();
                    attachment.FileName = fileDto.Name+"xlsx";
                    attachment.Content = Convert.ToBase64String(fileDto.File);
                    emailDataDto.Attachments.Add(attachment);
                    emailDataDto.IsBodyHTML = true;
                    emailDataDto.Parameters.Add(typeStr + " " + name); //userFrom.IdEmployeeNavigation.FirstName + " " + userFrom.IdEmployeeNavigation.LastName
                    emailDataDto.Parameters.Add("Cecilia Rodriguez");
                    emailDataDto.Parameters.Add("crodriguez@del-risco.com");
                    emailDataDto.BodyHTML = emailDataDto.IsBodyHTML ? await GetBodyHtml(emailDataDto) : emailDataDto.BodyHTML;
                    _logger.LogInformation(JsonConvert.SerializeObject(emailDataDto));
                    await context.SaveChangesAsync();
                    var result = await _mailSender.SendMailAsync(_mapper.Map<EmailValues>(emailDataDto));

                    var emailHistory = _mapper.Map<EmailHistory>(emailDataDto);
                    emailHistory.Success = result;
                    response.Data = await _emailHistoryDomain.AddAsync(emailHistory);
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
        private async Task<string> GetBodyHtml(EmailDataDTO emailDataDto)
        {
            var emailConfiguration = await _emailConfigurationDomain.GetByNameAsync(emailDataDto.EmailKey);

            var emailConfigurationFooter = await _emailConfigurationDomain.GetByNameAsync(Constants.DRR_WORKFLOW_FOOTER);
            var stringBody = await _mailFormatter.GetEmailBody(emailConfiguration.Name, emailConfiguration.Value, emailDataDto.Parameters, emailDataDto.Table);
            return stringBody.Replace(Constants.FOOTER, emailConfiguration.FlagFooter.Value ? emailConfigurationFooter.Value : string.Empty);

        }
        public async Task<Response<List<GetAgentInvoice>>> GetAgentInvoice(string code, string startDate, string endDate)
        {
            var response = new Response<List<GetAgentInvoice>>();
            response.Data = new List<GetAgentInvoice>();
            try
            {
                using var context = new SqlCoreContext();
                var agentInvoiceList = context.Set<GetAgentInvoice>()
                                    .FromSqlRaw("EXECUTE GetAgentInvoice @code = '" + code + "', @startDate = '" + startDate + "', @endDate = '" + endDate + "'")
                               
                                    .ToList();
                response.Data = agentInvoiceList;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<decimal>> GetAgentPrice(int idCountry, string asignedTo, string quality, string procedureType, bool hasBalance, int? idSpecialPrice)
        {
            var response = new Response<decimal>();
            try
            {
                using var context = new SqlCoreContext();
                var price = context.Set<PriceResult>().FromSqlRaw(
                                "SELECT dbo.GetAgentPrice({0}, {1}, {2}, {3}, {4}, {5}) AS Price",
                                idCountry, asignedTo, quality, procedureType, hasBalance, idSpecialPrice
                            ).ToList();
                decimal resultPrice = price.FirstOrDefault()?.Price ?? 0;
                response.Data = resultPrice;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> GetExcelAgentInvoice(string code, string startDate, string endDate)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                string fileFormat = "{0}{1}";
                string report = "LISTA_PEDIDOS_AGENTES_POR_FACTURAR";
                var reportRenderType = StaticFunctions.GetReportRenderType("excel");
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var startDateD = StaticFunctions.VerifyDate(startDate);
                var endDateD = StaticFunctions.VerifyDate(endDate);

                string startDateString = startDateD?.ToString("MM/dd/yyyy");
                string endDateString = endDateD?.ToString("MM/dd/yyyy");

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                    { "startDate", startDateString },
                    { "endDate", endDateString },
                    { "startDateS", startDate },
                    { "endDateS", endDate }
                };

                var file = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary);
                response.Data = new GetFileResponseDto
                {
                    File = file,
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "Listado Por Facturar - "+code, extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public string LetrasCastellano(string numero)
        {
            string palabras = "", entero = "", dec = "", flag = "N";
            int num = 0;

            // Si el número comienza con un signo negativo, lo manejamos
            if (numero.StartsWith("-"))
            {
                numero = numero.Substring(1);
                palabras = "MENOS ";
            }

            // Separar el número en parte entera y decimal
            numero = numero.TrimStart('0');
            string[] partes = numero.Split('.');

            entero = partes[0];  // Parte entera
            dec = partes.Length > 1 ? partes[1] : "";  // Parte decimal, si existe

            // Si la parte decimal tiene solo un dígito, agregar un "0" al final
            if (dec.Length == 1)
            {
                dec += "0";
            }

            // Convertir a entero y verificar que no exceda el límite
            if (int.TryParse(entero, out num) && num <= 999999999)
            {
                // Convertir la parte entera en palabras
                for (int y = entero.Length; y > 0; y--)
                {
                    int pos = entero.Length - y;
                    switch (y)
                    {
                        case 3:
                        case 6:
                        case 9:
                            switch (entero[pos].ToString())
                            {
                                case "1":
                                    if (entero.Length > pos + 1 && entero[pos + 1] == '0' && entero[pos + 2] == '0')
                                        palabras += "CIEN ";
                                    else
                                        palabras += "CIENTO ";
                                    break;
                                case "2":
                                    palabras += "DOSCIENTOS ";
                                    break;
                                case "3":
                                    palabras += "TRESCIENTOS ";
                                    break;
                                case "4":
                                    palabras += "CUATROCIENTOS ";
                                    break;
                                case "5":
                                    palabras += "QUINIENTOS ";
                                    break;
                                case "6":
                                    palabras += "SEISCIENTOS ";
                                    break;
                                case "7":
                                    palabras += "SETECIENTOS ";
                                    break;
                                case "8":
                                    palabras += "OCHOCIENTOS ";
                                    break;
                                case "9":
                                    palabras += "NOVECIENTOS ";
                                    break;
                            }
                            break;

                        case 2:
                        case 5:
                        case 8:
                            switch (entero[pos].ToString())
                            {
                                case "1":
                                    if (entero.Length > pos + 1 && "012345".Contains(entero[pos + 1].ToString()))
                                    {
                                        flag = "S";
                                        switch (entero[pos + 1])
                                        {
                                            case '0': palabras += "DIEZ "; break;
                                            case '1': palabras += "ONCE "; break;
                                            case '2': palabras += "DOCE "; break;
                                            case '3': palabras += "TRECE "; break;
                                            case '4': palabras += "CATORCE "; break;
                                            case '5': palabras += "QUINCE "; break;
                                        }
                                    }
                                    else
                                    {
                                        flag = "N";
                                        palabras += "DIECI";
                                    }
                                    break;

                                case "2":
                                    if (entero.Length > pos + 1 && entero[pos + 1] == '0')
                                    {
                                        palabras += "VEINTE ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras += "VEINTI";
                                        flag = "N";
                                    }
                                    break;

                                case "3": palabras += entero.Length > pos + 1 && entero[pos + 1] == '0' ? "TREINTA " : "TREINTA Y "; break;
                                case "4": palabras += entero.Length > pos + 1 && entero[pos + 1] == '0' ? "CUARENTA " : "CUARENTA Y "; break;
                                case "5": palabras += entero.Length > pos + 1 && entero[pos + 1] == '0' ? "CINCUENTA " : "CINCUENTA Y "; break;
                                case "6": palabras += entero.Length > pos + 1 && entero[pos + 1] == '0' ? "SESENTA " : "SESENTA Y "; break;
                                case "7": palabras += entero.Length > pos + 1 && entero[pos + 1] == '0' ? "SETENTA " : "SETENTA Y "; break;
                                case "8": palabras += entero.Length > pos + 1 && entero[pos + 1] == '0' ? "OCHENTA " : "OCHENTA Y "; break;
                                case "9": palabras += entero.Length > pos + 1 && entero[pos + 1] == '0' ? "NOVENTA " : "NOVENTA Y "; break;
                            }
                            break;

                        case 1:
                        case 4:
                        case 7:
                            switch (entero[pos].ToString())
                            {
                                case "1":
                                    if (flag == "N")
                                        palabras += y == 1 ? "UNO " : "UN ";
                                    break;
                                case "2": palabras += flag == "N" ? "DOS " : ""; break;
                                case "3": palabras += flag == "N" ? "TRES " : ""; break;
                                case "4": palabras += flag == "N" ? "CUATRO " : ""; break;
                                case "5": palabras += flag == "N" ? "CINCO " : ""; break;
                                case "6": palabras += flag == "N" ? "SEIS " : ""; break;
                                case "7": palabras += flag == "N" ? "SIETE " : ""; break;
                                case "8": palabras += flag == "N" ? "OCHO " : ""; break;
                                case "9": palabras += flag == "N" ? "NUEVE " : ""; break;
                            }
                            break;
                    }

                    if (y == 4)
                    {
                        if (entero.Length <= 6 && entero.Substring(0, 3) == "000")
                            palabras += "MIL ";
                    }
                    if (y == 7)
                    {
                        if (entero.Length == 7 && entero[0] == '1')
                            palabras += "MILLON ";
                        else
                            palabras += "MILLONES ";
                    }
                }

                // Manejar la parte decimal, si existe
                if (!string.IsNullOrEmpty(dec))
                {
                    return palabras + "Y " + dec + "/100";
                }
                else
                {
                    return palabras + "Y 00/100";
                }
            }
            else
            {
                return string.Empty;
            }
        }


        public async Task<Response<bool>> GetTramo(AddOrUpdateSubscriberInvoiceRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var country = await context.Countries.Where(x => x.Id == (int)obj.IdCountry).FirstOrDefaultAsync();
                var currency = await context.Currencies.Where(x => x.Id == obj.IdCurrency).FirstOrDefaultAsync();
                var subscriber = await context.Subscribers.Where(x => x.Code == obj.SubscriberCode).FirstOrDefaultAsync();
                var cuenta = "";

                string CODIGO_PAIS_EXPORTACION = "", NRO_DOC_ADQUIRIENTE = "", TIPO_OPERACION = "";
                string Mone = "", TOTAL_OPERACIONES_GRAV = "0.00", TOTAL_OPERACIONES_EXPORTACION = "0.00", MONTO_TOTAL_IGV = "0.00", Letras = "", INDICADOR_AFECTACION_ITEM = "";

                string labTipo = "";
                decimal? lblValorVenta = 0;
                foreach (var ob in obj.InvoiceSubscriberList)
                {
                    lblValorVenta += ob.Price;
                }


                if (obj.IdCurrency == 1)
                {
                    Mone = "USD";
                    Letras = LetrasCastellano((lblValorVenta + obj.Igv) + "").ToString() + " DOLARES AMERICANOS";
                }
                else if (obj.IdCurrency == 2)
                {
                    Mone = "EUR";
                    Letras = LetrasCastellano((lblValorVenta + obj.Igv) + "").ToString() + " EUROS";
                }
                else if (obj.IdCurrency == 31)
                {
                    Mone = "PEN";
                    Letras = LetrasCastellano((lblValorVenta + obj.Igv) + "").ToString() + " SOLES";
                }

                if (subscriber.TaxRegistration.Trim().Length == 11)
                {
                    if (subscriber.TaxRegistration.Substring(0, 2) == "10" || subscriber.TaxRegistration.Substring(0, 2) == "20")
                    {
                        labTipo = "06";
                    }
                    else
                    {
                        labTipo = "00";
                    }
                }
                else
                {
                    labTipo = "00";
                }

                if (labTipo == "06")
                {
                    TOTAL_OPERACIONES_GRAV = (lblValorVenta + obj.Igv) + "";
                    TOTAL_OPERACIONES_EXPORTACION = "0";
                    if (obj.Igv == 0)
                    {
                        MONTO_TOTAL_IGV = obj.Igv + "";
                    }
                    else
                    {
                        MONTO_TOTAL_IGV = "0";
                    }
                    INDICADOR_AFECTACION_ITEM = "10";
                    NRO_DOC_ADQUIRIENTE = obj.TaxTypeCode?.Trim();
                }
                else
                {
                    TOTAL_OPERACIONES_GRAV = "0.00";
                    TOTAL_OPERACIONES_EXPORTACION = lblValorVenta + "";
                    MONTO_TOTAL_IGV = "0.00";
                    INDICADOR_AFECTACION_ITEM = "40";
                    NRO_DOC_ADQUIRIENTE = "-";
                    CODIGO_PAIS_EXPORTACION = Codigo_Pais(country.OldCode);
                }


                if (obj.SubscriberCode == "1031" || obj.SubscriberCode == "1050" || obj.SubscriberCode == "1105" || obj.SubscriberCode == "2065" || obj.SubscriberCode == "3008" ||
                    obj.SubscriberCode == "3012" || obj.SubscriberCode == "1077" || obj.SubscriberCode == "3008" || obj.SubscriberCode == "2001" || obj.SubscriberCode == "2002" ||
                    obj.SubscriberCode == "2024" || obj.SubscriberCode == "3008")
                {
                    cuenta = "BANCO INTERNACIONAL DEL PERU SAA - INTERBANK.,Calle Villaran 140 La Victoria -PERU,Cta.Cte.USD. # 2593001863534,Swift: BINPPEPL,Beneficiario: DEL RISCO REPORTS EIRL";
                }
                else if (obj.SubscriberCode == "0135" || obj.SubscriberCode == "1026" || obj.SubscriberCode == "2057" || obj.SubscriberCode == "1037" || obj.SubscriberCode == "1104")
                {
                    cuenta = "BBVA PERU,Calle Emilio Cavenecia con esquina Tudela y Varela San Isidro - PERU,Cta. Cte.  USD. # 0011-0179-0100063330-93,Swift: BCONPEPL,Beneficiario: DEL RISCO REPORTS EIRL";
                }
                else
                {
                    if (obj.SubscriberCode == "0112" || obj.SubscriberCode == "0156" || obj.SubscriberCode == "0107")
                    {
                        cuenta = "SCOTIABANK,No. Cuenta corriente Soles 000-1480324,CCI 009-213-000001480324-01,Beneficiario DEL RISCO REPORTS";
                    }
                    else
                    {
                        cuenta = "SCOTIABANK PERU SAA.,Calle Miguel Dasso 250 Lima 27 - PERU,Cta. Cte.  USD. # 000-4592669,Swift: BSUDPEPL,Beneficiario: DEL RISCO REPORTS EIRL";
                    }
                }

                decimal? PV = 0;
                int EXISTE_GRAVADA = 0;
                int EXISTE_INAFECTA = 0;
                int EXISTE_EXONERADA = 0;
                int EXISTE_GRATUITA = 0;
                int EXISTE_EXPORTACION = 0;

                decimal? lblGeneral = lblValorVenta + decimal.Parse(MONTO_TOTAL_IGV);
                if (obj.IdCountry == 182)
                {
                    PV = lblValorVenta + decimal.Parse(MONTO_TOTAL_IGV);
                    EXISTE_GRAVADA = 1;
                    EXISTE_INAFECTA = 0;
                    EXISTE_EXONERADA = 0;
                    EXISTE_GRATUITA = 0;
                    EXISTE_EXPORTACION = 0;
                    TIPO_OPERACION = "0101";
                }
                else
                {
                    PV = decimal.Parse(TOTAL_OPERACIONES_EXPORTACION);
                    EXISTE_GRAVADA = 0;
                    EXISTE_INAFECTA = 0;
                    EXISTE_EXONERADA = 0;
                    EXISTE_GRATUITA = 0;
                    EXISTE_EXPORTACION = 1;
                    TIPO_OPERACION = "0201";
                }


                decimal? EVALUAR = 0;
                decimal? Monto_Detracc = 0;
                string Trama = "";
                if (labTipo == "06")
                {
                    if (obj.IdCountry == 182 && obj.IdCurrency == 1)
                    {
                        EVALUAR = PV * obj.ExchangeRate;
                    }
                    else
                    {
                        EVALUAR = PV;
                    }

                    if (PV > 700)
                    {
                        if (obj.IdCurrency == 1)
                        {
                            Monto_Detracc = PV * 0.12m * obj.ExchangeRate;
                        }
                        else
                        {
                            Monto_Detracc = PV * 0.12m * 1;
                        }

                        Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                        "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                        "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                        "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                        "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + Decimal.Parse(TOTAL_OPERACIONES_GRAV).ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + Decimal.Parse(MONTO_TOTAL_IGV).ToString("0.00") + "|MONTO_PAGAR:" +
                        lblGeneral?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + "1001" + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                        "|VALOR_VENTA:" + lblValorVenta?.ToString("0.00") + "|PRECIO_VENTA:" + PV?.ToString("0.00") +
                        "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                        "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToShortDateString() + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + (PV - (PV * 12 / 100))?.ToString("0.00") +
                        "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "" + "|IA_46:" + obj.ExchangeRate +
                        "|PORCENTAJE_DETRACC:" + "12.00" + "|MONTO_DETRACC:" + Monto_Detracc?.ToString("0.00") + "|COD_SUNAT_PAGO_DETRACC:001" + "|TASA_IGV:18.00" + "|BB_SS_CODIGO_SUJETO_A_DETRACC:037|BB_SS_DESCRIPCION_SUJETO_A_DETRACC:DEMAS SERVICIOS GRAVADOS CON EL IGV|NUMERO_CTA_BANCO_NACION_DETRACC:00000812773" + "~";
                    }
                    else
                    {
                        Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                        "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                        "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                        "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                        "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + Decimal.Parse(TOTAL_OPERACIONES_GRAV).ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + Decimal.Parse(MONTO_TOTAL_IGV).ToString("0.00") + "|MONTO_PAGAR:" +
                        lblGeneral?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                        "|VALOR_VENTA:" + lblValorVenta?.ToString("0.00") + "|PRECIO_VENTA:" + PV?.ToString("0.00") +
                        "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                        "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToShortDateString() + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + PV + "|TASA_IGV:18.00" +
                        "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";

                    }
                }
                else
                {
                    Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                    "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                    "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                    "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                    "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + Decimal.Parse(TOTAL_OPERACIONES_GRAV).ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:" +
                    Decimal.Parse(TOTAL_OPERACIONES_EXPORTACION).ToString("0.00") + "|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + Decimal.Parse(MONTO_TOTAL_IGV).ToString("0.00") + "|MONTO_PAGAR:" +
                    lblGeneral?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                    "|VALOR_VENTA:" + Decimal.Parse(TOTAL_OPERACIONES_EXPORTACION).ToString("0.00") + "|PRECIO_VENTA:" + PV?.ToString("0.00") +
                    "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                    "|CODIGO_PAIS_EXPORTACION:" + CODIGO_PAIS_EXPORTACION +
                    "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToShortDateString() + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + PV + "|TASA_IGV:18.00" +
                    "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";
                }

                int Vueltas = 0;
                string T1 = "", T2 = "", T3 = "", PRECIO_VENTA_UNITARIO_ITEM = "", VALOR_ITEM = "", IGV_TOTAL_ITEM = "";


                decimal? T1a = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T1"))
                {
                    T1a += item.Price;
                }
                if (obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T1").Count() > 0)
                {
                    T1a = T1a / obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T1").Count();
                }


                decimal? T1b = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T1"))
                {
                    T1b++;
                }

                decimal? T1c = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T1"))
                {
                    T1c += item.Price;
                }

                if (obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T1").ToList().Count == 0)
                {
                    T1 = "";
                }
                else
                {
                    Vueltas = Vueltas + 1;

                    if (labTipo == "06")
                    {
                        PRECIO_VENTA_UNITARIO_ITEM = (T1c / T1b * 118 / 100) + "";
                        VALOR_ITEM = T1c?.ToString("0.00");
                        IGV_TOTAL_ITEM = (T1c * 118 / 100)?.ToString("0.00");
                    }
                    else if (labTipo == "00")
                    {
                        PRECIO_VENTA_UNITARIO_ITEM = T1a?.ToString("0.00");
                        VALOR_ITEM = T1c?.ToString("0.00");
                        IGV_TOTAL_ITEM = "0.00";
                    }
                    T1 = "ID_ITEM:" + Vueltas + "|COD_PROD_SERV_ITEM:T1|DESRIP_ITEM:T1(Informes-Normales)|COD_UNIDAD_MEDIDA_ITEM:NIU|INDICADOR_PS_ITEM:S|INDICADOR_TRANS_GRAT:0|INDICADOR_AFECTACION_ITEM:" +
                    INDICADOR_AFECTACION_ITEM + "|VALOR_VENTA_UNITARIA:" + T1a?.ToString("0.00") +
                    "|PRECIO_VENTA_UNITARIO_ITEM:" + PRECIO_VENTA_UNITARIO_ITEM + "|CANTIDAD_ITEM:" + T1b?.ToString("0.00") + "|DESCUENTO_ITEM:0.00|" +
                    "VALOR_ITEM:" + VALOR_ITEM +
                    "|IGV_TOTAL_ITEM:" + (labTipo == "06" ? (decimal.Parse(VALOR_ITEM) * 18 / 100).ToString("0.00") : "0") +
                    "|TOTAL_ITEM:" + (labTipo == "06" ? (decimal.Parse(VALOR_ITEM) + (decimal.Parse(VALOR_ITEM) * 18 / 100)).ToString("0.00") : (decimal.Parse(VALOR_ITEM)).ToString("0.00")) + "^";
                }


                decimal? T2a = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T2"))
                {
                    T2a += item.Price;
                }
                if (obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T2").Count() > 0)
                {
                    T2a = T2a / obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T2").Count();
                }


                decimal? T2b = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T2"))
                {
                    T2b++;
                }

                decimal? T2c = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T2"))
                {
                    T2c += item.Price;
                }
                if (obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T2").ToList().Count == 0)
                {
                    T2 = "";
                }
                else
                {
                    Vueltas = Vueltas + 1;

                    if (labTipo == "06")
                    {
                        PRECIO_VENTA_UNITARIO_ITEM = (T2c / T2b * 118 / 100) + "";
                        VALOR_ITEM = T2c?.ToString("0.00");
                        IGV_TOTAL_ITEM = (T2c * 118 / 100)?.ToString("0.00");
                    }
                    else if (labTipo == "00")
                    {
                        PRECIO_VENTA_UNITARIO_ITEM = T2a?.ToString("0.00");
                        VALOR_ITEM = T2c?.ToString("0.00");
                        IGV_TOTAL_ITEM = "0.00";
                    }
                       T2 = T2 + "ID_ITEM:" + Vueltas + 
                         "|COD_PROD_SERV_ITEM:T2|DESRIP_ITEM:T2(Informes-Normales)|COD_UNIDAD_MEDIDA_ITEM:NIU|INDICADOR_PS_ITEM:S|INDICADOR_TRANS_GRAT:0|INDICADOR_AFECTACION_ITEM:" +
                         INDICADOR_AFECTACION_ITEM + 
                         "|VALOR_VENTA_UNITARIA:" + T2a?.ToString("0.00") +
                         "|PRECIO_VENTA_UNITARIO_ITEM:" + PRECIO_VENTA_UNITARIO_ITEM + 
                         "|CANTIDAD_ITEM:" + T2b?.ToString("0.00") + 
                         "|DESCUENTO_ITEM:0.00|" +
                         "VALOR_ITEM:" + VALOR_ITEM +
                         "|IGV_TOTAL_ITEM:" + (labTipo == "06" ? (decimal.Parse(VALOR_ITEM) * 18 / 100).ToString("0.00") : "0") +
                         "|TOTAL_ITEM:" + (labTipo == "06" ? 
                        (decimal.Parse(VALOR_ITEM) + (decimal.Parse(VALOR_ITEM) * 18 / 100)).ToString("0.00") : 
                        (decimal.Parse(VALOR_ITEM)).ToString("0.00")) + "^";

                }

                decimal? T3a = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T3"))
                {
                    T3a += item.Price;
                }
                if(obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T3").Count() > 0)
                {
                    T3a = T3a / obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T3").Count();
                }


                decimal? T3b = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T3"))
                {
                    T3b++;
                }

                decimal? T3c = 0;
                foreach (var item in obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T3"))
                {
                    T3c += item.Price;
                }
                if (obj.InvoiceSubscriberList.Where(x => x.ProcedureType == "T3").ToList().Count == 0)
                {
                    T3 = "";
                }
                else
                {
                    Vueltas = Vueltas + 1;

                    if (labTipo == "06")
                    {
                        PRECIO_VENTA_UNITARIO_ITEM = (T3c / T3b * 118 / 100) + "";
                        VALOR_ITEM = T3c?.ToString("0.00");
                        IGV_TOTAL_ITEM = (T3c * 118 / 100)?.ToString("0.00");
                    }
                    else if (labTipo == "00")
                    {
                        PRECIO_VENTA_UNITARIO_ITEM = T3a?.ToString("0.00");
                        VALOR_ITEM = T3c?.ToString("0.00");
                        IGV_TOTAL_ITEM = "0.00";
                    }
                       T3 = T3 + "ID_ITEM:" + Vueltas + 
                         "|COD_PROD_SERV_ITEM:T3|DESRIP_ITEM:T3(Informes-Normales)|COD_UNIDAD_MEDIDA_ITEM:NIU|INDICADOR_PS_ITEM:S|INDICADOR_TRANS_GRAT:0|INDICADOR_AFECTACION_ITEM:" +
                         INDICADOR_AFECTACION_ITEM + 
                         "|VALOR_VENTA_UNITARIA:" + T3a?.ToString("0.00") +
                         "|PRECIO_VENTA_UNITARIO_ITEM:" + PRECIO_VENTA_UNITARIO_ITEM + 
                         "|CANTIDAD_ITEM:" + T3b?.ToString("0.00") + 
                         "|DESCUENTO_ITEM:0.00|" +
                         "VALOR_ITEM:" + VALOR_ITEM +
                         "|IGV_TOTAL_ITEM:" + (labTipo == "06" ? (decimal.Parse(VALOR_ITEM) * 18 / 100).ToString("0.00") : "0") +
                         "|TOTAL_ITEM:" + (labTipo == "06" ? 
                        (decimal.Parse(VALOR_ITEM) + (decimal.Parse(VALOR_ITEM) * 18 / 100)).ToString("0.00") : 
                        (decimal.Parse(VALOR_ITEM)).ToString("0.00")) + "^";

                }

                string Detalles = Trama + T1 + T2 + T3;

                var facRuta = await context.Parameters.Where(x => x.Key == "FAC_RUTA").FirstOrDefaultAsync();
                var facSerie = await context.Parameters.Where(x => x.Key == "FAC_SERIE").FirstOrDefaultAsync();


                string fileDirectory = System.IO.Path.Combine(facRuta.Value, facSerie.Value+obj.InvoiceCode+".txt");

                try
                {
                    File.WriteAllText(fileDirectory, Detalles);
                    Console.WriteLine("Archivo exportado exitosamente a: " + fileDirectory);
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error al escribir el archivo: " + ex.Message);
                }
                response.Data = true;
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        private string Codigo_Pais(string codigo)
        {
            switch (codigo)
            {
                case "152": return "AF";
                case "185": return "AL";
                case "36": return "DE";
                case "186": return "AD";
                case "105": return "AO";
                case "59": return "AI";
                case "63": return "AG";
                case "81": return "AN";
                case "174": return "SA";
                case "97": return "DZ";
                case "1": return "AR";
                case "153": return "AM";
                case "43": return "AW";
                case "37": return "AU";
                case "44": return "AT";
                case "154": return "AZ";
                case "155": return "BH";
                case "156": return "BD";
                case "38": return "BB";
                case "45": return "BE";
                case "32": return "BZ";
                case "106": return "BJ";
                case "46": return "BM";
                case "2": return "BO";
                case "187": return "BA";
                case "107": return "BW";
                case "3": return "BR";
                case "158": return "BN";
                case "188": return "BG";
                case "108": return "BF";
                case "109": return "BI";
                case "157": return "BT";
                case "160": return "KH";
                case "110": return "CM";
                case "31": return "CA";
                case "113": return "TD";
                case "6": return "CL";
                case "61": return "CN";
                case "161": return "CY";
                case "4": return "CO";
                case "114": return "KM";
                case "221": return "KP";
                case "54": return "KR";
                case "5": return "CR";
                case "190": return "HR";
                case "40": return "CU";
                case "65": return "DK";
                case "115": return "DJ";
                case "47": return "DM";
                case "7": return "EC";
                case "116": return "EG";
                case "8": return "SV";
                case "95": return "AE";
                case "118": return "ER";
                case "205": return "SK";
                case "206": return "SI";
                case "41": return "ES";
                case "191": return "EE";
                case "119": return "ET";
                case "210": return "FJ";
                case "35": return "PH";
                case "68": return "FI";
                case "48": return "FR";
                case "120": return "GA";
                case "121": return "GM";
                case "99": return "GE";
                case "122": return "GH";
                case "91": return "GI";
                case "49": return "GD";
                case "100": return "GR";
                case "24": return "GP";
                case "213": return "GU";
                case "9": return "GT";
                case "219": return "GF";
                case "117": return "GN";
                case "123": return "GW";
                case "25": return "GY";
                case "22": return "HT";
                case "50": return "NL";
                case "10": return "HN";
                case "51": return "HK";
                case "193": return "HU";
                case "86": return "IN";
                case "162": return "ID";
                case "163": return "IR";
                case "164": return "IQ";
                case "195": return "IE";
                case "194": return "IS";
                case "26": return "KY";
                case "192": return "FO";
                case "212": return "MH";
                case "208": return "SB";
                case "80": return "TC";
                case "30": return "VG";
                case "29": return "VI";
                case "87": return "IL";
                case "52": return "IT";
                case "34": return "JM";
                case "53": return "JP";
                case "64": return "JO";
                case "96": return "KZ";
                case "124": return "KE";
                case "166": return "KG";
                case "167": return "KW";
                case "85": return "LV";
                case "101": return "LB";
                case "125": return "LR";
                case "126": return "LY";
                case "103": return "LI";
                case "89": return "LT";
                case "197": return "LU";
                case "225": return "MO";
                case "127": return "MG";
                case "92": return "MY";
                case "128": return "MW";
                case "129": return "ML";
                case "199": return "MT";
                case "132": return "MA";
                case "23": return "MQ";
                case "60": return "MU";
                case "130": return "MR";
                case "39": return "MX";
                case "200": return "MD";
                case "201": return "MC";
                case "169": return "MN";
                case "76": return "MS";
                case "133": return "MZ";
                case "134": return "NA";
                case "211": return "NR";
                case "170": return "NP";
                case "12": return "NI";
                case "135": return "NG";
                case "11": return "NU";
                case "69": return "NO";
                case "28": return "NC";
                case "90": return "NZ";
                case "171": return "OM";
                case "104": return "PK";
                case "215": return "PW";
                case "172": return "PS";
                case "13": return "PA";
                case "14": return "PY";
                case "15": return "PE";
                case "217": return "PF";
                case "88": return "PL";
                case "42": return "PT";
                case "16": return "PR";
                case "173": return "QA";
                case "73": return "GB";
                case "111": return "CF";
                case "17": return "DO";
                case "70": return "CZ";
                case "136": return "RW";
                case "202": return "RO";
                case "71": return "RU";
                case "137": return "EH";
                case "214": return "WS";
                case "55": return "KN";
                case "203": return "SM";
                case "56": return "LC";
                case "139": return "SN";
                case "204": return "CS";
                case "140": return "SL";
                case "102": return "SG";
                case "176": return "SY";
                case "141": return "SO";
                case "175": return "LK";
                case "143": return "SZ";
                case "98": return "ZA";
                case "142": return "SD";
                case "84": return "SE";
                case "83": return "CH";
                case "58": return "SR";
                case "178": return "TH";
                case "62": return "TW";
                case "177": return "TJ";
                case "33": return "BS";
                case "145": return "TG";
                case "216": return "TO";
                case "18": return "TT";
                case "66": return "TN";
                case "179": return "TM";
                case "93": return "TR";
                case "20": return "US";
                case "72": return "UA";
                case "147": return "UG";
                case "19": return "UY";
                case "181": return "UZ";
                case "209": return "VU";
                case "21": return "VE";
                case "182": return "VN";
                case "183": return "YE";
                case "148": return "CD";
                case "149": return "ZM";
                case "150": return "ZW";
                case "226": return "CI";
                case "227": return "PG";
                case "229": return "MV";
                case "230": return "SC";
                case "231": return "CG";
                case "235": return "GS";
                case "236": return "TZ";
                case "239": return "BS";
                case "67": return "PRK";
                default: return ".";
            }
        }


        public async Task<Response<bool>> SaveSubscriberInvoice(AddOrUpdateSubscriberInvoiceRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var invoiceSubscriberDetails = new List<SubscriberInvoiceDetail>();

                var result = GetTramo(obj).Result.Data;
                if (result == true)
                {
                    decimal? totalAmount = 0;
                    foreach (var item in obj.InvoiceSubscriberList)
                    {
                        totalAmount += item.Price;
                        invoiceSubscriberDetails.Add(new SubscriberInvoiceDetail
                        {
                            Id = 0,
                            IdTicket = item.IdTicket,
                            Amount = item.Price,
                        });
                        var ticket = await context.Tickets.Where(x => x.Id == item.IdTicket).FirstOrDefaultAsync();
                        if (ticket != null)
                        {
                            ticket.IdInvoiceState = 2;
                            context.Tickets.Update(ticket);
                        }
                    }
                    await context.SubscriberInvoices.AddAsync(new SubscriberInvoice
                    {
                        IdInvoiceState = 2,
                        InvoiceCode = obj.InvoiceCode,
                        InvoiceEmitDate = obj.InvoiceDate,
                        IdSubscriber = obj.IdSubscriber,
                        IdCurrency = obj.IdCurrency,
                        Quantity = obj.InvoiceSubscriberList.Count(),
                        IgvAmount = obj.Igv,
                        TotalAmount = totalAmount,
                        IgvFlag = obj.Igv > 0 ? true : false,
                        Type = "FM",
                        SubscriberInvoiceDetails = invoiceSubscriberDetails
                    });
                    await context.SaveChangesAsync();
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Error al guardar el tramo";
                    _logger.LogError("Error al guardar el tramo");
                }
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<bool>> SaveSubscriberInvoiceCC(AddOrUpdateSubscriberInvoiceCCRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var result = GetTramoCC(obj).Result.Data;
                if(result == true)
                {
                    foreach (var ob in obj.Details)
                    {
                        var history = await context.CouponBillingSubscriberHistories.Where(x => x.Id == ob.Id).FirstOrDefaultAsync();
                        if (history != null)
                        {
                            history.State = "PC";
                            context.CouponBillingSubscriberHistories.Update(history);
                        }
                    }
                    await context.SubscriberInvoices.AddAsync(new SubscriberInvoice
                    {
                        IdInvoiceState = 2,
                        InvoiceCode = obj.InvoiceCode,
                        InvoiceEmitDate = obj.InvoiceDate,
                        IdSubscriber = obj.IdSubscriber,
                        IdCurrency = obj.IdCurrency,
                        Quantity = obj.Quantity,
                        TotalAmount = obj.TotalPrice,
                        Type = "CC"
                    });
                    await context.SaveChangesAsync();
                    response.Data = true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Error al guardar el tramo";
                    _logger.LogError("Error al guardar el tramo");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> GetTramoCC(AddOrUpdateSubscriberInvoiceCCRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();

                var country = await context.Countries.Where(x => x.Id == (int)obj.IdCountry).FirstOrDefaultAsync();
                var currency = await context.Currencies.Where(x => x.Id == obj.IdCurrency).FirstOrDefaultAsync();
                var subscriber = await context.Subscribers.Where(x => x.Code == obj.SubscriberCode).FirstOrDefaultAsync();
                var cuenta = "";

                string Mone = "", TOTAL_OPERACIONES_GRAV = "0.00", TOTAL_OPERACIONES_EXPORTACION = "0.00", MONTO_TOTAL_IGV = "0.00";
                string Letras = "", INDICADOR_AFECTACION_ITEM = "";

                string CODIGO_PAIS_EXPORTACION = "", NRO_DOC_ADQUIRIENTE = "", TIPO_OPERACION = "";


                string labTipo = "";
                decimal? lblValorVenta = 0;
                foreach (var ob in obj.Details)
                {
                    lblValorVenta += ob.TotalPrice;
                }

                if (obj.IdCurrency == 1)
                {
                    Mone = "USD";
                    Letras = LetrasCastellano((lblValorVenta) + "").ToString() + " DOLARES AMERICANOS";
                }
                else if (obj.IdCurrency == 2)
                {
                    Mone = "EUR";
                    Letras = LetrasCastellano((lblValorVenta) + "").ToString() + " EUROS";
                }
                else if (obj.IdCurrency == 31)
                {
                    Mone = "PEN";
                    Letras = LetrasCastellano((lblValorVenta) + "").ToString() + " SOLES";
                }


                if (subscriber.TaxRegistration.Trim().Length == 11)
                {
                    if (subscriber.TaxRegistration.Substring(0, 2) == "10" || subscriber.TaxRegistration.Substring(0, 2) == "20")
                    {
                        labTipo = "06";
                    }
                    else
                    {
                        labTipo = "00";
                    }
                }
                else
                {
                    labTipo = "00";
                }

                if (labTipo == "06")
                {
                    TOTAL_OPERACIONES_GRAV = lblValorVenta + "";
                    TOTAL_OPERACIONES_EXPORTACION = "0";
                    if (obj.Igv == 0)
                    {
                        MONTO_TOTAL_IGV = obj.Igv + "";
                    }
                    else
                    {
                        MONTO_TOTAL_IGV = "0";
                    }
                    INDICADOR_AFECTACION_ITEM = "10";
                    NRO_DOC_ADQUIRIENTE = obj.TaxTypeCode?.Trim();
                }
                else
                {
                    TOTAL_OPERACIONES_GRAV = "0.00";
                    TOTAL_OPERACIONES_EXPORTACION = lblValorVenta + "";
                    MONTO_TOTAL_IGV = "0.00";
                    INDICADOR_AFECTACION_ITEM = "40";
                    NRO_DOC_ADQUIRIENTE = "-";
                    CODIGO_PAIS_EXPORTACION = Codigo_Pais(country.OldCode);
                }

                if (obj.SubscriberCode == "1031" || obj.SubscriberCode == "1050" || obj.SubscriberCode == "1105" || obj.SubscriberCode == "2065" || obj.SubscriberCode == "3008" ||
                    obj.SubscriberCode == "3012" || obj.SubscriberCode == "1077" || obj.SubscriberCode == "3008" || obj.SubscriberCode == "2001" || obj.SubscriberCode == "2002" ||
                    obj.SubscriberCode == "2024" || obj.SubscriberCode == "3008")
                {
                    cuenta = "BANCO INTERNACIONAL DEL PERU SAA - INTERBANK.,Calle Villaran 140 La Victoria -PERU,Cta.Cte.USD. # 2593001863534,Swift: BINPPEPL,Beneficiario: DEL RISCO REPORTS EIRL";
                }
                else if (obj.SubscriberCode == "0135" || obj.SubscriberCode == "1026" || obj.SubscriberCode == "2057" || obj.SubscriberCode == "1037" || obj.SubscriberCode == "1104")
                {
                    cuenta = "BBVA PERU,Calle Emilio Cavenecia con esquina Tudela y Varela San Isidro - PERU,Cta. Cte.  USD. # 0011-0179-0100063330-93,Swift: BCONPEPL,Beneficiario: DEL RISCO REPORTS EIRL";
                }
                else
                {
                    if (obj.SubscriberCode == "0112" || obj.SubscriberCode == "0156" || obj.SubscriberCode == "0107")
                    {
                        cuenta = "SCOTIABANK,No. Cuenta corriente Soles 000-1480324,CCI 009-213-000001480324-01,Beneficiario DEL RISCO REPORTS";
                    }
                    else
                    {
                        cuenta = "SCOTIABANK PERU SAA.,Calle Miguel Dasso 250 Lima 27 - PERU,Cta. Cte.  USD. # 000-4592669,Swift: BSUDPEPL,Beneficiario: DEL RISCO REPORTS EIRL";
                    }
                }

                decimal? PV = 0;
                int EXISTE_GRAVADA = 0;
                int EXISTE_INAFECTA = 0;
                int EXISTE_EXONERADA = 0;
                int EXISTE_GRATUITA = 0;
                int EXISTE_EXPORTACION = 0;

                decimal? lblGeneral = lblValorVenta + decimal.Parse(MONTO_TOTAL_IGV);
                if (obj.IdCountry == 182)
                {
                    PV = lblValorVenta + decimal.Parse(MONTO_TOTAL_IGV);
                    EXISTE_GRAVADA = 1;
                    EXISTE_INAFECTA = 0;
                    EXISTE_EXONERADA = 0;
                    EXISTE_GRATUITA = 0;
                    EXISTE_EXPORTACION = 0;
                    TIPO_OPERACION = "0101";
                }
                else
                {
                    PV = decimal.Parse(TOTAL_OPERACIONES_EXPORTACION);
                    EXISTE_GRAVADA = 0;
                    EXISTE_INAFECTA = 0;
                    EXISTE_EXONERADA = 0;
                    EXISTE_GRATUITA = 0;
                    EXISTE_EXPORTACION = 1;
                    TIPO_OPERACION = "0201";
                }


                decimal? EVALUAR = 0;
                decimal? Monto_Detracc = 0;
                string Trama = "";
                if (labTipo == "06")
                {
                    if (obj.IdCountry == 182 && obj.IdCurrency == 1)
                    {
                        EVALUAR = PV * obj.ExchangeRate;
                    }
                    else
                    {
                        EVALUAR = PV;
                    }

                    if (PV > 700)
                    {
                        if (obj.IdCurrency == 1)
                        {
                            Monto_Detracc = PV * 0.12m * obj.ExchangeRate;
                        }
                        else
                        {
                            Monto_Detracc = PV * 0.12m * 1;
                        }

                        Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                        "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                        "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                        "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                        "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + Decimal.Parse(TOTAL_OPERACIONES_GRAV).ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + Decimal.Parse(MONTO_TOTAL_IGV).ToString("0.00") + "|MONTO_PAGAR:" +
                        lblGeneral?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + "1001" + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                        "|VALOR_VENTA:" + lblValorVenta?.ToString("0.00") + "|PRECIO_VENTA:" + PV?.ToString("0.00") +
                        "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                        "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToShortDateString() + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + (PV - (PV * 12 / 100))?.ToString("0.00") +
                        "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "" + "|IA_46:" + obj.ExchangeRate +
                        "|PORCENTAJE_DETRACC:" + "12.00" + "|MONTO_DETRACC:" + Monto_Detracc?.ToString("0.00") + "|COD_SUNAT_PAGO_DETRACC:001" + "|TASA_IGV:18.00" + "|BB_SS_CODIGO_SUJETO_A_DETRACC:037|BB_SS_DESCRIPCION_SUJETO_A_DETRACC:DEMAS SERVICIOS GRAVADOS CON EL IGV|NUMERO_CTA_BANCO_NACION_DETRACC:00000812773" + "~";
                    }
                    else
                    {
                        Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                        "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                        "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                        "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                        "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + Decimal.Parse(TOTAL_OPERACIONES_GRAV).ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + Decimal.Parse(MONTO_TOTAL_IGV).ToString("0.00") + "|MONTO_PAGAR:" +
                        lblGeneral?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                        "|VALOR_VENTA:" + lblValorVenta?.ToString("0.00") + "|PRECIO_VENTA:" + PV?.ToString("0.00") +
                        "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                        "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToShortDateString() + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + PV + "|TASA_IGV:18.00" +
                        "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";

                    }
                }
                else
                {
                    Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                    "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                    "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                    "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                    "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + Decimal.Parse(TOTAL_OPERACIONES_GRAV).ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:" +
                    Decimal.Parse(TOTAL_OPERACIONES_EXPORTACION).ToString("0.00") + "|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + Decimal.Parse(MONTO_TOTAL_IGV).ToString("0.00") + "|MONTO_PAGAR:" +
                    lblGeneral?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                    "|VALOR_VENTA:" + Decimal.Parse(TOTAL_OPERACIONES_EXPORTACION).ToString("0.00") + "|PRECIO_VENTA:" + PV?.ToString("0.00") +
                    "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                    "|CODIGO_PAIS_EXPORTACION:" + CODIGO_PAIS_EXPORTACION +
                    "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToShortDateString() + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + PV + "|TASA_IGV:18.00" +
                    "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";
                }

                int Vueltas = 0;
                string T1 = "", PRECIO_VENTA_UNITARIO_ITEM = "", VALOR_ITEM = "", IGV_TOTAL_ITEM = "";
                string txtpreciosaldocupones = "";
                Vueltas = Vueltas + 1;
                if(labTipo == "06")
                {
                    PRECIO_VENTA_UNITARIO_ITEM = (obj.TotalPrice / obj.Quantity * 118 / 100)?.ToString("0.00") + "";
                    VALOR_ITEM = lblValorVenta?.ToString("0.00");
                    IGV_TOTAL_ITEM = (lblValorVenta * 118 / 100)?.ToString("0.00");
                }
                else if(labTipo == "00")
                {
                    PRECIO_VENTA_UNITARIO_ITEM = (obj.TotalPrice / obj.Quantity)?.ToString("0.00") + "";
                    VALOR_ITEM = (lblValorVenta + obj.Igv)?.ToString("0.00");
                    IGV_TOTAL_ITEM = "0.00";
                }
                T1 = T1 + "ID_ITEM:" + Vueltas + "|COD_PROD_SERV_ITEM:T1|DESRIP_ITEM:Cupones_pagados_por_adelantado_para_solicitar_Informes_Comerciales|COD_UNIDAD_MEDIDA_ITEM:NIU|INDICADOR_PS_ITEM:S|INDICADOR_TRANS_GRAT:0|INDICADOR_AFECTACION_ITEM:" +
                INDICADOR_AFECTACION_ITEM + "|VALOR_VENTA_UNITARIA:" + (obj.TotalPrice / obj.Quantity)?.ToString("0.00") +
                "|PRECIO_VENTA_UNITARIO_ITEM:" + PRECIO_VENTA_UNITARIO_ITEM + "|CANTIDAD_ITEM:" + (obj.Quantity)?.ToString("0.00") + "|DESCUENTO_ITEM:0.00|" +
                "VALOR_ITEM:" + VALOR_ITEM +
                "|IGV_TOTAL_ITEM:" + labTipo == "06" ? (Decimal.Parse(VALOR_ITEM) * 18 / 100).ToString("0.00") : "0" +
                "|TOTAL_ITEM:" + labTipo == "06" ? (Decimal.Parse(VALOR_ITEM) + (Decimal.Parse(VALOR_ITEM) * 18 / 100)).ToString("0.00") : VALOR_ITEM + "^";

                string Detalles = Trama + T1;

                var facRuta = await context.Parameters.Where(x => x.Key == "FAC_RUTA").FirstOrDefaultAsync();
                var facSerie = await context.Parameters.Where(x => x.Key == "FAC_SERIE").FirstOrDefaultAsync();


                string fileDirectory = System.IO.Path.Combine(facRuta.Value, facSerie.Value + obj.InvoiceCode + ".txt");

                try
                {
                    File.WriteAllText(fileDirectory, Detalles);
                    Console.WriteLine("Archivo exportado exitosamente a: " + fileDirectory);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error al escribir el archivo: " + ex.Message);
                }
                response.Data = true;

            }
            catch (Exception ex)
            {
            }
            return response;
        }

        public async Task<Response<int?>> GetInvoiceNumber()
        {
            var response = new Response<int?>();
            try
            {
                using var context = new SqlCoreContext();
                var invoiceNumber = new Numeration();
                invoiceNumber = await context.Numerations.Where(x => x.Name == "NUM_INVOICE").FirstOrDefaultAsync();
                if(invoiceNumber != null)
                {
                    response.Data = (invoiceNumber.Number + 1);
                }
                else
                {
                    invoiceNumber = new Numeration();
                    invoiceNumber.Name = "NUM_INVOICE";
                    invoiceNumber.Description = "Número de Facturación";
                    invoiceNumber.Number = 0;
                    await context.Numerations.AddAsync(invoiceNumber);
                    await context.SaveChangesAsync();
                    response.Data = (invoiceNumber.Number + 1);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetSubscriberPricesDto>> GetSubscriberPriceByTicket(int idSubscriber, int idCountry)
        {
            var response = new Response<GetSubscriberPricesDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberPrice = await context.SubscriberPrices.Where(x => x.IdSubscriber == idSubscriber && x.IdCountry == idCountry).FirstOrDefaultAsync();
                if (subscriberPrice != null)
                {
                    response.Data = new GetSubscriberPricesDto
                    {
                        PriceT1 = subscriberPrice.PriceT1 ?? 0,
                        PriceT2 = subscriberPrice.PriceT2 ?? 0,
                        PriceT3 = subscriberPrice.PriceT3 ?? 0,
                    };
                }
                else
                {
                    response.IsSuccess = false;
                }

            }
            catch (Exception ex)
            {
            }
            return response;
        }
    }
}
