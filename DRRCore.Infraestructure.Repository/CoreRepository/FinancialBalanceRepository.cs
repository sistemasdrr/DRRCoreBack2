using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class FinancialBalanceRepository : IFinancialBalanceRepository
    {
        private readonly ILogger _logger;
        public FinancialBalanceRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(FinancialBalance obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.FinancialBalances.AddAsync(obj);
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
                var deleteBalance = await context.FinancialBalances.FindAsync(id);
                if(deleteBalance != null)
                {
                    deleteBalance.Enable = false;
                    deleteBalance.DeleteDate = DateTime.UtcNow;
                    deleteBalance.LastUpdateUser = 1;
                    context.FinancialBalances.Update(deleteBalance);
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

        public Task<List<FinancialBalance>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FinancialBalance> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingBalance = await context.FinancialBalances.FindAsync(id);
                return existingBalance;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<FinancialBalance>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FinancialBalance>> GetFinancialBalanceByIdCompany(int idCompany, string balanceType)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.FinancialBalances.Include(x => x.IdCurrencyNavigation).Where(x => x.IdCompany == idCompany && x.BalanceType == balanceType && x.Enable == true)
                    .Include(x => x.IdCurrencyNavigation)
                    .ToListAsync();  
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(FinancialBalance obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.FinancialBalances.Update(obj);
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
