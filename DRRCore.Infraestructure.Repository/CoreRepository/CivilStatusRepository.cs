using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CivilStatusRepository : ICivilStatusRepository
    {
        private readonly ILogger _logger;
        public CivilStatusRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(CivilStatus obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CivilStatus>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.CivilStatuses.Where(x => x.Enable == true).OrderBy(x => x.Level).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<CivilStatus>();
            }
        }

        public Task<CivilStatus> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CivilStatus>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CivilStatus obj)
        {
            throw new NotImplementedException();
        }
    }
}
