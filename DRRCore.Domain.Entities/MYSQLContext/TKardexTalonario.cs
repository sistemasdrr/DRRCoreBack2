using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TKardexTalonario
{
    public string AboCodigo { get; set; } = null!;

    public string? AboNombre { get; set; }

    public string? PaiNombre { get; set; }

    public double? Precio { get; set; }

    public double? SaldoAnterior { get; set; }

    public double? TotalSaldoAnterior { get; set; }

    public double? CuponesCompra { get; set; }

    public double? TotalCompra { get; set; }

    public double? UnidAtendidas { get; set; }

    public double? TotalUnidAtendidas { get; set; }

    public double? SaldoActual { get; set; }

    public double? TotalSaldoActual { get; set; }

    public sbyte? Migra { get; set; }
}
