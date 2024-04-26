using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IBankDebtRepository : IBaseRepository<BankDebt>
    {
        Task<List<BankDebt>> GetBankDebtsByIdCompany(int idCompany);
        Task<List<BankDebt>> GetBankDebtsByIdPerson(int idPerson);
    }
}
