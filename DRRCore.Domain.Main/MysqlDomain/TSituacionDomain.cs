using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TSituacionDomain : ITSituacionDomain
    {
        public readonly ITSituacionRepository _repository;
        public TSituacionDomain(ITSituacionRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TSituacion>> GetAllTSituacionAsync()
        {
            return await _repository.GetAllTSituacionAsync();
        }

        public async Task<TSituacion> GetTSituacionByCodigoAsync(string codigo)
        {
            return await _repository.GetTSituacionByCodigoAsync(codigo);
        }
    }
}
