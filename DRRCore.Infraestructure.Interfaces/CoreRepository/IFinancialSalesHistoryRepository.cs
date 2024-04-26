using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IFinancialSalesHistoryRepository : IBaseRepository<SalesHistory>
    {
        Task<List<SalesHistory>> GetByIdCompany(int idCompany);
    }
}
