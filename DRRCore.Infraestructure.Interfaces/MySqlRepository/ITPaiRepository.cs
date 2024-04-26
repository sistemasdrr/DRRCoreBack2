using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITPaiRepository
    {
        Task<List<TPai>> GetAllTPaisAsync();
        Task<TPai> GetTPaiByCodigoAsync(string codigo);
    }
}
