using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Infraestructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.SQLRepository
{
    public class ApiHistoryRepository : IApiHistoryRepository
    {
        public async Task<bool> AddApiHistoryAsync(ApiHistory obj)
        {
            try
            {
                using var context = new SqlContext();
                context.ApiHistories.Add(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeleteApiHistoryAsync(int idApiHistory)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryAsync()
        {
            try
            {
                using var context = new SqlContext();
                var apiHistories = await context.ApiHistories.ToListAsync();
                return apiHistories;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryByApiUserAsync(int idApiUser)
        {
            try
            {
                using var context = new SqlContext();
                var apiHistories = await context.ApiHistories.Where(x => x.IdApiUser == idApiUser).ToListAsync();
                return apiHistories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryBySearchAsync(string search)
        {
            try
            {
                using var context = new SqlContext();
                var apiHistories = await context.ApiHistories.Where(x => x.Search == search).ToListAsync();
                return apiHistories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryBySuccessAsync(bool success)
        {
            try
            {
                using var context = new SqlContext();
                var apiHistories = await context.ApiHistories.Where(x => x.Success == true).ToListAsync();
                return apiHistories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiHistory> GetApiHistoryByIdAsync(int idApiHistory)
        {
            try
            {
                using var context = new SqlContext();
                var apiHistories = await context.ApiHistories.FindAsync(idApiHistory);
                return apiHistories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateApiHistoryAsync(ApiHistory obj)
        {
            try
            {
                using var context = new SqlContext();
                context.ApiHistories.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
    }
}
