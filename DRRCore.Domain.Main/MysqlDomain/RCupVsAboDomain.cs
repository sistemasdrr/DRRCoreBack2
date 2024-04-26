using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class RCupVsAboDomain : IRCupVsAboDomain
    {
        public readonly IRCupVsAboRepository _repository;
        public RCupVsAboDomain(IRCupVsAboRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<RCupVsAbo>> GetAllRCupVsAboAsync()
        {
            return await _repository.GetAllRCupVsAboAsync();
        }

        public async Task<RCupVsAbo> GetRCupVsAboByCodigoAsync(int codigo)
        {
            return await _repository.GetRCupVsAboByCodigoAsync(codigo);
        }
    }
}
