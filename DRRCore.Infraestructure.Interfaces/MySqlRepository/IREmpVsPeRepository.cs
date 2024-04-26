using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IREmpVsPeRepository
    {
        Task<REmpVsPe> GetREmpVsPeByCodigoAsync(string codigo);
        Task<List<REmpVsPe>> GetAllREmpVsPeAsync();
    }
}
