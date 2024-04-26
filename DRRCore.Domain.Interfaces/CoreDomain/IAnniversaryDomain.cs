using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IAnniversaryDomain:IBaseDomain<Anniversary>
    {
        Task<bool> ActiveAnniversaryAsync(int id);
    }
}
