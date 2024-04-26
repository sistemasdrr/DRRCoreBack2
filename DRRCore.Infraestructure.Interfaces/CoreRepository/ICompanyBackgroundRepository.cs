using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyBackgroundRepository:IBaseRepository<CompanyBackground>
    {
        Task<int?> UpdateAsync(CompanyBackground obj, List<Traduction> traductions);
        Task<int?> AddAsync(CompanyBackground obj, List<Traduction> traductions);
    }
}
