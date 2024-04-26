using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class TicketAssignationRepository : ITicketAssignationRepository
    {
        private readonly ILogger _logger;
        public TicketAssignationRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(TicketAssignation obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TicketAssignation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TicketAssignation> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.TicketAssignations.Where(x => x.IdTicket == id).FirstOrDefaultAsync();
                if(ticket != null)
                {
                    return ticket;
                }
                else
                {
                    return null;
                }
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<TicketAssignation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(TicketAssignation obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                context.TicketAssignations.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
