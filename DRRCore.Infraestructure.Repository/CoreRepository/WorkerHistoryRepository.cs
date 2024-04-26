using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class WorkerHistoryRepository : IWorkerHistoryRepository
    {
        private readonly ILogger _logger;
        public WorkerHistoryRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(WorkersHistory obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.WorkersHistories.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
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
                var obj = await context.WorkersHistories.FindAsync(id);
                if(obj != null)
                {
                    obj.DeleteDate = DateTime.Now;
                    obj.LastUpdateUser = 1;
                    context.WorkersHistories.Update(obj);
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

        public Task<List<WorkersHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<WorkersHistory> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.WorkersHistories.FindAsync(id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<List<WorkersHistory>> GetByIdCompanyAsync(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.WorkersHistories.Where(x => x.IdCompany == idCompany && x.Enable == true).ToListAsync();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<WorkersHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(WorkersHistory obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.WorkersHistories.Update(obj);
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
