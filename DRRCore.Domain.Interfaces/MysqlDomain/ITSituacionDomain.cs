using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITSituacionDomain
    {
        Task<TSituacion> GetTSituacionByCodigoAsync(string codigo);
        Task<List<TSituacion>> GetAllTSituacionAsync();
    }
}
