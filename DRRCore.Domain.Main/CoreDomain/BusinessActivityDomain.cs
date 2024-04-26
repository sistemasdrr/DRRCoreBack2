using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class BusinessActivityDomain : IBusinessActivityDomain
    {
        private readonly IBusinessActivityRepository _businessActivityRepository;
        public BusinessActivityDomain(IBusinessActivityRepository businessActivityRepository)
        {
            _businessActivityRepository = businessActivityRepository;
        }

        public Task<bool> AddAsync(BusineesActivity obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusineesActivity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BusineesActivity>> GetAllByIdBranch(int idBusinessBranch)
        {
            return await _businessActivityRepository.GetAllByIdBranch(idBusinessBranch);
        }

        public Task<BusineesActivity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusineesActivity>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BusineesActivity obj)
        {
            throw new NotImplementedException();
        }
    }
}
