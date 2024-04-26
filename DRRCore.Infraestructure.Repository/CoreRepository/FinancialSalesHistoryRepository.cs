using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class FinancialSalesHistoryRepository : IFinancialSalesHistoryRepository
    {
        private readonly ILogger _logger;
        public FinancialSalesHistoryRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(SalesHistory obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.SalesHistories.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var saleHistory = await context.SalesHistories.FindAsync(id);
                if (saleHistory != null)
                {
                    saleHistory.Enable = false;
                    saleHistory.DeleteDate = DateTime.Now;
                    saleHistory.LastUpdateUser = 1;
                    context.SalesHistories.Update(saleHistory);
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
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Task<List<SalesHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SalesHistory> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var saleHistory = await context.SalesHistories.FindAsync(id);
                return saleHistory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<SalesHistory>> GetByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var saleHistories = await context.SalesHistories.Include(x => x.IdCurrencyNavigation).Where(x => x.IdCompany == idCompany && x.Enable == true).ToListAsync();
                return saleHistories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<SalesHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(SalesHistory obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.SalesHistories.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
