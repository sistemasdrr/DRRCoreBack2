using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class NumerationDomain : INumerationDomain
    {
        private INumerationRepository _numerationRepository;
        public NumerationDomain(INumerationRepository numerationRepository) { 
         _numerationRepository = numerationRepository;
        }

        public async Task<bool> AddAsync(Numeration obj)
        {
            return await _numerationRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _numerationRepository.DeleteAsync(id);
        }

        public Task<List<Numeration>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Numeration> GetByIdAsync(int id)
        {
            return await _numerationRepository.GetByIdAsync(id);
        }

        public Task<List<Numeration>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Numeration> GetOrderNumberAsync()
        {
            return await _numerationRepository.GetOrderNumberAsync();
        }

        public async Task<Numeration> GetTicketNumberAsync()
        {
            return await _numerationRepository.GetTicketNumberAsync();
        }

        public async Task<bool> UpdateAsync(Numeration obj)
        {
            return await _numerationRepository.UpdateAsync(obj);
        }

        public async Task<bool> UpdateTicketNumberAsync()
        {
            return await _numerationRepository.UpdateTicketNumberAsync();
        }
    }
}
