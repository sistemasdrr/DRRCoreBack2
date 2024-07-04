using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonJobRepository : IPersonJobRepository
    {
        private readonly ILogger _logger;
        public PersonJobRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(PersonJob obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonJobAsync(PersonJob obj, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                var trad = await context.TraductionPeople.Where(x => x.IdPerson == obj.IdPerson).FirstOrDefaultAsync();
                if (trad != null)
                {
                    trad.TCcurjob= traductions.Where(x => x.Identifier == "S_C_CURJOB").FirstOrDefault().ShortValue;
                    trad.TCstartDate = traductions.Where(x => x.Identifier == "S_C_STARTDT").FirstOrDefault().ShortValue;
                    trad.TCenddt= traductions.Where(x => x.Identifier == "S_C_ENDDT").FirstOrDefault().ShortValue;
                    trad.TCincome = traductions.Where(x => x.Identifier == "S_C_INCOME").FirstOrDefault().ShortValue;
                    trad.TCdetails = traductions.Where(x => x.Identifier == "L_C_DETAILS").FirstOrDefault().LargeValue;
                    trad.UploadDate = DateTime.Now;
                    context.TraductionPeople.Update(trad);
                }
                else
                {
                    trad = new TraductionPerson();
                    trad.TCcurjob = traductions.Where(x => x.Identifier == "S_C_CURJOB").FirstOrDefault().ShortValue;
                    trad.TCstartDate = traductions.Where(x => x.Identifier == "S_C_STARTDT").FirstOrDefault().ShortValue;
                    trad.TCenddt = traductions.Where(x => x.Identifier == "S_C_ENDDT").FirstOrDefault().ShortValue;
                    trad.TCincome = traductions.Where(x => x.Identifier == "S_C_INCOME").FirstOrDefault().ShortValue;
                    trad.TCdetails = traductions.Where(x => x.Identifier == "L_C_DETAILS").FirstOrDefault().LargeValue;
                    await context.TraductionPeople.AddAsync(trad);
                }
                context.PersonJobs.Add(obj);
                

                //foreach (var item in traductions)
                //{
                //    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == obj.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                //        newTraduction.IdPerson = obj.IdPerson;
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonJob>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonJob> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonJob> GetByIdPersonAsync(int idPerson)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.PersonJobs
                    .Include(x => x.IdPersonNavigation).ThenInclude(x => x.TraductionPeople)
                    .Include(x => x.IdCompanyNavigation)
                    .Where(x => x.IdPerson == idPerson).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");

                if (obj.IdPersonNavigation.TraductionPeople.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_CURJOB",
                        ShortValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCcurjob?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_STARTDT",
                        ShortValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCstartDate?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_ENDDT",
                        ShortValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCenddt ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_INCOME",
                        ShortValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCincome ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_C_DETAILS",
                        LargeValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCdetails ?? "",
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_CURJOB",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_STARTDT",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_ENDDT",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_C_INCOME",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_C_DETAILS",
                        LargeValue = "",
                    });
                }

                //traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == idPerson && x.Identifier.Contains("_C_")).ToListAsync());

                if (obj.IdPersonNavigation == null)
                    throw new Exception("No existe la persona");

                obj.IdPersonNavigation.Traductions = traductions;
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<PersonJob>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonJob obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonJobAsync(PersonJob obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;

                    if (obj.IdPersonNavigation.TraductionPeople.FirstOrDefault() != null)
                    {
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCcurjob= traductions.Where(x => x.Identifier == "S_C_CURJOB").FirstOrDefault().ShortValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCstartDate = traductions.Where(x => x.Identifier == "S_C_STARTDT").FirstOrDefault().ShortValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCenddt = traductions.Where(x => x.Identifier == "S_C_ENDDT").FirstOrDefault().ShortValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCincome = traductions.Where(x => x.Identifier == "S_C_INCOME").FirstOrDefault().ShortValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TCdetails = traductions.Where(x => x.Identifier == "L_C_DETAILS").FirstOrDefault().LargeValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().UploadDate = DateTime.Now;
                    }

                    obj.IdPersonNavigation.Traductions = null;
                    context.PersonJobs.Update(obj);

                    //foreach (var item in traductions)
                    //{
                    //    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == obj.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                    //        newTraduction.IdPerson = obj.IdPerson;
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
