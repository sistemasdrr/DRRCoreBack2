using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface INumerationDomain : IBaseDomain<Numeration>
    {
        Task<Numeration> GetTicketNumberAsync();
        Task<bool> UpdateTicketNumberAsync();
        Task<Numeration> GetOrderNumberAsync();
    }
}
