using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsExp
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? ExAno { get; set; }

    public string? ExMonto { get; set; }
}
