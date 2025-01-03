﻿using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyGeneralInformationRepository : ICompanyGeneralInformationRepository
    {
        private readonly ILogger _logger;
        public CompanyGeneralInformationRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(CompanyGeneralInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.CompanyGeneralInformations.Add(obj);

                    //foreach (var item in traductions)
                    //{
                    //    var modifierTraduction = await context.Traductions.Where(x => x.IdCompany == obj.IdCompany && x.Identifier == item.Identifier).FirstOrDefaultAsync();
                    //    if (modifierTraduction != null)
                    //    {
                    //        modifierTraduction.ShortValue = item.ShortValue;
                    //        modifierTraduction.LargeValue = item.LargeValue;
                    //        modifierTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        context.Traductions.Update(modifierTraduction);
                    //    }
                    //    else
                    //    {
                    //        var newTraduction = new Traduction();
                    //        newTraduction.Id = 0;
                    //        newTraduction.IdCompany = obj.IdCompany;
                    //        newTraduction.Identifier = item.Identifier;
                    //        newTraduction.ShortValue = item.ShortValue;
                    //        newTraduction.LargeValue = item.LargeValue;
                    //        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        await context.Traductions.AddAsync(newTraduction);
                    //        await context.SaveChangesAsync();
                    //    }
                    //}
                    var trad = await context.TraductionCompanies.Where(x => x.IdCompany == obj.IdCompany).FirstOrDefaultAsync();
                    if (trad != null)
                    {
                        trad.TIgeneral= traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue;
                        context.TraductionCompanies.Update(trad);
                    }
                    else
                    {
                        trad = new TraductionCompany();
                        trad.TIgeneral= traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue;
                        await context.TraductionCompanies.AddAsync(trad);
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

        public Task<List<CompanyGeneralInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyGeneralInformation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyGeneralInformation> GetByIdCompany(int idCompany)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var generalInformation = await context.CompanyGeneralInformations
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Where(x => x.IdCompany == idCompany)
                    .FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");

                if (generalInformation.IdCompanyNavigation.TraductionCompanies.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_I_GENERAL",
                        LargeValue = generalInformation.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TIgeneral?? "",
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_I_GENERAL",
                        LargeValue = "",
                    });
                }
                
                //traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany && x.Identifier.Contains("_I_")).ToListAsync());

                if (generalInformation.IdCompanyNavigation == null)
                    throw new Exception("No existe la empresa");

                generalInformation.IdCompanyNavigation.Traductions = traductions;
                return generalInformation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<CompanyGeneralInformation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CompanyGeneralInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    if (obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault() != null)
                    {
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TIgeneral = traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().UploadDate = DateTime.Now;
                    }
                    obj.IdCompanyNavigation.Traductions = null;
                    context.CompanyGeneralInformations.Update(obj);

                    //foreach (var item in traductions)
                    //{
                    //    var modifierTraduction = await context.Traductions.Where(x => x.IdCompany == obj.IdCompany && x.Identifier == item.Identifier).FirstOrDefaultAsync();
                    //    if (modifierTraduction != null)
                    //    {
                    //        modifierTraduction.ShortValue = item.ShortValue;
                    //        modifierTraduction.LargeValue = item.LargeValue;
                    //        modifierTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        context.Traductions.Update(modifierTraduction);
                    //    }
                    //    else
                    //    {
                    //        var newTraduction = new Traduction();
                    //        newTraduction.Id = 0;
                    //        newTraduction.IdCompany = obj.IdCompany;
                    //        newTraduction.Identifier = item.Identifier;
                    //        newTraduction.ShortValue = item.ShortValue;
                    //        newTraduction.LargeValue = item.LargeValue;
                    //        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        await context.Traductions.AddAsync(newTraduction);
                    //    }
                    //}
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
