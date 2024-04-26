using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPrecioAgente
{
    public string AgeCodigo { get; set; } = null!;

    public string? PaiCodigo { get; set; }

    public string? PaPrenor { get; set; }

    public string? PaPreurg { get; set; }

    public string? PaPresup { get; set; }

    public string? PaPret4 { get; set; }

    public string? PaPrenat { get; set; }

    public string? PaPrebas { get; set; }

    public string? PaPrereg { get; set; }

    public string? PaPrecre { get; set; }

    public DateTime? PaFecha { get; set; }

    public int PaContador { get; set; }

    public string? MonCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
