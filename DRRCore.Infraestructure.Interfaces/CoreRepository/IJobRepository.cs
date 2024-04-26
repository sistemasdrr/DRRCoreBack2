using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<List<Job>> GetJobByDepartment(int idDepartment);
    }
}
