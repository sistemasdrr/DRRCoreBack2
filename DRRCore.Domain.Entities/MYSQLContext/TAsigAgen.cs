using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAsigAgen
{
    public DateTime? AgFecent { get; set; }

    public DateTime? AgFecvcto { get; set; }

    public DateTime? AgFecdev { get; set; }

    public string? AgObserv { get; set; }

    public string? AgObtbal { get; set; }

    public string? CalCodigo { get; set; }

    public string? PerCodigo { get; set; }

    public string? PerCodigoAge { get; set; }

    public string CupCodigo { get; set; } = null!;

    public string? TramCodigo { get; set; }

    public string? AgTipinf { get; set; }

    public string? AgRecome { get; set; }

    public string? AgRefere { get; set; }

    public double? AgCosto { get; set; }

    public int? AgNumord { get; set; }

    public bool? AgActivo { get; set; }

    public string? AgVerif { get; set; }

    public string? AgFactura { get; set; }

    public long AgNumped { get; set; }

    public sbyte Migra { get; set; }
}
