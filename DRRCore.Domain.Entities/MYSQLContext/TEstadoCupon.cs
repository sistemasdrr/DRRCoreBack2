using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TEstadoCupon
{
    public string EcCodigo { get; set; } = null!;

    public string? EcNombre { get; set; }

    public string? EcAbrevi { get; set; }

    public string? EcObserv { get; set; }

    public bool? EcActivo { get; set; }

    public bool? Migra { get; set; }
}
