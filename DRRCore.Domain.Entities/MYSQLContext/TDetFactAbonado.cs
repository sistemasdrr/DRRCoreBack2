using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TDetFactAbonado
{
    public string FacCodigo { get; set; } = null!;

    public string? CupCodigo { get; set; }

    public double? CupMonto { get; set; }

    public sbyte? Migra { get; set; }
}
