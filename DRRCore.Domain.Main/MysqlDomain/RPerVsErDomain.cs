using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class RPerVsErDomain : IRPerVsErDomain
    {
        public readonly IRPerVsErRepository _repository;
        public RPerVsErDomain(IRPerVsErRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<RPerVsEr>> GetAllRPerVsErAsync()
        {
            return await _repository.GetAllRPerVsErAsync();
        }

        public async Task<RPerVsEr> GetRPerVsErByCodigoAsync(string codigo)
        {
            return await _repository.GetRPerVsErByCodigoAsync(codigo);
        }
    }
}
