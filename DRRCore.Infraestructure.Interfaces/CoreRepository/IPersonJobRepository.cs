using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonJobRepository : IBaseRepository<PersonJob>
    {
        Task<int?> AddPersonJobAsync(PersonJob obj, List<Traduction> traductions);
        Task<int?> UpdatePersonJobAsync(PersonJob obj, List<Traduction> traductions);
        Task<PersonJob> GetByIdPersonAsync(int idPerson);
    }
}
