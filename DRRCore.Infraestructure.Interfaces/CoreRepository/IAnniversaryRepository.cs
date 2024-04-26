using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IAnniversaryRepository:IBaseRepository<Anniversary>
    {
        Task<bool> ActiveAnniversaryAsync(int id);
    }
}
