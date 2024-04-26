using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IREmpVsRamNegDomain
    {
        Task<REmpVsRamNeg> GetREmpVsRamNegByCodigoAsync(string codigo);
        Task<List<REmpVsRamNeg>> GetAllREmpVsRamNegAsync();
    }
}
