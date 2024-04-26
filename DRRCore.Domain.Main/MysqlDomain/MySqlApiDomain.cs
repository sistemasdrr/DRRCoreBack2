using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class MySqlApiDomain : IMySqlApiDomain
    {
        private readonly IMySqlApiDomain _repository;
        public MySqlApiDomain(IMySqlApiDomain repository)
        {
            _repository = repository;
        }
        public async Task<REmpVsRep> DeleteRepComercialEmpresaAsync(string codigo)
        {
            return await _repository.DeleteRepComercialEmpresaAsync(codigo);
        }

        public async Task<List<TClasif>> GetAllClasifAsync()
        {
            return await _repository.GetAllClasifAsync();
        }

        public async Task<List<MPersona>> GetAllMPersonaAsync()
        {
            return await _repository.GetAllMPersonaAsync();
        }

        public async Task<List<TCalidad>> GetAllTCalidadAsync()
        {
            return await _repository.GetAllTCalidadAsync();
        }

        public async Task<List<TTemporalPersona>> GetAllTemporalPersonaAsync()
        {
            return await _repository.GetAllTemporalPersonaAsync();
        }

        public async Task<List<TJuridi>> GetAllTJuridiAsync()
        {
            return await _repository.GetAllTJuridiAsync();
        }

        public async Task<List<TPago>> GetAllTPagoAsync()
        {
            return await _repository.GetAllTPagoAsync();
        }

        public async Task<List<TPai>> GetAllTPaisAsync()
        {
            return await _repository.GetAllTPaisAsync();
        }

        public async Task<List<TRepCom>> GetAllTRepComAsync()
        {
            return await _repository.GetAllTRepComAsync();
        }

        public async Task<List<TSituacion>> GetAllTSituacionAsync()
        {
            return await _repository.GetAllTSituacionAsync();
        }

        public async Task<List<TTipoTramite>> GetAllTTipoTramiteAsync()
        {
            return await _repository.GetAllTTipoTramiteAsync();
        }

        public async Task<TClasif> GetClasifByCodigoAsync(string codigo)
        {
            return await _repository.GetClasifByCodigoAsync(codigo);
        }

        public async Task<MEmpresa> GetmEmpresaByCodigoAsync(string codigo)
        {
            return await _repository.GetmEmpresaByCodigoAsync(codigo);
        }

        public async Task<MPersona> GetMPersonaByCodigoAsync(string codigo)
        {
            return await _repository.GetMPersonaByCodigoAsync(codigo);
        }

        public async Task<RCupVsAbo> GetRCupVsAboByCodigoAsync(int codigo)
        {
            return await _repository.GetRCupVsAboByCodigoAsync(codigo);
        }

        public async Task<REmpVsAspLeg> GetRempByCodigoAsync(string codigo)
        {
            return await _repository.GetRempByCodigoAsync(codigo);
        }

        public async Task<REmpVsInfFin> GetREmpVsInfByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsInfByCodigoAsync(codigo);
        }

        public async Task<REmpVsRamNeg> GetREmpVsRamNegByCodigoAsync(string codigo)
        {
            return await _repository.GetREmpVsRamNegByCodigoAsync(codigo);
        }

        public async Task<RPerVsEr> GetRPerVsErByCodigoAsync(string codigo)
        {
            return await _repository.GetRPerVsErByCodigoAsync(codigo);
        }

        public async Task<TCalidad> GetTCalidadByCodigoAsync(string codigo)
        {
            return await _repository.GetTCalidadByCodigoAsync(codigo);
        }

        public async Task<TContinente> GetTContinenteByCodigoAsync(string codigo)
        {
            return await _repository.GetTContinenteByCodigoAsync(codigo);
        }

        public async Task<TCupon> GetTCuponByCodigoAsync(int codigo)
        {
            return await _repository.GetTCuponByCodigoAsync(codigo);
        }

        public async Task<TTemporalPersona> GetTemporalPersonaByCodigoAsync(string codigo)
        {
            return await _repository.GetTemporalPersonaByCodigoAsync(codigo);
        }

        public async Task<TJuridi> GetTJuridiByCodigoAsync(string codigo)
        {
            return await _repository.GetTJuridiByCodigoAsync(codigo);
        }

        public async Task<TPago> GetTPagoByCodigoAsync(string codigo)
        {
            return await _repository.GetTPagoByCodigoAsync(codigo);
        }

        public async Task<TPai> GetTPaiByCodigoAsync(string codigo)
        {
            return await _repository.GetTPaiByCodigoAsync(codigo);
        }

        public async Task<TRepCom> GetTRepComByCodigoAsync(string codigo)
        {
            return await _repository.GetTRepComByCodigoAsync(codigo);
        }

        public async Task<TSituacion> GetTSituacionByCodigoAsync(string codigo)
        {
            return await _repository.GetTSituacionByCodigoAsync(codigo);
        }

        public async Task<TTipoTramite> GetTTipoTramiteByCodigoAsync(string codigo)
        {
            return await _repository.GetTTipoTramiteByCodigoAsync(codigo);
        }
    }
}
