using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITCalidadDomain
    {
        Task<TCalidad> GetTCalidadByCodigoAsync(string codigo);
        Task<List<TCalidad>> GetAllTCalidadAsync();
    }
}
