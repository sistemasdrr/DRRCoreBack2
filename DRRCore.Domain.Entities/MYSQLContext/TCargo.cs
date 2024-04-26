using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCargo
{
    public int CaCodigo { get; set; }

    public string? CaNombre { get; set; }

    public string? CaCodigoIng { get; set; }

    public string? CaNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
