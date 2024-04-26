using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCalifRef
{
    public string? CarCodigo { get; set; }

    public string? CarNombre { get; set; }

    public string? CarValor { get; set; }

    public sbyte? CarActivo { get; set; }

    public sbyte? Migra { get; set; }
}
