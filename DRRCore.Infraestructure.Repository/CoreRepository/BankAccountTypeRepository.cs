using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class BankAccountTypeRepository : IBankAccountTypeRepository
    {
        private readonly ILogger _logger;
        public BankAccountTypeRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(BankAccountType obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BankAccountType>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.BankAccountTypes.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<BankAccountType>();
            }
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
