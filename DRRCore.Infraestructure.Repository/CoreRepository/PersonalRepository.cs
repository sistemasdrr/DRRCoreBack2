using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly ILogger _logger;
        public PersonalRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(Personal obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Personal>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var lista = await context.Personals.Where(x => x.Enable == true).Include(x => x.IdEmployeeNavigation).Include(x => x.IdEmployeeNavigation.UserLogins).ToListAsync();
                return lista;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<Personal> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Personal>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Personal obj)
        {
            throw new NotImplementedException();
        }
    }
}
