using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TEstCiv
{
    public string EcCodigo { get; set; } = null!;

    public string? EcNombre { get; set; }

    public string? EcNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
