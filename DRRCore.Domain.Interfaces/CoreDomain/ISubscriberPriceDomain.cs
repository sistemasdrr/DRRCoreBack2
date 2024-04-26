using DRRCore.Domain.Entities.SqlCoreContext;
using Microsoft.Data.SqlClient.DataClassification;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ISubscriberPriceDomain : IBaseDomain<SubscriberPrice>
    {
        Task<List<SubscriberPrice>> GetPricesBySubscriberId(int idSubscriber);
        Task<SubscriberPrice> GetPriceBySubscriberIds(int idSubscriber, int idContinent, int idCountry);
    }
}
