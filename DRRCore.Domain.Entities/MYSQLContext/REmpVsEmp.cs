using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsEmp
{
    public string EmCodigo { get; set; } = null!;

    public string EeCodigo { get; set; } = null!;

    /// <summary>
    /// Numero de Orden (Sin Uso Momentaneamente)
    /// </summary>
    public string? EeNumero { get; set; }

    public string? ReCodigo { get; set; }

    /// <summary>
    /// Tipo de Relacion &lt;= tConGen
    /// </summary>
    public string? ReNombre { get; set; }

    public string? ReNombreIng { get; set; }

    public string? EePorAcc { get; set; }

    public string? EePorAccIng { get; set; }

    public string? EeDesde { get; set; }

    public string? EeComen { get; set; }

    public string? EeComenIng { get; set; }

    /// <summary>
    /// Participacion De la Empresa Subsidiaria
    /// </summary>
    public string? EePorAcc2 { get; set; }

    public string? EePorAcc2Ing { get; set; }

    public sbyte? Migra { get; set; }
}
