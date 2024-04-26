using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonPhotoRepository : IPersonPhotoRepository
    {
        private readonly ILogger _logger;
        public PersonPhotoRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(PhotoPerson obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.PhotoPeople.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var photo = await context.PhotoPeople.Where(x => x.Id == id).FirstOrDefaultAsync();
                if(photo != null)
                {
                    photo.Enable = false;
                    photo.DeleteDate = DateTime.Now;
                    context.PhotoPeople.Update(photo);
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

        public Task<List<PhotoPerson>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PhotoPerson> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var photo = await context.PhotoPeople.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (photo != null)
                {
                    return photo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<PhotoPerson>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PhotoPerson>> GetPhotosByIdPersonAsync(int idPerson)
        {
            try
            {
                using var context = new SqlCoreContext();
                var photos = await context.PhotoPeople.Where(x => x.IdPerson == idPerson && x.Enable == true).ToListAsync();
                if (photos != null)
                {
                    return photos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(PhotoPerson obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.PhotoPeople.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
