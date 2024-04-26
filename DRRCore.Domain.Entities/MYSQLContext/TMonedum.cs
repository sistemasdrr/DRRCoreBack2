using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TMonedum
{
    public string MonCodigo { get; set; } = null!;

    public string? MonNombre { get; set; }

    public string? MonAbrevi { get; set; }

    public string? MonObserv { get; set; }

    public bool? MonActivo { get; set; }

    public bool? Migra { get; set; }
}
