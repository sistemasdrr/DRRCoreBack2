using DRRCore.Application.DTO.Enum;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class TicketHistoryRepository : ITicketHistoryRepository
    {

        private readonly ILogger _logger;
        public TicketHistoryRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(TicketHistory obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.TicketHistories.AddAsync(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.TicketHistories.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
                    obj.Enable = false;
                    obj.DeleteDate = DateTime.Now;
                    context.TicketHistories.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<TicketHistory>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketHistories.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<TicketHistory>();
            }
        }

        public async Task<List<TicketHistory>> GetAllByIdTicket(int? idTicket)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketHistories.Where(x => x.IdTicket == idTicket).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<TicketHistory> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketHistories.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<TicketHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TicketHistory>> GetTicketsPreAssignedToUser(string userTo)
        {

            try
            {
                using (var context = new SqlCoreContext())
                {

                    var list = await context.TicketHistories.Include(x => x.IdTicketNavigation)
                        .Include(x => x.IdTicketNavigation.IdSubscriberNavigation)
                    .Include(x => x.IdTicketNavigation.IdSubscriberNavigation.IdCountryNavigation)
                    .Include(x => x.IdTicketNavigation.IdContinentNavigation)
                    .Include(x => x.IdTicketNavigation.IdCompanyNavigation)
                    .Include(x => x.IdTicketNavigation.TicketAssignation.IdEmployeeNavigation.UserLogins)
                    .Include(x => x.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation)
                    .Include(x => x.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.IdContinentNavigation)
                    .Include(x => x.IdTicketNavigation.IdPersonNavigation)
                    .Include(x => x.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation)
                    .Include(x => x.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.IdContinentNavigation)
                    .Include(x => x.IdTicketNavigation.IdCountryNavigation)
                    .Include(x => x.IdTicketNavigation.IdStatusTicketNavigation)
                    .Include(x => x.IdStatusTicketNavigation)
                    .Include(x => x.IdTicketNavigation.TicketAssignation)
                    .Include(x => x.IdTicketNavigation.TicketQuery)
                    .Include(x => x.IdTicketNavigation.TicketHistories)
                    .Include(x => x.IdTicketNavigation.TicketFiles)
                    .Include(x => x.IdTicketNavigation.TicketHistories.OrderByDescending(x => x.Id)).Where(x => x.Enable == true)
                    .OrderByDescending(x => x.IdTicketNavigation.OrderDate)
                    .Where(x => x.UserTo == userTo && x.Flag == false && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Despachado && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Observado && x.IdTicketNavigation.IdStatusTicket != (int)TicketStatusEnum.Rechazado)
                        .ToListAsync();
                    return list;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(TicketHistory obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {

                    obj.UpdateDate = DateTime.Now;
                    context.TicketHistories.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
