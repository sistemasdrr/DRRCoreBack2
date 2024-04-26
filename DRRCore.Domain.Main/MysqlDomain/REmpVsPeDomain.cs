using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class REmpVsPeDomain : IREmpVsPeDomain
    {
        public readonly IREmpVsPeRepository _repository;
        public REmpVsPeDomain(IREmpVsPeRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<REmpVsPe>> GetAllREmpVsPeAsync()
        {
            return await _repository.GetAllREmpVsPeAsync();
        }

        public async Task<REmpVsPe> GetREmpVsPeByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsPeByCodigoAsync(codigo);
        }
    }
}
