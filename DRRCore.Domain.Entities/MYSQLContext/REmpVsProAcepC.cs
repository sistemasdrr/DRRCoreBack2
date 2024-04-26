using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsProAcepC
{
    public int? PaNumero { get; set; }

    public string? EmCodigo { get; set; }

    public string? PaGirador { get; set; }

    public string? PaTitulo { get; set; }

    public string? PaTituloIng { get; set; }

    public double? PaMonmn { get; set; }

    public double? PaMonme { get; set; }

    public string? PaFecpro { get; set; }

    public string? PaFecreg { get; set; }

    public sbyte? Migra { get; set; }
}
