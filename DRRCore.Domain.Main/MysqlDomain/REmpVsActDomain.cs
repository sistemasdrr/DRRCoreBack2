using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class REmpVsActDomain : IREmpVsActDomain
    {
        public readonly IREmpVsActRepository _repository;
        public REmpVsActDomain(IREmpVsActRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<REmpVsAct>> GetAllREmpVsActAsync()
        {
            return await _repository.GetAllREmpVsActAsync();
        }

        public async Task<REmpVsAct> GetREmpVsActByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsActByCodigoAsync(codigo);
        }
    }
}
