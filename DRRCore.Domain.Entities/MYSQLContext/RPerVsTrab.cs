using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Tabla relacionada de Persona con Trabajo
/// </summary>
public partial class RPerVsTrab
{
    public string PeCodigo { get; set; } = null!;

    public string? PtCentra { get; set; }

    public string? PtDirecc { get; set; }

    public string? PtTelefo { get; set; }

    public string? EmCodigo { get; set; }

    public int CaCodigo { get; set; }

    public string? CaNombre { get; set; }

    public string? CaNombreIng { get; set; }

    public string? PtFecing { get; set; }

    public string? PtFecingIng { get; set; }

    public string? PtFecces { get; set; }

    public string? PtFeccesIng { get; set; }

    public double? PtEstadi { get; set; }

    public string? PtInganu { get; set; }

    public string? PtInganuIng { get; set; }

    public string? PtDetall { get; set; }

    public string? PtDetallIng { get; set; }

    public sbyte? Migra { get; set; }
}
