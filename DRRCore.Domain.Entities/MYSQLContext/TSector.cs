using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TSector
{
    public string? SecCodigo { get; set; }

    public string? SecNombre { get; set; }

    public string? SecNombreIng { get; set; }

    public string? SecFlag { get; set; }

    public sbyte? Migra { get; set; }
}
