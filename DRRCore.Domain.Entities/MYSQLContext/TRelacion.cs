using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TRelacion
{
    public string ReCodigo { get; set; } = null!;

    public string? ReNombre { get; set; }

    public string? ReNombreIng { get; set; }

    public int? ReActivo { get; set; }

    public int? ReOrden { get; set; }

    public string? ReTipo { get; set; }

    public sbyte? Migra { get; set; }
}
