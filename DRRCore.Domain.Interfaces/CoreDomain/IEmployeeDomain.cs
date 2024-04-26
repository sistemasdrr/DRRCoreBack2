using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IEmployeeDomain:IBaseDomain<Employee>
    {
        Task<bool> ActiveEmployeeAsync(int id);
        Task<Employee> FindByPersonalCode(string code);
    }
}
