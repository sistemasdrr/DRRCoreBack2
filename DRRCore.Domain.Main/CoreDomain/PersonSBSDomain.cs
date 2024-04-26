using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonSBSDomain : IPersonSBSDomain
    {
        private readonly IPersonSBSRepository _personSBSRepository;
        public PersonSBSDomain(IPersonSBSRepository personSBSRepository)
        {
            _personSBSRepository = personSBSRepository;
        }

        public Task<bool> AddAsync(PersonSb obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonSBS(PersonSb obj, List<Traduction> traductions)
        {
            return await _personSBSRepository.AddPersonSBS(obj, traductions);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonSb>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonSb> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonSb> GetByIdPerson(int idPerson)
        {
            return await _personSBSRepository.GetByIdPerson(idPerson);
        }

        public Task<List<PersonSb>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonSb obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonSBS(PersonSb obj, List<Traduction> traductions)
        {
            return await _personSBSRepository.UpdatePersonSBS(obj, traductions);
        }
    }
}
