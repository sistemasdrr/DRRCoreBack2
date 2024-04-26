using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IREmpVsBaDomain
    {
        Task<REmpVsBa> GetREmpVsBaByCodigoAsync(string codigo);
        Task<List<REmpVsBa>> GetAllREmpVsBaAsync();
    }
}
