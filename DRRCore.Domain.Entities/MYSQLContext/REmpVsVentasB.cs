using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsVentasB
{
    public int VeCodigo { get; set; }

    public string? EmCodigo { get; set; }

    public string? VeTipcam { get; set; }

    public string? VeFecha { get; set; }

    public string? VeVentas { get; set; }

    public string? PaiMone { get; set; }

    public sbyte? Migra { get; set; }
}
