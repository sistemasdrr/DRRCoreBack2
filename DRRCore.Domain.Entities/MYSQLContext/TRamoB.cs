using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TRamoB
{
    public int? RamBCodigo { get; set; }

    public string? RamCodigo { get; set; }

    public string? RamBNombre { get; set; }

    public string? RamBNombreIng { get; set; }

    public string? RamBFlag { get; set; }

    public sbyte? Migra { get; set; }
}
