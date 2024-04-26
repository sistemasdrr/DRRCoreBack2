using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCumplimiento
{
    public string CumCodigo { get; set; } = null!;

    public string? CumNombre { get; set; }

    public string? CumNombreIng { get; set; }

    public string? TgDesrdc { get; set; }

    public string? TgRdcdes { get; set; }

    public string? TgObsGen { get; set; }

    public string? TgObsGenIng { get; set; }

    public sbyte? Migra { get; set; }
}
