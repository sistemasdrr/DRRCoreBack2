using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Estado de Opinion de Credito
/// </summary>
public partial class TEstOpiCred
{
    public string OcCodigo { get; set; } = null!;

    public string? OcDescri { get; set; }

    public string? OcDescriIng { get; set; }

    public int? OcOrden { get; set; }

    public sbyte? Migra { get; set; }
}
