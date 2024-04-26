using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TTemporalPersonaDomain : ITTemporalPersonaDomain
    {
        public readonly ITTemporalPersonaRepository _repository;
        public TTemporalPersonaDomain(ITTemporalPersonaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TTemporalPersona>> GetAllTemporalPersonaAsync()
        {
            return await _repository.GetAllTemporalPersonaAsync();
        }

        public async Task<TTemporalPersona> GetTemporalPersonaByCodigoAsync(string codigo)
        {
            return await _repository.GetTemporalPersonaByCodigoAsync(codigo);
        }
    }
}
