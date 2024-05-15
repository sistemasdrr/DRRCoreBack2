using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyBackgroundRepository : ICompanyBackgroundRepository
    {
        private readonly ILogger _logger;
        public CompanyBackgroundRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<int?> AddAsync(CompanyBackground obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {                    
                    context.CompanyBackgrounds.Add (obj);

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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> AddAsync(CompanyBackground obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyBackground>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyBackground> GetByIdAsync(int id)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var companyBackground = await context.CompanyBackgrounds.Include(x=>x.IdCompanyNavigation)
                    .Include(x => x.CurrentPaidCapitalCurrencyNavigation)
                    .Include(x => x.CurrencyNavigation)
                    .Where(x => x.IdCompany == id).Take(1).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == id).Take(15).ToListAsync());
                traductions = traductions.Where(x => x.Identifier.Contains("_B_")).ToList();
                
                if (companyBackground.IdCompanyNavigation == null)                
                    throw new Exception("No existe la empresa");               

                companyBackground.IdCompanyNavigation.Traductions = traductions;
                return companyBackground;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<CompanyBackground>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdateAsync(CompanyBackground obj,List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    context.CompanyBackgrounds.Update(obj);
                    var listTraductions = await context.Traductions.Where(x => x.IdCompany == obj.IdCompany && x.Identifier.Contains("_B_")).ToListAsync();

                    foreach (var item in listTraductions)
                    {
                        item.ShortValue = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().ShortValue;
                        item.LargeValue = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().LargeValue;
                        item.LastUpdaterUser = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().LastUpdaterUser;
                        context.Traductions.Update(item);
                    }
                    await context.SaveChangesAsync();
                    return obj.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> UpdateAsync(CompanyBackground obj)
        {
            throw new NotImplementedException();
        }
    }
}
