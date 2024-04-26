using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MAgente
{
    public string AgeCodigo { get; set; } = null!;

    public string AgeNombre { get; set; } = null!;

    public DateTime? AgeFecing { get; set; }

    public string? AgeDirecc { get; set; }

    public string? AgeEmail { get; set; }

    public string? AgeTelefo { get; set; }

    public string? AgeFax { get; set; }

    public string? AgeEncarga { get; set; }

    public string? PaiCodigo { get; set; }

    public string? IdiCodigo { get; set; }

    public string? AgeObserv { get; set; }

    public string? AgeExcepc { get; set; }

    public string? AgeAbo { get; set; }

    public int? AgeActivo { get; set; }

    public sbyte? Migra { get; set; }
}
