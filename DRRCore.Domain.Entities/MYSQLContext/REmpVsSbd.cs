using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsSbd
{
    public string EmCodigo { get; set; } = null!;

    public int SbdOrden { get; set; }

    public string? SbdNombre { get; set; }

    public string? SbdNormal { get; set; }

    public string? SbdProPot { get; set; }

    public string? SbdDefici { get; set; }

    public string? SbdDudoso { get; set; }

    public string? SbdPerdida { get; set; }

    public string? SbdCalifi { get; set; }

    public string? SbdCalifiIng { get; set; }

    public double? SbdMonto { get; set; }

    public double? SbdMonMe { get; set; }

    public string? SbdSemaforo { get; set; }

    public string? SbdMemo { get; set; }

    public string? SbdMemoIng { get; set; }

    public sbyte? Migra { get; set; }
}
