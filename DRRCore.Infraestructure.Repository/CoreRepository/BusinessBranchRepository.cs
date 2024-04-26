using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class BusinessBranchRepository : IBusinessBranchRepository
    {
        private readonly ILogger _logger;
        public BusinessBranchRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(BusinessBranch obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BusinessBranch>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.BusinessBranches.Where(x => x.Enable == true).ToListAsync();
                return list;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<BusinessBranch> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusinessBranch>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BusinessBranch obj)
        {
            throw new NotImplementedException();
        }
    }
}
