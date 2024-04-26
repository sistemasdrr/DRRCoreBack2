using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TSectorEconomico
{
    public string? SeCodigo { get; set; }

    public string? SeNombre { get; set; }

    public string? SeActividades { get; set; }

    public string? SeNombreIng { get; set; }

    public string? SeActividadesIng { get; set; }

    public sbyte? Migra { get; set; }
}
