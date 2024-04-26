using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITTipoTramiteDomain
    {
        Task<TTipoTramite> GetTTipoTramiteByCodigoAsync(string codigo);
        Task<List<TTipoTramite>> GetAllTTipoTramiteAsync();
    }
}
