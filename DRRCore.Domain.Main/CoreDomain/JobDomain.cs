using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class JobDomain:IJobDomain
    {
        private readonly IJobRepository _repository;
        public JobDomain(IJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(Job obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<Job>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Job>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<List<Job>> GetJobByDepartment(int idDepartment)
        {
            return await _repository.GetJobByDepartment(idDepartment);
        }

        public async Task<bool> UpdateAsync(Job obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
