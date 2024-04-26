using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IMEmpresaRepository
    {
        Task<MEmpresa> GetmEmpresaByCodigoAsync(string codigo);
        Task<List<MEmpresa>> GetNotMigratedEmpresa();
        Task<TCabEmpAval> GetmEmpresaAvalByCodigoAsync(string codigo);
        Task<REmpVsAspLeg> GetmEmpresaAspLegByCodigoAsync(string codigo);
        Task<REmpVsRamNeg> GetmEmpresaRamoByCodigoAsync(string codigo);
        Task<REmpVsInfFin> GetmEmpresaFinanzasByCodigoAsync(string codigo);
        Task<REmpVsBa> GetmEmpresaBalanceByCodigoAsync(string codigo);
        Task<REmpVsB> GetmEmpresaBalanceSitByCodigoAsync(string codigo);
        Task<REmpVsRep> GetmEmpresaReputacionByCodigoAsync(string codigo);
        Task<List<REmpVsVenta>> GetmEmpresaHistVentByCodigoAsync(string codigo);
        Task<List<REmpVsImp>> GetmEmpresaImpByCodigoAsync(string codigo);
        Task<List<REmpVsExp>> GetmEmpresaExpByCodigoAsync(string codigo);
        Task<List<REmpVsProv>> GetmEmpresaProvByCodigoAsync(string codigo);
        Task<List<REmpVsProAcep>> GetmEmpresaMorComByCodigoAsync(string codigo);
        Task<List<REmpVsSbd>> GetmEmpresaEndBancByCodigoAsync(string codigo);
        Task<string> GetActividadesByCodigo(string codigo);
        Task<bool> MigrateEmpresa(string code);
        Task<bool> MigrateEmpresaAspLeg(string code);
        Task<bool> MigrateEmpresaRamo(string code);
        Task<bool> MigrateEmpresaFinanzas(string code);
        Task<List<MEmpresa>> GetNotMigratedEmpresa(int migra);
    }
}
