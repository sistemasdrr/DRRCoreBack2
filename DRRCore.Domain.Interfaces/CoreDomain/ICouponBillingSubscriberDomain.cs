using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICouponBillingSubscriberDomain : IBaseDomain<CouponBillingSubscriber>
    {
        Task<CouponBillingSubscriber> GetCouponBillingByIdSubscriber(int idSubscriber);
    }
}
