using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class JobDepartmentDomain:IJobDepartmentDomain
    {
        private readonly IJobDepartmentRepository _repository;
        public JobDepartmentDomain(IJobDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(JobDepartment obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<JobDepartment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<JobDepartment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<JobDepartment>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<bool> UpdateAsync(JobDepartment obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
