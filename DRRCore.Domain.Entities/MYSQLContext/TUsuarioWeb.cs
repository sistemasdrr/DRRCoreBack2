using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TUsuarioWeb
{
    public int UwCodigo { get; set; }

    public string? UwNombre { get; set; }

    /// <summary>
    /// Nombre por el cual se va a Logear
    /// </summary>
    public string? UwLogin { get; set; }

    public string? UwPassword { get; set; }

    public sbyte? Migra { get; set; }
}
