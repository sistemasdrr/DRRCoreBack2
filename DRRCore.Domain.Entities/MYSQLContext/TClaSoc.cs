using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TClaSoc
{
    public int CsoCodigo { get; set; }

    public string? CsoNombre { get; set; }

    public string? CsoNombreIng { get; set; }

    public string? CsoActivo { get; set; }

    public sbyte? Migra { get; set; }
}
