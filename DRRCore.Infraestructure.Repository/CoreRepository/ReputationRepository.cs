using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class ReputationRepository : IReputationRepository
    {
        private readonly ILogger _logger;
        public ReputationRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(Reputation obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<List<Reputation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Reputation>> GetAllCompanyReputationAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Reputations.Where(x => x.Enable == true && x.Type == "E").OrderBy(x => x.Level).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Reputation>();
            }
        }

        public Task<Reputation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reputation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Reputation obj)
        {
            throw new NotImplementedException();
        }
    }
}
