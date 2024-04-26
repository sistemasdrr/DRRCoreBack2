using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAsigDig
{
    public string CupCodigo { get; set; } = null!;

    public DateTime? AdFecent { get; set; }

    public DateTime? AdFecvcto { get; set; }

    public DateTime? AdFecdev { get; set; }

    public string? PerCodigoDig { get; set; }

    public string? PerCodigo { get; set; }

    public double? AdCosto { get; set; }

    public string? AdTipinf { get; set; }

    /// <summary>
    /// No - &gt;Solo Digitadora.   Si -&gt; Es Digitadora / Reportera.
    /// </summary>
    public string? AdRepdig { get; set; }

    /// <summary>
    /// Si tiene o no Observaciones
    /// </summary>
    public string? AdLogobs { get; set; }

    public long AdNumped { get; set; }

    public string Tipo { get; set; } = null!;

    public sbyte Migra { get; set; }
}
