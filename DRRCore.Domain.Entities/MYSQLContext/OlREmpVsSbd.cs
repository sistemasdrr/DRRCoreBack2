using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsSbd
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? SbdNombre { get; set; }

    public string? SbdCalifi { get; set; }

    public double? SbdMonto { get; set; }

    public double? SbdMonme { get; set; }

    public string? SbdSemaforo { get; set; }

    public string? SbdMemo { get; set; }
}
