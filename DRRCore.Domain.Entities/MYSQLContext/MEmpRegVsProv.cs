using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MEmpRegVsProv
{
    public int PrCodigo { get; set; }

    public int? ErCodigo { get; set; }

    public string? EpNombre { get; set; }

    public string? EpCodigoPai { get; set; }

    public sbyte? Migra { get; set; }
}
