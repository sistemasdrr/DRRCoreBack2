using AspNetCore.Reporting;
using AutoMapper;
using CoreFtp;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Email;
using DRRCore.Application.DTO.Enum;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Interfaces.EmailApplication;
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
                var today = DateTime.Today;
                using var context = new SqlCoreContext();
                var ticketHistory = await context.TicketHistories
                    .Where(x => x.UserTo.Contains(userTo) && x.Flag == true && x.ShippingDate.HasValue && x.ShippingDate.Value.Month == today.Month)
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
