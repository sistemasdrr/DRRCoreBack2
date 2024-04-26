using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CurrencyDomain : ICurrencyDomain
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyDomain(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }
        public Task<bool> AddAsync(Currency obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Currency>> GetAllAsync()
        {
            return _currencyRepository.GetAllAsync();
        }

        public Task<Currency> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Currency>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Currency obj)
        {
            throw new NotImplementedException();
        }
    }
}
