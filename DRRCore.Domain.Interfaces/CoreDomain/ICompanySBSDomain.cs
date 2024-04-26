using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICompanySBSDomain : IBaseDomain<CompanySb>
    {
        Task<int> AddCompanySBS(CompanySb companySb, List<Traduction> traductions);
        Task<int> UpdateCompanySBS(CompanySb companySb, List<Traduction> traductions);
        Task<CompanySb> GetByIdCompany(int idCompany);
        Task<bool> NewComercialReferences(int idCompany, int? idTicket);
    }
}
