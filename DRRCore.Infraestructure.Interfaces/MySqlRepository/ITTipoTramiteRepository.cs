using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITTipoTramiteRepository
    {
        Task<TTipoTramite> GetTTipoTramiteByCodigoAsync(string codigo);
        Task<List<TTipoTramite>> GetAllTTipoTramiteAsync();
    }
}
