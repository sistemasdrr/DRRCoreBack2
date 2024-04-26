using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyShareHolderDomain : IBaseDomain<CompanyShareHolder>
    {
        Task<List<CompanyShareHolder>> GetShareHoldersByIdCompany(int idCompany);
    }
}
