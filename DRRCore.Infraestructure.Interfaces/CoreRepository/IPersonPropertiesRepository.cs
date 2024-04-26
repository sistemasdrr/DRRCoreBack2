using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonPropertiesRepository : IBaseRepository<PersonProperty>
    {
        Task<int?> AddPersonPropertiesAsync(PersonProperty personProperty, List<Traduction> traductions);
        Task<int?> UpdatePersonPropertiesAsync(PersonProperty personProperty, List<Traduction> traductions);
        Task<PersonProperty> GetByIdPersonAsync(int idPerson);
    }
}
