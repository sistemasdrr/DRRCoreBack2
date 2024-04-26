using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class BusinessActivityRepository : IBusinessActivityRepository
    {
        private readonly ILogger _logger;
        public BusinessActivityRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(BusineesActivity obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusineesActivity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BusineesActivity>> GetAllByIdBranch(int idBusinessBranch)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.BusineesActivities.Where(x => x.Enable == true && x.IdBusinessBranch == idBusinessBranch).ToListAsync();
                return list;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<BusineesActivity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusineesActivity>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BusineesActivity obj)
        {
            throw new NotImplementedException();
        }
    }
}
