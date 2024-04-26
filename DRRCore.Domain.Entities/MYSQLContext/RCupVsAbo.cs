using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Tabla Historico de Pedidos
/// </summary>
public partial class RCupVsAbo
{
    public int EcCodigo { get; set; }

    public string? CupCodigo { get; set; }

    public string? EpCodigo { get; set; }

    public string? CupNomsol { get; set; }

    public string? CupDirecc { get; set; }

    public string? AboCodigo { get; set; }

    public DateTime? CupFecped { get; set; }

    /// <summary>
    /// Fecha de Despacho
    /// </summary>
    public DateTime? CupFecdes { get; set; }

    public string? CupNroord { get; set; }

    public string? CupNroref { get; set; }

    public string? PerCodrep { get; set; }

    public string? PerCodage { get; set; }

    public string? PerCoddig { get; set; }

    public string? PerCodtra { get; set; }

    public string? PerCodsup { get; set; }

    public string? CupTipinf { get; set; }

    public string? TramNombre { get; set; }

    public string? TramCodigo { get; set; }

    public string? EmFecCla { get; set; }

    public string? EmAnobal { get; set; }

    public string? MonNombre { get; set; }

    public double? EmTipcam { get; set; }

    public double? EmVenBal { get; set; }

    public double? EmPatBal { get; set; }

    public string? EmTrabaj { get; set; }

    public string? CrNombre { get; set; }

    public string? PaNombre { get; set; }

    public string? EmTenden { get; set; }

    public string? RcNombre { get; set; }

    public string? EmEntrev { get; set; }

    public sbyte? Migra { get; set; }
}
