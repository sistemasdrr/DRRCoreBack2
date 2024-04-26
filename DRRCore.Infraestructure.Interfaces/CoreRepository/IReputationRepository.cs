using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IReputationRepository:IBaseRepository<Reputation>
    {
        Task<List<Reputation>> GetAllCompanyReputationAsync();
    }
}
