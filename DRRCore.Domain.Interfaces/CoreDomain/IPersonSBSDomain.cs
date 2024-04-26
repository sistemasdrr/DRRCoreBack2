using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonSBSDomain : IBaseDomain<PersonSb>
    {
        Task<int?> AddPersonSBS(PersonSb obj, List<Traduction> traductions);
        Task<int?> UpdatePersonSBS(PersonSb obj, List<Traduction> traductions);
        Task<PersonSb> GetByIdPerson(int idPerson);
    }
}
