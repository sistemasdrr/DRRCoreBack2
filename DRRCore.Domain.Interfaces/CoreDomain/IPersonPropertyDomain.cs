using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonPropertyDomain: IBaseDomain<PersonProperty>
    {
        Task<int?> AddPersonPropertiesAsync(PersonProperty personProperty, List<Traduction> traductions);
        Task<int?> UpdatePersonPropertiesAsync(PersonProperty personProperty, List<Traduction> traductions);
        Task<PersonProperty> GetByIdPersonAsync(int idPerson);
    }
}
