using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonHomeRepository : IBaseRepository<PersonHome>
    {
        Task<int?> AddPersonHomeAsync(PersonHome personHome, List<Traduction> traductions);
        Task<int?> UpdatePersonHomeAsync(PersonHome personHome, List<Traduction> traductions);
        Task<PersonHome> GetByIdPersonAsync(int idPerson);
    }
}
