using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IREmpVsRamNegRepository
    {
        Task<REmpVsRamNeg> GetREmpVsRamNegByCodigoAsync(string codigo);
        Task<List<REmpVsRamNeg>> GetAllREmpVsRamNegAsync();
    }
}
