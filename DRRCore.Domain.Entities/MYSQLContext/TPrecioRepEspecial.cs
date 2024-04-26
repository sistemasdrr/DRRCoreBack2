using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPrecioRepEspecial
{
    public string PaiCodigo { get; set; } = null!;

    public string? PerCodigoRep { get; set; }

    public double? PrPrecioA { get; set; }

    public double? PrPrecioA1 { get; set; }

    public double? PrPrecioB { get; set; }

    public double? PrPrecioB1 { get; set; }

    public double? PrPrecioC { get; set; }

    public double? PrPrecioC1 { get; set; }

    public double? PrPrecioD { get; set; }

    public double? PrPrecioX { get; set; }

    public sbyte? Migra { get; set; }
}
