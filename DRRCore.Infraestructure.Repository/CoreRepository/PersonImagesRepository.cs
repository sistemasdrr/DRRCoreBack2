using CoreFtp;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonImagesRepository : IPersonImagesRepository
    {
        private readonly ILogger _logger;
        public PersonImagesRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(PersonImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonImage(PersonImage obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.PersonImages.Add(obj);

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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonImage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonImage> GetByIdPerson(int idPerson)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var images = await context.PersonImages.Include(x => x.IdPersonNavigation).Where(x => x.IdPerson== idPerson).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdPerson== idPerson && x.Identifier.Contains("_IP_")).ToListAsync());

                if (images.IdPersonNavigation == null)
                    throw new Exception("No existe la empresa");

                images.IdPersonNavigation.Traductions = traductions;
                return images;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<PersonImage>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonImage(PersonImage obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    context.PersonImages.Update(obj);

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
