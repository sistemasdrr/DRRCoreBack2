using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class NumerationRepository : INumerationRepository
    {
        private readonly ILogger _logger;
        public NumerationRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(Numeration obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingNumeration = await context.Numerations.Where(x => x.Name == obj.Name).FirstOrDefaultAsync();
                if (existingNumeration != null)
                {
                    existingNumeration.Number++;
                    context.Numerations.Update(existingNumeration);
                    await context.SaveChangesAsync();
                }
                else
                {
                    await context.Numerations.AddAsync(obj);
                    await context.SaveChangesAsync();
                }
                return true;
            }catch(Exception ex)
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
                var numeration = await context.Numerations.FindAsync(id);
                numeration.Enable = false;
                context.Numerations.Update(numeration);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public Task<List<Numeration>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Numeration> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var numeration = await context.Numerations.FindAsync(id);
                return numeration;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<Numeration>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Numeration> GetOrderNumberAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Numeration> GetTicketNumberAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Numerations.Where(x=>x.Name== "NUM_TICKET").FirstOrDefaultAsync() ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Numeration obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                context.Numerations.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<bool> UpdateTicketNumberAsync()
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var number = await context.Numerations.Where(x => x.Name == "NUM_TICKET").FirstOrDefaultAsync() ?? throw new Exception("No existe el objeto solicitado");

                    number.UpdateDate = DateTime.Now;
                    number.Number++;
                    context.Numerations.Update(number);
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
