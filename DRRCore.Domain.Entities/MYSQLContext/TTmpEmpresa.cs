using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTmpEmpresa
{
    /// <summary>
    /// Usuario que abrio el Informe
    /// </summary>
    public string UsCodigo { get; set; } = null!;

    public string? EmCodigo { get; set; }

    public DateTime? EmFecinf { get; set; }

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

    public string? EmComprov { get; set; }

    public string? EmComprovIng { get; set; }

    public string? EmComlit { get; set; }

    public string? EmComlitIng { get; set; }

    public string? EmBanco { get; set; }

    public string? EmBancoIng { get; set; }

    public string? EmSupban { get; set; }

    public string? EmSupbanIng { get; set; }

    public string? EmSubacu { get; set; }

    public string? EmSubacuIng { get; set; }

    public string? EmInfgen { get; set; }

    public string? EmInfgenIng { get; set; }

    public string? EmIngecu { get; set; }

    public string? EmIngecuIng { get; set; }

    public string? EmSnopcr { get; set; }

    public string? EmTiopcr { get; set; }

    public string? EmOpicre { get; set; }

    public string? EmOpicreIng { get; set; }

    public string? EmMtopcr { get; set; }

    public string? EmMtopcrIng { get; set; }

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

    public string? PeNombre { get; set; }
}
