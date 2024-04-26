using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IFinancialBalanceDomain : IBaseDomain<FinancialBalance>
    {
        Task<List<FinancialBalance>> GetFinancialBalanceByIdCompany(int idCompany, string balanceType);

    }
}
