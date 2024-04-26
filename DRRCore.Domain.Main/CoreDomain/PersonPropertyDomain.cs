using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonPropertyDomain : IPersonPropertyDomain
    {
        private readonly IPersonPropertiesRepository _personPropertiesRepository;
        public PersonPropertyDomain(IPersonPropertiesRepository personPropertiesRepository)
        {
            _personPropertiesRepository = personPropertiesRepository;
        }

        public Task<bool> AddAsync(PersonProperty obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonPropertiesAsync(PersonProperty personProperty, List<Traduction> traductions)
        {
            return await _personPropertiesRepository.AddPersonPropertiesAsync(personProperty, traductions);
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
            return await _personPropertiesRepository.GetByIdPersonAsync(idPerson);
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
            return await _personPropertiesRepository.UpdatePersonPropertiesAsync(personProperty, traductions);
        }
    }
}
