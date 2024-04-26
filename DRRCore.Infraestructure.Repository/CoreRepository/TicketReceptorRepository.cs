using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class TicketReceptorRepository : ITicketReceptorRepository
    {
        private readonly ILogger _logger;
        public TicketReceptorRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(TicketReceptor obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.TicketReceptors.AddAsync(obj);
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
                    var obj = await context.TicketReceptors.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
                    obj.Enable = false;
                    context.TicketReceptors.Update(obj);
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

        public async Task<List<TicketReceptor>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketReceptors.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<TicketReceptor>();
            }
        }

        public async Task<TicketReceptor> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketReceptors.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new TicketReceptor();
            }
        }

        public Task<List<TicketReceptor>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<TicketReceptor> GetReceptorDoubleDate(int idCountry)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketReceptors.Where(x => x.IsDobleFecha == true && x.IdCountry==idCountry && x.IsEnFecha==false).FirstOrDefaultAsync() ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new TicketReceptor();
            }
        }

        public async Task<TicketReceptor> GetReceptorInDate(int idCountry)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketReceptors.Where(x => x.IsEnFecha == true && x.IdCountry == idCountry && x.IsDobleFecha == false).FirstOrDefaultAsync() ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new TicketReceptor();
            }
        }

        public async Task<TicketReceptor> GetReceptorOtherCase(int idCountry)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.TicketReceptors.Where(x => x.IdCountry == idCountry && x.IsEnFecha == false && x.IsDobleFecha == false).FirstOrDefaultAsync() ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new TicketReceptor();
            }
        }

        public async Task<bool> UpdateAsync(TicketReceptor obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.TicketReceptors.Update(obj);
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
    }
}
