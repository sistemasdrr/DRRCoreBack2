using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITSectorRepository
    {
        Task<TSector> GetTSectorByCodigoAsync(string codigo);
        Task<List<TSector>> GetAllTSectorAsync();
    }
}
