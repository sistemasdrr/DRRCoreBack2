using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTemporalCostosGenerale
{
    public string? AboCodigo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaDespacho { get; set; }

    public string? Nombre { get; set; }

    public string? Pais { get; set; }

    public string? Tramite { get; set; }

    public string? Informe { get; set; }

    public double? PrecioInforme { get; set; }

    public double? PrecioReportero { get; set; }

    public double? PrecioAgente { get; set; }

    public double? PrecioDigitadora { get; set; }

    public double? PrecioTraductora { get; set; }

    public double? GastosAdministrativos { get; set; }

    public double? Costo { get; set; }

    public double? Dif { get; set; }
}
