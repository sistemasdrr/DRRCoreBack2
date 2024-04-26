using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class AnniversaryRepository : IAnniversaryRepository
    {
        private readonly ILogger _logger;
        public AnniversaryRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> ActiveAnniversaryAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.Anniversaries.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
                    obj.Enable = true;
                    obj.DeleteDate = null;
                    context.Anniversaries.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> AddAsync(Anniversary obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.Anniversaries.AddAsync(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.Anniversaries.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
                    obj.Enable = false;
                    obj.DeleteDate = DateTime.Now;
                    context.Anniversaries.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<Anniversary>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Anniversaries.Where(x=>x.Enable==true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Anniversary>();
            }
        }

        public async Task<Anniversary> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Anniversaries.FindAsync(id)?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<Anniversary>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Anniversary obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                  
                    obj.UpdateDate = DateTime.Now;
                    context.Anniversaries.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
