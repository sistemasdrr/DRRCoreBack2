using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class SubscriberCategoryRepository : ISubscriberCategoryRepository
    {
        private readonly ILogger _logger;
        public SubscriberCategoryRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(SubscriberCategory obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.SubscriberCategories.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingSubscriberCategory = await context.SubscriberCategories.FindAsync(id);
                if (existingSubscriberCategory != null)
                {
                    existingSubscriberCategory.DeleteDate = DateTime.Now;
                    existingSubscriberCategory.Enable = false;
                    context.SubscriberCategories.Update(existingSubscriberCategory);
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
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<SubscriberCategory>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.SubscriberCategories.Where(x => x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<SubscriberCategory>();
            }
        }

        public async Task<SubscriberCategory> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var subscriberCategory = await context.SubscriberCategories.FindAsync(id);
                return subscriberCategory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new SubscriberCategory();
            }
        }

        public Task<List<SubscriberCategory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(SubscriberCategory obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.SubscriberCategories.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
