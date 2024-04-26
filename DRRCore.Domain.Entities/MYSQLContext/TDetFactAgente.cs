using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TDetFactAgente
{
    public string FacCodigo { get; set; } = null!;

    public long? CupCodigo { get; set; }

    public double? AgMonto { get; set; }

    public sbyte? Migra { get; set; }
}
