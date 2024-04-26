using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Tabla Relacionada de Empresa con Personas
/// </summary>
public partial class REmpVsPe
{
    public string EmCodigo { get; set; } = null!;

    public string PeCodigo { get; set; } = null!;

    public int EpNumero { get; set; }

    /// <summary>
    /// Codigo del Cargo
    /// </summary>
    public uint? CaCodigo { get; set; }

    /// <summary>
    /// Cargo mas especifico
    /// </summary>
    public string? EpCargo { get; set; }

    public string? EpCargoIng { get; set; }

    public string? EpPoracc { get; set; }

    public string? EpPorAccIng { get; set; }

    public string? EpDesde { get; set; }

    public string? EpHasta { get; set; }

    /// <summary>
    /// Principal ejecutivo (1=Si,0=No)
    /// </summary>
    public int? EpPrinci { get; set; }

    /// <summary>
    /// Si se impreme o no se impreme(Nombre o todo) algo asi es
    /// </summary>
    public int? EpApenom { get; set; }

    /// <summary>
    /// (1= Se Imprime la foto, 0= No se imprime la foto)
    /// </summary>
    public int? EpFoto { get; set; }

    public string? EpTitulo1 { get; set; }

    public string? EpTitulo2 { get; set; }

    public string? EpTitulo3 { get; set; }

    public string? EpTitulo4 { get; set; }

    public string? EpTitulo5 { get; set; }

    public string? EpTitulo6 { get; set; }

    public string? EpTitulo7 { get; set; }

    public string? EpTitulo8 { get; set; }

    public sbyte? Migra { get; set; }
}
