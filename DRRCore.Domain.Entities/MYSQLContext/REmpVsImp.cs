using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsImp
{
    public string EmCodigo { get; set; } = null!;

    public int EiAno { get; set; }

    public string? EiMonto { get; set; }

    public sbyte? Migra { get; set; }
}
