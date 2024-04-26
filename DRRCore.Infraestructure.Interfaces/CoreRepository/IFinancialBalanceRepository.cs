using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IFinancialBalanceRepository : IBaseRepository<FinancialBalance>
    {
        Task<List<FinancialBalance>> GetFinancialBalanceByIdCompany(int idCompany, string balanceType);
        
    }
}
