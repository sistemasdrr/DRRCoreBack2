using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITRamoARepository
    {
        Task<TRamoA> GetTRamoAByCodigoAsync(string codigo);
        Task<List<TRamoA>> GetAllTRamoAAsync();
    }
}
