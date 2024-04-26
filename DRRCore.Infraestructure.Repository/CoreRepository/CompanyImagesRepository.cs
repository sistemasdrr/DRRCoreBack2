using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyImagesRepository : ICompanyImagesRepository
    {
        private readonly ILogger _logger;
        public CompanyImagesRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(CompanyImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompanyImage(CompanyImage obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.CompanyImages.Add(obj);

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
                            await context.SaveChangesAsync();
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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyImage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyImage> GetByIdCompany(int idCompany)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var images = await context.CompanyImages.Include(x => x.IdCompanyNavigation).Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany && x.Identifier.Contains("_IMG_")).ToListAsync());

                if (images.IdCompanyNavigation == null)
                    throw new Exception("No existe la empresa");

                images.IdCompanyNavigation.Traductions = traductions;
                return images;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<CompanyImage>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CompanyImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCompanyImage(CompanyImage obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    context.CompanyImages.Update(obj);

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
    }
}
