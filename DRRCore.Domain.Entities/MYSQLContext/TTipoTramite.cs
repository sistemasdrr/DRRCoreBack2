using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTipoTramite
{
    public string TramCodigo { get; set; } = null!;

    public string? TramNombre { get; set; }

    public string? TramAbrev { get; set; }

    public string? TramObserv { get; set; }

    public int? TramEstado { get; set; }

    public sbyte? Migra { get; set; }
}
