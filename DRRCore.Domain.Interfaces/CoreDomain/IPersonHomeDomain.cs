using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonHomeDomain : IBaseDomain<PersonHome>
    {
        Task<int?> AddPersonHomeAsync(PersonHome personHome, List<Traduction> traductions);
        Task<int?> UpdatePersonHomeAsync(PersonHome personHome, List<Traduction> traductions);
        Task<PersonHome> GetByIdPersonAsync(int idPerson);
    }
}
