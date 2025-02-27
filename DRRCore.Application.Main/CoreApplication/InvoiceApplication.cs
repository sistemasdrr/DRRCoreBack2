
using AutoMapper;
using CoreFtp;
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
using Org.BouncyCastle.Crypto.Parameters;
using SharpCompress.Common;
using System.IO;
using System.Net;

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
                    if (ticketHistory.IdTicketNavigation.Quality != null)
                    {
                        if (ticketHistory.IdTicketNavigation.Quality.Trim() != quality.Trim())
                        {
                            ticketHistory.IdTicketNavigation.Quality = quality.Trim();
                            ticketHistory.IdTicketNavigation.QualityTranslator = quality.Trim();
                            ticketHistory.IdTicketNavigation.QualityTypist = quality.Trim();

                        }
                    }
                    ticketHistory.IdTicketNavigation.RequestedName = requestedName;
                    ticketHistory.IdTicketNavigation.ProcedureTypeAgent = procedureType;
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
                                    (x.IdStatusTicket == (int)TicketStatusEnum.Despachado || x.IdStatusTicket == (int)TicketStatusEnum.Despachado_con_Observacion) && x.IsComplement==false && x.Enable==true)
                        .OrderBy(x=>x.DispatchtDate)
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

                    DateTime lastDayOfCurrentMonth = DateTime.Now.AddDays(20);
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
                                DateTime lastDayOfCurrentMonth = DateTime.Now.AddDays(20);
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
                                DateTime lastDayOfCurrentMonth = DateTime.Now.AddDays(20);
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
                        var t = await context.Tickets.Where(x => x.Id == ticket.Id).FirstOrDefaultAsync();
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
                            IdTicketHistory = ticket.IdTicketHistory,
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
                        var t = await context.Tickets.Where(x => x.Id == ticket.Id).FirstOrDefaultAsync();
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
                            IdTicketHistory = ticket.IdTicketHistory,
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
      
        public string LetrasCastellano(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try

            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

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
                string Mone = "", TOTAL_OPERACIONES_EXPORTACION = "0.00", MONTO_TOTAL_IGV = "0.00", Letras = "", INDICADOR_AFECTACION_ITEM = "";

                string labTipo = "";
                decimal? lblValorVenta = 0;
                decimal? totalVentaConIgv = 0, montoIgv = 0, totalSinIgv = 0, montoDetraccion = 0, montoPendientePago = 0;
                foreach (var ob in obj.InvoiceSubscriberList)
                {
                    totalSinIgv += ob.Price;
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
                bool existeDetraccion = false;
                if (labTipo == "06")
                {
                    totalVentaConIgv = totalSinIgv * 118 / 100;
                    montoIgv = totalVentaConIgv - totalSinIgv;
                    if (obj.IdCountry == 182)
                    {
                        if (obj.IdCurrency == 31)
                        {
                            montoDetraccion = totalVentaConIgv * 12 / 100;
                            existeDetraccion = totalVentaConIgv > 700;

                        }
                        else
                        {
                            montoDetraccion = totalVentaConIgv * 12 * obj.ExchangeRate / 100;
                            existeDetraccion = (totalVentaConIgv * obj.ExchangeRate) > 700;
                        }
                    }
                    montoPendientePago = existeDetraccion? (totalVentaConIgv * (100 - 12) / 100): totalVentaConIgv;
                              
                    INDICADOR_AFECTACION_ITEM = "10";
                    NRO_DOC_ADQUIRIENTE = obj.TaxTypeCode?.Trim();
                }
                else
                {
                    totalVentaConIgv = totalSinIgv;
                    montoIgv = 0;
                    montoDetraccion = 0;
                    montoPendientePago = totalVentaConIgv;
                    INDICADOR_AFECTACION_ITEM = "40";
                    NRO_DOC_ADQUIRIENTE = "-";
                    CODIGO_PAIS_EXPORTACION = await Codigo_Pais(context, country.OldCode);
                }


                if (obj.IdCurrency == 1)
                {
                    Mone = "USD";
                    Letras = LetrasCastellano(totalVentaConIgv.ToString()) + " DOLARES AMERICANOS";
                }
                else if (obj.IdCurrency == 2)
                {
                    Mone = "EUR";
                    Letras = LetrasCastellano(totalVentaConIgv.ToString()) + " EUROS";
                }
                else if (obj.IdCurrency == 31)
                {
                    Mone = "PEN";
                    Letras = LetrasCastellano(totalVentaConIgv.ToString()) + " SOLES";
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


               
                string Trama = "";
                if (labTipo == "06")
                {
                  
                    if (existeDetraccion)
                    {
                      
                        Trama = "ACTION:Registrar~"+
                            "FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") +
                            "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                        "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                        "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                        "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                        "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + totalSinIgv.Value.ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + montoIgv.Value.ToString("0.00") + "|MONTO_PAGAR:" +
                        totalVentaConIgv?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:1001|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                        "|VALOR_VENTA:" + totalSinIgv?.ToString("0.00") + "|PRECIO_VENTA:" + totalVentaConIgv?.ToString("0.00") +
                        "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                        "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + montoPendientePago?.ToString("0.00") +
                        "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "" + "|IA_46:" + obj.ExchangeRate +
                        "|PORCENTAJE_DETRACC:" + "12.00" + "|MONTO_DETRACC:" + montoDetraccion?.ToString("0.00") + "|COD_SUNAT_PAGO_DETRACC:001" + "|TASA_IGV:18.00" + "|BB_SS_CODIGO_SUJETO_A_DETRACC:037|BB_SS_DESCRIPCION_SUJETO_A_DETRACC:DEMAS SERVICIOS GRAVADOS CON EL IGV|NUMERO_CTA_BANCO_NACION_DETRACC:00000812773" + "~";
                    }
                    else
                    {
                        Trama = "ACTION:Registrar~" +
                             "FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") +
                             "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                         "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                         "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                         "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                         "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + totalSinIgv.Value.ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + montoIgv.Value.ToString("0.00") + "|MONTO_PAGAR:" +
                         totalVentaConIgv?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                         "|VALOR_VENTA:" + totalSinIgv?.ToString("0.00") + "|PRECIO_VENTA:" + totalVentaConIgv?.ToString("0.00") +
                         "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                         "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + montoPendientePago?.ToString("0.00") + "|TASA_IGV:18.00" +
                        "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";

                    }
                }
                else
                {
                    Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                    "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                    "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                    "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                    "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV: 0.00|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:" +
                    totalSinIgv?.ToString("0.00") + "|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:0.00|MONTO_PAGAR:" +
                    totalSinIgv?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                    "|VALOR_VENTA:" + totalSinIgv?.ToString("0.00") + "|PRECIO_VENTA:" + totalSinIgv?.ToString("0.00") +
                    "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                    "|CODIGO_PAIS_EXPORTACION:" + CODIGO_PAIS_EXPORTACION +
                    "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "|TIPO_FORMA_PAGO:02|MONTO_PENDIENTE_PAGO:" + totalSinIgv?.ToString("0.00") + "|TASA_IGV:18.00" +
                    "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";
                }

                int Vueltas = 0;
                string TramoDetail = "";

                string specialCaracter = "^";

                var LstGrupoSumado = obj.InvoiceSubscriberList.GroupBy(l => l.ProcedureType)
                          .Select(la =>
                                new {
                                    IdGrupo = la.Key,
                                    NoArticulos = la.Count(),
                                    SumaPrecio = la.Sum(s => s.Price)??0,
                                }).OrderBy(x=>x.IdGrupo).ToList();
         
                foreach (var procedure in LstGrupoSumado)
                {
                    Vueltas++;
                    string DescripcionItem = string.Empty;
                    switch (procedure.IdGrupo)
                    {
                        case "T1":
                            DescripcionItem = "T1(Informes - Normales)";
                            break;
                        case "T2":
                            DescripcionItem = "T2(Informes - Urgentes)";
                            break;
                        case "T3":
                            DescripcionItem = "T3(Informes - Super Urgentes)";
                            break;
                        case "T4":
                            DescripcionItem = "T4(Informes Online)";
                            break;
                        default:
                            DescripcionItem = procedure.IdGrupo+ "(Informes Varios)";
                            break;
                    }
                    decimal precioUnitario = decimal.Zero;
                    decimal precioUnitarioIgv = decimal.Zero;
                    decimal igvItem = 0;
                    decimal totalItem = 0;

                    if (labTipo == "06")
                    {
                        precioUnitario = procedure.SumaPrecio/procedure.NoArticulos;
                        precioUnitarioIgv=precioUnitario * 118 / 100;
                        igvItem = procedure.SumaPrecio * 18 / 100;
                        totalItem = procedure.SumaPrecio * 118 / 100;
                       
                    }
                    else if (labTipo == "00")
                    {
                        precioUnitario = procedure.SumaPrecio / procedure.NoArticulos;
                        igvItem = 0;
                        totalItem = procedure.SumaPrecio;
                        precioUnitarioIgv = precioUnitario;


                    }

                    TramoDetail = TramoDetail + (Vueltas != 1 ? specialCaracter : string.Empty) +  "ID_ITEM:" + Vueltas + "|COD_PROD_SERV_ITEM:"+procedure.IdGrupo+"|DESRIP_ITEM:"+DescripcionItem+"|COD_UNIDAD_MEDIDA_ITEM:NIU|INDICADOR_PS_ITEM:S|INDICADOR_TRANS_GRAT:0|INDICADOR_AFECTACION_ITEM:" +
                    INDICADOR_AFECTACION_ITEM + "|VALOR_VENTA_UNITARIA:" + precioUnitario.ToString("0.00") +
                    "|PRECIO_VENTA_UNITARIO_ITEM:" + precioUnitarioIgv.ToString("0.00") + "|CANTIDAD_ITEM:" + procedure.NoArticulos.ToString("0.00") + "|DESCUENTO_ITEM:0.00|" +
                    "VALOR_ITEM:" + procedure.SumaPrecio.ToString("0.00") +
                    "|IGV_TOTAL_ITEM:" + igvItem.ToString("0.00") +
                    "|TOTAL_ITEM:" + totalItem.ToString("0.00");


                   
                }        

                string Detalles = Trama + TramoDetail;

                var facRuta = await context.Parameters.Where(x => x.Key == "FAC_RUTA").FirstOrDefaultAsync();
                var facSerie = await context.Parameters.Where(x => x.Key == "FAC_SERIE").FirstOrDefaultAsync();

                var host = await context.Parameters.Where(x => x.Key == "HOST_FTP_CONTANET").FirstOrDefaultAsync();
                var port = await context.Parameters.Where(x => x.Key == "PORT_FTP_CONTANET").FirstOrDefaultAsync();
                var user = await context.Parameters.Where(x => x.Key == "USER_FTP_CONTANET").FirstOrDefaultAsync();
                var password = await context.Parameters.Where(x => x.Key == "PASSWORD_FTP_CONTANET").FirstOrDefaultAsync();
               

                string fileDirectory = facSerie.Value+obj.InvoiceCode+".txt";

                var ftpServerUrl = @"ftp://" + host.Value + ":" + port.Value + "/ENTRADA/";
                var username = user.Value;
                var passwordv = password.Value;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpServerUrl + fileDirectory));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, passwordv);
                request.UsePassive = false;

                try
                {
                    byte[] bytes = null;
                    using (var ms = new MemoryStream())
                    {
                        using (TextWriter tw = new StreamWriter(ms))
                        {
                            tw.Write(Detalles);
                            tw.Flush();
                            ms.Position = 0;
                            bytes = ms.ToArray();

                            using (var writeStream = await request.GetRequestStreamAsync())
                            {
                                ms.Position = 0;
                                await ms.CopyToAsync(writeStream);
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    response.Data = false;
                    _logger.LogError(ex.Message);
                }
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Data = false;
                _logger.LogError(ex.Message);
            }
            return response;
        }
       
        private async Task<FtpClientConfiguration> GetFtpClientConfiguration(SqlCoreContext context)
        {
            var host = await context.Parameters.Where(x => x.Key == "HOST_FTP_CONTANET").FirstOrDefaultAsync();
            var port = await context.Parameters.Where(x => x.Key == "PORT_FTP_CONTANET").FirstOrDefaultAsync();
            var user = await context.Parameters.Where(x => x.Key == "USER_FTP_CONTANET").FirstOrDefaultAsync();
            var password = await context.Parameters.Where(x => x.Key == "PASSWORD_FTP_CONTANET").FirstOrDefaultAsync();
            return new FtpClientConfiguration
            {
                Host = host.Value,
                Port = int.Parse(port.Value),
                Username = user.Value,
                Password = password.Value
            };
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
                    var number=await context.Numerations.Where(x => x.Name == "NUM_INVOICE").FirstOrDefaultAsync();
                    number.Number = int.Parse(obj.InvoiceCode);
                    context.Numerations.Update(number);
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
                    var number = await context.Numerations.Where(x => x.Name == "NUM_INVOICE").FirstOrDefaultAsync();
                    number.Number = int.Parse(obj.InvoiceCode);
                    context.Numerations.Update(number);
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

                string CODIGO_PAIS_EXPORTACION = "", NRO_DOC_ADQUIRIENTE = "", TIPO_OPERACION = "";
                string Mone = "", TOTAL_OPERACIONES_EXPORTACION = "0.00", MONTO_TOTAL_IGV = "0.00", Letras = "", INDICADOR_AFECTACION_ITEM = "";

                string labTipo = "";
                decimal? lblValorVenta = 0;
                decimal? totalVentaConIgv = 0, montoIgv = 0, totalSinIgv = 0, montoDetraccion = 0, montoPendientePago = 0;

                totalSinIgv = obj.TotalPrice;
              
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
                bool existeDetraccion = false;
                if (labTipo == "06")
                {
                    totalVentaConIgv = totalSinIgv * 118 / 100;
                    montoIgv = totalVentaConIgv - totalSinIgv;
                    if (obj.IdCountry == 182)
                    {
                        if (obj.IdCurrency == 31)
                        {
                            montoDetraccion = totalVentaConIgv * 12 / 100;
                            existeDetraccion = totalVentaConIgv > 700;
                           
                        }
                        else
                        {
                            montoDetraccion = totalVentaConIgv * 12 * obj.ExchangeRate / 100;
                            existeDetraccion = (totalVentaConIgv*obj.ExchangeRate) > 700;
                        }
                    }

                    montoPendientePago = existeDetraccion ? (totalVentaConIgv * (100 - 12) / 100) : totalVentaConIgv;

                    INDICADOR_AFECTACION_ITEM = "10";
                    NRO_DOC_ADQUIRIENTE = obj.TaxTypeCode?.Trim();
                }
                else
                {
                    totalVentaConIgv = totalSinIgv;
                    montoIgv = 0;
                    montoDetraccion = 0;
                    montoPendientePago = totalVentaConIgv;
                    INDICADOR_AFECTACION_ITEM = "40";
                    NRO_DOC_ADQUIRIENTE = "-";
                    CODIGO_PAIS_EXPORTACION = await Codigo_Pais(context, country.OldCode);
                }


                if (obj.IdCurrency == 1)
                {
                    Mone = "USD";
                    Letras = LetrasCastellano(totalVentaConIgv.ToString()) + " DOLARES AMERICANOS";
                }
                else if (obj.IdCurrency == 2)
                {
                    Mone = "EUR";
                    Letras = LetrasCastellano(totalVentaConIgv.ToString()) + " EUROS";
                }
                else if (obj.IdCurrency == 31)
                {
                    Mone = "PEN";
                    Letras = LetrasCastellano(totalVentaConIgv.ToString()) + " SOLES";
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


              
                string Trama = "";
                if (labTipo == "06")
                {                  
                    if (existeDetraccion)
                    {
                   
                        Trama = "ACTION:Registrar~" +
                            "FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") +
                            "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                        "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                        "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                        "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                        "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + totalSinIgv.Value.ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + montoIgv.Value.ToString("0.00") + "|MONTO_PAGAR:" +
                        totalVentaConIgv?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:1001|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                        "|VALOR_VENTA:" + totalSinIgv?.ToString("0.00") + "|PRECIO_VENTA:" + totalVentaConIgv?.ToString("0.00") +
                        "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                        "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "|TIPO_FORMA_PAGO:01|MONTO_PENDIENTE_PAGO:0.00|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "" + "|IA_46:" + obj.ExchangeRate +
                        "|PORCENTAJE_DETRACC:" + "12.00" + "|MONTO_DETRACC:" + montoDetraccion?.ToString("0.00") + "|COD_SUNAT_PAGO_DETRACC:001" + "|TASA_IGV:18.00" + "|BB_SS_CODIGO_SUJETO_A_DETRACC:037|BB_SS_DESCRIPCION_SUJETO_A_DETRACC:DEMAS SERVICIOS GRAVADOS CON EL IGV|NUMERO_CTA_BANCO_NACION_DETRACC:00000812773" + "~";
                    }
                    else
                    {
                        Trama = "ACTION:Registrar~" +
                             "FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") +
                             "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                         "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                         "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                         "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                         "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV:" + totalSinIgv.Value.ToString("0.00") + "|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:0.00|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:" + montoIgv.Value.ToString("0.00") + "|MONTO_PAGAR:" +
                         totalVentaConIgv?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                         "|VALOR_VENTA:" + totalSinIgv?.ToString("0.00") + "|PRECIO_VENTA:" + totalVentaConIgv?.ToString("0.00") +
                         "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                         "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "|TIPO_FORMA_PAGO:01|MONTO_PENDIENTE_PAGO:0.00|TASA_IGV:18.00" +
                        "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";

                    }
                }
                else
                {
                    Trama = "ACTION:Registrar~FEC_ED:" + obj.InvoiceDate.Value.ToString("yyyy-MM-dd") + "|RUC_EMISOR:20504166318|TIP_DOC_EMISOR:06|APAMNO_RAZON_SOCIAL_EMISOR:DEL RISCO REPORTS E.I.R.L." +
                    "|UBIGEO_EMISOR:150120|DIRECCION_EMISOR:Jr. Tomas Ramsey Nro. 930 Dpto. 603|URBANIZACION_EMISOR:|DEPARTAMENTO_EMISOR:LIMA|PROVINCIA_EMISOR:LIMA" +
                    "|DISTRITO_EMISOR:MAGDALENA|CODIGO_PAIS_EMISOR:PE|NOMBRE_COMERCIAL_EMISOR:DEL RISCO REPORTS|TIP_DOC:01|NRO_SERIE:F005|NRO_DOC:" + obj.InvoiceCode +
                    "|NRO_DOC_ADQUIRIENTE:" + NRO_DOC_ADQUIRIENTE + "|TIP_DOC_ADQUIRIENTE:" + labTipo.Trim() + "|APAMNO_RAZON_SOCIAL_ADQUIRIENTE:" + subscriber.Name +
                    "|MONEDA:" + Mone + "|TOTAL_OPERACIONES_GRAV: 0.00|TOTAL_OPERACIONES_INF:0.00|TOTAL_OPERACIONES_EXONERADAS:0.00|TOTAL_OPERACIONES_EXPORTACION:" +
                    totalSinIgv?.ToString("0.00") + "|MONTO_TOTAL_OPERACIONES_GRAT:0.00" + "|MONTO_DESCUENTOS_GLOBALES:0.00|MONTO_TOTAL_IGV:0.00|MONTO_PAGAR:" +
                    totalSinIgv?.ToString("0.00") + "|MONTO_PERCEPCION:0.00|MONTO_TOTAL_PERCEP:0.00" + "|TIPO_OPERACION:" + TIPO_OPERACION + "|LEYENDA:" + Letras + "|CORREO_CLIENTE:" + "mail@del-risco.com" +
                    "|VALOR_VENTA:" + totalSinIgv?.ToString("0.00") + "|PRECIO_VENTA:" + totalSinIgv?.ToString("0.00") +
                    "|EXISTE_GRAVADA:" + EXISTE_GRAVADA + "|EXISTE_INAFECTA:" + EXISTE_INAFECTA + "|EXISTE_EXONERADA:" + EXISTE_EXONERADA + "|EXISTE_GRATUITA:" + EXISTE_GRATUITA + "|EXISTE_EXPORTACION:" + EXISTE_EXPORTACION +
                    "|CODIGO_PAIS_EXPORTACION:" + CODIGO_PAIS_EXPORTACION +
                    "|FECHA_VENCIMIENTO:" + DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "|TIPO_FORMA_PAGO:01|MONTO_PENDIENTE_PAGO:0.00|TASA_IGV:18.00" +
                    "|IA_40:" + subscriber.Code + " - " + subscriber.Name + "|IA_41:" + obj.Address + "|IA_42:" + obj.AttendedBy + "|IA_43:" + "" + "|IA_44:PAGO POR TRANSFERENCIA BANCARIA" + "|IA_45:" + cuenta + "~";
                }

              
                string TramoDetail = "";                  
                    decimal? precioUnitario = decimal.Zero;
                    decimal? precioUnitarioIgv = decimal.Zero;
                    decimal? igvItem = 0;
                    decimal? totalItem = 0;
                    decimal? quantity = 0;
                if (obj.Details.Count > 0)
                {
                    quantity = obj.Details[0].CouponAmount;
                }

                    if (labTipo == "06")
                    {
                        precioUnitario = obj.TotalPrice / quantity;
                        precioUnitarioIgv = precioUnitario * 118 / 100;
                        igvItem = obj.TotalPrice * 18 / 100;
                        totalItem = obj.TotalPrice * 118 / 100;

                    }
                    else if (labTipo == "00")
                    {
                        precioUnitario = obj.TotalPrice / quantity;
                        igvItem = 0;
                        totalItem = obj.TotalPrice;
                        precioUnitarioIgv = precioUnitario;


                    }

                    TramoDetail = "ID_ITEM:1|COD_PROD_SERV_ITEM:T1|DESRIP_ITEM:Cupones_pagados_por_adelantado_para_solicitar_Informes_Comerciales|COD_UNIDAD_MEDIDA_ITEM:NIU|INDICADOR_PS_ITEM:S|INDICADOR_TRANS_GRAT:0|INDICADOR_AFECTACION_ITEM:" +
                    INDICADOR_AFECTACION_ITEM + "|VALOR_VENTA_UNITARIA:" + precioUnitario?.ToString("0.00") +
                    "|PRECIO_VENTA_UNITARIO_ITEM:" + precioUnitarioIgv?.ToString("0.00") + "|CANTIDAD_ITEM:" + quantity?.ToString("0.00") + "|DESCUENTO_ITEM:0.00|" +
                    "VALOR_ITEM:" + obj.TotalPrice?.ToString("0.00") +
                    "|IGV_TOTAL_ITEM:" + igvItem?.ToString("0.00") +
                    "|TOTAL_ITEM:" + totalItem?.ToString("0.00");

                string Detalles = Trama + TramoDetail;

                var facRuta = await context.Parameters.Where(x => x.Key == "FAC_RUTA").FirstOrDefaultAsync();
                var facSerie = await context.Parameters.Where(x => x.Key == "FAC_SERIE").FirstOrDefaultAsync();

                var host = await context.Parameters.Where(x => x.Key == "HOST_FTP_CONTANET").FirstOrDefaultAsync();
                var port = await context.Parameters.Where(x => x.Key == "PORT_FTP_CONTANET").FirstOrDefaultAsync();
                var user = await context.Parameters.Where(x => x.Key == "USER_FTP_CONTANET").FirstOrDefaultAsync();
                var password = await context.Parameters.Where(x => x.Key == "PASSWORD_FTP_CONTANET").FirstOrDefaultAsync();

            
                string fileDirectory = facSerie.Value + obj.InvoiceCode + ".txt";

          
                var ftpServerUrl = @"ftp://" + host.Value + ":" + port.Value + "/ENTRADA/";
                var username = user.Value;
                var passwordv = password.Value;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpServerUrl + fileDirectory));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, passwordv);
               request.UsePassive = false;
                try
                {
                    byte[] bytes = null;
                    using (var ms = new MemoryStream())
                    {
                        using (TextWriter tw = new StreamWriter(ms))
                        {
                            tw.Write(Detalles);
                            tw.Flush();
                            ms.Position = 0;
                            bytes = ms.ToArray();                          
                             
                                using (var writeStream = await request.GetRequestStreamAsync())
                                {
                                    ms.Position = 0;
                                    await ms.CopyToAsync(writeStream);
                                }
                           
                        }

                    }
                }
                catch (Exception ex)
                {
                    response.Data = false;
                    _logger.LogError(ex.Message);
                }
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Data = false;
                _logger.LogError(ex.Message);
            }
            return response;

        }

        private async Task<string> Codigo_Pais(SqlCoreContext context, string? oldCode)
        {
            var country =await context.Countries.Where(x => x.OldCode == oldCode).FirstOrDefaultAsync();
            if (country== null)
            {
                return ".";
            }
            return country.FlagIso.ToUpper();
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
