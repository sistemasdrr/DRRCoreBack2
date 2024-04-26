using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TSitFin
{
    public string SfCodigo { get; set; } = null!;

    public string? SfNombre { get; set; }

    public string? SfComen { get; set; }

    public string? SfNombreIng { get; set; }

    public string? SfComenIng { get; set; }

    public sbyte? Migra { get; set; }
}
