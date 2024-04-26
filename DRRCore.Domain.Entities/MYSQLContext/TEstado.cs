using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TEstado
{
    public string EstCodigo { get; set; } = null!;

    public string? EstNombre { get; set; }

    public string? EstNombreIng { get; set; }

    public int? EstOrden { get; set; }

    public bool? EstEstado { get; set; }

    public bool? Migra { get; set; }
}
