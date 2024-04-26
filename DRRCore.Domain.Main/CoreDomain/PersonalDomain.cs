using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonalDomain : IPersonalDomain
    {
        private readonly IPersonalRepository _personalRepository;
        public PersonalDomain(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }
        public Task<bool> AddAsync(Personal obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Personal>> GetAllAsync()
        {
            return await _personalRepository.GetAllAsync();
        }

        public Task<Personal> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Personal>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Personal obj)
        {
            throw new NotImplementedException();
        }
    }
}
