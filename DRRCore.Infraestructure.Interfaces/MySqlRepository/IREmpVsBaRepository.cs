using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IREmpVsBaRepository
    {
        Task<REmpVsBa> GetREmpVsBaByCodigoAsync(string codigo); 
        Task<List<REmpVsBa>> GetAllREmpVsBaAsync();
    }
}
