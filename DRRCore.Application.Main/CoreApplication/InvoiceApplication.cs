
using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using DRRCore.Transversal.Common.JsonReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using DRRCore.Application.DTO.Core.Request;
using Org.BouncyCastle.Crypto;
using AutoMapper.Execution;

namespace DRRCore.Application.Main.CoreApplication
{
    public class InvoiceApplication : IInvoiceApplication
    {
        private readonly List<SpecialPriceAgent> _specialPriceAgent;
        private readonly ILogger _logger;
        private IMapper _mapper;
        public InvoiceApplication(ILogger logger, IMapper mapper, IOptions<List<SpecialPriceAgent>> specialPriceAgent)
        {
            _logger = logger;
            _mapper = mapper;
            _specialPriceAgent = specialPriceAgent.Value;
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
                if(quality != null)
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
                        .Where(x => x.ShippingDate >= startDateTime && x.ShippingDate <= endDateTime && x.Flag == true && x.FlagInvoice == false && !x.AsignedTo.Contains("P") && x.AsignedTo.Contains("A"))
                        .ToListAsync();
                    foreach (var item in ticketHistory)
                    {
                        var agent1 = new Agent();
                        var agent2 = new Personal();
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

        

        public async Task<Response<bool>> UpdateAgentTicket(int idTicketHistory, string requestedName, string procedureType, string shippingDate)
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
                        .Where(x => x.DispatchtDate >= startDateTime && x.DispatchtDate <= endDateTime && x.IdInvoiceState == 1 &&
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

        public async Task<Response<List<GetInvoiceSubscriberListToCollectResponseDto>>> GetInvoiceSubscriberListToCollect(int month, int year)
        {
            var response = new Response<List<GetInvoiceSubscriberListToCollectResponseDto>>();
            response.Data = new List<GetInvoiceSubscriberListToCollectResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoices
                    .Where(x => x.InvoiceEmitDate.Value.Month == month && x.InvoiceEmitDate.Value.Year == year && x.IdInvoiceState == 2)
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
        public async Task<Response<List<GetInvoiceSubscriberListPaidsResponseDto>>> GetInvoiceSubscriberListPaids(int month, int year)
        {
            var response = new Response<List<GetInvoiceSubscriberListPaidsResponseDto>>();
            response.Data = new List<GetInvoiceSubscriberListPaidsResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var subscriberInvoices = await context.SubscriberInvoices
                    .Where(x => x.InvoiceCancelDate.Value.Month == month && x.InvoiceCancelDate.Value.Year == year && x.IdInvoiceState == 3)
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

        public async Task<Response<bool>> SaveSubscriberInvoice(AddOrUpdateSubscriberInvoiceRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var invoiceSubscriberDetails = new List<SubscriberInvoiceDetail>();
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
                    IdSubscriber= obj.IdSubscriber,
                    IdCurrency = obj.IdCurrency,
                    Quantity = obj.InvoiceSubscriberList.Count(),
                    TotalAmount = totalAmount,
                    SubscriberInvoiceDetails = invoiceSubscriberDetails
                });
                await context.SaveChangesAsync();
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

    }
}
