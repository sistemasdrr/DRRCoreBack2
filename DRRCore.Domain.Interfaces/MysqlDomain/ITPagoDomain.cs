using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITPagoDomain
    {
        Task<TPago> GetTPagoByCodigoAsync(string codigo);
        Task<List<TPago>> GetAllTPagoAsync();
    }
}
