using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonActivitiesRepository : IPersonActivitiesRepository
    {
        private readonly ILogger _logger;
        public PersonActivitiesRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(PersonActivity obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                var trad = await context.TraductionPeople.Where(x => x.IdPerson == personActivity.IdPerson).FirstOrDefaultAsync();
                if (trad != null)
                {
                    trad.TAotherAct= traductions.Where(x => x.Identifier == "L_A_OTHERACT").FirstOrDefault().LargeValue;
                    context.TraductionPeople.Update(trad);
                }
                else
                {
                    trad = new TraductionPerson();
                    trad.TAotherAct = traductions.Where(x => x.Identifier == "L_A_OTHERACT").FirstOrDefault().LargeValue;
                    await context.TraductionPeople.AddAsync(trad);
                }
                context.PersonActivities.Add(personActivity);

                //foreach (var item in traductions)
                //{
                //    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == personActivity.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                //        newTraduction.IdPerson= personActivity.IdPerson;
                //        newTraduction.Identifier = item.Identifier;
                //        newTraduction.ShortValue = item.ShortValue;
                //        newTraduction.LargeValue = item.LargeValue;
                //        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                //        await context.Traductions.AddAsync(newTraduction);
                //    }
                //}
                await context.SaveChangesAsync();
                return personActivity.Id;

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

        public Task<List<PersonActivity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonActivity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonActivity> GetByIdPersonAsync(int idPerson)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var personActivities = await context.PersonActivities
                    .Include(x => x.IdPersonNavigation).ThenInclude(x => x.TraductionPeople)
                    .Where(x => x.IdPerson == idPerson).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");

                if (personActivities.IdPersonNavigation.TraductionPeople.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_A_OTHERACT",
                        LargeValue = personActivities.IdPersonNavigation.TraductionPeople.FirstOrDefault().TAotherAct ?? "",
                    });

                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_A_OTHERACT",
                        LargeValue = "",
                    });
                }
                //traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == idPerson && x.Identifier.Contains("_A_")).ToListAsync());

                if (personActivities.IdPersonNavigation == null)
                    throw new Exception("No existe la persona");

                personActivities.IdPersonNavigation.Traductions = traductions;
                return personActivities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<PersonActivity>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonActivity obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    personActivity.UpdateDate = DateTime.Now;
                    if (personActivity.IdPersonNavigation.TraductionPeople.FirstOrDefault() != null)
                    {
                        personActivity.IdPersonNavigation.TraductionPeople.FirstOrDefault().TAotherAct = traductions.Where(x => x.Identifier == "L_A_OTHERACT").FirstOrDefault().LargeValue;
                        personActivity.IdPersonNavigation.TraductionPeople.FirstOrDefault().UploadDate = DateTime.Now;
                    }
                    context.PersonActivities.Update(personActivity);

                    //foreach (var item in traductions)
                    //{
                    //    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == personActivity.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                    //        newTraduction.IdPerson = personActivity.IdPerson;
                    //        newTraduction.Identifier = item.Identifier;
                    //        newTraduction.ShortValue = item.ShortValue;
                    //        newTraduction.LargeValue = item.LargeValue;
                    //        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        await context.Traductions.AddAsync(newTraduction);
                    //    }
                    //}
                    await context.SaveChangesAsync();
                    return personActivity.Id;
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
