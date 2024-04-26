using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TComplemento
{
    public string? EmCodigo { get; set; }

    public string? PerCod { get; set; }

    public double? Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
