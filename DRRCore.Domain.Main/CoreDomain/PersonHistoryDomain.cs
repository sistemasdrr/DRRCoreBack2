using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonHistoryDomain : IPersonHistoryDomain
    {
        private readonly IPersonHistoryRepository _personHistoryRepository;
        public PersonHistoryDomain(IPersonHistoryRepository personHistoryRepository)
        {
            _personHistoryRepository = personHistoryRepository;
        }

        public Task<bool> AddAsync(PersonHistory obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonHistoryAsync(PersonHistory obj, List<Traduction> traductions)
        {
            return await _personHistoryRepository.AddPersonHistoryAsync(obj, traductions);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonHistory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonHistory> GetByIdPersonAsync(int idPerson)
        {
            return await _personHistoryRepository.GetByIdPersonAsync(idPerson);
        }

        public Task<List<PersonHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonHistory obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonHistoryAsync(PersonHistory obj, List<Traduction> traductions)
        {
            return await _personHistoryRepository.UpdatePersonHistoryAsync(obj, traductions);
        }
    }
}
