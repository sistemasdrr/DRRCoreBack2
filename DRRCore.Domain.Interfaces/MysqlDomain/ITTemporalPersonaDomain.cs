using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITTemporalPersonaDomain
    {
        Task<TTemporalPersona> GetTemporalPersonaByCodigoAsync(string codigo);
        Task<List<TTemporalPersona>> GetAllTemporalPersonaAsync();
    }
}
