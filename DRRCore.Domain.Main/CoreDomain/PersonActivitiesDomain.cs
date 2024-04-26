using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonActivitiesDomain : IPersonActivitiesDomain
    {
        private readonly IPersonActivitiesRepository _personActivitiesRepository;
        public PersonActivitiesDomain(IPersonActivitiesRepository personActivitiesRepository)
        {
            _personActivitiesRepository = personActivitiesRepository;
        }
        public Task<bool> AddAsync(PersonActivity obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions)
        {
            return await _personActivitiesRepository.AddPersonActivitiesAsync(personActivity, traductions);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonActivity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonActivity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonActivity> GetByIdPersonAsync(int idPerson)
        {
            return await _personActivitiesRepository.GetByIdPersonAsync(idPerson);
        }

        public Task<List<PersonActivity>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonActivity obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions)
        {
            return await _personActivitiesRepository.UpdatePersonActivitiesAsync(personActivity, traductions);
        }
    }
}
