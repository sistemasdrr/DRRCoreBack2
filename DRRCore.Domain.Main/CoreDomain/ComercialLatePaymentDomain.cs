using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class ComercialLatePaymentDomain : IComercialLatePaymentDomain
    {
        private readonly IComercialLatePaymentRepository _repository;
        public ComercialLatePaymentDomain(IComercialLatePaymentRepository repository)
        {
            this._repository = repository;
        }

        public async Task<bool> AddAsync(ComercialLatePayment obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<ComercialLatePayment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ComercialLatePayment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<ComercialLatePayment>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComercialLatePayment>> GetComercialLatePaymetByIdCompany(int idCompany)
        {
            return await _repository.GetComercialLatePaymetByIdCompany(idCompany);
        }

        public async Task<List<ComercialLatePayment>> GetComercialLatePaymetByIdPerson(int idPerson)
        {
            return await _repository.GetComercialLatePaymetByIdPerson(idPerson);
        }

        public async Task<bool> UpdateAsync(ComercialLatePayment obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
