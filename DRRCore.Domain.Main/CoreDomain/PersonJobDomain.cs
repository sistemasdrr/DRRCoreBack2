using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonJobDomain : IPersonJobDomain
    {
        private readonly IPersonJobRepository _personJobRepository;
        public PersonJobDomain(IPersonJobRepository personJobRepository)
        {
            _personJobRepository = personJobRepository;
        }
        public Task<bool> AddAsync(PersonJob obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonJobAsync(PersonJob obj, List<Traduction> traductions)
        {
            return await _personJobRepository.AddPersonJobAsync(obj, traductions);
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
            return await _personJobRepository.GetByIdPersonAsync(idPerson);
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
            return await _personJobRepository.UpdatePersonJobAsync(obj, traductions);
        }
    }
}
