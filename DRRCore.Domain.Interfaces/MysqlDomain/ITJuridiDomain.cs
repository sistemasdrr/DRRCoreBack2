using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITJuridiDomain
    {
        Task<List<TJuridi>> GetAllTJuridiAsync();
        Task<TJuridi> GetTJuridiByCodigoAsync(string codigo);
    }
}
