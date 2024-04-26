using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ITicketHistoryDomain:IBaseDomain<TicketHistory>
    {
        public Task<List<TicketHistory>> GetAllByIdTicket(int? idTicket);
        public Task<List<TicketHistory>> GetTicketsPreAssignedToUser(string userTo);
    }
}
