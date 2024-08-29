using AspNetCore.Reporting;
using AutoMapper;
using CoreFtp;
using DocumentFormat.OpenXml.Bibliography;
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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace DRRCore.Application.Main.CoreApplication
{
    public class DashboardApplication : IDashboardApplication
    {

        private ILogger _logger;
        public DashboardApplication(ILogger logger) 
        {
            _logger = logger;
        }

        public async Task<Response<List<PendingTaskResponseDto>>> PendingTask(string userTo)
        {
            var response = new Response<List<PendingTaskResponseDto>>();
            response.Data = new List<PendingTaskResponseDto>();

            try
            {
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories
                    .Where(x => x.UserTo == userTo && x.Flag == false
                        && x.IdStatusTicket != (int?)TicketStatusEnum.Despachado
                        && x.IdStatusTicket != (int)TicketStatusEnum.Observado
                        && x.IdStatusTicket != (int)TicketStatusEnum.Rechazado)
                    .ToListAsync();

                var groupedTickets = ticketHistory
                    .GroupBy(x => x.AsignedTo)
                    .Select(g => new PendingTaskResponseDto
                    {
                        AsignedTo = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                response.Data = groupedTickets;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
                response.Message = ex.Message;  // Opcional: Agregar mensaje de error en la respuesta
            }
            return response;
        }

        public async Task<Response<int?>> DailyProduction(string userTo)
        {
            var response = new Response<int?>();
            try
            {
                var today = DateTime.Today;
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories
                    .Where(x => x.UserTo.Contains(userTo) && x.Flag == true && x.ShippingDate.HasValue && x.ShippingDate.Value.Date == today)
                    .ToListAsync();
                response.Data = ticketHistory?.Count();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<int?>> MonthlyProduction(string userTo)
        {
            var response = new Response<int?>();
            try
            {
                var num = 0;
                var today = DateTime.Today;
                using var context = new SqlCoreContext();
                var cycle = await context.ProductionClosures.Where(x => x.EndDate.Value.Month == today.Month && x.EndDate.Value.Year == today.Year).FirstOrDefaultAsync();
                if(cycle != null)
                {
                    var ticketHistory = await context.TicketHistories
                    .Where(x => x.UserTo.Contains(userTo) && x.Flag == true && x.AsignedTo.Contains("CR") == false && x.Cycle == cycle.Code && x.ShippingDate.HasValue && (x.AsignationType == "RP" || x.AsignationType == "DI" || x.AsignationType == "TR" || x.AsignationType == "RF"))
                    .ToListAsync();
                    num = ticketHistory.Count();
                }

                response.Data = num;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<ObservedTickets?>>> ObservedTickets(int idEmployee)
        {
            var response = new Response<List<ObservedTickets?>>();
            response.Data = new List<ObservedTickets?>();
            try
            {
                using var context = new SqlCoreContext();
                var personal = await context.Personals.Where(x => x.IdEmployee == idEmployee).ToListAsync();
                foreach (var item in personal)
                {
                    var listTicketObservations = await context.DetailsTicketObservations
                        .Include(x => x.IdTicketObservationsNavigation)
                        .Include(x => x.IdTicketObservationsNavigation.IdTicketNavigation)
                        .Where(x => x.AssignedTo.Contains(item.Code) && x.IdTicketObservationsNavigation.IdStatusTicketObservations == 1).ToListAsync();
                    foreach (var item1 in listTicketObservations)
                    {
                        response.Data.Add(new ObservedTickets
                        {
                            AsignedTo = item1.AssignedTo,
                            IdTicket = item1.IdTicketObservationsNavigation.IdTicket,
                            Ticket = item1.IdTicketObservationsNavigation.IdTicketNavigation.Number.ToString("D6")
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = true;
            }
            return response;
        }
        public async Task<Response<object>> TicketsInCurrentMonth()
        {
            var response = new Response<object>();
            var listSerie=new List<SeriesDashboard>();
            try
            {
                using var context = new SqlCoreContext();
                var resultRelated = context.Set<TicketsInCurrentMonthSP>()
                                    .FromSqlRaw("EXECUTE SP_TicketsInCurrentMonth")
                                    .AsEnumerable()
                                    .ToList();
                var selectRt= resultRelated.Select(x=>x.ReportType).Distinct().ToArray();
                var selectPt = resultRelated.Select(x => x.ProcedureType).Distinct().ToArray();

                for (int i = 0; i < selectPt.Length; i++)
                {
                    int[] arrayData = new int[selectRt.Length];
                    if (selectPt[i] != null) {

                        for (int j = 0; j < selectRt.Length; j++)
                        {
                            var selectPtByRt = resultRelated.Where(x => x.ReportType == selectRt[j] && x.ProcedureType == selectPt[i]).FirstOrDefault();

                            arrayData[j]=selectPtByRt != null? selectPtByRt.Quantity.Value:0;
                        }

                        listSerie.Add(new SeriesDashboard
                        {
                            Name = selectPt[i].ToString(),
                            Data= arrayData
                        });
                   }
                }



                response.Data = new SeriesDashboardResponse
                {
                    Series = listSerie,
                    Categories = selectRt
                };
                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = true;
            }
            return response;
        }

        public async Task<Response<List<PendingTaskSupervisorResponseDto>>> GetPendingTaskByUser(string userTo)
        {
            var response = new Response<List<PendingTaskSupervisorResponseDto>>();
            response.Data = new List<PendingTaskSupervisorResponseDto>();
            try
            {
                using var context = new SqlCoreContext();


                var supervisor = await context.UserLogins.Where(x => x.Id == int.Parse(userTo))
                    .Include(x => x.IdEmployeeNavigation).ThenInclude(x => x.Personals).FirstOrDefaultAsync();
                var subordinates = new List<Supervisor>();
                if (supervisor != null && supervisor.IdEmployeeNavigation.Personals.FirstOrDefault() != null)
                {
                    if(supervisor.Id == 31 || supervisor.Id == 38 || supervisor.Id == 42) //GERENCIA
                    {
                        subordinates = await context.Supervisors
                            .Include(x => x.IdUserLoginNavigation).ThenInclude(x => x.IdEmployeeNavigation).ThenInclude(x => x.Personals)
                            .ToListAsync();
                        var idSupervisors = subordinates.DistinctBy(x => x.IdUserLogin);
                        foreach (var item in idSupervisors)
                        {
                            var pendingTaskSupervisor = new PendingTaskSupervisorResponseDto();
                            pendingTaskSupervisor.Details = new List<PendingTaskPersonalResponseDto>();
                            pendingTaskSupervisor.Name = item.IdUserLoginNavigation.IdEmployeeNavigation.FirstName + " " + item.IdUserLoginNavigation.IdEmployeeNavigation.LastName;
                            pendingTaskSupervisor.Code = item.IdUserLoginNavigation.IdEmployeeNavigation.Personals.Where(x => x.Type == "SU").FirstOrDefault().Code;
                            foreach (var subordinate in subordinates.Where(x => x.IdUserLogin == item.IdUserLogin))
                            {
                                var pendingTaskPersonal = new PendingTaskPersonalResponseDto();
                                pendingTaskPersonal.Details = new List<PendingTaskPersonalDetailsResponseDto>();

                                string name = "";
                                string country = "";
                                string flagCountry = "";

                                if (subordinate.Type == "AG")
                                {
                                    var agentI = await context.Agents
                                        .Where(x => x.Code.Contains(subordinate.AsignedTo))
                                        .Include(x => x.IdCountryNavigation)
                                        .FirstOrDefaultAsync();

                                    var agentE = await context.Personals
                                        .Where(x => x.Code.Contains(subordinate.AsignedTo))
                                        .Include(x => x.IdEmployeeNavigation)
                                        .FirstOrDefaultAsync();
                                    pendingTaskPersonal.Type = "AG";
                                    if (agentI != null)
                                    {
                                        name = agentI.Name;
                                        country = agentI.IdCountryNavigation.Iso ?? "";
                                        flagCountry = agentI.IdCountryNavigation.FlagIso ?? "";
                                    }
                                    else
                                    {
                                        name = agentE.IdEmployeeNavigation.FirstName + " " + agentE.IdEmployeeNavigation.LastName;
                                        if (agentE.IdEmployeeNavigation.IdCountry != null && agentE.IdEmployeeNavigation.IdCountry != 0)
                                        {
                                            var cty = await context.Countries.Where(x => x.Id == agentE.IdEmployeeNavigation.IdCountry).FirstOrDefaultAsync();
                                            if (cty != null)
                                            {
                                                country = cty.Iso;
                                                flagCountry = cty.FlagIso;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var reporter = await context.Personals
                                        .Where(x => x.Code.Contains(subordinate.AsignedTo))
                                        .Include(x => x.IdEmployeeNavigation)
                                        .FirstOrDefaultAsync();
                                    if (reporter != null)
                                    {
                                        name = reporter.IdEmployeeNavigation.FirstName + " " + reporter.IdEmployeeNavigation.LastName;
                                        if (reporter.IdEmployeeNavigation.IdCountry != null && reporter.IdEmployeeNavigation.IdCountry != 0)
                                        {
                                            var cty = await context.Countries.Where(x => x.Id == reporter.IdEmployeeNavigation.IdCountry).FirstOrDefaultAsync();
                                            if (cty != null)
                                            {
                                                country = cty.Iso;
                                                flagCountry = cty.FlagIso;
                                            }
                                        }
                                    }
                                    pendingTaskPersonal.Type = "RP";
                                }
                                pendingTaskPersonal.AsignedTo = subordinate.AsignedTo;
                                pendingTaskPersonal.Name = name;
                                pendingTaskPersonal.Country = country;
                                pendingTaskPersonal.FlagCountry = flagCountry;
                                var ticketHistory = await context.TicketHistories
                                    .Where(x => x.AsignedTo.Contains(subordinate.AsignedTo.Trim())
                                    && x.IdTicketNavigation.IdStatusTicket != (int?)TicketStatusEnum.Despachado
                                    && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Observado
                                    && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Rechazado
                                    && x.Flag == false)
                                    .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                                    .ToListAsync();
                                foreach (var ticket in ticketHistory)
                                {
                                    var details = new PendingTaskPersonalDetailsResponseDto();
                                    details.Id = ticket.IdTicket;
                                    details.RequestedName = ticket.IdTicketNavigation.RequestedName;
                                    details.Number = ticket.IdTicketNavigation.IsComplement != null && ticket.IdTicketNavigation.IsComplement == true ? ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6") + " (C) " : ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6");
                                    details.Country = ticket.IdTicketNavigation.IdCountryNavigation.Iso ?? "";
                                    details.FlagCountry = ticket.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "";
                                    details.ExpireDate = StaticFunctions.DateTimeToString(ticket.IdTicketNavigation.ExpireDate);
                                    details.Flag = GetFlagDate(ticket.IdTicketNavigation.ExpireDate);
                                    pendingTaskPersonal.Details.Add(details);
                                }
                                pendingTaskSupervisor.Details.Add(pendingTaskPersonal);
                            }

                            var typists = await context.Personals.Where(x => x.Type == "DI" && x.Enable == true).Include(x => x.IdEmployeeNavigation).ToListAsync();
                            foreach (var item1 in typists)
                            {
                                var pendingTaskTypist = new PendingTaskPersonalResponseDto();
                                pendingTaskTypist.Details = new List<PendingTaskPersonalDetailsResponseDto>();
                                var c = "";
                                var fc = "";
                                pendingTaskTypist.Name = item1.IdEmployeeNavigation.FirstName + " " + item1.IdEmployeeNavigation.LastName;
                                if (item1.IdEmployeeNavigation.IdCountry != null && item1.IdEmployeeNavigation.IdCountry != 0)
                                {
                                    var country1 = await context.Countries.Where(x => x.Id == item1.IdEmployeeNavigation.IdCountry).FirstOrDefaultAsync();
                                    if (country1 != null)
                                    {
                                        c = country1.Iso;
                                        fc = country1.FlagIso;
                                    }
                                }
                                pendingTaskTypist.FlagCountry = fc;
                                pendingTaskTypist.Country = c;
                                pendingTaskTypist.Type = "DI";
                                pendingTaskTypist.AsignedTo = item1.Code.Trim();

                                var ticketHistoryTypist = await context.TicketHistories
                                .Where(x => x.AsignedTo.Contains(item1.Code.Trim())
                                && x.IdTicketNavigation.IdStatusTicket != (int?)TicketStatusEnum.Despachado
                                && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Observado
                                && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Rechazado
                                && x.Flag == false)
                                .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                                .ToListAsync();
                                foreach (var ticket in ticketHistoryTypist)
                                {
                                    var details = new PendingTaskPersonalDetailsResponseDto();
                                    details.Id = ticket.IdTicket;
                                    details.RequestedName = ticket.IdTicketNavigation.RequestedName;
                                    details.Number = ticket.IdTicketNavigation.IsComplement != null && ticket.IdTicketNavigation.IsComplement == true ? ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6") + " (C) " : ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6");
                                    details.Country = ticket.IdTicketNavigation.IdCountryNavigation.Iso ?? "";
                                    details.FlagCountry = ticket.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "";
                                    details.ExpireDate = StaticFunctions.DateTimeToString(ticket.IdTicketNavigation.ExpireDate);
                                    details.Flag = GetFlagDate(ticket.IdTicketNavigation.ExpireDate);
                                    pendingTaskTypist.Details.Add(details);
                                }


                                pendingTaskSupervisor.Details.Add(pendingTaskTypist);
                            }

                            var translators = await context.Personals.Where(x => x.Type == "TR" && x.Enable == true).Include(x => x.IdEmployeeNavigation).ToListAsync();
                            foreach (var item1 in translators)
                            {
                                var pendingTaskTranslator = new PendingTaskPersonalResponseDto();
                                pendingTaskTranslator.Details = new List<PendingTaskPersonalDetailsResponseDto>();
                                var c = "";
                                var fc = "";
                                pendingTaskTranslator.Name = item1.IdEmployeeNavigation.FirstName + " " + item1.IdEmployeeNavigation.LastName;
                                if (item1.IdEmployeeNavigation.IdCountry != null && item1.IdEmployeeNavigation.IdCountry != 0)
                                {
                                    var country1 = await context.Countries.Where(x => x.Id == item1.IdEmployeeNavigation.IdCountry).FirstOrDefaultAsync();
                                    if (country1 != null)
                                    {
                                        c = country1.Iso;
                                        fc = country1.FlagIso;
                                    }
                                }
                                pendingTaskTranslator.FlagCountry = fc;
                                pendingTaskTranslator.Country = c;
                                pendingTaskTranslator.Type = "TR";
                                pendingTaskTranslator.AsignedTo = item1.Code.Trim();

                                var ticketHistoryTranslator = await context.TicketHistories
                                .Where(x => x.AsignedTo.Contains(item1.Code.Trim())
                                && x.IdTicketNavigation.IdStatusTicket != (int?)TicketStatusEnum.Despachado
                                && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Observado
                                && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Rechazado
                                && x.Flag == false)
                                .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                                .ToListAsync();
                                foreach (var ticket in ticketHistoryTranslator)
                                {
                                    var details = new PendingTaskPersonalDetailsResponseDto();
                                    details.Id = ticket.IdTicket;
                                    details.RequestedName = ticket.IdTicketNavigation.RequestedName;
                                    details.Number = ticket.IdTicketNavigation.IsComplement != null && ticket.IdTicketNavigation.IsComplement == true ? ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6") + " (C) " : ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6");
                                    details.Country = ticket.IdTicketNavigation.IdCountryNavigation.Iso ?? "";
                                    details.FlagCountry = ticket.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "";
                                    details.ExpireDate = StaticFunctions.DateTimeToString(ticket.IdTicketNavigation.ExpireDate);
                                    details.Flag = GetFlagDate(ticket.IdTicketNavigation.ExpireDate);
                                    pendingTaskTranslator.Details.Add(details);
                                }


                                pendingTaskSupervisor.Details.Add(pendingTaskTranslator);
                            }

                           
                            response.Data.Add(pendingTaskSupervisor);
                        }
                    }
                    else
                    {
                        switch (supervisor.Id)
                        {
                            case 23:
                                subordinates = await context.Supervisors.Where(x => x.Type == "AG").ToListAsync();
                                break;
                            case 50:
                                subordinates = await context.Supervisors.Where(x => x.Type == "AG").ToListAsync();
                                break;
                            case 42:
                                subordinates = await context.Supervisors.Where(x => x.Type == "RP").ToListAsync();
                                break;
                            default:
                                subordinates = await context.Supervisors.Where(x => x.IdUserLogin == int.Parse(userTo)).ToListAsync();
                                break;
                        }
                        var pendingTaskSupervisor = new PendingTaskSupervisorResponseDto();
                        pendingTaskSupervisor.Details = new List<PendingTaskPersonalResponseDto>();
                        pendingTaskSupervisor.Name = supervisor.IdEmployeeNavigation.FirstName + " " + supervisor.IdEmployeeNavigation.LastName;
                        if(userTo == "42" || userTo == "23" || userTo == "50")
                        {
                            pendingTaskSupervisor.Code = "";
                        }
                        else
                        {
                            pendingTaskSupervisor.Code = supervisor.IdEmployeeNavigation.Personals.Where(x => x.Type == "SU").FirstOrDefault().Code;
                        }
                        foreach (var subordinate in subordinates)
                        {
                            var pendingTaskPersonal = new PendingTaskPersonalResponseDto();
                            pendingTaskPersonal.Details = new List<PendingTaskPersonalDetailsResponseDto>();

                            string name = "";
                            string country = "";
                            string flagCountry = "";

                            if (subordinate.Type == "AG")
                            {
                                var agentI = await context.Agents
                                    .Where(x => x.Code.Contains(subordinate.AsignedTo))
                                    .Include(x => x.IdCountryNavigation)
                                    .FirstOrDefaultAsync();

                                var agentE = await context.Personals
                                    .Where(x => x.Code.Contains(subordinate.AsignedTo))
                                    .Include(x => x.IdEmployeeNavigation)
                                    .FirstOrDefaultAsync();
                                if (agentI != null)
                                {
                                    name = agentI.Name;
                                    country = agentI.IdCountryNavigation.Iso ?? "";
                                    flagCountry = agentI.IdCountryNavigation.FlagIso ?? "";
                                }
                                else
                                {
                                    name = agentE.IdEmployeeNavigation.FirstName + " " + agentE.IdEmployeeNavigation.LastName;
                                    if (agentE.IdEmployeeNavigation.IdCountry != null && agentE.IdEmployeeNavigation.IdCountry != 0)
                                    {
                                        var cty = await context.Countries.Where(x => x.Id == agentE.IdEmployeeNavigation.IdCountry).FirstOrDefaultAsync();
                                        if (cty != null)
                                        {
                                            country = cty.Iso;
                                            flagCountry = cty.FlagIso;
                                        }
                                    }
                                }

                                pendingTaskPersonal.Type = "AG";
                            }
                            else
                            {
                                var reporter = await context.Personals
                                    .Where(x => x.Code.Contains(subordinate.AsignedTo))
                                    .Include(x => x.IdEmployeeNavigation)
                                    .FirstOrDefaultAsync();
                                if (reporter != null)
                                {
                                    name = reporter.IdEmployeeNavigation.FirstName + " " + reporter.IdEmployeeNavigation.LastName;
                                    if (reporter.IdEmployeeNavigation.IdCountry != null && reporter.IdEmployeeNavigation.IdCountry != 0)
                                    {
                                        var cty = await context.Countries.Where(x => x.Id == reporter.IdEmployeeNavigation.IdCountry).FirstOrDefaultAsync();
                                        if (cty != null)
                                        {
                                            country = cty.Iso;
                                            flagCountry = cty.FlagIso;
                                        }
                                    }
                                }
                                pendingTaskPersonal.Type = "RP";
                            }


                            pendingTaskPersonal.AsignedTo = subordinate.AsignedTo;
                            pendingTaskPersonal.Name = name;
                            pendingTaskPersonal.Country = country;
                            pendingTaskPersonal.FlagCountry = flagCountry;
                            var ticketHistory = await context.TicketHistories
                                .Where(x => x.AsignedTo.Contains(subordinate.AsignedTo.Trim())
                                && x.IdTicketNavigation.IdStatusTicket != (int?)TicketStatusEnum.Despachado
                                && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Observado
                                && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Rechazado
                                && x.Flag == false)
                                .Include(x => x.IdTicketNavigation).ThenInclude(x => x.IdCountryNavigation)
                                .ToListAsync();
                            foreach (var ticket in ticketHistory)
                            {
                                var details = new PendingTaskPersonalDetailsResponseDto();
                                details.Id = ticket.IdTicket;
                                details.RequestedName = ticket.IdTicketNavigation.RequestedName;
                                details.Number = ticket.IdTicketNavigation.IsComplement != null && ticket.IdTicketNavigation.IsComplement == true ? ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6") + " (C) " : ticket.IdTicketNavigation.About + " - " + ticket.IdTicketNavigation.Number.ToString("D6");
                                details.Country = ticket.IdTicketNavigation.IdCountryNavigation.Iso ?? "";
                                details.FlagCountry = ticket.IdTicketNavigation.IdCountryNavigation.FlagIso ?? "";
                                details.ExpireDate = StaticFunctions.DateTimeToString(ticket.IdTicketNavigation.ExpireDate);
                                details.Flag = GetFlagDate(ticket.IdTicketNavigation.ExpireDate);
                                pendingTaskPersonal.Details.Add(details);
                            }
                            pendingTaskSupervisor.Details.Add(pendingTaskPersonal);
                        }
                        response.Data.Add(pendingTaskSupervisor);
                    }
                }
                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = true;
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

    }

    public class SeriesDashboard
    {
        public string Name { get; set; }= string.Empty; 
        public int[] Data { get; set; }=new int[0];
    }
    public class SeriesDashboardResponse
    {
        public object Series { get; set; }=new object();
        public object Colors { get; set; } = new object();
        public object Categories { get; set; } = new object();
    }
}
