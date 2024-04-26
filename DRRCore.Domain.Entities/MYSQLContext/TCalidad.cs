using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCalidad
{
    public string CalCodigo { get; set; } = null!;

    public string? CalNombre { get; set; }

    public string? CalAbrevi { get; set; }

    public double? CalPreT1 { get; set; }

    public double? CalPreT2 { get; set; }

    public double? CalPreT3 { get; set; }

    public double? CalPrePer { get; set; }

    public bool? CalActivo { get; set; }

    public int? CalOrden { get; set; }

    public sbyte? Migra { get; set; }
}
