using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlRAccionista
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? Nombre { get; set; }

    public string? Cargo { get; set; }

    public string? Participacion { get; set; }

    public string? Desde { get; set; }

    public string? EpPrinci { get; set; }

    public int? EpNumero { get; set; }
}
