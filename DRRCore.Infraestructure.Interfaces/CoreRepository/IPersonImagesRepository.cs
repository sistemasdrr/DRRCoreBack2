using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonImagesRepository : IBaseRepository<PersonImage>
    {
        Task<int?> AddPersonImage(PersonImage obj, List<Traduction> traductions);
        Task<int?> UpdatePersonImage(PersonImage obj, List<Traduction> traductions);
        Task<PersonImage> GetByIdPerson(int idPerson);
    }
}
