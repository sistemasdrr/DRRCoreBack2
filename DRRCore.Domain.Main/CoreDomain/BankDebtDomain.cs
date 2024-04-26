using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class BankDebtDomain : IBankDebtDomain
    {
        private readonly IBankDebtRepository _repository;
        public BankDebtDomain(IBankDebtRepository repository)
        {
            this._repository = repository;
        }

        public async Task<bool> AddAsync(BankDebt obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<BankDebt>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BankDebt>> GetBankDebtsByIdCompany(int idCompany)
        {
            return await _repository.GetBankDebtsByIdCompany(idCompany);
        }

        public async Task<List<BankDebt>> GetBankDebtsByIdPerson(int idPerson)
        {
            return await _repository.GetBankDebtsByIdPerson(idPerson);
        }

        public async Task<BankDebt> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<BankDebt>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(BankDebt obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
