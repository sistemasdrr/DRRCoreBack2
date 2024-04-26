using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PaymentPolicyRepository : IPaymentPolicyRepository
    {
        private readonly ILogger _logger;
        public PaymentPolicyRepository(ILogger logger)
        {
            _logger = logger;
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
            try
            {
                using var context = new SqlCoreContext();
                return await context.PaymentPolicies.Where(x => x.Enable==true).OrderBy(x => x.Level).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<PaymentPolicy>();
            }
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
