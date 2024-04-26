using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TMatSub
{
    public string MatCodigo { get; set; } = null!;

    public string? MatNombre { get; set; }

    public string? MatNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
