using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IImportsAndExportsRepository : IBaseRepository<ImportsAndExport>
    {
        Task<List<ImportsAndExport>> GetImports(int idCompany);
        Task<List<ImportsAndExport>> GetExports(int idCompany);
    }
}
