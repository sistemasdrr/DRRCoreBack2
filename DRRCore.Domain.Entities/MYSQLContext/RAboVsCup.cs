using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Detalle de los Pedidos de Abonados con Cupones
/// </summary>
public partial class RAboVsCup
{
    public string? AboCodigo { get; set; }

    /// <summary>
    /// Numero de Cupones Consumidos
    /// </summary>
    public double? AcCupcon { get; set; }

    public DateTime? AcFecha { get; set; }

    /// <summary>
    /// Cupones Disponibles a la Fecha
    /// </summary>
    public double? AcCupdis { get; set; }

    public string CupCodigo { get; set; } = null!;

    public sbyte Migra { get; set; }
}
