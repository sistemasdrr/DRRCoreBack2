using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TEstRegTribPer
{
    public string ErCodigo { get; set; } = null!;

    public string? ErNombre { get; set; }

    public string? ErNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
