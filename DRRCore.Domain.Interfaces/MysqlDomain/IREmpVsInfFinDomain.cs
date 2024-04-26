using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IREmpVsInfFinDomain
    {
        Task<REmpVsInfFin> GetREmpVsInfByCodigoAsync(string codigo);
        Task<List<REmpVsInfFin>> GetAllREmpVsInfAsync();
    }
}
