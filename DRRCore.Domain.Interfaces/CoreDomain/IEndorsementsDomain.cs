using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IEndorsementsDomain : IBaseDomain<Endorsement>
    {
        Task<List<Endorsement>> GetByIdCompany(int idCompany);
    }
}
