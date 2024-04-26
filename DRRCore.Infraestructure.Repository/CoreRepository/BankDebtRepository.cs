using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class BankDebtRepository : IBankDebtRepository
    {
        private readonly ILogger _logger;
        public BankDebtRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(BankDebt obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.BankDebts.AddAsync(obj);
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
                var bankDebt = await context.BankDebts.FindAsync(id);
                if(bankDebt == null)
                {
                    bankDebt.Enable = false;
                    bankDebt.DeleteDate = DateTime.Now;
                    context.BankDebts.Update(bankDebt);
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

        public Task<List<BankDebt>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BankDebt>> GetBankDebtsByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.BankDebts.Where(x => x.IdCompany == idCompany && x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<List<BankDebt>> GetBankDebtsByIdPerson(int idPerson)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.BankDebts.Where(x => x.IdPerson == idPerson && x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<BankDebt> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var bankDebt = await context.BankDebts.FindAsync(id);
                return bankDebt;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<BankDebt>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(BankDebt obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.BankDebts.Update(obj);
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
