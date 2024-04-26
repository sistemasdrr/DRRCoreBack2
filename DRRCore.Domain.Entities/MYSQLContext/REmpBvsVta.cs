using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpBvsVta
{
    public string? EmCodigo { get; set; }

    public double? EvVentas { get; set; }

    public double? EvTipcam { get; set; }

    public string? EvAnio { get; set; }

    public sbyte? Migra { get; set; }
}
