using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class ProcessDomain:IProcessDomain
    {
        private readonly IProcessRepository _repository;
        public ProcessDomain(IProcessRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(Process obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<Process>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Process> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Process>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<bool> UpdateAsync(Process obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
