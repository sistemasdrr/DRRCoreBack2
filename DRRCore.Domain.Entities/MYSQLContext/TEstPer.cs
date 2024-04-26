using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TEstPer
{
    public string EsCodigo { get; set; } = null!;

    public string? EsNombre { get; set; }

    public string? EsNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
