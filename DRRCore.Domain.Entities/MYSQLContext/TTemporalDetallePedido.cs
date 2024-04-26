using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTemporalDetallePedido
{
    public int? Nro { get; set; }

    public DateTime? Fped { get; set; }

    public DateTime? Fdesp { get; set; }

    public string? NroReferencia { get; set; }

    public string? NombreInforme { get; set; }

    public string? Pais { get; set; }

    public string? Tramite { get; set; }

    public double? Costo { get; set; }

    public double? Igv { get; set; }

    public double? Monto { get; set; }
}
