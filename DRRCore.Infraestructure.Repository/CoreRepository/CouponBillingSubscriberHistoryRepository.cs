using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Domain.Entities.SqlCoreContext
{
    public class CouponBillingSubscriberHistoryRepository : ICouponBillingSubscriberHistoryRepository
    {
        private readonly ILogger _logger;
        public CouponBillingSubscriberHistoryRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(CouponBillingSubscriberHistory obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
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
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.CouponBillingSubscriberHistories.Where(x => x.IdCouponBillingNavigation.IdSubscriber == idSubscriber).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<CouponBillingSubscriberHistory>();
            }
        }

        public Task<bool> UpdateAsync(CouponBillingSubscriberHistory obj)
        {
            throw new NotImplementedException();
        }
    }
}
