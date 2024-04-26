using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsVenta
{
    public int VeCodigo { get; set; }

    public string EmCodigo { get; set; } = null!;

    public string VeFecha { get; set; } = null!;

    public double VeTipcam { get; set; }

    public double? VeVentas { get; set; }

    public string PaiMone { get; set; } = null!;

    public sbyte Migra { get; set; }
}
