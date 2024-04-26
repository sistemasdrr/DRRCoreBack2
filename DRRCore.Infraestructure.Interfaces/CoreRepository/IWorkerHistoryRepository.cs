using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IWorkerHistoryRepository : IBaseRepository<WorkersHistory>
    {
        Task<List<WorkersHistory>> GetByIdCompanyAsync(int idCompany);
    }
}
