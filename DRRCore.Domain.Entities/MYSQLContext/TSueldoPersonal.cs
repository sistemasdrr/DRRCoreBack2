using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TSueldoPersonal
{
    public long Nro { get; set; }

    public string? PerCodigo { get; set; }

    public DateTime? FechaPago { get; set; }

    public double? Monto { get; set; }

    public string? MonCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
