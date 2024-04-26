using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TContinente
{
    public string ConCodigo { get; set; } = null!;

    public string ConNombre { get; set; } = null!;

    public string? ConAbrevi { get; set; }

    public string? ConObserv { get; set; }

    public int ConActivo { get; set; }

    public sbyte Migra { get; set; }
}
