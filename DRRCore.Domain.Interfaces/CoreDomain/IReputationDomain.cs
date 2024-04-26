using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IReputationDomain:IBaseDomain<Reputation>
    {
        Task<List<Reputation>> GetAllCompanyReputationAsync();
    }
}
