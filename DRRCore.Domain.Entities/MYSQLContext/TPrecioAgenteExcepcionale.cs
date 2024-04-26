using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TPrecioAgenteExcepcionale
{
    /// <summary>
    /// PRECIO EXCEPCIONAL(PE
    /// </summary>
    public int PeContador { get; set; }

    public string CalCodigo { get; set; } = null!;

    public string? AgeCodigo { get; set; }

    public double? PePrecio { get; set; }

    public bool? PeActivo { get; set; }

    public string? PaiCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
