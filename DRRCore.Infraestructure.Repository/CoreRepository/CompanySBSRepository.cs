using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanySBSRepository : ICompanySBSRepository
    {
        private readonly ILogger _logger;
        public CompanySBSRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(CompanySb obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCompanySBS(CompanySb companySb)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompanySBS(CompanySb companySb, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.CompanySbs.Add(companySb);

                    foreach (var item in traductions)
                    {
                        var modifierTraduction = await context.Traductions.Where(x => x.IdCompany == companySb.IdCompany && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                            newTraduction.IdCompany = companySb.IdCompany;
                            newTraduction.Identifier = item.Identifier;
                            newTraduction.ShortValue = item.ShortValue;
                            newTraduction.LargeValue = item.LargeValue;
                            newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                            await context.Traductions.AddAsync(newTraduction);
                        }
                    }
                    await context.SaveChangesAsync();
                    return companySb.Id;
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
                var companySbs = await context.CompanySbs.FindAsync(id);
                if(companySbs != null)
                {
                    companySbs.Enable = false;
                    companySbs.DeleteDate = DateTime.Now;
                    companySbs.LastUpdateUser = 1;
                    context.CompanySbs.Update(companySbs);
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

        public Task<List<CompanySb>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanySb> GetByIdAsync(int id)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var companySbs = await context.CompanySbs.Include(x => x.IdCompanyNavigation).Where(x => x.IdCompany == id).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == companySbs.IdCompany && x.Identifier.Contains("_S_")).ToListAsync());

                if (companySbs.IdCompanyNavigation == null)
                    throw new Exception("No existe la empresa");

                companySbs.IdCompanyNavigation.Traductions = traductions;
                return companySbs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<CompanySb> GetByIdCompany(int idCompany)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var companySbs = await context.CompanySbs.Include(x => x.IdCompanyNavigation).Include(x => x.IdOpcionalCommentarySbsNavigation).Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany  && x.Identifier.Contains("_S_")).ToListAsync());

                if (companySbs.IdCompanyNavigation == null)
                    throw new Exception("No existe la empresa");

                companySbs.IdCompanyNavigation.Traductions = traductions;
                return companySbs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<CompanySb>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NewComercialReferences(int idCompany, int? idTicket)
        {
            try 
            { 
                using var context = new SqlCoreContext();
                var providers = await context.Providers.Where(x => x.IdCompany == idCompany && x.Flag == true).ToListAsync();
                foreach (var item in providers)
                {
                    item.Flag = false;
                    item.IdTicket = idTicket;
                    context.Providers.Update(item);
                    await context.SaveChangesAsync();
                }
                return true;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Task<bool> UpdateAsync(CompanySb obj)
        {
            throw new NotImplementedException();
        }

       

        public async Task<int> UpdateCompanySBS(CompanySb companySb, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    companySb.UpdateDate = DateTime.Now;
                    context.CompanySbs.Update(companySb);

                    foreach (var item in traductions)
                    {
                        var modifierTraduction = await context.Traductions.Where(x => x.IdCompany == companySb.IdCompany && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                            newTraduction.IdCompany = companySb.IdCompany;
                            newTraduction.Identifier = item.Identifier;
                            newTraduction.ShortValue = item.ShortValue;
                            newTraduction.LargeValue = item.LargeValue;
                            newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                            await context.Traductions.AddAsync(newTraduction);
                        }
                    }
                    await context.SaveChangesAsync();
                    return companySb.Id;
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
