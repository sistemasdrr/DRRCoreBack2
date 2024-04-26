using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpBvsPro
{
    public string? EmCodigo { get; set; }

    public string? PrNombre { get; set; }

    public string? PrCremax { get; set; }

    public string? PrCremaxIng { get; set; }

    public string? CumCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
