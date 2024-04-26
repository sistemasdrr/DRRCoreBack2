using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TConciliacionDeCuentum
{
    public int CdCodigo { get; set; }

    public string? CdNombre { get; set; }

    public string? CdFaccod { get; set; }

    public DateTime? CdFacfec { get; set; }

    public double? CdFacmon { get; set; }

    public string? CdTipo { get; set; }

    public sbyte? Migra { get; set; }
}
