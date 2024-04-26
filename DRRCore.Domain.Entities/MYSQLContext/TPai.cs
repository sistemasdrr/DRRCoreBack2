using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPai
{
    public string PaiCodigo { get; set; } = null!;

    public string? PaiNombreCas { get; set; }

    public string? PaiNombreIng { get; set; }

    public string? PaiAbreviatura { get; set; }

    public string? PaiDocTrb { get; set; }

    public string? PaiDoctrbPer { get; set; }

    public string? PaiDocIde { get; set; }

    public string? PaiPrfInt { get; set; }

    public string? PaiEstado { get; set; }

    public string? ConCodigo { get; set; }

    public int? PaiTop { get; set; }

    public string? PaiMone { get; set; }

    public string? PaiMoneda { get; set; }

    public string? Sector { get; set; }

    public sbyte? Migra { get; set; }
}
