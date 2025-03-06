using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ILogger _logger;
        public CompanyRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> ActiveWebVision(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.Companies.FindAsync(id) ?? throw new Exception("No existe la empresa solicitada");
                    obj.OnWeb = true;
                    obj.UpdateDate = DateTime.Now;
                    context.Companies.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> AddAsync(Company obj)
        {
            throw new NotImplementedException();

        }

        public async Task<int> AddCompanyAsync(Company obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var traduction = new TraductionCompany();
                    traduction.TEcomide = obj.Traductions.Where(x => x.Identifier == "L_E_COMIDE").FirstOrDefault().LargeValue;
                    traduction.TEduration = obj.Traductions.Where(x => x.Identifier == "S_E_DURATION").FirstOrDefault().ShortValue;
                    traduction.TEreputation = obj.Traductions.Where(x => x.Identifier == "L_E_REPUTATION").FirstOrDefault().LargeValue;
                    traduction.TEnew = obj.Traductions.Where(x => x.Identifier == "L_E_NEW").FirstOrDefault().LargeValue;
                    obj.TraductionCompanies.Add(traduction);
                    obj.Traductions = null;

                    //foreach (var item in Constants.TRADUCTIONS_FORMS)
                    //{
                    //var exist = obj.Traductions.Where(x => x.Identifier == item).FirstOrDefault();
                    //if (exist == null)
                    //    {
                    //        obj.Traductions.Add(new Traduction
                    //        {
                    //            IdPerson = null,
                    //            Identifier = item,
                    //            IdLanguage = 1,
                    //            LastUpdaterUser = 1,
                    //        });
                    //    }
                    //}
                    await context.Companies.AddAsync(obj);
                    await context.SaveChangesAsync();
                    obj.OldCode = "N" + obj.Id.ToString("D6");
                    //obj.CompanyFinancialInformations.Add(new CompanyFinancialInformation
                    //{
                    //    IdFinancialSituacion = obj.IdCreditRisk == null ? 8 : obj.IdCreditRisk == 1 ? 9 : obj.IdCreditRisk == 1 ? 10 : obj.IdCreditRisk == 3 ? 11 : obj.IdCreditRisk == 4 ? 12 : obj.IdCreditRisk == 5 ? 13 : obj.IdCreditRisk == 6 ? 15 : obj.IdCreditRisk == 7 ? 14 : 8
                    //});
                    context.Companies.Update(obj);
                    await context.SaveChangesAsync();
                    return obj.Id;
                }
            }
            catch (Exception ex)
            {               
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.Companies.FindAsync(id) ?? throw new Exception("No existe la empresa solicitada");
                    obj.Enable = false;
                    obj.DeleteDate = DateTime.Now;
                    context.Companies.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DesactiveWebVision(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.Companies.FindAsync(id) ?? throw new Exception("No existe la empresa solicitada");
                    obj.OnWeb = false;
                    obj.UpdateDate = DateTime.Now;
                    context.Companies.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var company= await context.Companies
                    .Where(x => x.Id == id)
                    .Include(x => x.IdCountryNavigation)
                    .Include(x => x.IdReputationNavigation)
                    .Include(x => x.IdLegalPersonTypeNavigation)
                    .Include(x => x.IdPaymentPolicyNavigation)
                    .Include(x => x.IdCreditRiskNavigation)
                    .Include(x => x.CompanyFinancialInformations)
                    .Include(x => x.TraductionCompanies)
                   .FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                if (company.TraductionCompanies.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_E_COMIDE",
                        LargeValue = company.TraductionCompanies.FirstOrDefault().TEcomide,
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_E_DURATION",
                        ShortValue = company.TraductionCompanies.FirstOrDefault().TEduration,
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_E_REPUTATION",
                        LargeValue = company.TraductionCompanies.FirstOrDefault().TEreputation,
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_E_NEW",
                        LargeValue = company.TraductionCompanies.FirstOrDefault().TEnew,
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_E_COMIDE",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_E_DURATION",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_E_REPUTATION",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_E_NEW",
                        LargeValue = "",
                    });
                }
                //traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == id).Take(10).ToListAsync());
                //traductions = traductions.Where(x => x.Identifier.Contains("_E_")).ToList();
                company.Traductions = traductions;
                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Company>> GetByNameAsync(string name, string form, int idCountry,bool haveReport, string filterBy)
        {
            //Fata el Have Report
            List<Company> companys = new List<Company>();
            try
            {
                using var context = new SqlCoreContext();
                if (filterBy == "N")
                {
                    if (haveReport)
                    {
                        companys = await context.Tickets
                            .Include(x => x.IdCompanyNavigation)
                        .Include(x => x.IdCompanyNavigation.TraductionCompanies)
                        .Include(x => x.IdCompanyNavigation.IdCreditRiskNavigation)
                        .Include(x => x.IdCompanyNavigation.IdCountryNavigation)
                        .Include(x => x.IdCompanyNavigation.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                        .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                  
                                    (form == "C" ? (x.IdCompanyNavigation.Name.Contains(name)||x.RequestedName.Contains(name)) : form == "I" ? (x.IdCompanyNavigation.Name.StartsWith(name)||x.RequestedName.StartsWith(name)) : false) &&
                                    x.IdCompanyNavigation.HaveReport == true)
                         .Select(x => x.IdCompanyNavigation)
                        .Take(100)                       
                        .ToListAsync();
                    }
                    else
                    {

                        companys = await context.Tickets
                            .Include(x => x.IdCompanyNavigation)
                        .Include(x => x.IdCompanyNavigation.TraductionCompanies)
                        .Include(x => x.IdCompanyNavigation.IdCreditRiskNavigation)
                        .Include(x => x.IdCompanyNavigation.IdCountryNavigation)
                        .Include(x => x.IdCompanyNavigation.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                        .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&

                                    (form == "C" ? (x.IdCompanyNavigation.Name.Contains(name) || x.RequestedName.Contains(name)) : form == "I" ? (x.IdCompanyNavigation.Name.StartsWith(name) || x.RequestedName.StartsWith(name)) : false) )
                         .Select(x => x.IdCompanyNavigation)
                        .Take(100)
                        .ToListAsync();
                    }
                }
                else if (filterBy == "C")
                {
                    if (haveReport)
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                        .Include(x => x.IdCreditRiskNavigation)
                        .Include(x => x.IdCountryNavigation)
                        .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                        .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                    (form == "C" ? x.SocialName.Contains(name) : form == "I" ? x.SocialName.StartsWith(name) : false) &&
                                    x.HaveReport == true)
                        .Take(100)
                        .ToListAsync();
                    }
                    else
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                       .Include(x => x.IdCreditRiskNavigation)
                       .Include(x => x.IdCountryNavigation)
                       .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                       .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                   (form == "C" ? x.SocialName.Contains(name) : form == "I" ? x.SocialName.StartsWith(name) : false))
                       .Take(100)
                       .ToListAsync();
                    }
                }
                else if (filterBy == "D")
                {
                    if (haveReport)
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                        .Include(x => x.IdCreditRiskNavigation)
                        .Include(x => x.IdCountryNavigation)
                        .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                        .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                    (form == "C" ? x.Address.Contains(name) : form == "I" ? x.Address.StartsWith(name) : false) &&
                                   x.HaveReport == true)
                        .Take(100)
                        .ToListAsync();
                    }
                    else
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                       .Include(x => x.IdCreditRiskNavigation)
                       .Include(x => x.IdCountryNavigation)
                       .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                       .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                   (form == "C" ? x.Address.Contains(name) : form == "I" ? x.Address.StartsWith(name) : false))
                       .Take(100)
                       .ToListAsync();
                    }
                }
                else if (filterBy == "R")
                {
                    if (haveReport)
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                        .Include(x => x.IdCreditRiskNavigation)
                        .Include(x => x.IdCountryNavigation)
                        .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                        .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                    (form == "C" ? x.TaxTypeCode.Contains(name) : form == "I" ? x.TaxTypeCode.StartsWith(name) : false) &&
                                    x.HaveReport == true)
                        .Take(100)
                        .ToListAsync();
                    }
                    else
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                       .Include(x => x.IdCreditRiskNavigation)
                       .Include(x => x.IdCountryNavigation)
                        .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                       .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                   (form == "C" ? x.TaxTypeCode.Contains(name) : form == "I" ? x.TaxTypeCode.StartsWith(name) : false))
                       .Take(100)
                       .ToListAsync();
                    }
                }
                else if (filterBy == "T")
                {
                    if (haveReport)
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                        .Include(x => x.IdCreditRiskNavigation)
                        .Include(x => x.IdCountryNavigation)
                        .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                        .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                    (form == "C" ? x.Telephone.Contains(name) : form == "I" ? x.Telephone.StartsWith(name) : false) &&
                                    x.HaveReport == true)
                        .Take(100)
                        .ToListAsync();
                    }
                    else
                    {
                        companys = await context.Companies
                        .Include(x => x.TraductionCompanies)
                        .Include(x => x.IdCreditRiskNavigation)
                        .Include(x => x.IdCountryNavigation)
                        .Include(x => x.CompanyPartners.Where(x => x.MainExecutive == true)).ThenInclude(x => x.IdPersonNavigation)
                        .Where(x => (idCountry == 0 || x.IdCountry == idCountry) &&
                                    (form == "C" ? x.Telephone.Contains(name) : form == "I" ? x.Telephone.StartsWith(name) : false))
                        .Take(100)
                        .ToListAsync();
                    }
                }
                return companys.Where(x=>x!=null).ToList(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<Company>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetByOldCode(string oldCode)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Include(x => x.IdCountryNavigation).FirstOrDefaultAsync(x => x.OldCode == oldCode);
                return company;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Company>> GetCompanySearch(string name, string taxCode, int? idCountry)
        {
            try
            {
                using var context = new SqlCoreContext();
                var companies = new List<Company>();
                if (idCountry != null && idCountry != 0)
                {
                    companies = await context.Companies
                        .Where(x => x.Name.Contains(name) && x.TaxTypeCode.Contains(taxCode) && x.IdCountry == idCountry)
                        .Include(x => x.FinancialBalances.Where(x => x.BalanceType == "GENERAL"))
                        .Include(x => x.IdCountryNavigation)
                        .Take(100)
                        .ToListAsync();
                }
                else
                {
                    companies = await context.Companies
                        .Where(x => x.Name.Contains(name) && x.TaxTypeCode.Contains(taxCode))
                        .Include(x => x.FinancialBalances.Where(x => x.BalanceType == "GENERAL"))
                        .Include(x => x.IdCountryNavigation)
                        .Take(100)
                        .ToListAsync();
                }
                return companies;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Company>> GetCompanySituation(string typeSearch, string? search, int? idCountry)
        {
            try
            {
                using var context = new SqlCoreContext();
                var companies = new List<Company>();
                if(typeSearch == "N")
                {
                    companies = await context.Companies.Include(x => x.IdCountryNavigation)
                        .Where(x => x.Name.Contains(search) || x.Name.Contains(search) && x.IdCountry == idCountry).Take(100).ToListAsync();
                }
                else if(typeSearch == "R")
                {
                    companies = await context.Companies.Include(x => x.IdCountryNavigation)
                        .Where(x => x.TaxTypeCode.Contains(search) || x.TaxTypeCode.Contains(search) && x.IdCountry == idCountry).Take(100).ToListAsync();
                }
                else if (typeSearch == "T")
                {
                    companies = await context.Companies.Include(x => x.IdCountryNavigation)
                        .Where(x => x.Telephone.Contains(search) || x.Telephone.Contains(search) && x.IdCountry == idCountry).Take(100).ToListAsync();
                }
                return companies;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Company obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    //var existTraduction = obj.Traductions;
                    //obj.Traductions=new List<Traduction>();
                    obj.UpdateDate = DateTime.Now;
                    

                    if(obj.TraductionCompanies.FirstOrDefault() != null)
                    {
                        obj.TraductionCompanies.FirstOrDefault().TEcomide = obj.Traductions.Where(x => x.Identifier == "L_E_COMIDE").FirstOrDefault().LargeValue;
                        obj.TraductionCompanies.FirstOrDefault().TEduration = obj.Traductions.Where(x => x.Identifier == "S_E_DURATION").FirstOrDefault().ShortValue;
                        obj.TraductionCompanies.FirstOrDefault().TEreputation = obj.Traductions.Where(x => x.Identifier == "L_E_REPUTATION").FirstOrDefault().LargeValue;
                        obj.TraductionCompanies.FirstOrDefault().TEnew = obj.Traductions.Where(x => x.Identifier == "L_E_NEW").FirstOrDefault().LargeValue;
                    }
                    else
                    {
                        var traduction = new TraductionCompany();
                        traduction.TEcomide = obj.Traductions.Where(x => x.Identifier == "L_E_COMIDE").FirstOrDefault().LargeValue;
                        traduction.TEduration = obj.Traductions.Where(x => x.Identifier == "S_E_DURATION").FirstOrDefault().ShortValue;
                        traduction.TEreputation = obj.Traductions.Where(x => x.Identifier == "L_E_REPUTATION").FirstOrDefault().LargeValue;
                        traduction.TEnew = obj.Traductions.Where(x => x.Identifier == "L_E_NEW").FirstOrDefault().LargeValue;
                        obj.TraductionCompanies.Add(traduction);
                    }
                    obj.Traductions = null;
                    //if(obj.CompanyFinancialInformations.Count > 0)
                    //{
                    //    obj.CompanyFinancialInformations.FirstOrDefault().IdFinancialSituacion = obj.IdCreditRisk == null ? 8 : obj.IdCreditRisk == 1 ? 9 : obj.IdCreditRisk == 1 ? 10 : obj.IdCreditRisk == 3 ? 11 : obj.IdCreditRisk == 4 ? 12 : obj.IdCreditRisk == 5 ? 13 : obj.IdCreditRisk == 6 ? 15 : obj.IdCreditRisk == 7 ? 14 : 8;
                    //}
                    //else
                    //{
                    //    var financial = new List<CompanyFinancialInformation>
                    //    {
                    //        new CompanyFinancialInformation
                    //        {
                    //            IdFinancialSituacion = obj.IdCreditRisk == null ? 8 : obj.IdCreditRisk == 1 ? 9 : obj.IdCreditRisk == 1 ? 10 : obj.IdCreditRisk == 3 ? 11 : obj.IdCreditRisk == 4 ? 12 : obj.IdCreditRisk == 5 ? 13 : obj.IdCreditRisk == 6 ? 15 : obj.IdCreditRisk == 7 ? 14 : 8
                    //        }
                    //    };
                    //    obj.CompanyFinancialInformations = financial;
                    //}
                    context.Companies.Update(obj);    
                    await context.SaveChangesAsync();
                    return true;
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
