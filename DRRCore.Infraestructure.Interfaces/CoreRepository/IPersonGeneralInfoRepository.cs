using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonGeneralInfoRepository : IBaseRepository<PersonGeneralInformation>
    {
        Task<int?> AddPersonGeneralInfoAsync(PersonGeneralInformation obj, List<Traduction> traductions);
        Task<int?> UpdatePersonGeneralInfoAsync(PersonGeneralInformation obj, List<Traduction> traductions);
        Task<PersonGeneralInformation> GetByIdPersonAsync(int idPerson);
    }
}
