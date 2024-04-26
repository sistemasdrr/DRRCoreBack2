using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<bool> ActiveEmployeeAsync(int id);
        Task<Employee> FindByPersonalCode(string code);
    }
}
