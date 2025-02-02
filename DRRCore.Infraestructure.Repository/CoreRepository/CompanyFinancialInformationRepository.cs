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
                var trad = await context.TraductionCompanies.Where(x => x.IdCompany == obj.IdCompany).FirstOrDefaultAsync();
                if (trad != null)
                {
                    trad.TFjob = traductions.Where(x => x.Identifier == "S_F_JOB").FirstOrDefault().ShortValue;
                    trad.TFcomment = traductions.Where(x => x.Identifier == "L_F_COMENT").FirstOrDefault().LargeValue;
                    trad.TFprincActiv = traductions.Where(x => x.Identifier == "L_F_PRINCACTIV").FirstOrDefault().LargeValue;
                    trad.TFselectFin = traductions.Where(x => x.Identifier == "L_F_SELECTFIN").FirstOrDefault().LargeValue;
                    trad.TFanalistCom = traductions.Where(x => x.Identifier == "L_F_ANALISTCOM").FirstOrDefault().LargeValue;
                    trad.TFtabComm = traductions.Where(x => x.Identifier == "L_F_TABCOMM").FirstOrDefault().LargeValue;
                    context.TraductionCompanies.Update(trad);
                }
                else
                {
                    trad = new TraductionCompany();
                    trad.TFjob = traductions.Where(x => x.Identifier == "S_F_JOB").FirstOrDefault().ShortValue;
                    trad.TFcomment = traductions.Where(x => x.Identifier == "L_F_COMENT").FirstOrDefault().LargeValue;
                    trad.TFprincActiv = traductions.Where(x => x.Identifier == "L_F_PRINCACTIV").FirstOrDefault().LargeValue;
                    trad.TFselectFin = traductions.Where(x => x.Identifier == "L_F_SELECTFIN").FirstOrDefault().LargeValue;
                    trad.TFanalistCom = traductions.Where(x => x.Identifier == "L_F_ANALISTCOM").FirstOrDefault().LargeValue;
                    trad.TFtabComm = traductions.Where(x => x.Identifier == "L_F_TABCOMM").FirstOrDefault().LargeValue;
                    await context.TraductionCompanies.AddAsync(trad);
                }
                await context.CompanyFinancialInformations.AddAsync(obj);
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
            throw new NotImplementedException();
        }

        public async Task<CompanyFinancialInformation> GetByIdCompany(int idCompany)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.CompanyFinancialInformations
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Include(x => x.IdFinancialSituacionNavigation)
                    .Include(x => x.IdCollaborationDegreeNavigation)
                    .Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");

                if (company.IdCompanyNavigation.TraductionCompanies.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_F_JOB",
                        ShortValue = company.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFjob?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_COMENT",
                        LargeValue = company.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFcomment?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_PRINCACTIV",
                        LargeValue = company.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFprincActiv?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_SELECTFIN",
                        LargeValue = company.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFselectFin ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_ANALISTCOM",
                        LargeValue = company.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFanalistCom ?? "",
                    });

                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_TABCOMM",
                        LargeValue = company.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFtabComm ?? "",
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_F_JOB",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_COMENT",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_PRINCACTIV",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_SELECTFIN",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_ANALISTCOM",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_F_TABCOMM",
                        LargeValue = "",
                    });
                }

                //traductions.AddRange(await context.Traductions.Where(x => x.IdCompany == idCompany && x.Identifier.Contains("_F_")).ToListAsync());

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
                if (obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault() != null)
                {
                    obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFjob= traductions.Where(x => x.Identifier == "S_F_JOB").FirstOrDefault().ShortValue;
                    obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFcomment= traductions.Where(x => x.Identifier == "L_F_COMENT").FirstOrDefault().LargeValue;
                    obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFprincActiv= traductions.Where(x => x.Identifier == "L_F_PRINCACTIV").FirstOrDefault().LargeValue;
                    obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFselectFin = traductions.Where(x => x.Identifier == "L_F_SELECTFIN").FirstOrDefault().LargeValue;
                    obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFanalistCom= traductions.Where(x => x.Identifier == "L_F_ANALISTCOM").FirstOrDefault().LargeValue;
                    obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().TFtabComm = traductions.Where(x => x.Identifier == "L_F_TABCOMM").FirstOrDefault().LargeValue;
                    obj.IdCompanyNavigation.TraductionCompanies.FirstOrDefault().UploadDate = DateTime.Now;
                }
                obj.IdCompanyNavigation.Traductions = null;
              //  obj.IdCompanyNavigation.IdCreditRisk = obj.IdFinancialSituacion == null ? null : obj.IdFinancialSituacion == 8 ? null : obj.IdFinancialSituacion == 9 ? 1 : obj.IdFinancialSituacion == 10 ? 2 : obj.IdFinancialSituacion == 11 ? 3 : obj.IdFinancialSituacion == 12 ? 4 : obj.IdFinancialSituacion == 13 ? 5 : obj.IdFinancialSituacion == 14 ? 7 : obj.IdFinancialSituacion == 15 ? 6 : null;
                context.CompanyFinancialInformations.Update(obj);
                await context.SaveChangesAsync();

                //var listTraductions = await context.Traductions.Where(x => x.IdCompany == obj.IdCompany && x.Identifier.Contains("_F_")).ToListAsync();
                //foreach (var item in listTraductions)
                //{
                //    item.ShortValue = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().ShortValue;
                //    item.LargeValue = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().LargeValue;
                //    item.LastUpdaterUser = traductions.Where(x => x.Identifier == item.Identifier).FirstOrDefault().LastUpdaterUser;
                //    context.Traductions.Update(item);
                //}
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
