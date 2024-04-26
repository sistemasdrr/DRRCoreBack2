using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsExp
{
    public string EmCodigo { get; set; } = null!;

    public int ExAno { get; set; }

    public string? ExMonto { get; set; }

    public sbyte? Migra { get; set; }
}
