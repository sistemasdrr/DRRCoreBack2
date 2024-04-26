using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonSituationDomain : IPersonSituationDomain
    {
        private readonly IPersonSituationRepository _personSituationRepository;
        public PersonSituationDomain(IPersonSituationRepository personSituationRepository)
        {
            _personSituationRepository = personSituationRepository;
        }
        public async Task<bool> AddAsync(PersonSituation obj)
        {
            return await _personSituationRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _personSituationRepository.DeleteAsync(id);
        }

        public async Task<List<PersonSituation>> GetAllAsync()
        {
            return await _personSituationRepository.GetAllAsync();
        }

        public async Task<PersonSituation> GetByIdAsync(int id)
        {
            return await _personSituationRepository.GetByIdAsync(id);
        }

        public Task<List<PersonSituation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(PersonSituation obj)
        {
            return await _personSituationRepository.UpdateAsync(obj);
        }
    }
}
