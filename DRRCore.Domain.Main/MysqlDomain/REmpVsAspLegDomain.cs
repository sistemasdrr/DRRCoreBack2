using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class REmpVsAspLegDomain : IREmpVsAspLegDomain
    {
        public readonly IREmpVsAspLegRepository _repository;
        public REmpVsAspLegDomain(IREmpVsAspLegRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<REmpVsAspLeg>> GetAllREmpVsAspLegAsync()
        {
            return await _repository.GetAllREmpVsAspLegAsync();
        }

        public async Task<REmpVsAspLeg> GetREmpVsAspLegByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsAspLegByCodigoAsync(codigo);
        }
    }
}
