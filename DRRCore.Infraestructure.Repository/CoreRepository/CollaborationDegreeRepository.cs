using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CollaborationDegreeRepository : ICollaborationDegreeRepository
    {
        private readonly ILogger _logger;
        public CollaborationDegreeRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(CollaborationDegree obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.CollaborationDegrees.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingCollaborationDegree = await context.CollaborationDegrees.FindAsync(id);
                if(existingCollaborationDegree != null)
                {
                    existingCollaborationDegree.DeleteDate = DateTime.Now;
                    existingCollaborationDegree.Enable = false;
                    context.CollaborationDegrees.Update(existingCollaborationDegree);
                    await context.SaveChangesAsync();
                    return true;
                }
                else 
                {
                    return false;
                }
            }catch (Exception ex)
            {
                _logger?.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<List<CollaborationDegree>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.CollaborationDegrees.Where(x => x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message, ex);
                return new List<CollaborationDegree>();
            }
        }

        public async Task<CollaborationDegree> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var collaborationDegree = await context.CollaborationDegrees.FindAsync(id);
                return collaborationDegree;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message, ex);
                return new CollaborationDegree();
            }
        }

        public Task<List<CollaborationDegree>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(CollaborationDegree obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                if (obj != null)
                {
                    obj.UpdateDate = DateTime.Now;
                    context.CollaborationDegrees.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
