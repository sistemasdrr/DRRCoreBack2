using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly ILogger _logger;
        public UserLoginRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(UserLogin obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.UserLogins.AddAsync(obj);
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
                    var obj = await context.UserLogins.FindAsync(id) ?? throw new Exception("No existe el país solicitado");
                    obj.Enable = false;
                    context.UserLogins.Update(obj);
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

        public Task<List<UserLogin>> GetAllAsync()
        {
           throw new NotImplementedException();
        }

        public async Task<UserLogin> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.UserLogins.Include(x=>x.IdEmployeeNavigation).Where(x=>x.Id==id).FirstOrDefaultAsync() ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<Country>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GetIdUserByIdEmployee(int idEmployee)
        {
            try
            {
                using var context = new SqlCoreContext();
                var user = await context.UserLogins.FirstOrDefaultAsync(x => x.IdEmployee == idEmployee);
                if(user != null)
                {
                    return user.Id;
                }else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<UserLogin>> GetUserLoginEmails()
        {
            try
            {
                using var context = new SqlCoreContext();
                var users = await context.UserLogins.Include(x => x.IdEmployeeNavigation).ToListAsync();
                return users != null ? users : null;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(UserLogin obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.UserLogins.Update(obj);
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

        public async Task<UserLogin> UserLogin(string username, string password)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.UserLogins.FirstOrDefaultAsync(x => x.UserLogin1 == username && x.Password == password) ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        Task<List<UserLogin>> IBaseRepository<UserLogin>.GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
