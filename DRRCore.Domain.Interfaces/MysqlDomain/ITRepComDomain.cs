using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITRepComDomain
    {
        Task<TRepCom> GetTRepComByCodigoAsync(string codigo);
        Task<List<TRepCom>> GetAllTRepComAsync();
    }
}
