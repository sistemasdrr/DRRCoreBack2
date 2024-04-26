using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class LandOwnershipDomain : ILandOwnershipDomain
    {
        private readonly ILandOwnershipRepository _landOwnershipRepository;
        public LandOwnershipDomain(ILandOwnershipRepository landOwnershipRepository)
        {
            _landOwnershipRepository = landOwnershipRepository;
        }

        public Task<bool> AddAsync(LandOwnership obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LandOwnership>> GetAllAsync()
        {
            return await _landOwnershipRepository.GetAllAsync();
        }

        public Task<LandOwnership> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LandOwnership>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LandOwnership obj)
        {
            throw new NotImplementedException();
        }
    }
}
