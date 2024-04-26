using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IPersonGeneralInfoDomain : IBaseDomain<PersonGeneralInformation>
    {
        Task<int?> AddPersonGeneralInfoAsync(PersonGeneralInformation obj, List<Traduction> traductions);
        Task<int?> UpdatePersonGeneralInfoAsync(PersonGeneralInformation obj, List<Traduction> traductions);
        Task<PersonGeneralInformation> GetByIdPersonAsync(int idPerson);
    }
}
