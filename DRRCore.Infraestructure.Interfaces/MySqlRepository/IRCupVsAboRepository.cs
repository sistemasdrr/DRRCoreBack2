using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IRCupVsAboRepository
    {
        Task<RCupVsAbo> GetRCupVsAboByCodigoAsync(int codigo);
        Task<List<RCupVsAbo>> GetAllRCupVsAboAsync();
    }
}
