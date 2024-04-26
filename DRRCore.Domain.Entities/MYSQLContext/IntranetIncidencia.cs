using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class IntranetIncidencia
{
    public int? IncCodigo { get; set; }

    public DateTime? IncFecha { get; set; }

    public string? IncUsCodigo { get; set; }

    public short? IncStatus { get; set; }

    public short? IncTipo { get; set; }

    public string? IncAsunto { get; set; }

    public string? IncConsulta { get; set; }

    public string? IncSolu { get; set; }

    public string? IncSoluUsCodigo { get; set; }

    public DateTime? IncSoluFecha { get; set; }

    public string? IncArea { get; set; }

    public string? IncCorreoDe { get; set; }

    public string? IncCorreoPara { get; set; }

    public short? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
