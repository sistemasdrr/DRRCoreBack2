using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAsigSup
{
    public long AsNumped { get; set; }

    public string CupCodigo { get; set; } = null!;

    public DateTime? AsFecent { get; set; }

    public DateTime? AsFecdev { get; set; }

    public string? PerCodigoSup { get; set; }

    public string? PerCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
