using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class FamilyBondyTypeRepository : IFamilyBondTypeRepository
    {
        private readonly ILogger _logger;
        public FamilyBondyTypeRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(FamilyBondType obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FamilyBondType>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.FamilyBondTypes.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<FamilyBondType>();
            }
        }

        public Task<FamilyBondType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FamilyBondType>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(FamilyBondType obj)
        {
            throw new NotImplementedException();
        }
    }
}
