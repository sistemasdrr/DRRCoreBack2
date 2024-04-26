using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonSBSRepository : IBaseRepository<PersonSb>
    {
        Task<int?> AddPersonSBS(PersonSb obj, List<Traduction> traductions);
        Task<int?> UpdatePersonSBS(PersonSb obj, List<Traduction> traductions);
        Task<PersonSb> GetByIdPerson(int idPerson);
    }
}
