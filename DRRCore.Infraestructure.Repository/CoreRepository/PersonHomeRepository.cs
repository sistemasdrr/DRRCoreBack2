using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonHomeRepository : IPersonHomeRepository
    {
        private readonly ILogger _logger;
        public PersonHomeRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(PersonHome obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonHomeAsync(PersonHome personHome, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.PersonHomes.Add(personHome);

                foreach (var item in traductions)
                {
                    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == personHome.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                        newTraduction.IdPerson = personHome.IdPerson;
                        newTraduction.Identifier = item.Identifier;
                        newTraduction.ShortValue = item.ShortValue;
                        newTraduction.LargeValue = item.LargeValue;
                        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                        await context.Traductions.AddAsync(newTraduction);
                    }
                }
                await context.SaveChangesAsync();
                return personHome.Id;

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

        public Task<List<PersonHome>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonHome> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonHome> GetByIdPersonAsync(int idPerson)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var personHome = await context.PersonHomes.Include(x => x.IdPersonNavigation).Where(x => x.IdPerson == idPerson).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == idPerson && x.Identifier.Contains("_D_")).ToListAsync());

                if (personHome.IdPersonNavigation == null)
                    throw new Exception("No existe la persona");

                personHome.IdPersonNavigation.Traductions = traductions;
                return personHome;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<PersonHome>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonHome obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonHomeAsync(PersonHome personHome, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    personHome.UpdateDate = DateTime.Now;
                    context.PersonHomes.Update(personHome);

                    foreach (var item in traductions)
                    {
                        var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == personHome.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                            newTraduction.IdPerson = personHome.IdPerson;
                            newTraduction.Identifier = item.Identifier;
                            newTraduction.ShortValue = item.ShortValue;
                            newTraduction.LargeValue = item.LargeValue;
                            newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                            await context.Traductions.AddAsync(newTraduction);
                        }
                    }
                    await context.SaveChangesAsync();
                    return personHome.Id;
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
