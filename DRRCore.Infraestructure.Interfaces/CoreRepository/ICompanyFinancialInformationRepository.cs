using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyFinancialInformationRepository : IBaseRepository<CompanyFinancialInformation>
    {
        Task<int> AddCompanyFinancialInformation (CompanyFinancialInformation obj, List<Traduction> traduction);
        Task<int> UpdateCompanyFinancialInformation(CompanyFinancialInformation obj, List<Traduction> traduction);
        Task<CompanyFinancialInformation> GetByIdCompany(int idCompany);
    }
}
