using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IWorkerHistoryDomain : IBaseDomain<WorkersHistory>
    {
        Task<List<WorkersHistory>> GetByIdCompanyAsync(int idCompany);
    }
}
