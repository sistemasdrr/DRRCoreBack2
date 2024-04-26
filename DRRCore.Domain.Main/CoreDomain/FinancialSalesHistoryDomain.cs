using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class FinancialSalesHistoryDomain : IFinancialSalesHistoryDomain
    {
        private readonly IFinancialSalesHistoryRepository _repository;
        public FinancialSalesHistoryDomain(IFinancialSalesHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(SalesHistory obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<SalesHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SalesHistory> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<SalesHistory>> GetByIdCompany(int idCompany)
        {
            return await _repository.GetByIdCompany(idCompany);
        }

        public Task<List<SalesHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(SalesHistory obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
