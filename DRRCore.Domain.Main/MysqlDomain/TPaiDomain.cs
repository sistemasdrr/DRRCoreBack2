using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TPaiDomain : ITPaiDomain
    {
        public readonly ITPaiRepository _repository;
        public TPaiDomain(ITPaiRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TPai>> GetAllTPaisAsync()
        {
            return await _repository.GetAllTPaisAsync();
        }

        public async Task<TPai> GetTPaiByCodigoAsync(string codigo)
        {
            return await _repository.GetTPaiByCodigoAsync(codigo);
        }
    }
}
