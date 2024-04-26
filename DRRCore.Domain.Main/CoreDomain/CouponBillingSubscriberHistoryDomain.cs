using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CouponBillingSubscriberHistoryDomain : ICouponBillingSubscriberHistoryDomain
    {
        private readonly ICouponBillingSubscriberHistoryRepository _couponBillingSubscriberHistoryRepository;
        public CouponBillingSubscriberHistoryDomain(ICouponBillingSubscriberHistoryRepository couponBillingSubscriberHistoryRepository)
        {
            _couponBillingSubscriberHistoryRepository = couponBillingSubscriberHistoryRepository;
        }

        public async Task<bool> AddAsync(CouponBillingSubscriberHistory obj)
        {
            return await _couponBillingSubscriberHistoryRepository.AddAsync(obj);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CouponBillingSubscriberHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CouponBillingSubscriberHistory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CouponBillingSubscriberHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CouponBillingSubscriberHistory>> GetCouponBillingHistoriesByIdSubscriber(int idSubscriber)
        {
            return await _couponBillingSubscriberHistoryRepository.GetCouponBillingHistoriesByIdSubscriber(idSubscriber);
        }

        public Task<bool> UpdateAsync(CouponBillingSubscriberHistory obj)
        {
            throw new NotImplementedException();
        }
    }
}
