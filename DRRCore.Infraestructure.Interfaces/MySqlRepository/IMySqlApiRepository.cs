using DRRCore.Domain.Entities.MYSQLContext;
namespace DRRCore.Infraestructure.Interfaces.MySqlRepository

{
    public interface IMySqlApiRepository
    {
        Task<MEmpresa> GetmEmpresaByCodigoAsync(string codigo);//
        Task<REmpVsAspLeg> GetRempByCodigoAsync(string codigo);//

        //Usp_ListarPersJuridicaEmpresa (PERSONERIA JURIDICA - BOTON ?)
        Task<TJuridi> GetTJuridiByCodigoAsync(string codigo);//
        Task<List<TJuridi>> GetAllTJuridiAsync();//
        Task<REmpVsRamNeg> GetREmpVsRamNegByCodigoAsync(string codigo);//
        Task<List<REmpVsRamNeg>> GetAllREmpVsRamNegAsync();//
        Task<RPerVsEr> GetRPerVsErByCodigoAsync(string codigo);//
        Task<List<RPerVsEr>> GetAllRPerVsErAsync();//

        //Usp_ListarSituacionEmpresa (SITUACION RUC - BOTON ?)
        Task<TSituacion> GetTSituacionByCodigoAsync(string codigo);//
        Task<List<TSituacion>> GetAllTSituacionAsync();//

        //Usp_ListarPais (BOTON ?)
        Task<List<TPai>> GetAllTPaisAsync();//
        Task<TPai> GetTPaiByCodigoAsync(string codigo);//
        Task<TContinente> GetTContinenteByCodigoAsync(string codigo);//
        Task<List<TContinente>> GetAllTContinenteAsync();//

        //Usp_ListarRepComercialEmpresa (BOTON REPUTACION)
        Task<TRepCom> GetTRepComByCodigoAsync(string codigo);//
        Task<List<TRepCom>> GetAllTRepComAsync();//

        // //Usp_MostrarHistoricoPedido (BOTON Ver Historico)
        Task<REmpVsInfFin> GetREmpVsInfByCodigoAsync(string codigo);//
        Task<List<REmpVsInfFin>> GetAllREmpVsInfAsync();//
        Task<RCupVsAbo> GetRCupVsAboByCodigoAsync(int codigo);//
        Task<List<RCupVsAbo>> GetAllRCupVsAboAsync();//
        Task<TCupon> GetTCuponByCodigoAsync(int codigo);//
        Task<List<TCupon>> GetAllTCuponAsync();//

        //Usp_ListarTipoTramite (TIPO INFORME - BOTON ?)
        Task<TTipoTramite> GetTTipoTramiteByCodigoAsync(string codigo);//
        Task<List<TTipoTramite>> GetAllTTipoTramiteAsync();//

        //Usp_ListarCalidadInforme (CALIDAD INFORME - BOTON ?)
        Task<TCalidad> GetTCalidadByCodigoAsync(string codigo);//
        Task<List<TCalidad>> GetAllTCalidadAsync();//

        //Usp_TraducirPeComRep (TRADUCIR COMENTARIO DE REPUTACION)
        Task<MPersona> GetMPersonaByCodigoAsync(string codigo);//
        Task<List<MPersona>> GetAllMPersonaAsync();//
        // //Usp_TraducirPePrensa (TRADUCIR PRENSA)
        Task<TTemporalPersona> GetTemporalPersonaByCodigoAsync(string codigo);//
        Task<List<TTemporalPersona>> GetAllTemporalPersonaAsync();//

        //Usp_ListarCalificacionEmpresa (BOTON RIESGO CREDITICIO)
        Task<TClasif> GetClasifByCodigoAsync(string codigo);//
        Task<List<TClasif>> GetAllClasifAsync();//

        //Usp_ListarPagosEmpresa (BOTON POLTICA DE PAGOS)
        Task<TPago> GetTPagoByCodigoAsync(string codigo);//
        Task<List<TPago>> GetAllTPagoAsync();//

        //Usp_EliminarRepComercialEmpresa (BOTON -)
        Task<bool> DeleteRepComercialEmpresaAsync(string codigo);
    }
}
