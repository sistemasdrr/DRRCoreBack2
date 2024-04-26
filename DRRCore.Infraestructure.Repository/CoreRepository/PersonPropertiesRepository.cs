using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonPropertiesRepository : IPersonPropertiesRepository
    {
        private readonly ILogger _logger;
        public PersonPropertiesRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(PersonProperty obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonPropertiesAsync(PersonProperty personProperty, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.PersonProperties.Add(personProperty);

                foreach (var item in traductions)
                {
                    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == personProperty.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                        newTraduction.IdPerson = personProperty.IdPerson;
                        newTraduction.Identifier = item.Identifier;
                        newTraduction.ShortValue = item.ShortValue;
                        newTraduction.LargeValue = item.LargeValue;
                        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                        await context.Traductions.AddAsync(newTraduction);
                    }
                }
                await context.SaveChangesAsync();
                return personProperty.Id;

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

        public Task<List<PersonProperty>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonProperty> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonProperty> GetByIdPersonAsync(int idPerson)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var personProperty= await context.PersonProperties.Include(x => x.IdPersonNavigation).Where(x => x.IdPerson == idPerson).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == idPerson && x.Identifier.Contains("_PR_")).ToListAsync());

                if (personProperty.IdPersonNavigation == null)
                    throw new Exception("No existe la persona");

                personProperty.IdPersonNavigation.Traductions = traductions;
                return personProperty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<PersonProperty>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonProperty obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonPropertiesAsync(PersonProperty personProperty, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    personProperty.UpdateDate = DateTime.Now;
                    context.PersonProperties.Update(personProperty);

                    foreach (var item in traductions)
                    {
                        var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == personProperty.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                            newTraduction.IdPerson = personProperty.IdPerson;
                            newTraduction.Identifier = item.Identifier;
                            newTraduction.ShortValue = item.ShortValue;
                            newTraduction.LargeValue = item.LargeValue;
                            newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                            await context.Traductions.AddAsync(newTraduction);
                        }
                    }
                    await context.SaveChangesAsync();
                    return personProperty.Id;
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
