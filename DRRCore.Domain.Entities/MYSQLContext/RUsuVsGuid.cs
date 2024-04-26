using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RUsuVsGuid
{
    public string? UsCodigo { get; set; }

    public string EmCodigo { get; set; } = null!;

    public long CupCodigo { get; set; }

    public string UsGuid { get; set; } = null!;

    public int? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
