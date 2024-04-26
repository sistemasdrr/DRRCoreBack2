using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TJuridi
{
    public string JuCodigo { get; set; } = null!;

    public string? JuNombre { get; set; }

    public string? JuSigla { get; set; }

    public string? JuCodigoIng { get; set; }

    public string? JuNombreIng { get; set; }

    public string? JuSiglaIng { get; set; }

    public sbyte? Migra { get; set; }
}
