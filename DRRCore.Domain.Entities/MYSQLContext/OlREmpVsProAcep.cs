using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsProAcep
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? PaBoletin { get; set; }

    public string? PaNumdoc { get; set; }

    public string? PaGirador { get; set; }

    public string? PaTitulo { get; set; }

    public double? PaMonmn { get; set; }

    public double? PaMonme { get; set; }

    public string? PaFecpro { get; set; }

    public string? PaFecreg { get; set; }

    public int? PaDiaatr { get; set; }
}
