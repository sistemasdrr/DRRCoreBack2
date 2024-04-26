using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCatCiiu
{
    public string CcCodigo { get; set; } = null!;

    public string? CcNombre { get; set; }

    public string? CcNombreIng { get; set; }

    public string? CcDescri { get; set; }

    public sbyte? Migra { get; set; }
}
