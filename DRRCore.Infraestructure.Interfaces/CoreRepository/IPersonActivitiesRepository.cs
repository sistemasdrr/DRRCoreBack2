using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonActivitiesRepository : IBaseRepository<PersonActivity>
    {
        Task<int?> AddPersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions);
        Task<int?> UpdatePersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions);
        Task<PersonActivity> GetByIdPersonAsync(int idPerson);
    }
}
