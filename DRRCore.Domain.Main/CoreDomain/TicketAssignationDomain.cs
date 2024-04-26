using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class TicketAssignationDomain : ITicketAssignationDomain
    {
        private readonly ITicketAssignationRepository _ticketAssignationRepository;
        public TicketAssignationDomain(ITicketAssignationRepository ticketAssignationRepository)
        {
            _ticketAssignationRepository = ticketAssignationRepository;
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
            return await _ticketAssignationRepository.GetByIdAsync(id);
        }

        public Task<List<TicketAssignation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(TicketAssignation obj)
        {
            return await _ticketAssignationRepository.UpdateAsync(obj);
        }
    }
}
