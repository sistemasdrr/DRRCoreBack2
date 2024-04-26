using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    internal class REmpVsInfFinDomain : IREmpVsInfFinDomain
    {
        public readonly IREmpVsInfFinRepository _repository;
        public REmpVsInfFinDomain(IREmpVsInfFinRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<REmpVsInfFin>> GetAllREmpVsInfAsync()
        {
            return await _repository.GetAllREmpVsInfAsync();
        }

        public async Task<REmpVsInfFin> GetREmpVsInfByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsInfByCodigoAsync(codigo);
        }
    }
}
