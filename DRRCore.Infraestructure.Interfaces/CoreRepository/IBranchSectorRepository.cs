using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IBranchSectorRepository : IBaseRepository<BranchSector>
    {
        Task<bool> ActiveBranchSectorAsync(int id);
    }
}
