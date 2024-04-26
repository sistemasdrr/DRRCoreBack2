using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class TicketHistoryDomain : ITicketHistoryDomain
    {
        private readonly ITicketHistoryRepository _ticketHistoryRepository;
        public TicketHistoryDomain(ITicketHistoryRepository ticketHistoryRepository)
        {
            _ticketHistoryRepository = ticketHistoryRepository;
        }
        public async Task<bool> AddAsync(TicketHistory obj)
        {
           return await _ticketHistoryRepository.AddAsync(obj); 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _ticketHistoryRepository.DeleteAsync(id);
        }

        public async Task<List<TicketHistory>> GetAllAsync()
        {
           return await _ticketHistoryRepository.GetAllAsync();
        }

        public async Task<List<TicketHistory>> GetAllByIdTicket(int? idTicket)
        {
            return await _ticketHistoryRepository.GetAllByIdTicket(idTicket);
        }

        public async Task<TicketHistory> GetByIdAsync(int id)
        {
           return await _ticketHistoryRepository.GetByIdAsync(id);
        }

        public Task<List<TicketHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TicketHistory>> GetTicketsPreAssignedToUser(string userTo)
        {
            return await _ticketHistoryRepository.GetTicketsPreAssignedToUser(userTo);
        }

        public async Task<bool> UpdateAsync(TicketHistory obj)
        {
           return await _ticketHistoryRepository.UpdateAsync(obj);    
        }
    }
}
