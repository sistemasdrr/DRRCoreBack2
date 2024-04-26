using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyGeneralInformationDomain : IBaseDomain<CompanyGeneralInformation>
    {
        Task<int> AddGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions);
        Task<int> UpdateGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions);
        Task<CompanyGeneralInformation> GetByIdCompany(int idCompany);
    }
}
