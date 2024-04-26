using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonPhotoDomain : IBaseDomain<PhotoPerson>
    {
        Task<List<PhotoPerson>> GetPhotosByIdPersonAsync(int idPerson);
    }
}
