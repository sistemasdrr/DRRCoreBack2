using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Morosidad Comercial de Empresas
/// </summary>
public partial class REmpVsMorCom
{
    public int McNumero { get; set; }

    public string? EmCodigo { get; set; }

    public string? McAcreed { get; set; }

    public string? McFecinc { get; set; }

    public string? McNrodoc { get; set; }

    public double? McMonmn { get; set; }

    public double? McMonme { get; set; }

    public string? McFecha { get; set; }

    public sbyte? Migra { get; set; }
}
