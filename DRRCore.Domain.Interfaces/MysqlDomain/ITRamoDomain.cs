using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITRamoDomain
    {
        Task<TRamo> GetTRamoByCodigoAsync(string codigo);
        Task<List<TRamo>> GetAllTRamoAsync();
    }
}
