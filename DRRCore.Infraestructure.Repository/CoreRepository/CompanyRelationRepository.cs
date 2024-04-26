using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyRelationRepository : ICompanyRelationRepository
    {
        private readonly ILogger _logger;
        public CompanyRelationRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(CompanyRelation obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.CompanyRelations.AddAsync(obj);
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
                var obj = await context.CompanyRelations.FindAsync(id);
                if(obj != null)
                {
                    obj.DeleteDate = DateTime.Now;
                    obj.LastUpdateUser = 1;
                    obj.Enable = false;
                    context.CompanyRelations.Update(obj);
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

        public Task<List<CompanyRelation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyRelation> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.CompanyRelations.FindAsync(id);
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

        public Task<List<CompanyRelation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyRelation>> GetCompanyRelationByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.CompanyRelations.Where(x => x.IdCompany == idCompany && x.Enable == true)
                    .Include(x => x.IdCompanyRelationNavigation).Include(x => x.IdCompanyRelationNavigation.IdCountryNavigation)
                    .Include(x => x.IdCompanyRelationNavigation.IdLegalRegisterSituationNavigation).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(CompanyRelation obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.CompanyRelations.Update(obj);
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
