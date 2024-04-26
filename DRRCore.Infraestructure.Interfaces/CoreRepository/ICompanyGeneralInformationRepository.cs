using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyGeneralInformationRepository: IBaseRepository<CompanyGeneralInformation>
    {
        Task<int> AddGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions);
        Task<int> UpdateGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions);
        Task<CompanyGeneralInformation> GetByIdCompany(int idCompany);
    }
}
