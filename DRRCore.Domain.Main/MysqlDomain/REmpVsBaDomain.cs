using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class REmpVsBaDomain : IREmpVsBaDomain
    {
        public readonly IREmpVsBaRepository _repository;
        public REmpVsBaDomain(IREmpVsBaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<REmpVsBa>> GetAllREmpVsBaAsync()
        {
            return await _repository.GetAllREmpVsBaAsync();
        }

        public async Task<REmpVsBa> GetREmpVsBaByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsBaByCodigoAsync(codigo);
        }
    }
}
