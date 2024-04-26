using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCabFactAbonado
{
    public string FacCodigo { get; set; } = null!;

    public DateTime? FacFecfac { get; set; }

    public DateTime? FacFeccan { get; set; }

    public string? AboCodigo { get; set; }

    public string? FacSerie { get; set; }

    public string? PerCodigo { get; set; }

    public string? MonCodigo { get; set; }

    public string? AboFacpara { get; set; }

    public double? FacValor { get; set; }

    public double? FacIgv { get; set; }

    public double? FacMonto { get; set; }

    public string? FacObserv { get; set; }

    public string? FacEstado { get; set; }

    public int? FacCaninf { get; set; }

    public double? FacNrocup { get; set; }

    public string? AboTipfac { get; set; }

    public double? FacTcSd { get; set; }

    public double? FacTcEd { get; set; }

    public sbyte? Migra { get; set; }
}
