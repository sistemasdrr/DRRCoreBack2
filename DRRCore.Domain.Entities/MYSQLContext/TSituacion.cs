using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TSituacion
{
    public string SitCodigo { get; set; } = null!;

    public string? SitNombre { get; set; }

    public string? SitNombreIng { get; set; }

    public string? SitAbrevia { get; set; }

    public sbyte? Migra { get; set; }
}
