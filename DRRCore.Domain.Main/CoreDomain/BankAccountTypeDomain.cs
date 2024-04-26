using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class BankAccountTypeDomain : IBankAccountTypeDomain
    {
        private readonly IBankAccountTypeRepository _bankAccountTypeRepository;
        public BankAccountTypeDomain(IBankAccountTypeRepository bankAccountTypeRepository)
        {
            _bankAccountTypeRepository = bankAccountTypeRepository;
        }

        public Task<bool> AddAsync(BankAccountType obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BankAccountType>> GetAllAsync()
        {
           return _bankAccountTypeRepository.GetAllAsync();
        }

        public Task<BankAccountType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BankAccountType>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BankAccountType obj)
        {
            throw new NotImplementedException();
        }
    }
}
