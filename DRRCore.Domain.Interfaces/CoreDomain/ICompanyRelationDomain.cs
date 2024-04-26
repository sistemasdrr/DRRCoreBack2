using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyRelationDomain : IBaseDomain<CompanyRelation>
    {
        public Task<List<CompanyRelation>> GetCompanyRelationByIdCompany(int idCompany);
    }
}
