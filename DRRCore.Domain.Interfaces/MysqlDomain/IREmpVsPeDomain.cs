using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IREmpVsPeDomain
    {
        Task<REmpVsPe> GetREmpVsPeByCodigoAsync(string codigo);
        Task<List<REmpVsPe>> GetAllREmpVsPeAsync();
    }
}
