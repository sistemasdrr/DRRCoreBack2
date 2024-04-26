using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyBranchDomain:IBaseDomain<CompanyBranch>
    {
        Task<int> UpdateAsync(CompanyBranch obj, List<Traduction> traductions);
        Task<int> AddAsync(CompanyBranch obj, List<Traduction> traductions);
        Task<CompanyBranch> GetCompanyBranchByIdCompany(int idCompany);
    }
}
