using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITJuridiRepository
    {
        Task<List<TJuridi>> GetAllTJuridiAsync();
        Task<TJuridi> GetTJuridiByCodigoAsync(string codigo);
    }
}
