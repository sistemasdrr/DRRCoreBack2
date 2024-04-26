using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAbonadoCuponera
{
    public int AcNumero { get; set; }

    public DateTime AcFecini { get; set; }

    public string? AboCodigo { get; set; }

    public double? AcMonto { get; set; }

    /// <summary>
    /// Cuponera Restantes
    /// </summary>
    public double? AcCuprest { get; set; }

    /// <summary>
    /// Cantidad de Compra
    /// </summary>
    public double? AcCancom { get; set; }

    public string? AcFactur { get; set; }

    public double? AcPrecio { get; set; }

    public sbyte? Migra { get; set; }
}
