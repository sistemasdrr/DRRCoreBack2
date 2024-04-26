using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPrecioAbonado
{
    public int PaCodigo { get; set; }

    public string AboCodigo { get; set; } = null!;

    public string? PaiCodigo { get; set; }

    public string? PaPrenor { get; set; }

    public string? PaPreurg { get; set; }

    public string? PaPresup { get; set; }

    /// <summary>
    /// Precio Para los EF
    /// </summary>
    public string? PaPreef2 { get; set; }

    public DateTime? PaFecha { get; set; }

    public string? MonCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
