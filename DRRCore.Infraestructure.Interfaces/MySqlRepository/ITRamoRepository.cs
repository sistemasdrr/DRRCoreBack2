using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITRamoRepository
    {
        Task<TRamo> GetTRamoByCodigoAsync(string codigo);
        Task<List<TRamo>> GetAllTRamoAsync();
    }
}
