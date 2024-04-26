using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCabEmpAval
{
    public string EmCodigo { get; set; } = null!;

    public string? AvObservacion { get; set; }

    public string? AvObservacionIng { get; set; }

    public sbyte? Migra { get; set; }
}
