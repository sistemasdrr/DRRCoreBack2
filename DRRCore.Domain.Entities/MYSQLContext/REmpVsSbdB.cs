using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsSbdB
{
    public int? PaNumero2 { get; set; }

    public string? EmCodigo { get; set; }

    public int? SbdOrden { get; set; }

    public string? SbdNombre { get; set; }

    public double? SbdMonto { get; set; }

    public double? SbdMonMe { get; set; }

    public string? SbdCalifi { get; set; }

    public string? SbdCalifiIng { get; set; }

    public sbyte? Migra { get; set; }
}
