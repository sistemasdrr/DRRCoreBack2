using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonHistoryRepository : IBaseRepository<PersonHistory>
    {
        Task<int?> AddPersonHistoryAsync(PersonHistory obj, List<Traduction> traductions);
        Task<int?> UpdatePersonHistoryAsync(PersonHistory obj, List<Traduction> traductions);
        Task<PersonHistory> GetByIdPersonAsync(int idPerson);
    }
}
