using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyBranchRepository:IBaseRepository<CompanyBranch>
    {
        Task<int> UpdateAsync(CompanyBranch obj, List<Traduction> traductions);
        Task<int> AddAsync(CompanyBranch obj, List<Traduction> traductions);
        Task<CompanyBranch> GetCompanyBranchByIdCompany(int idCompany);
    }
}
