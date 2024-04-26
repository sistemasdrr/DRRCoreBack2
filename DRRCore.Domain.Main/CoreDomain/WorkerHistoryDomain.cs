using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Infraestructure.Repository.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class WorkerHistoryDomain : IWorkerHistoryDomain
    {
        private readonly IWorkerHistoryRepository _repository;
        public WorkerHistoryDomain(IWorkerHistoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddAsync(WorkersHistory obj)
        {
            return  await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<WorkersHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<WorkersHistory> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<WorkersHistory>> GetByIdCompanyAsync(int idCompany)
        {
            return await _repository.GetByIdCompanyAsync(idCompany);
        }

        public Task<List<WorkersHistory>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(WorkersHistory obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
