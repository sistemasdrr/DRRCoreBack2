using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAbonadoCupon
{
    public int AcNumero { get; set; }

    public string? AboCodigo { get; set; }

    public double? AcMonto { get; set; }

    /// <summary>
    /// Equivalencia cupon de compra
    /// </summary>
    public double? AcEquiva { get; set; }

    public DateTime AcFecini { get; set; }

    public DateTime AcFecfin { get; set; }

    public double AcPrecio { get; set; }

    /// <summary>
    /// Cupones Restantes
    /// </summary>
    public double? AcCuprest { get; set; }

    /// <summary>
    /// Cantidad de Compra
    /// </summary>
    public double? AcCancom { get; set; }

    public string? AcFactur { get; set; }

    public sbyte? Migra { get; set; }
}
