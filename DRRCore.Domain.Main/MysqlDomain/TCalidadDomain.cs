using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TCalidadDomain : ITCalidadDomain
    {
        public readonly ITCalidadRepository _repository;
        public TCalidadDomain(ITCalidadRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TCalidad>> GetAllTCalidadAsync()
        {
            return await _repository.GetAllTCalidadAsync();
        }

        public async Task<TCalidad> GetTCalidadByCodigoAsync(string codigo)
        {
            return await _repository.GetTCalidadByCodigoAsync(codigo);
        }
    }
}
