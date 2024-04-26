using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RCuponesOffLine
{
    public long? CupCodigo { get; set; }

    public string? Url { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
