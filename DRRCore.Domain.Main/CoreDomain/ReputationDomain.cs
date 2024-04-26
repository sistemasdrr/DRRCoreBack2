using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class ReputationDomain : IReputationDomain
    {
        private readonly IReputationRepository _reputationRepository;
        public ReputationDomain(IReputationRepository reputationRepository)
        {
            _reputationRepository = reputationRepository;
        }

        public Task<bool> AddAsync(Reputation obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reputation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Reputation>> GetAllCompanyReputationAsync()
        {
            return await _reputationRepository.GetAllCompanyReputationAsync();
        }

        public Task<Reputation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reputation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Reputation obj)
        {
            throw new NotImplementedException();
        }
    }
}
