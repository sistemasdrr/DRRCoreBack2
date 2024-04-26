using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TOpcionSitFin
{
    public string OfCodigo { get; set; } = null!;

    public string? SfCodigo { get; set; }

    public string? OfDescri1 { get; set; }

    public string? OfDescri2 { get; set; }

    public string? OfDescri1Ing { get; set; }

    public string? OfDescri2Ing { get; set; }

    public sbyte? Migra { get; set; }
}
