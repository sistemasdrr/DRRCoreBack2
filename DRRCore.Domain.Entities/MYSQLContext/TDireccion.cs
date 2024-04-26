using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TDireccion
{
    public string? DiCodigo { get; set; }

    public string? DiNombre { get; set; }

    public string? DiNombreIng { get; set; }

    public sbyte? DiOrden { get; set; }

    public sbyte? Migra { get; set; }
}
