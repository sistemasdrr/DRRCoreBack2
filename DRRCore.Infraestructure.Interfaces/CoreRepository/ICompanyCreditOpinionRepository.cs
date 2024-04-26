using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyCreditOpinionRepository : IBaseRepository<CompanyCreditOpinion>
    {
        Task<int> AddCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions);
        Task<int> UpdateCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions);
        Task<CompanyCreditOpinion> GetByIdCompany(int idCompany);
    }
}
