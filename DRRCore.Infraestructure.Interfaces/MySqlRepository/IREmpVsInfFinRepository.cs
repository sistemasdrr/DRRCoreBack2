using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IREmpVsInfFinRepository
    {
        Task<REmpVsInfFin> GetREmpVsInfByCodigoAsync(string codigo);
        Task<List<REmpVsInfFin>> GetAllREmpVsInfAsync();
    }
}
