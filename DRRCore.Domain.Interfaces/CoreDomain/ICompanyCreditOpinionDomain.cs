using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanyCreditOpinionDomain : IBaseDomain<CompanyCreditOpinion>
    {
        Task<int> AddCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions);
        Task<int> UpdateCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions);
        Task<CompanyCreditOpinion> GetByIdCompany(int idCompany);
    }
}
