using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsSe
{
    public string EmCodigo { get; set; } = null!;

    public int EsOrden { get; set; }

    public string? EsCia { get; set; }

    public string? EsContra { get; set; }

    public string? EsContraIng { get; set; }

    public string? EsMonto { get; set; }

    public string? EsMontoIng { get; set; }

    public string? EsVence { get; set; }

    public string? EsVenceIng { get; set; }

    public sbyte? Migra { get; set; }
}
