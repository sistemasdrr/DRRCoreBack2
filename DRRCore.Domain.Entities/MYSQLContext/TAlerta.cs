using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAlerta
{
    public string? CupCodigo { get; set; }

    public string? TramCodigo { get; set; }

    public string? PerCodigo1 { get; set; }

    public DateTime? PerCodigo1Fecha { get; set; }

    public string? PerCodigo2 { get; set; }

    public DateTime? PerCodigo2Fecha { get; set; }

    public string? CupNomsol { get; set; }

    public bool Flag { get; set; }

    public bool Migra { get; set; }
}
