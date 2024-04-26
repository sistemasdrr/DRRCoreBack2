using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IMPersonaDomain
    {
        Task<MPersona> GetMPersonaByCodigoAsync(string codigo);
        Task<List<MPersona>> GetAllMPersonaAsync();
        Task<MPersona> GetmPersonaByCodigoAsync(string codigo);
        Task<List<MPersona>> GetNotMigratedPersona();
        Task<RPerVsRep> GetmPersonaReputacionByCodigoAsync(string codigo);
        Task<RPerVsTrab> GetmPersonaTrabajoByCodigoAsync(string codigo);
        Task<List<RPerVsProv>> GetmPersonaProvByCodigoAsync(string codigo);
        Task<List<RPerVsProAcep>> GetmPersonaMorComByCodigoAsync(string codigo);
        Task<List<RPerVsSbd>> GetmPersonaEndBancByCodigoAsync(string codigo);
        Task<bool> MigratePersona(string codigo);
    }
}
