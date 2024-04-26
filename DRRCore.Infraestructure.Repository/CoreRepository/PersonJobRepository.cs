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
                context.PersonJobs.Add(obj);

                foreach (var item in traductions)
                {
                    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == obj.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                        newTraduction.IdPerson = obj.IdPerson;
                        newTraduction.Identifier = item.Identifier;
                        newTraduction.ShortValue = item.ShortValue;
                        newTraduction.LargeValue = item.LargeValue;
                        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                        await context.Traductions.AddAsync(newTraduction);
                    }
                }
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
                var obj = await context.PersonJobs.Include(x => x.IdPersonNavigation).Include(x => x.IdCompanyNavigation).Where(x => x.IdPerson == idPerson).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == idPerson && x.Identifier.Contains("_C_")).ToListAsync());

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
                    context.PersonJobs.Update(obj);

                    foreach (var item in traductions)
                    {
                        var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == obj.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
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
                            newTraduction.IdPerson = obj.IdPerson;
                            newTraduction.Identifier = item.Identifier;
                            newTraduction.ShortValue = item.ShortValue;
                            newTraduction.LargeValue = item.LargeValue;
                            newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                            await context.Traductions.AddAsync(newTraduction);
                        }
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
    }
}
