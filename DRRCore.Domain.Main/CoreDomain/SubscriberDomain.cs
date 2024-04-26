using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Infraestructure.Repository.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class SubscriberDomain : ISubscriberDomain
    {
        public readonly ISubscriberRepository _subscriberRepository;
        public SubscriberDomain(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task<bool> ActiveSubscriberAsync(int id)
        {
            return await _subscriberRepository.ActiveSubscriberAsync(id);
        }

        public async Task<int> AddSubscriberAsync(Subscriber subscriber)
        {
            return await _subscriberRepository.AddSubscriberAsync(subscriber);
        }

        public async Task<bool> DeleteSubscriberAsync(int id)
        {
            return await _subscriberRepository.DeleteSubscriberAsync(id);
        }

        public async Task<List<Subscriber>> GetSubscriber(string code, string name, string enable)
        {
            return await _subscriberRepository.GetSubscriber(code, name, enable);
        }

        public async Task<Subscriber> GetSubscriberByCode(string code)
        {
            return await _subscriberRepository.GetSubscriberByCode(code);
        }

        public async Task<Subscriber> GetSubscriberById(int id)
        {
            return await _subscriberRepository.GetSubscriberById(id);
        }

        public async Task<Subscriber> LoginSubscriber(string usr, string psw)
        {
            return await _subscriberRepository.LoginSubscriber(usr, psw);
        }

        public async Task<bool> UpdateSubscriberAsync(Subscriber subscriber)
        {
            return await _subscriberRepository.UpdateSubscriberAsync(subscriber);
        }
    }
}
