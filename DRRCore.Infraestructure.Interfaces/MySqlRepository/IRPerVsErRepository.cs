using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IRPerVsErRepository
    {
        Task<RPerVsEr> GetRPerVsErByCodigoAsync(string codigo);
        Task<List<RPerVsEr>> GetAllRPerVsErAsync();
    }
}
