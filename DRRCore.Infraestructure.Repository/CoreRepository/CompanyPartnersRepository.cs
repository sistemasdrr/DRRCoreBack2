using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyPartnersRepository : ICompanyPartnersRepository
    {
        private readonly ILogger _logger;
        public CompanyPartnersRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(CompanyPartner obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.CompanyPartners.AddAsync(obj);
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
                var obj = await context.CompanyPartners.FindAsync(id);
                if(obj != null)
                {
                    obj.DeleteDate = DateTime.Now;
                    obj.LastUpdateUser = 1;
                    obj.Enable = false;
                    context.CompanyPartners.Update(obj);
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

        public Task<List<CompanyPartner>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyPartner> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.CompanyPartners.FindAsync(id);
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

        public Task<List<CompanyPartner>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyPartner>> GetPartnersByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.CompanyPartners.Where(x => x.IdCompany == idCompany && x.Enable == true)
                    .Include(x => x.IdPersonNavigation)
                    //.Include(x => x.IdProfessionNavigation)
                    .Include(x => x.IdPersonNavigation.IdDocumentTypeNavigation).ToListAsync();
                if (list != null)
                {
                    return list;
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

        public async Task<List<CompanyPartner>> GetPartnersByIdPerson(int idPerson)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.CompanyPartners.Where(x => x.IdPerson == idPerson && x.Enable == true)
                    .Include(x => x.IdCompanyNavigation).Include(x => x.IdCompanyNavigation.IdCountryNavigation)
                    .Include(x => x.IdCompanyNavigation.IdLegalRegisterSituationNavigation).Include(x => x.IdPersonNavigation)
                    //.Include(x => x.IdProfessionNavigation)
                    .ToListAsync();
                if (list != null)
                {
                    return list;
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

        public async Task<bool> UpdateAsync(CompanyPartner obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.CompanyPartners.Update(obj);
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
