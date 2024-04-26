using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TRamoA
{
    public string? RamCodigo { get; set; }

    public string? RamNombre { get; set; }

    public string? RamNombreIng { get; set; }

    public string? RamFlag { get; set; }

    public sbyte? Migra { get; set; }
}
