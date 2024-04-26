using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TPagoDomain : ITPagoDomain
    {
        public readonly ITPagoRepository _repository;
        public TPagoDomain(ITPagoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TPago>> GetAllTPagoAsync()
        {
            return await _repository.GetAllTPagoAsync();
        }

        public async Task<TPago> GetTPagoByCodigoAsync(string codigo)
        {
            return await _repository.GetTPagoByCodigoAsync(codigo);
        }
    }
}
