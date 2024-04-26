using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class ComercialLatePaymentRepository : IComercialLatePaymentRepository
    {
        private readonly ILogger _logger;
        public ComercialLatePaymentRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(ComercialLatePayment obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.ComercialLatePayments.AddAsync(obj);
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
                var comercialLatePayment = await context.ComercialLatePayments.FindAsync(id);
                if (comercialLatePayment != null)
                {
                    comercialLatePayment.Enable = false;
                    comercialLatePayment.DeleteDate = DateTime.Now;
                    context.ComercialLatePayments.Update(comercialLatePayment);
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

        public Task<List<ComercialLatePayment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ComercialLatePayment> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var comercialLatePayment = await context.ComercialLatePayments.FindAsync(id);
                if (comercialLatePayment != null)
                {
                    return comercialLatePayment;
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

        public Task<List<ComercialLatePayment>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComercialLatePayment>> GetComercialLatePaymetByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.ComercialLatePayments.Where(x => x.IdCompany == idCompany).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<List<ComercialLatePayment>> GetComercialLatePaymetByIdPerson(int idPerson)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.ComercialLatePayments.Where(x => x.IdPerson == idPerson).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(ComercialLatePayment obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.ComercialLatePayments.Update(obj);
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
