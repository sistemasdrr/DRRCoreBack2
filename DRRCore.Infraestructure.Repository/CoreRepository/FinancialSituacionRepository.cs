using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class FinancialSituacionRepository : IFinancialSituacionRepository
    {
        private readonly ILogger _logger;
        public FinancialSituacionRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(FinancialSituacion obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.FinancialSituacions.AddAsync(obj);
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
                var existingFinancialSituation = await context.FinancialSituacions.FindAsync(id);
                if(existingFinancialSituation != null)
                {
                    existingFinancialSituation.Enable = false;
                    existingFinancialSituation.DeleteDate = DateTime.Now;
                    context.FinancialSituacions.Update(existingFinancialSituation);
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
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<List<FinancialSituacion>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.FinancialSituacions.Where(x => x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new List<FinancialSituacion>();
            }
        }

        public async Task<FinancialSituacion> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingFinancialSituacion= await context.FinancialSituacions.FindAsync(id);
                return existingFinancialSituacion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FinancialSituacion();
            }
        }

        public Task<List<FinancialSituacion>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(FinancialSituacion obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                context.FinancialSituacions.Update(obj);
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
