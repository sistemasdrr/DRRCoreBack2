using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonPhotoDomain : IPersonPhotoDomain
    {
        private readonly IPersonPhotoRepository _personPhotoRepository;
        public PersonPhotoDomain(IPersonPhotoRepository personPhotoRepository)
        {
            _personPhotoRepository = personPhotoRepository;
        }
        public async Task<bool> AddAsync(PhotoPerson obj)
        {
            return await _personPhotoRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _personPhotoRepository.DeleteAsync(id);
        }

        public Task<List<PhotoPerson>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PhotoPerson> GetByIdAsync(int id)
        {
            return await _personPhotoRepository.GetByIdAsync(id);
        }

        public Task<List<PhotoPerson>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PhotoPerson>> GetPhotosByIdPersonAsync(int idPerson)
        {
            return await _personPhotoRepository.GetPhotosByIdPersonAsync(idPerson);
        }

        public async Task<bool> UpdateAsync(PhotoPerson obj)
        {
            return await _personPhotoRepository.UpdateAsync(obj);
        }
    }
}
