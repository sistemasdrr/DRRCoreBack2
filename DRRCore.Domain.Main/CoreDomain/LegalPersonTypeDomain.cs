using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class LegalPersonTypeDomain : ILegalPersonTypeDomain
    {
        private readonly ILegalPersonTypeRepository _legalPersonTypeRepository;
        public LegalPersonTypeDomain(ILegalPersonTypeRepository legalPersonTypeRepository)
        {
            _legalPersonTypeRepository = legalPersonTypeRepository;
        }
        public Task<bool> AddAsync(LegalPersonType obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LegalPersonType>> GetAllAsync()
        {
            return await _legalPersonTypeRepository.GetAllAsync();
        }

        public Task<LegalPersonType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LegalPersonType>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LegalPersonType obj)
        {
            throw new NotImplementedException();
        }
    }
}
