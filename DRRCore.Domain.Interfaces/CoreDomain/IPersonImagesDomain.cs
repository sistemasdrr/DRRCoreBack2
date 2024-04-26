using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonImagesDomain : IBaseDomain<PersonImage>
    {
        Task<int?> AddPersonImage(PersonImage obj, List<Traduction> traductions);
        Task<int?> UpdatePersonImage(PersonImage obj, List<Traduction> traductions);
        Task<PersonImage> GetByIdPerson(int idPerson);
    }
}
