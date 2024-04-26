using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCalifSic
{
    public string CsCodigo { get; set; } = null!;

    public string? CsDescri { get; set; }

    public string? CsDescriIng { get; set; }

    public string? CsInterp { get; set; }

    public string? CsInterpIng { get; set; }

    public string? CcCodigo { get; set; }

    public string? CsSector { get; set; }

    public sbyte? Migra { get; set; }
}
