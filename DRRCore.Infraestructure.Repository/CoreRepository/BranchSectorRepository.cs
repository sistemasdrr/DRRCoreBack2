using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class BranchSectorRepository : IBranchSectorRepository
    {
        private readonly ILogger _logger;
        public BranchSectorRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> ActiveBranchSectorAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var branchSector = await context.BranchSectors.FindAsync(id);
                if(branchSector != null)
                {
                    branchSector.Enable = true;
                    branchSector.UpdateDate = DateTime.UtcNow;
                    context.BranchSectors.Update(branchSector);
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public Task<bool> AddAsync(BranchSector obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var branchSector = await context.BranchSectors.FindAsync(id);
                if (branchSector != null)
                {
                    branchSector.Enable = false;
                    branchSector.DeleteDate = DateTime.UtcNow;
                    context.BranchSectors.Update(branchSector);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<List<BranchSector>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.BranchSectors.Where(x => x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<BranchSector> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var branchSector = await context.BranchSectors.FindAsync(id);
                return branchSector;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<BranchSector>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BranchSector obj)
        {
            throw new NotImplementedException();
        }
    }
}
