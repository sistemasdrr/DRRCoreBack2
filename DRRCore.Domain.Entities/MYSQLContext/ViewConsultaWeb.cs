using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class ViewConsultaWeb
{
    /// <summary>
    /// Código Interno de la Empresa PRINCIPAL
    /// </summary>
    public string CodigoEmpresa { get; set; } = null!;

    public string? Empresa { get; set; }

    public string? NumeroRegistro { get; set; }

    public string? AnoFundacion { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public string? Importa { get; set; }

    public string? PaisesImporta { get; set; }

    public string? Exporta { get; set; }

    public string? PaisesExporta { get; set; }

    /// <summary>
    /// Fecha del Informe
    /// </summary>
    public DateTime? FechaInforme { get; set; }

    public string? PaisCodigo { get; set; }

    public string? Pais { get; set; }

    public string? PaisAbreviatura { get; set; }

    public string? FechaBalance1 { get; set; }

    public string? FechaBalance2 { get; set; }

    public string? FechaBalance3 { get; set; }

    public string? RamoCodigo { get; set; }

    public string? Ramo { get; set; }

    public string? RamoIngles { get; set; }

    public string? RamoActividad { get; set; }

    public string? RamoActividadIngles { get; set; }

    public string? Persona { get; set; }

    public string? CalidadCodigo { get; set; }

    public string? Calidad { get; set; }

    /// <summary>
    /// Tipo de Idioma/Traducción
    /// </summary>
    public int? CodigoIdioma { get; set; }

    public string? Actividad { get; set; }

    public string? ActividadIngles { get; set; }

    public string? Sector { get; set; }

    public string? SectorIngles { get; set; }
}
