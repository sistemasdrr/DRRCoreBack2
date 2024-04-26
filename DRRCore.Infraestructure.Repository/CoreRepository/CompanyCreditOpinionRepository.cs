using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyCreditOpinionRepository : ICompanyCreditOpinionRepository
    {
        private readonly ILogger _logger;
        public CompanyCreditOpinionRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(CompanyCreditOpinion obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.CompanyCreditOpinions.Add(obj);

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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var creditOpinion = await context.CompanyCreditOpinions.FindAsync(id);
                if(creditOpinion != null)
                {
                    creditOpinion.Enable = false;
                    creditOpinion.DeleteDate = DateTime.Now;
                    context.CompanyCreditOpinions.Update(creditOpinion);
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public Task<List<CompanyCreditOpinion>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyCreditOpinion> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyCreditOpinion> GetByIdCompany(int idCompany)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var creditOpinion = await context.CompanyCreditOpinions.Include(x => x.IdCompanyNavigation).Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany && x.Identifier.Contains("_O_")).ToListAsync());

                if (creditOpinion.IdCompanyNavigation == null)
                    throw new Exception("No existe la empresa");

                creditOpinion.IdCompanyNavigation.Traductions = traductions;
                return creditOpinion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<CompanyCreditOpinion>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CompanyCreditOpinion obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    context.CompanyCreditOpinions.Update(obj);

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
