using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CouponBillingSubscriberRepository : ICouponBillingSubscriberRepository
    {
        private readonly ILogger _logger;
        public CouponBillingSubscriberRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(CouponBillingSubscriber obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.CouponBillingSubscribers.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingCouponBillingSubscriber = await context.CouponBillingSubscribers.FirstOrDefaultAsync(x => x.Id == id);
                if(existingCouponBillingSubscriber != null)
                {
                    existingCouponBillingSubscriber.Enable = false;
                    context.Update(existingCouponBillingSubscriber);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Task<List<CouponBillingSubscriber>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CouponBillingSubscriber> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var couponBillingSubscriber = await context.CouponBillingSubscribers.FirstOrDefaultAsync(x => x.Id == id);
                return couponBillingSubscriber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new CouponBillingSubscriber();
            }
        }

        public Task<List<CouponBillingSubscriber>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CouponBillingSubscriber> GetCouponBillingByIdSubscriber(int idSubscriber)
        {
            try
            {
                using var context = new SqlCoreContext();
                var couponBillingSubscriber = await context.CouponBillingSubscribers.FirstOrDefaultAsync(x => x.IdSubscriber == idSubscriber);
                return couponBillingSubscriber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new CouponBillingSubscriber();
            }
        }

        public async Task<bool> UpdateAsync(CouponBillingSubscriber obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.CouponBillingSubscribers.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
