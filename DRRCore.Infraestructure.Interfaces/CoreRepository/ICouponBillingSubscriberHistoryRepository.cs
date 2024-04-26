using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICouponBillingSubscriberHistoryRepository : IBaseRepository<CouponBillingSubscriberHistory>
    {
        Task<List<CouponBillingSubscriberHistory>> GetCouponBillingHistoriesByIdSubscriber(int idSubscriber);
    }
}
