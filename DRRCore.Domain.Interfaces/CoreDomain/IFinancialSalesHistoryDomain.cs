using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IFinancialSalesHistoryDomain : IBaseDomain<SalesHistory>
    {
        Task<List<SalesHistory>> GetByIdCompany(int idCompany);
    }
}
