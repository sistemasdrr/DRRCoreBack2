using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Infraestructure.Interfaces.Repository
{
    public interface ICompanyImageRepository : IBaseRepository<CompanyImage>
    {
        Task<int?> AddCompanyImage(CompanyImage obj);
        Task<CompanyImage> GetImagesByIdCompany(int idCompany);
        Task<bool> UpdateImageCompany(int idCompany, int number, string? base64, string? description, string? descriptionEng, bool? print);
    }
}
