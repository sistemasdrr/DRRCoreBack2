using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class FinancialBalanceDomain : IFinancialBalanceDomain
    {
        private readonly IFinancialBalanceRepository _repository;
        public FinancialBalanceDomain(IFinancialBalanceRepository repository)
        {
            _repository = repository;
        }   
        public async Task<bool> AddAsync(FinancialBalance obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<FinancialBalance>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FinancialBalance> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<FinancialBalance>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FinancialBalance>> GetFinancialBalanceByIdCompany(int idCompany, string balanceType)
        {
            return await _repository.GetFinancialBalanceByIdCompany(idCompany, balanceType);
        }

        public async Task<bool> UpdateAsync(FinancialBalance obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
