using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class LandOwnershipRepository : ILandOwnershipRepository
    {
        private readonly ILogger _logger;
        public LandOwnershipRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<LandOwnership> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LandOwnership>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.LandOwnerships.Where(x => x.Enable == true).ToListAsync();
                return list;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<LandOwnership>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(LandOwnership obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LandOwnership obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
