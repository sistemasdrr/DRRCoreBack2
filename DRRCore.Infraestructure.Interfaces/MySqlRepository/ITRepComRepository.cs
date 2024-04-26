using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITRepComRepository
    {
        Task<TRepCom> GetTRepComByCodigoAsync(string codigo);
        Task<List<TRepCom>> GetAllTRepComAsync();
    }
}
