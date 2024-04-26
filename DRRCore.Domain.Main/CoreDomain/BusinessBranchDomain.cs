using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class BusinessBranchDomain : IBusinessBranchDomain
    {
        private readonly IBusinessBranchRepository _repository;
        public BusinessBranchDomain(IBusinessBranchRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(BusinessBranch obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BusinessBranch>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<BusinessBranch> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusinessBranch>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BusinessBranch obj)
        {
            throw new NotImplementedException();
        }
    }
}
