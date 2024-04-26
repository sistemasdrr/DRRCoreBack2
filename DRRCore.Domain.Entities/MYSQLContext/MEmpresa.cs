using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MEmpresa
{
    /// <summary>
    /// Código Interno de la Empresa PRINCIPAL
    /// </summary>
    public string EmCodigo { get; set; } = null!;

    /// <summary>
    /// Si es Activo 1 y se elimino es 2
    /// </summary>
    public int? EmActivo { get; set; }

    /// <summary>
    /// S-&gt;Va al Online   No-&gt;No va
    /// </summary>
    public string? EmOnline { get; set; }

    public string? EmNombre { get; set; }

    /// <summary>
    /// Nombre Correcto Si o No
    /// </summary>
    public string? EmNomcrr { get; set; }

    /// <summary>
    /// Identificador de Informe
    /// </summary>
    public string? EmLogico { get; set; }

    /// <summary>
    /// Nombre Solicitado
    /// </summary>
    public string? EmNomsol { get; set; }

    /// <summary>
    /// Tipo de Personería (Natural/Con Negocio)
    /// </summary>
    public int? EmTipper { get; set; }

    /// <summary>
    /// Fecha del Informe
    /// </summary>
    public DateTime? EmFecinf { get; set; }

    /// <summary>
    /// Fecha de Despacho
    /// </summary>
    public DateTime? EmFecdes { get; set; }

    /// <summary>
    /// Fecha de Traducción
    /// </summary>
    public DateTime? EmFectra { get; set; }

    /// <summary>
    /// Fecha de la Ultima Actualizacion
    /// </summary>
    public DateTime? EmFecact { get; set; }

    /// <summary>
    /// Fecha de Eliminación
    /// </summary>
    public DateTime? EmFeceli { get; set; }

    /// <summary>
    /// Usuario que elimino
    /// </summary>
    public string? EmUsueli { get; set; }

    /// <summary>
    /// Motivo de eliminación
    /// </summary>
    public string? EmMoteli { get; set; }

    /// <summary>
    /// Manera de Despacho (02Definitiva/03Preliminar)&lt;= tConGen
    /// </summary>
    public string? EmEstado { get; set; }

    public string? EmSiglas { get; set; }

    public string? EmDirecc { get; set; }

    public string? EmTipvia { get; set; }

    public string? EmNomvia { get; set; }

    public string? EmPiso { get; set; }

    public string? EmDistri { get; set; }

    public string? EmCiudad { get; set; }

    public string? EmDepart { get; set; }

    public string? EmCodpos { get; set; }

    public string? PaiCodigo { get; set; }

    public string? EmPrftlf { get; set; }

    public string? EmTelef1 { get; set; }

    public string? EmPrffax { get; set; }

    public string? EmFax { get; set; }

    public string? EmAnobal { get; set; }

    public string? EmEmail { get; set; }

    public string? EmPagweb { get; set; }

    /// <summary>
    /// Comentario de Reputación
    /// </summary>
    public string? EmComrep { get; set; }

    public string? EmComrepIng { get; set; }

    /// <summary>
    /// Comentario de Identificación
    /// </summary>
    public string? EmComide { get; set; }

    public string? EmComideIng { get; set; }

    /// <summary>
    /// Personería Jurídica (Código)&lt;= tJuridi.Ju_Codigo
    /// </summary>
    public string? JuCodigo { get; set; }

    public string? EmAnofun { get; set; }

    /// <summary>
    /// Código de la Situacion del la Empresa &lt;=tConGen
    /// </summary>
    public string? SitCodigo { get; set; }

    public string? EmRegtri { get; set; }

    /// <summary>
    /// Prensa Observ. General Imprime si no hay Opinón de Crédito
    /// </summary>
    public string? EmPrensa { get; set; }

    public string? EmPrensaIng { get; set; }

    /// <summary>
    /// Prensa Seleccionable
    /// </summary>
    public string? EmPrensasel { get; set; }

    /// <summary>
    /// Prensa Seleccionada en Ingles
    /// </summary>
    public string? EmPrensaselIng { get; set; }

    /// <summary>
    /// Indicador Log de Prensa (Em_ObsGen)
    /// </summary>
    public int? EmLogpre { get; set; }

    /// <summary>
    /// Código de Clasificación &lt;=TClasif
    /// </summary>
    public string? CrCodigo { get; set; }

    public string? EmRating { get; set; }

    /// <summary>
    /// Fecha de Inicio del Registro
    /// </summary>
    public DateTime? EmFecini { get; set; }

    /// <summary>
    /// Fecha de ultima modificación
    /// </summary>
    public DateTime? EmFecmod { get; set; }

    /// <summary>
    /// Usuario del Sistema
    /// </summary>
    public string? EmUsuario { get; set; }

    /// <summary>
    /// Código de Tipo de Pago (Ver rEmpVsPa)
    /// </summary>
    public string? PaCodigo { get; set; }

    /// <summary>
    /// Digitadora
    /// </summary>
    public string? PerCoddig { get; set; }

    /// <summary>
    /// Traductora
    /// </summary>
    public string? PerCodtra { get; set; }

    /// <summary>
    /// Referencistas
    /// </summary>
    public string? PerCodref { get; set; }

    /// <summary>
    /// Fecha de la Referencias
    /// </summary>
    public DateTime? EmFecref { get; set; }

    /// <summary>
    /// Tipo de Idioma/Traducción
    /// </summary>
    public int? IdiCodigo { get; set; }

    /// <summary>
    /// Segundo Teléfono
    /// </summary>
    public string? EmTelef2 { get; set; }

    /// <summary>
    /// Indicador Log de Aspectos Legales
    /// </summary>
    public int? EmLaspleg { get; set; }

    /// <summary>
    /// Indicador Log de Ramo de Negocios
    /// </summary>
    public int? EmLramneg { get; set; }

    /// <summary>
    /// Indicador Log de Información Financiera
    /// </summary>
    public int? EmLinffin { get; set; }

    /// <summary>
    /// Indicador Log de Balances
    /// </summary>
    public int? EmLbalanc { get; set; }

    /// <summary>
    /// Indicador Log de Pagos y Bancos
    /// </summary>
    public int? EmLpagban { get; set; }

    /// <summary>
    /// Indicador Log de Datos Generales
    /// </summary>
    public int? EmLdatgen { get; set; }

    /// <summary>
    /// Si hay o no Balance Situacional 0=No 1=Si
    /// </summary>
    public int? EmBalsit { get; set; }

    /// <summary>
    /// Si hay o no Balance General 0=No 1=Si
    /// </summary>
    public int? EmBalgen { get; set; }

    /// <summary>
    /// Presidente (Ficha Resumen)
    /// </summary>
    public string? EmPresid { get; set; }

    /// <summary>
    /// Principal Ejecutivo (Ficha Resumen)
    /// </summary>
    public string? EmPrinci { get; set; }

    /// <summary>
    /// Cargo del Principal Ejecutivo (Ficha Resumen)
    /// </summary>
    public string? EmPrinciCargo { get; set; }

    /// <summary>
    /// Código de Tendencia =&gt; tTenden
    /// </summary>
    public string? TdCodigo { get; set; }

    public int? EmFoto { get; set; }

    public string EmInfgenrtf { get; set; } = null!;

    /// <summary>
    /// Comentario de Proveedores
    /// </summary>
    public string? EmComprov { get; set; }

    public string? EmComprovIng { get; set; }

    /// <summary>
    /// Comentario de Litigios
    /// </summary>
    public string? EmComlit { get; set; }

    public string? EmComlitIng { get; set; }

    /// <summary>
    /// Check para ver si se agrega la frase o no
    /// </summary>
    public string? EmChkBanco { get; set; }

    /// <summary>
    /// Comentarios de Banqueros
    /// </summary>
    public string? EmBanco { get; set; }

    public string? EmBancoIng { get; set; }

    /// <summary>
    /// Check para ver si se agrega la frase o no
    /// </summary>
    public string? EmChkban { get; set; }

    /// <summary>
    /// Comentario de SuperIntencia De Banca
    /// </summary>
    public string? EmSupban { get; set; }

    public string? EmSupbanIng { get; set; }

    /// <summary>
    /// Comentario de SuperIntencia De Banca Tabulado
    /// </summary>
    public string? EmSubacu { get; set; }

    public string? EmSubacuIng { get; set; }

    /// <summary>
    /// Fecha de Registro en la SBS
    /// </summary>
    public string? EmFecreg { get; set; }

    /// <summary>
    /// Calificacion SBS
    /// </summary>
    public string? EmCalsbs { get; set; }

    /// <summary>
    /// Calificacion SBS en Ingles
    /// </summary>
    public string? EmCalsbsIng { get; set; }

    public double? EmGaomn { get; set; }

    public double? EmGaome { get; set; }

    /// <summary>
    /// Informacion General
    /// </summary>
    public string? EmInfgen { get; set; }

    public string? EmInfgenIng { get; set; }

    /// <summary>
    /// Informacion General Tabulado
    /// </summary>
    public string? EmIngecu { get; set; }

    public string? EmIngecuIng { get; set; }

    /// <summary>
    /// Si es Apto o no la Opinion de Credito
    /// </summary>
    public string? EmSnopcr { get; set; }

    /// <summary>
    /// Tipo de Opinion De Credito
    /// </summary>
    public string? EmTiopcr { get; set; }

    /// <summary>
    /// Tipo de Opinion De Credito
    /// </summary>
    public string? OcCodigo { get; set; }

    public string? EmOcDescri { get; set; }

    public string? EmOcDescriIng { get; set; }

    /// <summary>
    /// Comentario de Opinion De Credito
    /// </summary>
    public string? EmOpicre { get; set; }

    public string? EmOpicreIng { get; set; }

    public string? EmMtopcr { get; set; }

    public string? EmMtopcrIng { get; set; }

    public string? EmCrerec { get; set; }

    public string? EmCrerecIng { get; set; }

    /// <summary>
    /// Comentario de Centrar de Riesgo
    /// </summary>
    public string? EmCenrie { get; set; }

    public string? EmCenrieIng { get; set; }

    /// <summary>
    /// Comentario de Antecedentes Crediticios
    /// </summary>
    public string? EmAntcre { get; set; }

    public string? EmAntcreIng { get; set; }

    public string? EmCiiu { get; set; }

    public string? EmFecbalAnu { get; set; }

    public string? EmFecbalAnu2 { get; set; }

    public double? EmTipcamAnu { get; set; }

    public double? EmTipcamAnu2 { get; set; }

    /// <summary>
    /// Ventas Anuales cuando no hay balance
    /// </summary>
    public double? EmVentasAnu { get; set; }

    public double? EmVentasAnu2 { get; set; }

    public double? EmVentas { get; set; }

    public int? EmLogventas { get; set; }

    public int? EmLoggrafico { get; set; }

    public string? AboCodigo { get; set; }

    public string? TramNombre { get; set; }

    /// <summary>
    /// Fecha de Pedido
    /// </summary>
    public string? CupFecped { get; set; }

    /// <summary>
    /// Numero de Referencia
    /// </summary>
    public string? CupNroref { get; set; }

    public string? CupTipinf { get; set; }

    /// <summary>
    /// Numero de Orden
    /// </summary>
    public string? CupNroord { get; set; }

    public string? PerCodrep { get; set; }

    public string? PerCodage { get; set; }

    public string? PerCodsup { get; set; }

    /// <summary>
    /// Calidad del Informe
    /// </summary>
    public string? CalCodigo { get; set; }

    public string? EmNument { get; set; }

    public string? EmFecsbs { get; set; }

    public double? EmTcsbs { get; set; }

    public string? EmPresta { get; set; }

    public string? EmPrestaMe { get; set; }

    public string? EmDescue { get; set; }

    public string? EmDescueMe { get; set; }

    public string? EmArrfin { get; set; }

    public string? EmArrfinMe { get; set; }

    public string? EmComexte { get; set; }

    public string? EmComexteMe { get; set; }

    public string? EmLeabac { get; set; }

    public string? EmLeabacMe { get; set; }

    public string? EmFactor { get; set; }

    public string? EmFactorMe { get; set; }

    public string? EmTarcred { get; set; }

    public string? EmTarcredMe { get; set; }

    public string? EmOtrdeu { get; set; }

    public string? EmOtrdeuMe { get; set; }

    public string? EmOtros { get; set; }

    public string? EmOtrosIng { get; set; }

    public string? EmTototr { get; set; }

    public string? EmTototrMe { get; set; }

    public string? EmTotdeu { get; set; }

    public string? EmTotdeuMe { get; set; }

    public string? EmOtros2 { get; set; }

    public string? EmOtros2Ing { get; set; }

    public string? EmTototr2 { get; set; }

    public string? EmTototr2Me { get; set; }

    public string? CupIdioma { get; set; }

    public string? DiCodigo { get; set; }

    public string? EmMatriz { get; set; }

    public string? EmAudito { get; set; }

    /// <summary>
    /// 0-&gt; No hay datos
    /// 1-&gt; Si Hay datos
    /// </summary>
    public int EmLogantleg { get; set; }

    public int EmLogramneg { get; set; }

    public int EmLoginffin { get; set; }

    public int EmLogbalsit { get; set; }

    public int EmLogcuatab { get; set; }

    public int EmLogbalance { get; set; }

    public int EmLogpagos { get; set; }

    public int EmLogprove { get; set; }

    public int EmLogcenrie { get; set; }

    public int EmLoglitigio { get; set; }

    public int EmLogbanque { get; set; }

    public int EmLogimagen { get; set; }

    public string? CpCodigo { get; set; }

    public int? EmTipoa { get; set; }

    public int? EmTipob { get; set; }

    public int? EmRubro1 { get; set; }

    public int? EmRubro2 { get; set; }

    public int? EmRubro3 { get; set; }

    public int? EmRubro4 { get; set; }

    public int? EmRubro1a { get; set; }

    public int? EmRubro1b { get; set; }

    public int? EmRubro1c { get; set; }

    public int? EmRubro1d { get; set; }

    public int? EmRubro2a { get; set; }

    public int? EmRubro3a { get; set; }

    public int? EmRubro3b { get; set; }

    public int? EmRubro3c { get; set; }

    public int? EmRubro4a { get; set; }

    public int? EmRubro4b { get; set; }

    public int? EmRubro4c { get; set; }

    public int? EmRubro4d { get; set; }

    public int? EmRubro4e { get; set; }

    public int? EmRubro4f { get; set; }

    public string? EmLogicoB { get; set; }

    public string? EmLogicoC { get; set; }

    public string? SitDesde { get; set; }

    public string? EmEstadoempresa { get; set; }

    public string? EmComenSup { get; set; }

    public int? Migra { get; set; }
}
