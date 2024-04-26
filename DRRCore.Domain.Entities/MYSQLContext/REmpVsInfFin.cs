using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsInfFin
{
    public string EmCodigo { get; set; } = null!;

    public string? EmConinf { get; set; }

    public string? EmConinfIng { get; set; }

    public string? SfCodigo { get; set; }

    public string? EmSitfin { get; set; }

    public string? EmSitfinIng { get; set; }

    public string? EmPropie { get; set; }

    public string? EmPropieIng { get; set; }

    public string? EmSeguro { get; set; }

    public string? EmSeguroIng { get; set; }

    /// <summary>
    /// Personas Entrevistadas
    /// </summary>
    public string? EmEntrev { get; set; }

    public int? GcCodigo { get; set; }

    public string? EmCargos { get; set; }

    public string? EmCargosIng { get; set; }

    /// <summary>
    /// Grado de Colaboracion
    /// </summary>
    public string? EmGrado { get; set; }

    public string? EmGradoIng { get; set; }

    /// <summary>
    /// Informacion Proporcionada
    /// </summary>
    public string? EmInfpro { get; set; }

    public string? EmInfproIng { get; set; }

    /// <summary>
    /// Indicador para saber cual se imprimie (0 Nada, 1 Solo Entrevistados, 2 Solo Memo, 3 Los dos juntos)
    /// </summary>
    public int? EmLogInffin { get; set; }

    /// <summary>
    /// Situacion  Financiera Tabulado
    /// </summary>
    public string? EmSitfinTab { get; set; }

    public string? EmSitfinTabIng { get; set; }

    public string? EmAnalista { get; set; }

    public string? EmAnalistaIng { get; set; }

    public string? EmAnalistaVb { get; set; }

    public int? EmChkBal { get; set; }

    public sbyte? Migra { get; set; }
}
