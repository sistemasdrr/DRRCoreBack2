using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonActivitiesDomain : IBaseDomain<PersonActivity>
    {
        Task<int?> AddPersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions);
        Task<int?> UpdatePersonActivitiesAsync(PersonActivity personActivity, List<Traduction> traductions);
        Task<PersonActivity> GetByIdPersonAsync(int idPerson);
    }
}
