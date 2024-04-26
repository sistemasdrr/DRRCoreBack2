using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TConGen
{
    public string? TgCodigo { get; set; }

    public string? TgNombre { get; set; }

    public string? TgName { get; set; }

    public string? TgOrden { get; set; }

    public string? TgDesdtl { get; set; }

    public string? TgDtldes { get; set; }

    public string? TgDesrdc { get; set; }

    public string? TgRdcdes { get; set; }

    public string? TgObsGen { get; set; }

    public string? TgObsGenIng { get; set; }

    public sbyte? Migra { get; set; }
}
