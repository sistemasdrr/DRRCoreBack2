using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                    var trad = await context.TraductionCompanies.Where(x => x.IdCompany == obj.IdCompany).FirstOrDefaultAsync();
                    if(trad != null)
                    {
                        trad.TBduration = traductions.Where(x => x.Identifier == "S_B_DURATION").FirstOrDefault().ShortValue;
                        trad.TBregisterIn = traductions.Where(x => x.Identifier == "S_B_REGISTERIN").FirstOrDefault().ShortValue;
                        trad.TBpublicRegis = traductions.Where(x => x.Identifier == "S_B_PUBLICREGIS").FirstOrDefault().ShortValue;
                        trad.TBpaidCapital = traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue;
                        trad.TBincreaseDate = traductions.Where(x => x.Identifier == "S_B_INCREASEDATE").FirstOrDefault().ShortValue;
                        trad.TBtacRate= traductions.Where(x => x.Identifier == "S_B_TAXRATE").FirstOrDefault().ShortValue;
                        trad.TBlegalBack= traductions.Where(x => x.Identifier == "L_B_LEGALBACK").FirstOrDefault().LargeValue;
                        trad.TBhistory= traductions.Where(x => x.Identifier == "L_B_HISTORY").FirstOrDefault().LargeValue;
                        context.TraductionCompanies.Update(trad);
                    }
                    else
                    {
                        trad = new TraductionCompany();
                        trad.TBduration = traductions.Where(x => x.Identifier == "S_B_DURATION").FirstOrDefault().ShortValue;
                        trad.TBregisterIn = traductions.Where(x => x.Identifier == "S_B_REGISTERIN").FirstOrDefault().ShortValue;
                        trad.TBpublicRegis = traductions.Where(x => x.Identifier == "S_B_PUBLICREGIS").FirstOrDefault().ShortValue;
                        trad.TBpaidCapital = traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue;
                        trad.TBincreaseDate = traductions.Where(x => x.Identifier == "S_B_INCREASEDATE").FirstOrDefault().ShortValue;
                        trad.TBtacRate = traductions.Where(x => x.Identifier == "S_B_TAXRATE").FirstOrDefault().ShortValue;
                        trad.TBlegalBack = traductions.Where(x => x.Identifier == "L_B_LEGALBACK").FirstOrDefault().LargeValue;
                        trad.TBhistory = traductions.Where(x => x.Identifier == "L_B_HISTORY").FirstOrDefault().LargeValue;
                        await context.TraductionCompanies.AddAsync(trad);
                    }
                    context.CompanyBackgrounds.Add(obj);

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
                var companyBackground = await context.CompanyBackgrounds
                    .Include(x=>x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Include(x => x.CurrentPaidCapitalCurrencyNavigation)
                    .Include(x => x.CurrencyNavigation)
                    .Where(x => x.IdCompany == id).Take(1).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                if(companyBackground.IdCompanyNavigation.TraductionCompanies.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_DURATION",
                        ShortValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBduration ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_REGISTERIN",
                        ShortValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBregisterIn ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_PUBLICREGIS",
                        ShortValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBpublicRegis ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_B_PAIDCAPITAL",
                        LargeValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBpaidCapital ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_INCREASEDATE",
                        ShortValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBincreaseDate ?? "",
                    });

                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_TAXRATE",
                        ShortValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBtacRate ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_B_LEGALBACK",
                        LargeValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBlegalBack ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_B_HISTORY",
                        LargeValue = companyBackground.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBhistory ?? "",
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_DURATION",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_REGISTERIN",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_PUBLICREGIS",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_B_PAIDCAPITAL",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_INCREASEDATE",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_B_TAXRATE",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_B_LEGALBACK",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_B_HISTORY",
                        LargeValue = "",
                    });
                }
                //traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == id).Take(15).ToListAsync());
                //traductions = traductions.Where(x => x.Identifier.Contains("_B_")).ToList();
                
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
                    if (obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault() != null)
                    {
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBduration= traductions.Where(x => x.Identifier == "S_B_DURATION").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBregisterIn = traductions.Where(x => x.Identifier == "S_B_REGISTERIN").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBpublicRegis = traductions.Where(x => x.Identifier == "S_B_PUBLICREGIS").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBpaidCapital = traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBincreaseDate = traductions.Where(x => x.Identifier == "S_B_INCREASEDATE").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBtacRate= traductions.Where(x => x.Identifier == "S_B_TAXRATE").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBlegalBack= traductions.Where(x => x.Identifier == "L_B_LEGALBACK").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TBhistory= traductions.Where(x => x.Identifier == "L_B_HISTORY").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().UploadDate = DateTime.Now;
                    }
                    context.CompanyBackgrounds.Update(obj);

                    //var listTraductions = await context.Traductions.Where(x => x.IdCompany == obj.IdCompany && x.Identifier.Contains("_B_")).ToListAsync();

                    //foreach (var item in listTraductions)
                    //{
                    //    item.ShortValue = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().ShortValue;
                    //    item.LargeValue = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().LargeValue;
                    //    item.LastUpdaterUser = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().LastUpdaterUser;
                    //    context.Traductions.Update(item);
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

        public Task<bool> UpdateAsync(CompanyBackground obj)
        {
            throw new NotImplementedException();
        }
    }
}
