using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IRCupVsAboDomain
    {
        Task<RCupVsAbo> GetRCupVsAboByCodigoAsync(int codigo);
        Task<List<RCupVsAbo>> GetAllRCupVsAboAsync();
    }
}
