using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TObservacionTipo
{
    public sbyte? ObTipo { get; set; }

    public string? ObNombre { get; set; }

    public sbyte? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
