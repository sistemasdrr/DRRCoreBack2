using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICouponBillingSubscriberRepository : IBaseRepository<CouponBillingSubscriber>
    {
        Task<CouponBillingSubscriber> GetCouponBillingByIdSubscriber(int idSubscriber);
    }
}
