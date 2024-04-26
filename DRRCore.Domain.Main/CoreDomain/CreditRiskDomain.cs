using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CreditRiskDomain : ICreditRiskDomain
    {
        private readonly ICreditRiskRepository _creditRiskDomain;
        public CreditRiskDomain(ICreditRiskRepository creditRiskDomain)
        {
            _creditRiskDomain = creditRiskDomain;
        }
        public Task<bool> AddAsync(CreditRisk obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CreditRisk>> GetAllAsync()
        {
            return await _creditRiskDomain.GetAllAsync();
        }

        public Task<CreditRisk> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CreditRisk>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CreditRisk obj)
        {
            throw new NotImplementedException();
        }
    }
}
