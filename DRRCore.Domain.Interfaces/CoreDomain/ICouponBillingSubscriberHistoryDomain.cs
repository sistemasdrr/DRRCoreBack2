using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICouponBillingSubscriberHistoryDomain : IBaseDomain<CouponBillingSubscriberHistory>
    {
        Task<List<CouponBillingSubscriberHistory>> GetCouponBillingHistoriesByIdSubscriber(int idSubscriber);
    }
}
