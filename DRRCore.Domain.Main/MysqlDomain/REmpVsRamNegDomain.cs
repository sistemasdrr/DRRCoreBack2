using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class REmpVsRamNegDomain : IREmpVsRamNegDomain
    {
        public readonly IREmpVsRamNegRepository _repository;
        public REmpVsRamNegDomain(IREmpVsRamNegRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<REmpVsRamNeg>> GetAllREmpVsRamNegAsync()
        {
            return await _repository.GetAllREmpVsRamNegAsync();
        }

        public async Task<REmpVsRamNeg> GetREmpVsRamNegByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsRamNegByCodigoAsync(codigo);
        }
    }
}
