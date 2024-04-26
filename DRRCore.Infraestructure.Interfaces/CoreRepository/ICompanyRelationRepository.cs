using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyRelationRepository : IBaseRepository<CompanyRelation>
    {
        public Task<List<CompanyRelation>> GetCompanyRelationByIdCompany(int idCompany);
    }
}
