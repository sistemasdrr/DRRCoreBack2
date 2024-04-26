using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAsigTrad
{
    public long AtNumped { get; set; }

    public string CupCodigo { get; set; } = null!;

    public DateTime? AtFecent { get; set; }

    public DateTime? AtFecvcto { get; set; }

    public DateTime? AtFecdev { get; set; }

    public string? PerCodigoTra { get; set; }

    public string? PerCodigo { get; set; }

    public double? AtCosto { get; set; }

    /// <summary>
    /// Si se traduce directamente o no
    /// </summary>
    public string? AtTradir { get; set; }

    public string? AtTipinf { get; set; }

    /// <summary>
    /// Si tiene o no Observaciones
    /// </summary>
    public string? AtLogobs { get; set; }

    public string? Tipo { get; set; }

    public sbyte? Migra { get; set; }
}
