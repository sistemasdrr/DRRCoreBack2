using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CreditRiskRepository : ICreditRiskRepository
    {
        private readonly ILogger _logger;
        public CreditRiskRepository(ILogger logger)
        {
            _logger = logger;
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
            try
            {
                using var context = new SqlCoreContext();
                return await context.CreditRisks.Where(x => x.Enable == true).OrderBy(x=>x.Level).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<CreditRisk>();
            }
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
