using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAboVsKardex
{
    public string? AboCodigo { get; set; }

    public int? Ano { get; set; }

    public int? Mes { get; set; }

    public decimal? Valor { get; set; }

    public sbyte? Migra { get; set; }
}
