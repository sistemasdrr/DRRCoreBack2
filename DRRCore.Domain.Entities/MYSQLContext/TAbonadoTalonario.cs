using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAbonadoTalonario
{
    public int AtNumero { get; set; }

    public DateTime AtFecini { get; set; }

    public string? AboCodigo { get; set; }

    public double? AtMonto { get; set; }

    /// <summary>
    /// Cuponera Restantes
    /// </summary>
    public double? AtCuprest { get; set; }

    /// <summary>
    /// Cantidad de Compra
    /// </summary>
    public double? AtCancom { get; set; }

    public string? AtFactur { get; set; }

    public sbyte? Migra { get; set; }
}
