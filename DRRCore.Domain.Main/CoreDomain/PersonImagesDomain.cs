using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonImagesDomain : IPersonImagesDomain
    {
        private readonly IPersonImagesRepository _repository;
        public PersonImagesDomain(IPersonImagesRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(PersonImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonImage(PersonImage obj, List<Traduction> traductions)
        {
            return await _repository.AddPersonImage(obj, traductions);
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
            return await _repository.GetByIdPerson(idPerson);
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
            return await _repository.UpdatePersonImage(obj, traductions);
        }
    }
}
