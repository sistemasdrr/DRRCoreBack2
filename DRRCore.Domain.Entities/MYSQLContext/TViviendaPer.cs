using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TViviendaPer
{
    public string VivCodigo { get; set; } = null!;

    public string? VivNombre { get; set; }

    public string? VivNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
