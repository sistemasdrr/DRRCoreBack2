using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class WsConsulta
{
    public int? Id { get; set; }

    public string? AboCodigo { get; set; }

    public DateTime? Fecha { get; set; }

    public string? EmCodigo { get; set; }

    public sbyte? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
