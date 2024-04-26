using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IBusinessActivityDomain : IBaseDomain<BusineesActivity>
    {
        Task<List<BusineesActivity>> GetAllByIdBranch(int idBusinessBranch);
    }
}
