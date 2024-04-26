using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MPersonal
{
    public string PerCodigo { get; set; } = null!;

    public string? PerNombre { get; set; }

    public string? PerApepat { get; set; }

    public string? PerApemat { get; set; }

    public string? PerNombreAbre { get; set; }

    public string? PerSexo { get; set; }

    public string? PerEstciv { get; set; }

    public string? PerEmail { get; set; }

    public string? PerObserv { get; set; }

    public int? PerActivo { get; set; }

    public string? PerTelefo { get; set; }

    public string? PerCon { get; set; }

    public string? PerGrains { get; set; }

    public string? PerDni { get; set; }

    public string? PerDomici { get; set; }

    public DateTime? PerFecnac { get; set; }

    public string? PerLugnac { get; set; }

    public string? PerPadre { get; set; }

    public string? PerMadre { get; set; }

    public string? PerHijos { get; set; }

    public string? PerTraant { get; set; }

    public DateTime? PerFecing { get; set; }

    public string? PerModali { get; set; }

    public string? PerCargo { get; set; }

    public DateTime? PerFecces { get; set; }

    public string? PerMotivo { get; set; }

    public double? PerPredig { get; set; }

    /// <summary>
    /// Precio T1 de Terceras Fuentes
    /// </summary>
    public double? PerPredigT1 { get; set; }

    public double? PerPredigT2 { get; set; }

    public double? PerPredigT3 { get; set; }

    public double? PerPretra { get; set; }

    public string? PerCoddig { get; set; }

    public string? PerCodrep { get; set; }

    public string? PerCodtra { get; set; }

    public string? PerCodsup { get; set; }

    public string? PerCodref { get; set; }

    public int? PerActrep { get; set; }

    public int? PerActdig { get; set; }

    public int? PerActtra { get; set; }

    public int? PerAgrrep { get; set; }

    public sbyte? Migra { get; set; }
}
