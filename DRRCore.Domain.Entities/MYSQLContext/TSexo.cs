using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TSexo
{
    public string SexCodigo { get; set; } = null!;

    public string? SexDescri { get; set; }

    public string? SexDescriIng { get; set; }

    public sbyte? Migra { get; set; }
}
