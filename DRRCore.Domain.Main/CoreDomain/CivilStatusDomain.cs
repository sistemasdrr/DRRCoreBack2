using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CivilStatusDomain : ICivilStatusDomain
    {
        private readonly ICivilStatusRepository _civilStatusRepository;
        public CivilStatusDomain(ICivilStatusRepository civilStatusRepository) {
             _civilStatusRepository= civilStatusRepository;
        }
        public Task<bool> AddAsync(CivilStatus obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CivilStatus>> GetAllAsync()
        {
            return await _civilStatusRepository.GetAllAsync();
        }

        public Task<CivilStatus> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CivilStatus>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CivilStatus obj)
        {
            throw new NotImplementedException();
        }
    }
}
