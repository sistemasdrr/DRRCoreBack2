using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ITicketHistoryRepository:IBaseRepository<TicketHistory>
    {
        public Task<List<TicketHistory>> GetAllByIdTicket(int? idTicket);
        public Task<List<TicketHistory>> GetTicketsPreAssignedToUser(string userTo);
    }
}
