using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IBusinessActivityRepository : IBaseRepository<BusineesActivity>
    {
        Task<List<BusineesActivity>> GetAllByIdBranch(int idBusinessBranch);
    }
}
