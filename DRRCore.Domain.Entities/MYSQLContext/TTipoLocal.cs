using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTipoLocal
{
    public string TlCodigo { get; set; } = null!;

    public string? TlNombre { get; set; }

    public string? TlNombreIng { get; set; }

    public sbyte? Migra { get; set; }
}
