using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Infraestructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.SQLRepository
{
    public class ApiUserRepository : IApiUserRepository
    {
        public async Task<bool> DeleteApiUserAsync(int id)
        {
            using var context = new SqlContext();
            var apiUser = await context.ApiUsers.FindAsync(id);
            if (apiUser != null)
            {
                apiUser.Enable = false;
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<ApiUser> GetApiUserByAbonadoAndEnvironmentAsync(string codigoabonado, string environment)
        {
            try
            {
                using var context = new SqlContext();
                return await context.ApiUsers.FirstOrDefaultAsync(x => x.CodigoAbonado == codigoabonado && x.Environment == environment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiUser> GetApiUserByCodeAsync(string code)
        {
            try
            {
                using var context = new SqlContext();
                return await context.ApiUsers.FirstOrDefaultAsync(x => x.CodigoAbonado == code);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiUser> GetApiUserByTokenAsync(string token)
        {
            try
            {
                using var context = new SqlContext();
                return await context.ApiUsers.FirstOrDefaultAsync(x => x.Token == Guid.Parse(token));
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ApiUser>> GetApiUserListAllAsync()
        {
            try
            {
                using var context = new SqlContext();
                return await context.ApiUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> InsertApiUserAsync(ApiUser obj)
        {
            try
            {
                using var context = new SqlContext();
                await context.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateApiUserAsync(ApiUser obj)
        {
            try
            {
                using var context = new SqlContext();
                context.Update(obj);
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
