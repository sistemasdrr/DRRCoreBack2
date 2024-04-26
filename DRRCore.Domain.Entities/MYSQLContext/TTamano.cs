using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTamano
{
    public string? TaCodigo { get; set; }

    public string? TaNombre { get; set; }

    public string? TaNombreIng { get; set; }

    public string? Valor { get; set; }

    public sbyte? Migra { get; set; }
}
