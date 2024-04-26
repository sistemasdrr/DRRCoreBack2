using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TLocal
{
    public string LoCodigo { get; set; } = null!;

    public string? LoNombre { get; set; }

    public string? LoNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
