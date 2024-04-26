using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Tabla de Protestos Por Aceptante de Personas.
/// </summary>
public partial class RPerVsProAcep
{
    public int PaNumero { get; set; }

    public string? PeCodigo { get; set; }

    public string? PaBoletin { get; set; }

    public string? PaNumdoc { get; set; }

    public string? PaGirador { get; set; }

    public string? PaTitulo { get; set; }

    public string? PaTituloIng { get; set; }

    public double? PaMonmn { get; set; }

    public double? PaMonme { get; set; }

    public string? PaFecpro { get; set; }

    public string? PaFecreg { get; set; }

    public sbyte? Migra { get; set; }
}
