using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyBranchRepository : ICompanyBranchRepository
    {
        private readonly ILogger _logger;
        public CompanyBranchRepository(ILogger logger) { 
        
            _logger = logger;
        }
        public async Task<int> AddAsync(CompanyBranch obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.CompanyBranches.Add(obj);

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

        public Task<bool> AddAsync(CompanyBranch obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyBranch>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyBranch> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.CompanyBranches.Where(x => x.IdCompany == id).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<CompanyBranch>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyBranch> GetCompanyBranchByIdCompany(int idCompany)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var companyBranch = await context.CompanyBranches.Include(x => x.IdCompanyNavigation).Include(x => x.IdLandOwnershipNavigation).Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany && x.Identifier.Contains("_R_")).ToListAsync());

                if (companyBranch.IdCompanyNavigation == null)
                    throw new Exception("No existe la empresa");

                companyBranch.IdCompanyNavigation.Traductions = traductions;
                return companyBranch;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<int> UpdateAsync(CompanyBranch obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    context.CompanyBranches.Update(obj);

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

        public Task<bool> UpdateAsync(CompanyBranch obj)
        {
            throw new NotImplementedException();
        }
    }
}
