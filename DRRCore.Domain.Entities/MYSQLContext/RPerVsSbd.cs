using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RPerVsSbd
{
    public string PeCodigo { get; set; } = null!;

    public int SbdOrden { get; set; }

    public string? SbdNombre { get; set; }

    public string? SbdNormal { get; set; }

    public string? SbdProPot { get; set; }

    public string? SbdDefici { get; set; }

    public string? SbdDudoso { get; set; }

    public string? SbdPerdida { get; set; }

    public string? SbdCalifi { get; set; }

    public string? SbdCalifiIng { get; set; }

    public double? SbdMonmn { get; set; }

    public double? SbdMonme { get; set; }

    public sbyte? Migra { get; set; }
}
