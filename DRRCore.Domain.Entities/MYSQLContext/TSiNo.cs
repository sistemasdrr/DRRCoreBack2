using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TSiNo
{
    public string SnCodigo { get; set; } = null!;

    public string? SnNombre { get; set; }

    public string? SnNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
