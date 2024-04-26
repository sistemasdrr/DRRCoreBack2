using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TContinenteDomain : ITContinenteDomain
    {
        public readonly ITContinenteRepository _repository;
        public TContinenteDomain(ITContinenteRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TContinente>> GetAllTContinenteAsync()
        {
            return await _repository.GetAllTContinenteAsync();
        }

        public async Task<TContinente> GetTContinenteByCodigoAsync(string codigo)
        {
            return await _repository.GetTContinenteByCodigoAsync(codigo);
        }
    }
}
