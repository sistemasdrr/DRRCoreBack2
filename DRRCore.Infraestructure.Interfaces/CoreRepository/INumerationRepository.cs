using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface INumerationRepository : IBaseRepository<Numeration>
    {
        Task<Numeration> GetTicketNumberAsync();
        Task<bool> UpdateTicketNumberAsync();
        Task<Numeration> GetOrderNumberAsync();
    }
}
