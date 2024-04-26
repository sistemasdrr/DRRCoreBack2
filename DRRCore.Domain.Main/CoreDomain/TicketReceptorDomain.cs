using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class TicketReceptorDomain : ITicketReceptorDomain
    {
        private readonly ITicketReceptorRepository _repository;
        public TicketReceptorDomain(ITicketReceptorRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddAsync(TicketReceptor obj)
        {
           return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<TicketReceptor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TicketReceptor> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<TicketReceptor>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<TicketReceptor> GetReceptorDoubleDate(int idCountry)
        {
           return await _repository.GetReceptorDoubleDate(idCountry);
        }

        public async Task<TicketReceptor> GetReceptorInDate(int idCountry)
        {
            return await _repository.GetReceptorInDate(idCountry);
        }

        public async Task<TicketReceptor> GetReceptorOtherCase(int idCountry)
        {
            return await _repository.GetReceptorOtherCase(idCountry);
        }

        public async Task<bool> UpdateAsync(TicketReceptor obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
