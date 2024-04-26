using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class ResumenMensual
{
    public string? AboCodigo { get; set; }

    public string? Abonado { get; set; }

    public string? Pais { get; set; }

    public sbyte? Mes { get; set; }

    public int? Cantidad { get; set; }

    public string? Anio { get; set; }

    public sbyte? Migra { get; set; }
}
