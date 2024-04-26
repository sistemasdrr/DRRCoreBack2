using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IREmpVsAspLegDomain
    {
        Task<REmpVsAspLeg> GetREmpVsAspLegByCodigoAsync(string codigo);
        Task<List<REmpVsAspLeg>> GetAllREmpVsAspLegAsync();
    }
}
