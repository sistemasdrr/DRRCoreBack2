using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ISubscriberDomain
    {
        Task<Subscriber> GetSubscriberById(int id);
        Task<Subscriber> GetSubscriberByCode(string code);
        Task<int> AddSubscriberAsync(Subscriber subscriber);
        Task<Boolean> UpdateSubscriberAsync(Subscriber subscriber);
        Task<List<Subscriber>> GetSubscriber(string code, string name, string enable);
        Task<bool> DeleteSubscriberAsync(int id);
        Task<bool> ActiveSubscriberAsync(int id);
        Task<Subscriber> LoginSubscriber(string usr, string psw);
    }
}
