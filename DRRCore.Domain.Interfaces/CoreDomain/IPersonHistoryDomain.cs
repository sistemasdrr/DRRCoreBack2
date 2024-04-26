using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonHistoryDomain : IBaseDomain<PersonHistory>
    {
        Task<int?> AddPersonHistoryAsync(PersonHistory obj, List<Traduction> traductions);
        Task<int?> UpdatePersonHistoryAsync(PersonHistory obj, List<Traduction> traductions);
        Task<PersonHistory> GetByIdPersonAsync(int idPerson);
    }
}
