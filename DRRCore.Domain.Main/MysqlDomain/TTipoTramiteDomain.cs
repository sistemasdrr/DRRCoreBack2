using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TTipoTramiteDomain : ITTipoTramiteDomain
    {
        public readonly ITTipoTramiteRepository _repository;
        public TTipoTramiteDomain(ITTipoTramiteRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TTipoTramite>> GetAllTTipoTramiteAsync()
        {
            return await _repository.GetAllTTipoTramiteAsync();
        }

        public async Task<TTipoTramite> GetTTipoTramiteByCodigoAsync(string codigo)
        {
            return await _repository.GetTTipoTramiteByCodigoAsync(codigo);
        }
    }
}
