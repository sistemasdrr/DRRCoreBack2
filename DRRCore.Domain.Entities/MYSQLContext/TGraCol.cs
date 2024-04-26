using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TGraCol
{
    public int GcCodigo { get; set; }

    public string? GcNombre { get; set; }

    public string? GcNombreIng { get; set; }

    public int? GcActivo { get; set; }

    public int? GcOrden { get; set; }

    public sbyte? Migra { get; set; }
}
