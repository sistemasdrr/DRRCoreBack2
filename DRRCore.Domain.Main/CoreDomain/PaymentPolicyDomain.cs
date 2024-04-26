using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PaymentPolicyDomain : IPaymentPolicyDomain
    {
        private readonly IPaymentPolicyRepository _paymentPolicyRepository;
        public PaymentPolicyDomain(IPaymentPolicyRepository paymentPolicyRepository)
        {
            _paymentPolicyRepository = paymentPolicyRepository;
        }
        public Task<bool> AddAsync(PaymentPolicy obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PaymentPolicy>> GetAllAsync()
        {
            return await _paymentPolicyRepository.GetAllAsync();
        }

        public Task<PaymentPolicy> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentPolicy>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PaymentPolicy obj)
        {
            throw new NotImplementedException();
        }
    }
}
