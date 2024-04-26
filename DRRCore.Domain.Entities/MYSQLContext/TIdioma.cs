using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TIdioma
{
    public string IdiCodigo { get; set; } = null!;

    public string? IdiNombre { get; set; }

    public string? IdiAbrevi { get; set; }

    public string? IdiObserv { get; set; }

    public bool? IdiActivo { get; set; }

    public bool? Migra { get; set; }
}
