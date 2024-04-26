using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IREmpVsAspLegRepository
    {
        Task<REmpVsAspLeg> GetREmpVsAspLegByCodigoAsync(string codigo);
        Task<List<REmpVsAspLeg>> GetAllREmpVsAspLegAsync();
    }
}
