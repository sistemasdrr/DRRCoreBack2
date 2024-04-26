using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCiiu
{
    public string CiCodigo { get; set; } = null!;

    public string? CiNombre { get; set; }

    public string? CcCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
