using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyImagesDomain : IBaseDomain<CompanyImage>
    {
        Task<int> AddCompanyImage(CompanyImage obj, List<Traduction> traductions);
        Task<int> UpdateCompanyImage(CompanyImage obj, List<Traduction> traductions);
        Task<CompanyImage> GetByIdCompany(int idCompany);
    }
}
