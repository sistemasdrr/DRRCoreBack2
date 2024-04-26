using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TComentProv
{
    public string CpCodigo { get; set; } = null!;

    public string? CpNombre { get; set; }

    public string? CpNombreIng { get; set; }

    public int? CpOrden { get; set; }

    public sbyte? Migra { get; set; }
}
