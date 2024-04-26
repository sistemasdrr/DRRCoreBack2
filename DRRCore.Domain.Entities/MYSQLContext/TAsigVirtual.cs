using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAsigVirtual
{
    public string? Guid { get; set; }

    public string? PerTipo { get; set; }

    public string? PerCodigo { get; set; }

    public string? PerUsuario { get; set; }

    public string? CupCodigo { get; set; }

    public long? NumPedido { get; set; }

    public int? Flag { get; set; }

    public DateTime? Fecha { get; set; }

    public sbyte? Migra { get; set; }
}
