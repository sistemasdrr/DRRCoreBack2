using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class MEmpresaDomain : IMEmpresaDomain
    {
        private readonly IMEmpresaRepository _repository;

        public MEmpresaDomain(IMEmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetActividadesByCodigo(string codigo)
        {
           return await _repository.GetActividadesByCodigo(codigo);
        }

        public async Task<REmpVsAspLeg> GetmEmpresaAspLegByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaAspLegByCodigoAsync(codigo);
        }

        public async Task<TCabEmpAval> GetmEmpresaAvalByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaAvalByCodigoAsync(codigo);
        }

        public async Task<REmpVsBa> GetmEmpresaBalanceByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaBalanceByCodigoAsync(codigo);
        }

        public async Task<REmpVsB> GetmEmpresaBalanceSitByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaBalanceSitByCodigoAsync(codigo);
        }

        public async Task<MEmpresa> GetmEmpresaByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaByCodigoAsync(codigo);
        }

        public async Task<List<REmpVsSbd>> GetmEmpresaEndBancByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaEndBancByCodigoAsync(codigo);
        }

        public async Task<List<REmpVsExp>> GetmEmpresaExpByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaExpByCodigoAsync(codigo);
        }

        public async Task<REmpVsInfFin> GetmEmpresaFinanzasByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaFinanzasByCodigoAsync(codigo);
        }

        public async Task<List<REmpVsVenta>> GetmEmpresaHistVentByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaHistVentByCodigoAsync(codigo);
        }

        public async Task<List<REmpVsImp>> GetmEmpresaImpByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaImpByCodigoAsync(codigo);
        }

        public async Task<List<REmpVsProAcep>> GetmEmpresaMorComByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaMorComByCodigoAsync(codigo);
        }

        public async Task<List<REmpVsProv>> GetmEmpresaProvByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaProvByCodigoAsync(codigo);
        }

        public async Task<REmpVsRamNeg> GetmEmpresaRamoByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaRamoByCodigoAsync(codigo);
        }

        public async Task<REmpVsRep> GetmEmpresaReputacionByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaReputacionByCodigoAsync(codigo);
        }

        public async Task<List<MEmpresa>> GetNotMigratedEmpresa()
        {
            return await _repository.GetNotMigratedEmpresa();
        }
        public async Task<List<MEmpresa>> GetNotMigratedEmpresa(int migra)
        {
            return await _repository.GetNotMigratedEmpresa(migra);
        }


        public async Task<bool> MigrateEmpresa(string code)
        {
            return await _repository.MigrateEmpresa(code);
        }

        public async Task<bool> MigrateEmpresaAspLeg(string code)
        {
            return await _repository.MigrateEmpresaAspLeg(code);
        }

        public async Task<bool> MigrateEmpresaFinanzas(string code)
        {
            return await _repository.MigrateEmpresaFinanzas(code);
        }

        public async Task<bool> MigrateEmpresaRamo(string code)
        {
            return await _repository.MigrateEmpresaAspLeg(code);
        }
    }
}
