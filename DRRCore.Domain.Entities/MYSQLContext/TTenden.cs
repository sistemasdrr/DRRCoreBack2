using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTenden
{
    public string TdCodigo { get; set; } = null!;

    public string? TdNombre { get; set; }

    public string? TdNombreIng { get; set; }

    public string? TdSimbol { get; set; }

    public byte[]? TdImagen { get; set; }

    public int? TdActivo { get; set; }

    public sbyte? Migra { get; set; }
}
