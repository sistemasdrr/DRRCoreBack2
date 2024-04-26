using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITSituacionRepository
    {
        Task<TSituacion> GetTSituacionByCodigoAsync(string codigo);
        Task<List<TSituacion>> GetAllTSituacionAsync();
    }
}
