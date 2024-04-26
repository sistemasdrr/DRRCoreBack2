using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonDomain : IPersonDomain
    {
        private readonly IPersonRepository _personRepository;
        public PersonDomain(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> ActivateWebAsync(int id)
        {
            return await _personRepository.ActivateWebAsync(id);
        }

        public Task<bool> AddAsync(Person obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddPersonAsync(Person person)
        {
            return await _personRepository.AddPersonAsync(person);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _personRepository.DeleteAsync(id);
        }

        public async Task<bool> DesactivateWebAsync(int id)
        {
            return await _personRepository.DesactivateWebAsync(id);
        }

        public Task<List<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Person>> GetAllByAsync(string fullname, string form, int idCountry, bool haveReport, string filterBy)
        {
            return await _personRepository.GetAllByAsync(fullname, form, idCountry, haveReport,filterBy);
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await  _personRepository.GetByIdAsync(id);
        }

        public Task<List<Person>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetByOldCode(string? empresa)
        {
            return await _personRepository.GetByOldCode(empresa);
        }

        public async Task<List<Person>> GetPersonSituation(string typeSearch, string? search, int? idCountry)
        {
            return await _personRepository.GetPersonSituation(typeSearch, search, idCountry);
        }

        public async Task<bool> UpdateAsync(Person obj)
        {
            return await _personRepository.UpdateAsync(obj);
        }
    }
}
