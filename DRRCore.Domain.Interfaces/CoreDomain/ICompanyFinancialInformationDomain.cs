using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyFinancialInformationDomain : IBaseDomain<CompanyFinancialInformation>
    {
        Task<CompanyFinancialInformation> GetByIdCompany(int idCompany);
        Task<int> AddCompanyFinancialInformation(CompanyFinancialInformation obj, List<Traduction> traduction);
        Task<int> UpdateCompanyFinancialInformation(CompanyFinancialInformation obj, List<Traduction> traduction);
    }
}
