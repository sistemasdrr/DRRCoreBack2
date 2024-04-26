using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TClasifDomain : ITClasifDomain
    {
        public readonly ITClasifRepository _repository;
        public TClasifDomain(ITClasifRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TClasif>> GetAllClasifAsync()
        {
            return await _repository.GetAllClasifAsync();
        }

        public async Task<TClasif> GetClasifByCodigoAsync(string codigo)
        {
            return await _repository.GetClasifByCodigoAsync(codigo);
        }
    }
}
