using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAsigRep
{
    public long ArNumped { get; set; }

    public DateTime? ArFecent { get; set; }

    public DateTime? ArFecvcto { get; set; }

    public DateTime? ArFecdev { get; set; }

    public string? ArObserv { get; set; }

    public string? ArObtbal { get; set; }

    public string? CalCodigo { get; set; }

    public string? PerCodigo { get; set; }

    public string? PerCodigoRep { get; set; }

    public string? CupCodigo { get; set; }

    public string? TramCodigo { get; set; }

    public string? ArTipinf { get; set; }

    public string? ArRecome { get; set; }

    public string? ArRefere { get; set; }

    public double? ArCosto { get; set; }

    public bool? ArActivo { get; set; }

    /// <summary>
    /// Si tuvo o no Observaciones
    /// </summary>
    public string? ArLogobs { get; set; }

    public string? Tipo { get; set; }

    public sbyte? Migra { get; set; }
}
