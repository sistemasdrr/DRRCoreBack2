using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class EmployeeDomain : IEmployeeDomain
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeDomain(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ActiveEmployeeAsync(int id)
        {
            return await _repository.ActiveEmployeeAsync(id);
        }

        public async Task<bool> AddAsync(Employee obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Employee> FindByPersonalCode(string code)
        {
            return await _repository.FindByPersonalCode(code);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Employee>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<bool> UpdateAsync(Employee obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
