using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class BranchSectorDomain : IBranchSectorDomain
    {
        public readonly IBranchSectorRepository _branchSectorRepository;
        public BranchSectorDomain(IBranchSectorRepository branchSectorRepository)
        {
            _branchSectorRepository = branchSectorRepository;
        }

        public async Task<bool> ActiveBranchSectorAsync(int id)
        {
            return await  _branchSectorRepository.ActiveBranchSectorAsync(id);
        }

        public Task<bool> AddAsync(BranchSector obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BranchSector>> GetAllAsync()
        {
            return await _branchSectorRepository.GetAllAsync();
        }

        public async Task<BranchSector> GetByIdAsync(int id)
        {
            return await _branchSectorRepository.GetByIdAsync(id);
        }

        public Task<List<BranchSector>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BranchSector obj)
        {
            throw new NotImplementedException();
        }
    }
}
