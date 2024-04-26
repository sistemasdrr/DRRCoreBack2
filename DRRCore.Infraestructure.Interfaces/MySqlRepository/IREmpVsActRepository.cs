using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IREmpVsActRepository
    {
        Task<REmpVsAct> GetREmpVsActByCodigoAsync(string codigo);
        Task<List<REmpVsAct>> GetAllREmpVsActAsync();
    }
}
