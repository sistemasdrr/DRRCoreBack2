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
                    var trad = await context.TraductionCompanies.Where(x => x.IdCompany == obj.IdCompany).FirstOrDefaultAsync();
                    if (trad != null)
                    {
                        trad.TRsalePer = traductions.Where(x => x.Identifier == "S_R_SALEPER").FirstOrDefault().ShortValue;
                        trad.TRcreditPer = traductions.Where(x => x.Identifier == "S_R_CREDITPER").FirstOrDefault().ShortValue;
                        trad.TRterritory = traductions.Where(x => x.Identifier == "S_R_TERRITORY").FirstOrDefault().ShortValue;
                        trad.TRextSales = traductions.Where(x => x.Identifier == "S_R_EXTSALES").FirstOrDefault().ShortValue;
                        trad.TRnatiBuy = traductions.Where(x => x.Identifier == "S_R_NATIBUY").FirstOrDefault().ShortValue;
                        trad.TRinterBuy = traductions.Where(x => x.Identifier == "S_R_INTERBUY").FirstOrDefault().ShortValue;
                        trad.TRtotalArea = traductions.Where(x => x.Identifier == "S_R_TOTALAREA").FirstOrDefault().ShortValue;
                        trad.TRotherLocals = traductions.Where(x => x.Identifier == "L_R_OTRHERLOCALS").FirstOrDefault().LargeValue;
                        trad.TRprincAct = traductions.Where(x => x.Identifier == "L_R_PRINCACT").FirstOrDefault().LargeValue;
                        trad.TRadiBus = traductions.Where(x => x.Identifier == "L_R_ADIBUS").FirstOrDefault().LargeValue;
                        trad.TRmainAddress = traductions.Where(x => x.Identifier == "L_R_DESCADD").FirstOrDefault().LargeValue;
                        context.TraductionCompanies.Update(trad);
                    }
                    else
                    {
                        trad = new TraductionCompany();
                        trad.TRsalePer = traductions.Where(x => x.Identifier == "S_R_SALEPER").FirstOrDefault().ShortValue;
                        trad.TRcreditPer = traductions.Where(x => x.Identifier == "S_R_CREDITPER").FirstOrDefault().ShortValue;
                        trad.TRterritory = traductions.Where(x => x.Identifier == "S_R_TERRITORY").FirstOrDefault().ShortValue;
                        trad.TRextSales = traductions.Where(x => x.Identifier == "S_R_EXTSALES").FirstOrDefault().ShortValue;
                        trad.TRnatiBuy = traductions.Where(x => x.Identifier == "S_R_NATIBUY").FirstOrDefault().ShortValue;
                        trad.TRinterBuy = traductions.Where(x => x.Identifier == "S_R_INTERBUY").FirstOrDefault().ShortValue;
                        trad.TRtotalArea = traductions.Where(x => x.Identifier == "S_R_TOTALAREA").FirstOrDefault().ShortValue;
                        trad.TRotherLocals = traductions.Where(x => x.Identifier == "L_R_OTRHERLOCALS").FirstOrDefault().LargeValue;
                        trad.TRprincAct = traductions.Where(x => x.Identifier == "L_R_PRINCACT").FirstOrDefault().LargeValue;
                        trad.TRadiBus = traductions.Where(x => x.Identifier == "L_R_ADIBUS").FirstOrDefault().LargeValue;
                        trad.TRmainAddress = traductions.Where(x => x.Identifier == "L_R_DESCADD").FirstOrDefault().LargeValue;
                        await context.TraductionCompanies.AddAsync(trad);
                    }

                    context.CompanyBranches.Add(obj);

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
            throw new NotImplementedException();
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
                var companyBranch = await context.CompanyBranches
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Include(x => x.IdLandOwnershipNavigation)
                    .Include(x => x.IdBranchSectorNavigation)
                    .Include(x => x.IdBusinessBranchNavigation)
                    .Where(x => x.IdCompany == idCompany)
                    .FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");

                if (companyBranch.IdCompanyNavigation.TraductionCompanies.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_SALEPER",
                        ShortValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRsalePer?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_CREDITPER",
                        ShortValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRcreditPer?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_TERRITORY",
                        ShortValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRterritory ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_EXTSALES",
                        ShortValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRextSales ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_NATIBUY",
                        ShortValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRnatiBuy?? "",
                    });

                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_INTERBUY",
                        ShortValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRinterBuy ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_TOTALAREA",
                        ShortValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRtotalArea?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_OTRHERLOCALS",
                        LargeValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRotherLocals ?? "",
                    });

                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_PRINCACT",
                        LargeValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRprincAct?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_ADIBUS",
                        LargeValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRadiBus ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_DESCADD",
                        LargeValue = companyBranch.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRmainAddress?? "",
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_SALEPER",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_CREDITPER",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_TERRITORY",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_EXTSALES",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_NATIBUY",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_INTERBUY",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_R_TOTALAREA",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_OTRHERLOCALS",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_PRINCACT",
                        LargeValue = "",
                    });

                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_ADIBUS",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_R_DESCADD",
                        LargeValue = "",
                    });
                }

                //traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany && x.Identifier.Contains("_R_")).ToListAsync());

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
                    if (obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault() != null)
                    {
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRsalePer= traductions.Where(x => x.Identifier == "S_R_SALEPER").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRcreditPer = traductions.Where(x => x.Identifier == "S_R_CREDITPER").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRterritory = traductions.Where(x => x.Identifier == "S_R_TERRITORY").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRextSales = traductions.Where(x => x.Identifier == "S_R_EXTSALES").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRnatiBuy = traductions.Where(x => x.Identifier == "S_R_NATIBUY").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRinterBuy = traductions.Where(x => x.Identifier == "S_R_INTERBUY").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRtotalArea = traductions.Where(x => x.Identifier == "S_R_TOTALAREA").FirstOrDefault().ShortValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRotherLocals = traductions.Where(x => x.Identifier == "L_R_OTRHERLOCALS").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRprincAct = traductions.Where(x => x.Identifier == "L_R_PRINCACT").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRadiBus = traductions.Where(x => x.Identifier == "L_R_ADIBUS").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TRmainAddress = traductions.Where(x => x.Identifier == "L_R_DESCADD").FirstOrDefault().LargeValue;
                        obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().UploadDate = DateTime.Now;
                    }
                    obj.IdCompanyNavigation.Traductions = null;
                    context.CompanyBranches.Update(obj);



                    //var listTraductions = await context.Traductions.Where(x => x.IdCompany == obj.Id && x.Identifier.Contains("_R_")).ToListAsync();

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

        public Task<bool> UpdateAsync(CompanyBranch obj)
        {
            throw new NotImplementedException();
        }
    }
}
