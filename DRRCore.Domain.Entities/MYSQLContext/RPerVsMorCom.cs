using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Morosidad Comerical de Personas
/// </summary>
public partial class RPerVsMorCom
{
    public int McNumero { get; set; }

    public string? PeCodigo { get; set; }

    public string? McFecha { get; set; }

    public string? McAcreed { get; set; }

    public string? McNrodoc { get; set; }

    public double? McMonmn { get; set; }

    public double? McMonme { get; set; }

    public string? McFecinc { get; set; }

    public sbyte? Migra { get; set; }
}
