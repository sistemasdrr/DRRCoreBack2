using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TJuridiDomain : ITJuridiDomain
    {
        public readonly ITJuridiRepository _repository;
        public TJuridiDomain(ITJuridiRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TJuridi>> GetAllTJuridiAsync()
        {
            return await _repository.GetAllTJuridiAsync();
        }

        public async Task<TJuridi> GetTJuridiByCodigoAsync(string codigo)
        {
            return await _repository.GetTJuridiByCodigoAsync(codigo);
        }
    }
}
