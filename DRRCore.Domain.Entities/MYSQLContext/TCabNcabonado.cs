using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCabNcabonado
{
    public string? NcCodigo { get; set; }

    public string? FacCodigo { get; set; }

    public DateTime? NcFecha { get; set; }

    public string? AboCodigo { get; set; }

    public string? PerCodigo { get; set; }

    public string? MonCodigo { get; set; }

    public double? NcValor { get; set; }

    public double? NcIgv { get; set; }

    public double? NcMonto { get; set; }

    public string? NcObservacion { get; set; }

    public string? NcEstado { get; set; }

    public sbyte? Migra { get; set; }
}
