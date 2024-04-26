using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class LegalPersonTypeRepository : ILegalPersonTypeRepository
    {
        private readonly ILogger _logger;
        public LegalPersonTypeRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(LegalPersonType obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LegalPersonType>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.LegalPersonTypes.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<LegalPersonType>();
            }
        }

        public Task<LegalPersonType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LegalPersonType>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LegalPersonType obj)
        {
            throw new NotImplementedException();
        }
    }
}
