using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class LegalRegisterSituationRepository : ILegalRegisterSituationRepository
    {
        private readonly ILogger _logger;
        public LegalRegisterSituationRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(LegalRegisterSituation obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LegalRegisterSituation>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.LegalRegisterSituations.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<LegalRegisterSituation>();
            }
        }

        public Task<LegalRegisterSituation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LegalRegisterSituation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LegalRegisterSituation obj)
        {
            throw new NotImplementedException();
        }
    }
}
