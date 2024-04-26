using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly ILogger _logger;
        public ProfessionRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(Profession obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.Professions.AddAsync(obj);
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
                var profession = await context.Professions.FindAsync(id);
                if (profession != null)
                {
                    return false;
                }
                else
                {
                    profession.DeleteDate = DateTime.Now;
                    profession.Enable = false;
                    context.Professions.Update(profession);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<List<Profession>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Professions.Where(x => x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<Profession> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var profession = await context.Professions.FindAsync(id);
                if (profession != null)
                {
                    return null;
                }
                else
                {
                    return profession;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<Profession>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Profession obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                context.Professions.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
