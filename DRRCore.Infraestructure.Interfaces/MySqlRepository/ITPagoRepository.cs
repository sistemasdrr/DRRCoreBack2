using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITPagoRepository
    {
        Task<TPago> GetTPagoByCodigoAsync(string codigo);
        Task<List<TPago>> GetAllTPagoAsync();
    }
}
