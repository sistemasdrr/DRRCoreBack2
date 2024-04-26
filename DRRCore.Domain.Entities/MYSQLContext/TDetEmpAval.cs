using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TDetEmpAval
{
    public int AvCodigo { get; set; }

    public string EmCodigo { get; set; } = null!;

    public string AvNombre { get; set; } = null!;

    public string AvRuc { get; set; } = null!;

    public double? AvMontousd { get; set; }

    public double? AvMontomn { get; set; }

    public DateTime? AvFecha { get; set; }

    public string? AvEntidad { get; set; }

    public sbyte? Migra { get; set; }
}
