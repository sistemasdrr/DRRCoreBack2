using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ITicketReceptorRepository:IBaseRepository<TicketReceptor>
    {
        Task<TicketReceptor> GetReceptorDoubleDate(int idCountry);
        Task<TicketReceptor> GetReceptorInDate(int idCountry);
        Task<TicketReceptor> GetReceptorOtherCase(int idCountry);

    }
}
