using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TConclusion
{
    public string? CoCodigo { get; set; }

    public string? CoNombre { get; set; }

    public string? CoNombreIng { get; set; }

    public sbyte? CoOrden { get; set; }

    public sbyte? Migra { get; set; }
}
