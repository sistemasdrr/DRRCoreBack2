using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonHomeDomain : IPersonHomeDomain
    {
        private readonly IPersonHomeRepository _personHomeRepository;
        public PersonHomeDomain(IPersonHomeRepository personHomeRepository)
        {
            _personHomeRepository = personHomeRepository;
        }

        public Task<bool> AddAsync(PersonHome obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonHomeAsync(PersonHome personHome, List<Traduction> traductions)
        {
            return await _personHomeRepository.AddPersonHomeAsync(personHome, traductions);
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
            return await _personHomeRepository.GetByIdPersonAsync(idPerson);
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
            return await _personHomeRepository.UpdatePersonHomeAsync(personHome, traductions);
        }
    }
}
