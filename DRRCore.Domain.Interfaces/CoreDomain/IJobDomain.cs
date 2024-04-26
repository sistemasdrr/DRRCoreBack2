using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IJobDomain : IBaseDomain<Job>
    {
        Task<List<Job>> GetJobByDepartment(int idDepartment);
    }
}
