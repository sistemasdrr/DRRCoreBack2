using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RPerVsLit
{
    public string PeCodigo { get; set; } = null!;

    public int LiOrden { get; set; }

    public string? LiFecha { get; set; }

    public string? LiFechaIng { get; set; }

    public string? LiAccion { get; set; }

    public string? LiAccionIng { get; set; }

    public string? LiDemand { get; set; }

    public string? LiDemandIng { get; set; }

    public string? LiEstado { get; set; }

    public sbyte? Migra { get; set; }
}
