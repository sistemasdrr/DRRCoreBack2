using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class FinancialSituacionDomain : IFinancialSituacionDomain
    {
        private readonly IFinancialSituacionRepository _financialSituacionRepository;
        public FinancialSituacionDomain(IFinancialSituacionRepository financialSituacionRepository)
        {
            _financialSituacionRepository = financialSituacionRepository;
        }

        public async Task<bool> AddAsync(FinancialSituacion obj)
        {
            return await _financialSituacionRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _financialSituacionRepository.DeleteAsync(id);
        }

        public async Task<List<FinancialSituacion>> GetAllAsync()
        {
            return await _financialSituacionRepository.GetAllAsync();
        }

        public async Task<FinancialSituacion> GetByIdAsync(int id)
        {
            return await _financialSituacionRepository.GetByIdAsync(id);
        }

        public Task<List<FinancialSituacion>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(FinancialSituacion obj)
        {
            return await _financialSituacionRepository.UpdateAsync(obj);
        }
    }
}
