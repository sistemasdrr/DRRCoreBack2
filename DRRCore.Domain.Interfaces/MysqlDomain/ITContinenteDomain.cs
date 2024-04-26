using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITContinenteDomain
    {
        Task<TContinente> GetTContinenteByCodigoAsync(string codigo);
        Task<List<TContinente>> GetAllTContinenteAsync();
    }
}
