using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TClasif
{
    public string CrCodigo { get; set; } = null!;

    public string? CrNombre { get; set; }

    public string? CrOrden { get; set; }

    public string? CrCodigoIng { get; set; }

    public string? CrNombreIng { get; set; }

    public string? CrOrdenIng { get; set; }

    public int? CrActivo { get; set; }

    public sbyte? Migra { get; set; }
}
