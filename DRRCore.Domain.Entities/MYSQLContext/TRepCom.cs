using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TRepCom
{
    public string RcCodigo { get; set; } = null!;

    public string? RcNombre { get; set; }

    public int? RcOrden { get; set; }

    /// <summary>
    /// Estado (1 Activo 2 Desactivado)
    /// </summary>
    public int? RcActivo { get; set; }

    public string? RcCodigoIng { get; set; }

    public string? RcNombreIng { get; set; }

    public string? RcOrdenIng { get; set; }

    public string? RcStatus { get; set; }

    public sbyte? Migra { get; set; }
}
