using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class AnniversaryDomain : IAnniversaryDomain
    {
        private readonly IAnniversaryRepository _anniversaryRepository;
        public AnniversaryDomain(IAnniversaryRepository anniversaryRepository)
        {
            _anniversaryRepository = anniversaryRepository;
        }

        public async Task<bool> ActiveAnniversaryAsync(int id)
        {
            return await _anniversaryRepository.ActiveAnniversaryAsync(id);
        }

        public async Task<bool> AddAsync(Anniversary obj)
        {
            return await _anniversaryRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _anniversaryRepository.DeleteAsync(id);
        }

        public async Task<List<Anniversary>> GetAllAsync()
        {
           return await _anniversaryRepository.GetAllAsync();
        }

        public async Task<Anniversary> GetByIdAsync(int id)
        {
            return await _anniversaryRepository.GetByIdAsync(id);
        }

        public Task<List<Anniversary>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Anniversary obj)
        {
            return await _anniversaryRepository.UpdateAsync(obj);
        }
    }
}
