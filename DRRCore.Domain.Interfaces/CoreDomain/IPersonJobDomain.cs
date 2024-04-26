using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonJobDomain : IBaseDomain<PersonJob>
    {
        Task<int?> AddPersonJobAsync(PersonJob obj, List<Traduction> traductions);
        Task<int?> UpdatePersonJobAsync(PersonJob obj, List<Traduction> traductions);
        Task<PersonJob> GetByIdPersonAsync(int idPerson);
    }
}
