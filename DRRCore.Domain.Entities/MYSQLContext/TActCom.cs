using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TActCom
{
    public string AcCodigo { get; set; } = null!;

    public string? AcNombre { get; set; }

    public string? AcNombreIng { get; set; }

    public string? EmCiiu { get; set; }

    public sbyte? Migra { get; set; }
}
