using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TSectorDomain : ITSectorDomain
    {
        public readonly ITSectorRepository _repository;
        public TSectorDomain(ITSectorRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TSector>> GetAllTSectorAsync()
        {
            return await _repository.GetAllTSectorAsync();
        }

        public async Task<TSector> GetTSectorByCodigoAsync(string codigo)
        {
            return await _repository.GetTSectorByCodigoAsync(codigo);
        }
    }
}
