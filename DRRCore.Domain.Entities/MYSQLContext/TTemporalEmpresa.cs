using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTemporalEmpresa
{
    /// <summary>
    /// Usuario que abrio el Informe
    /// </summary>
    public string UsCodigo { get; set; } = null!;

    public string? EmCodigo { get; set; }

    public DateTime? EmFecinf { get; set; }

    public string? EmOnline { get; set; }

    public string? EmLogico { get; set; }

    public string? IdiCodigo { get; set; }

    public int? EmTipper { get; set; }

    public string? EmNombre { get; set; }

    public string? EmNomsol { get; set; }

    /// <summary>
    /// Nombre Correcto Si o No
    /// </summary>
    public string? EmNomcrr { get; set; }

    public string? EmSiglas { get; set; }

    public string? PaiDoctrb { get; set; }

    public string? EmRegtri { get; set; }

    public string? SitCodigo { get; set; }

    public string? SitNombre { get; set; }

    public string? EmDirecc { get; set; }

    public string? EmTipvia { get; set; }

    public string? EmNomvia { get; set; }

    public string? EmPiso { get; set; }

    public string? EmDistri { get; set; }

    public string? EmCiudad { get; set; }

    public string? EmDepart { get; set; }

    public string? EmCodpos { get; set; }

    public string? PaiCodigo { get; set; }

    public string? PaiNombreCas { get; set; }

    public string? EmAnofun { get; set; }

    public string? EmPrftlf { get; set; }

    public string? EmTelef1 { get; set; }

    public string? EmTelef2 { get; set; }

    public string? EmPrffax { get; set; }

    public string? EmFax { get; set; }

    public string? EmAnobal { get; set; }

    public string? EmEmail { get; set; }

    public string? EmPagweb { get; set; }

    public string? JuCodigo { get; set; }

    public string? JuNombre { get; set; }

    public string? CrCodigo { get; set; }

    public string? CrNombre { get; set; }

    public string? PaCodigo { get; set; }

    public string? PaNombre { get; set; }

    public string? TdCodigo { get; set; }

    public string? TdNombre { get; set; }

    public string? AboCodigo { get; set; }

    public string? TramCodigo { get; set; }

    public string? TramNombre { get; set; }

    public string? CupFecped { get; set; }

    public string? CupRefabo { get; set; }

    public string? CupTipinf { get; set; }

    public string? PerCodrep { get; set; }

    public string? PerCodage { get; set; }

    public string? AtFecdev { get; set; }

    public string? PerCoddig { get; set; }

    public string? PerCodtra { get; set; }

    public string? PerCodsup { get; set; }

    public string? PerCodref { get; set; }

    public string? CalCodigo { get; set; }

    public string? CalNombre { get; set; }

    public DateTime? EmFecref { get; set; }

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

    public string? EmGarofr { get; set; }

    public string? EmComprov { get; set; }

    public string? EmComprovIng { get; set; }

    public string? EmComlit { get; set; }

    public string? EmComlitIng { get; set; }

    public string? EmChkBanco { get; set; }

    public string? EmBanco { get; set; }

    public string? EmBancoIng { get; set; }

    public string? EmChkban { get; set; }

    public string? EmSupban { get; set; }

    public string? EmSupbanIng { get; set; }

    public string? EmSubacu { get; set; }

    public string? EmSubacuIng { get; set; }

    public string? EmFecreg { get; set; }

    public string? EmCalsbs { get; set; }

    public string? EmCalsbsIng { get; set; }

    public double? EmGaomn { get; set; }

    public double? EmGaome { get; set; }

    public string? EmInfgen { get; set; }

    public string? EmInfgenIng { get; set; }

    public string? EmIngecu { get; set; }

    public string? EmIngecuIng { get; set; }

    public string? EmSnopcr { get; set; }

    public string? EmTiopcr { get; set; }

    public string? OcCodigo { get; set; }

    public string? OcDescri { get; set; }

    public string? OcDescriIng { get; set; }

    public string? EmOpicre { get; set; }

    public string? EmOpicreIng { get; set; }

    public string? EmOcDescri { get; set; }

    public string? EmOcDescriIng { get; set; }

    public string? EmMtopcr { get; set; }

    public string? EmMtopcrIng { get; set; }

    public string? EmCrerec { get; set; }

    public string? EmCrerecIng { get; set; }

    public string? EmCenrie { get; set; }

    public string? EmCenrieIng { get; set; }

    public string? EmAntcre { get; set; }

    public string? EmAntcreIng { get; set; }

    public string? EmComrep { get; set; }

    public string? EmComrepIng { get; set; }

    public string? EmComide { get; set; }

    public string? EmComideIng { get; set; }

    public string? EmPrensa { get; set; }

    public string? EmPrensaIng { get; set; }

    public string? EmPrensasel { get; set; }

    public string? EmPrensaselIng { get; set; }

    public int? EmLogpre { get; set; }

    /// <summary>
    /// 0
    /// </summary>
    public int? EmBalgen { get; set; }

    public int? EmBalsit { get; set; }

    public string? EmFecbalAnu { get; set; }

    public string? EmFecbalAnu2 { get; set; }

    public string? BaFecbalance { get; set; }

    public double EmTipcamAnu { get; set; }

    public double EmTipcamAnu2 { get; set; }

    public double EmVentasAnu { get; set; }

    public double EmVentasAnu2 { get; set; }

    /// <summary>
    /// Si es 1 es xq existe ventas para poder ver el grafico
    /// </summary>
    public int? EmLogventas { get; set; }

    /// <summary>
    /// Si es 1 es xq existe valores para grafico de activo corriente ,pasivo corriente y patrimonio
    /// </summary>
    public int? EmLoggrafico { get; set; }

    public string? EmUsuario { get; set; }

    public string? CupNroord { get; set; }

    public string? CupCodigo { get; set; }

    public string? CupIdioma { get; set; }

    public string? PeNombre { get; set; }

    public int EmLogantleg { get; set; }

    public int EmLogramneg { get; set; }

    public int EmLoginffin { get; set; }

    public int EmLogbalance { get; set; }

    public int EmLogpagos { get; set; }

    public int EmLogimagen { get; set; }

    public string CpCodigo { get; set; } = null!;

    public string CpNombre { get; set; } = null!;

    public string CpNombreIng { get; set; } = null!;

    public string? DiCodigo { get; set; }

    public string? DiNombre { get; set; }

    public int EmRubro1 { get; set; }

    /// <summary>
    /// Numero de historico
    /// </summary>
    public string EmNumhis { get; set; } = null!;

    public string? TlNombre { get; set; }

    public string? EmDomant { get; set; }

    public string? EmMatriz { get; set; }

    public string? EmAudito { get; set; }

    public int? EmMorCom { get; set; }

    public int? EmMorBan { get; set; }

    public string? TaNombre { get; set; }

    public string? SitDesde { get; set; }

    public string? EmMorosidad { get; set; }

    public string? EmMorosidadIng { get; set; }

    public string? EmEstadoempresa { get; set; }
}
