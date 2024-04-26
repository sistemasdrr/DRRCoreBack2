using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ILogger _logger;
        public CurrencyRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(Currency obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Currencies.Where(x => x.Enable == true).OrderBy(x=>x.Level).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Currency>();
            }
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
