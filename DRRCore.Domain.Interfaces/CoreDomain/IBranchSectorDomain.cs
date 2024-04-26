using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IBranchSectorDomain : IBaseDomain<BranchSector>
    {
        Task<bool> ActiveBranchSectorAsync(int id);
    }
}
