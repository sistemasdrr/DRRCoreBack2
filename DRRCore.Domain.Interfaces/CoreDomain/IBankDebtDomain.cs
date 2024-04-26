using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IBankDebtDomain : IBaseDomain<BankDebt>
    {
        Task<List<BankDebt>> GetBankDebtsByIdCompany(int idCompany);
        Task<List<BankDebt>> GetBankDebtsByIdPerson(int idPerson);
    }
}
