using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TControlCambio
{
    public string? EmCodigo { get; set; }

    public string? Opinion { get; set; }

    public sbyte? Migra { get; set; }
}
