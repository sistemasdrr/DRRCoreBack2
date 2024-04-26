using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyBackgroundDomain : IBaseDomain<CompanyBackground>
    {
        Task<int?> UpdateAsync(CompanyBackground obj, List<Traduction> traductions);
        Task<int?> AddAsync(CompanyBackground obj, List<Traduction> traductions);
    }
}
