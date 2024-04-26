using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TRubro
{
    public string RubCodigo { get; set; } = null!;

    public string RubNombre { get; set; } = null!;

    public string? RubAbrevi { get; set; }

    public string? RubObserv { get; set; }

    public bool? RubActivo { get; set; }

    public bool Migra { get; set; }
}
