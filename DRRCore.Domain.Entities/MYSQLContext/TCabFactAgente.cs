using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCabFactAgente
{
    public string FacCodigo { get; set; } = null!;

    public DateTime? FacFecfac { get; set; }

    public DateTime? FacFeccan { get; set; }

    public string? AgeCodigo { get; set; }

    public string? PerCodigo { get; set; }

    public string? MonCodigo { get; set; }

    public double? FacMonto { get; set; }

    public string? FacObserv { get; set; }

    public string? FacEstado { get; set; }

    public int? FacCantid { get; set; }

    public sbyte? Migra { get; set; }
}
