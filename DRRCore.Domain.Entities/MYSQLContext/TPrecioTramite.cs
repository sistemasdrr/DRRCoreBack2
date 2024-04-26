using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPrecioTramite
{
    public string TramCodigo { get; set; } = null!;

    public double? PreValor { get; set; }

    public string? PreAux1 { get; set; }

    public string? PreAux2 { get; set; }

    public string? PreAux3 { get; set; }

    public double? PreAux4 { get; set; }

    public double? PreAux5 { get; set; }

    public double? PreAux6 { get; set; }

    public sbyte? Migra { get; set; }
}
