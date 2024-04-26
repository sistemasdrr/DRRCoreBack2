using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class LegalRegisterSituationDomain : ILegalRegisterSituationDomain
    {
        private readonly ILegalRegisterSituationRepository _legalRegisterSituationRepository;

        public LegalRegisterSituationDomain(ILegalRegisterSituationRepository legalRegisterSituationRepository)
        {
            _legalRegisterSituationRepository = legalRegisterSituationRepository;
        }
        public Task<bool> AddAsync(LegalRegisterSituation obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LegalRegisterSituation>> GetAllAsync()
        {
            return await _legalRegisterSituationRepository.GetAllAsync();
        }

        public Task<LegalRegisterSituation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LegalRegisterSituation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LegalRegisterSituation obj)
        {
            throw new NotImplementedException();
        }
    }
}
