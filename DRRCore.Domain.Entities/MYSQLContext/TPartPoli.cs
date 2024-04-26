using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPartPoli
{
    public int PpCodigo { get; set; }

    public string? PpAbrevi { get; set; }

    public string? PpDescri { get; set; }

    public string? PpActivo { get; set; }

    public sbyte? Migra { get; set; }
}
