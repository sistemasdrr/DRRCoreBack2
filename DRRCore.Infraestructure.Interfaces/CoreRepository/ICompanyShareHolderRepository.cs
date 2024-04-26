using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyShareHolderRepository : IBaseRepository<CompanyShareHolder>
    {

        Task<List<CompanyShareHolder>> GetShareHoldersByIdCompany(int idCompany);
    }
}
