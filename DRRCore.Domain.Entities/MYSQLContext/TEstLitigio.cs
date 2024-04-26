using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TEstLitigio
{
    public string ElCodigo { get; set; } = null!;

    public string? ElDescri { get; set; }

    public string? ElDescriIng { get; set; }

    public sbyte? Migra { get; set; }
}
