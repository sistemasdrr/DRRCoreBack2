using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TComentProvVario
{
    public string? EmCodigo { get; set; }

    public string? CpNombre { get; set; }

    public string? CpNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
