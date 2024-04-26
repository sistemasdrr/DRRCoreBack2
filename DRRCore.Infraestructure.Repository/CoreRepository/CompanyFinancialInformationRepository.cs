using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using DRRCore.Transversal.Common;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyFinancialInformationRepository : ICompanyFinancialInformationRepository
    {
        private readonly ILogger _logger;
        public CompanyFinancialInformationRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(CompanyFinancialInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompanyFinancialInformation(CompanyFinancialInformation obj, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.CompanyFinancialInformations.AddAsync(obj);
                foreach (var item in traductions)
                {
                    var modifierTraduction = await context.Traductions.Where(x => x.IdCompany == obj.IdCompany && x.Identifier == item.Identifier).FirstOrDefaultAsync();
                    if (modifierTraduction != null)
                    {
                        modifierTraduction.ShortValue = item.ShortValue;
                        modifierTraduction.LargeValue = item.LargeValue;
                        modifierTraduction.LastUpdaterUser = item.LastUpdaterUser;
                        context.Traductions.Update(modifierTraduction);
                    }
                    else
                    {
                        var newTraduction = new Traduction();
                        newTraduction.Id = 0;
                        newTraduction.IdCompany = obj.IdCompany;
                        newTraduction.Identifier = item.Identifier;
                        newTraduction.ShortValue = item.ShortValue;
                        newTraduction.LargeValue = item.LargeValue;
                        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                        await context.Traductions.AddAsync(newTraduction);
                    }
                }
                await context.SaveChangesAsync();
                return obj.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingCompany = await context.CompanyFinancialInformations.FindAsync(id);
                if(existingCompany != null)
                {
                    existingCompany.Enable = false;
                    existingCompany.DeleteDate = DateTime.Now;
                    context.CompanyFinancialInformations.Update(existingCompany);
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

        public Task<List<CompanyFinancialInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyFinancialInformation> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingCompany = await context.CompanyFinancialInformations.Include(x => x.IdCompanyNavigation).Where(x => x.Id == id).FirstOrDefaultAsync();
                return existingCompany;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new CompanyFinancialInformation();
            }
        }

        public async Task<CompanyFinancialInformation> GetByIdCompany(int idCompany)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.CompanyFinancialInformations
                    .Include(x => x.IdCompanyNavigation).Include(x => x.IdFinancialSituacionNavigation).Include(x => x.IdCollaborationDegreeNavigation)
                    .Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany && x.Identifier.Contains("_F_")).ToListAsync());

                if (company == null)
                    throw new Exception("No existe la empresa");

                company.IdCompanyNavigation.Traductions = traductions;
                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<CompanyFinancialInformation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(CompanyFinancialInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCompanyFinancialInformation(CompanyFinancialInformation obj, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.CompanyFinancialInformations.Update(obj);
                var existingTraduction = Constants.TRADUCTIONS_FORMS.Where(x => x.Contains("_F_"));
                foreach (var item in traductions)
                {
                    var modifierTraduction = await context.Traductions.Where(x => x.IdCompany == obj.IdCompany && x.Identifier == item.Identifier).FirstOrDefaultAsync();
                    if (modifierTraduction != null)
                    {
                        modifierTraduction.ShortValue = item.ShortValue;
                        modifierTraduction.LargeValue = item.LargeValue;
                        modifierTraduction.LastUpdaterUser = item.LastUpdaterUser;
                        context.Traductions.Update(modifierTraduction);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        var newTraduction = new Traduction();
                        newTraduction.Id = 0;
                        newTraduction.IdCompany = obj.IdCompany;
                        newTraduction.Identifier = item.Identifier;
                        newTraduction.ShortValue = item.ShortValue;
                        newTraduction.LargeValue = item.LargeValue;
                        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                        await context.Traductions.AddAsync(newTraduction);
                        await context.SaveChangesAsync();
                    }
                }
                return obj.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }
    }
}
