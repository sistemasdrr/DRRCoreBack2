using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class SubscriberCategoryDomain : ISubscriberCategoryDomain
    {
        private readonly ISubscriberCategoryRepository _subscriberCategoryRepository;
        public SubscriberCategoryDomain(ISubscriberCategoryRepository subscriberCategoryRepository)
        {
            _subscriberCategoryRepository = subscriberCategoryRepository;
        }
        public async Task<bool> AddAsync(SubscriberCategory obj)
        {
            return await _subscriberCategoryRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _subscriberCategoryRepository.DeleteAsync(id);
        }

        public async Task<List<SubscriberCategory>> GetAllAsync()
        {
            return await _subscriberCategoryRepository.GetAllAsync();
        }

        public async Task<SubscriberCategory> GetByIdAsync(int id)
        {
            return await _subscriberCategoryRepository.GetByIdAsync(id);
        }

        public Task<List<SubscriberCategory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(SubscriberCategory obj)
        {
            return await _subscriberCategoryRepository.UpdateAsync(obj);
        }
    }
}
