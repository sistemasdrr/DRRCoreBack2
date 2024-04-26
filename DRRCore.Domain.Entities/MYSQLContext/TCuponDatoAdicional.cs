using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCuponDatoAdicional
{
    public string? EmCodigo { get; set; }

    public string? EmTelefono { get; set; }

    public string? EmFax { get; set; }

    public string EmCorreo { get; set; } = null!;

    public sbyte Migra { get; set; }
}
