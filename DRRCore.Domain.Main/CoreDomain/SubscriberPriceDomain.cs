
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class SubscriberPriceDomain : ISubscriberPriceDomain
    {
        public readonly ISubscriberPriceRepository _subscriberPriceRepository;
        public SubscriberPriceDomain(ISubscriberPriceRepository subscriberPriceRepository)
        {
            _subscriberPriceRepository = subscriberPriceRepository;
        }
        public async Task<bool> AddAsync(SubscriberPrice obj)
        {
            return await _subscriberPriceRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _subscriberPriceRepository.DeleteAsync(id);
        }

        public Task<List<SubscriberPrice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SubscriberPrice> GetByIdAsync(int id)
        {
            return await _subscriberPriceRepository.GetByIdAsync(id);
        }

        public Task<List<SubscriberPrice>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<SubscriberPrice> GetPriceBySubscriberIds(int idSubscriber, int idContinent, int idCountry)
        {
            return await _subscriberPriceRepository.GetPriceBySubscriberIds(idSubscriber, idContinent, idCountry);
        }

        public async Task<List<SubscriberPrice>> GetPricesBySubscriberId(int idSubscriber)
        {
            return await _subscriberPriceRepository.GetPricesBySubscriberId(idSubscriber);
        }

        public async Task<bool> UpdateAsync(SubscriberPrice obj)
        {
            return await _subscriberPriceRepository.UpdateAsync(obj);
        }
    }
}
