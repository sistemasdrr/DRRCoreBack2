using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TEmpresaExc
{
    public string? Nombre { get; set; }

    public string? Ruc { get; set; }

    public string? PaisCod { get; set; }

    public string? PaisNom { get; set; }

    public sbyte? Migra { get; set; }
}
