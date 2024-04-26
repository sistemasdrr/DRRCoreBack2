using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPago
{
    public string PaCodigo { get; set; } = null!;

    public string? PaNombre { get; set; }

    public string? PaOrden { get; set; }

    public string? PaCodigoIng { get; set; }

    public string? PaNombreIng { get; set; }

    public string? PaOrdenIng { get; set; }

    public int? PaActivo { get; set; }

    public sbyte? Migra { get; set; }
}
