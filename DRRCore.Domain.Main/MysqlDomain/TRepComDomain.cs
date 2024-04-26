using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TRepComDomain : ITRepComDomain
    {
        public readonly ITRepComRepository _repository;
        public TRepComDomain(ITRepComRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TRepCom>> GetAllTRepComAsync()
        {
            return await _repository.GetAllTRepComAsync();
        }

        public async Task<TRepCom> GetTRepComByCodigoAsync(string codigo)
        {
            return await _repository.GetTRepComByCodigoAsync(codigo);
        }
    }
}
