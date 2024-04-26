using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyPartnersDomain : IBaseDomain<CompanyPartner>
    {
        Task<List<CompanyPartner>> GetPartnersByIdCompany(int idCompany);
        Task<List<CompanyPartner>> GetPartnersByIdPerson(int idPerson);
    }
}
