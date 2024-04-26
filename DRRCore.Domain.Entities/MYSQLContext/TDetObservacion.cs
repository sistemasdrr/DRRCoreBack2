using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TDetObservacion
{
    public long ObCodigo { get; set; }

    public string PerCodigo { get; set; } = null!;

    public string? ObComent { get; set; }

    public sbyte? Migra { get; set; }
}
