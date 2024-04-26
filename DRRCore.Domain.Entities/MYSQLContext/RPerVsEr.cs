using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RPerVsEr
{
    public string PeCodigo { get; set; } = null!;

    public int PrOrden { get; set; }

    public string? PrEmpresa { get; set; }

    public string? CaCodigo { get; set; }

    public string? PrCargo { get; set; }

    public string? PrCargoIng { get; set; }

    public string? PrPoracc { get; set; }

    public string? PrFecini { get; set; }

    public string? PrFecces { get; set; }

    public string? PrAnoref { get; set; }

    public string? PaiCodigo { get; set; }

    public string? EmCodigo { get; set; }

    public string? Hasta { get; set; }

    public sbyte? Migra { get; set; }
}
