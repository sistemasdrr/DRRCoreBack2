using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CouponBillingSubscriberDomain : ICouponBillingSubscriberDomain
    {
        private ICouponBillingSubscriberRepository _repository;
        public CouponBillingSubscriberDomain(ICouponBillingSubscriberRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddAsync(CouponBillingSubscriber obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<CouponBillingSubscriber>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CouponBillingSubscriber> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<CouponBillingSubscriber>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CouponBillingSubscriber> GetCouponBillingByIdSubscriber(int idSubscriber)
        {
            return await _repository.GetCouponBillingByIdSubscriber(idSubscriber);
        }

        public async Task<bool> UpdateAsync(CouponBillingSubscriber obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
