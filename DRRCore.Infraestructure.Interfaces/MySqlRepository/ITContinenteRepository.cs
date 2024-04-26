using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITContinenteRepository
    {
        Task<TContinente> GetTContinenteByCodigoAsync(string codigo);
        Task<List<TContinente>> GetAllTContinenteAsync();
    }
}
