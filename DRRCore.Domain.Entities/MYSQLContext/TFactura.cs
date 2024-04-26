using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TFactura
{
    public string FacCodigo { get; set; } = null!;

    public DateTime? FacFecha { get; set; }

    public string? AbCodigo { get; set; }

    public string? FacDetalle { get; set; }

    public double? FacMonto { get; set; }

    public sbyte? Migra { get; set; }
}
