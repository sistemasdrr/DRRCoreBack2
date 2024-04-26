using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITCalidadRepository
    {
        Task<TCalidad> GetTCalidadByCodigoAsync(string codigo);
        Task<List<TCalidad>> GetAllTCalidadAsync();
    }
}
