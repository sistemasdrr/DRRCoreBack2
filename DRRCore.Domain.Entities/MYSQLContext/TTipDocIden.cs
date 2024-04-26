using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTipDocIden
{
    public string? TiCodigo { get; set; }

    public string? TiEmpper { get; set; }

    public string? TiNombre { get; set; }

    public string? TiAbrevia { get; set; }

    public string? TiNombreIng { get; set; }

    public string? TiAbreviaIng { get; set; }

    public sbyte? Migra { get; set; }
}
