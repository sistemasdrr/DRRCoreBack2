using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonPhotoRepository : IBaseRepository<PhotoPerson>
    {
        Task<List<PhotoPerson>> GetPhotosByIdPersonAsync(int idPerson);
    }
}
