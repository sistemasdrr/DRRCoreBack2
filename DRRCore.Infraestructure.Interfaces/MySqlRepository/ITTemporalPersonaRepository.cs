using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITTemporalPersonaRepository
    {
        // //Usp_TraducirPePrensa (TRADUCIR PRENSA)
        Task<TTemporalPersona> GetTemporalPersonaByCodigoAsync(string codigo);
        Task<List<TTemporalPersona>> GetAllTemporalPersonaAsync();
    }
}
