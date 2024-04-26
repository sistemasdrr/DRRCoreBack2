using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyImagesRepository : IBaseRepository<CompanyImage>
    {
        Task<int> AddCompanyImage(CompanyImage obj, List<Traduction> traductions);
        Task<int> UpdateCompanyImage(CompanyImage obj, List<Traduction> traductions);
        Task<CompanyImage> GetByIdCompany(int idCompany);

    }
}
