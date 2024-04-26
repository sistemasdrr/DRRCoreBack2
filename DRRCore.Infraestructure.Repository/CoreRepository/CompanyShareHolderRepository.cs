using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyShareHolderRepository : ICompanyShareHolderRepository
    {
        private readonly ILogger _logger;
        public CompanyShareHolderRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(CompanyShareHolder obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.CompanyShareHolders.AddAsync(obj);
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
                var obj = await context.CompanyShareHolders.FindAsync(id);
                if(obj != null)
                {
                    obj.Enable = false;
                    obj.DeleteDate = DateTime.Now;
                    obj.LastUpdateUser = 1;
                    context.CompanyShareHolders.Update(obj);
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

        public Task<List<CompanyShareHolder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyShareHolder> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.CompanyShareHolders.FindAsync(id);
                if (obj != null)
                {
                    return obj;
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

        public Task<List<CompanyShareHolder>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyShareHolder>> GetShareHoldersByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.CompanyShareHolders.Where(x => x.IdCompany == idCompany && x.Enable == true)
                    .Include(x => x.IdCompanyShareHolderNavigation). Include(x => x.IdCompanyShareHolderNavigation.IdCountryNavigation)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(CompanyShareHolder obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.CompanyShareHolders.Update(obj);
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
