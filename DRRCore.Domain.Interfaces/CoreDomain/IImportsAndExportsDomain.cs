using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IImportsAndExportsDomain : IBaseDomain<ImportsAndExport>
    {
        Task<List<ImportsAndExport>> GetImports(int idCompany);
        Task<List<ImportsAndExport>> GetExports(int idCompany);
    }
}
