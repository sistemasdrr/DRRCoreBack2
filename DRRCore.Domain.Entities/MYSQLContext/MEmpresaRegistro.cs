using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MEmpresaRegistro
{
    public int ErCodigo { get; set; }

    public string? ErNombre { get; set; }

    public string? ErDirecc { get; set; }

    public string? ErCiudad { get; set; }

    public string? ErCodigoPai { get; set; }

    public string? ErTelefo { get; set; }

    public string? ErPagweb { get; set; }

    public string? ErRegtri { get; set; }

    public string? ErRamneg { get; set; }

    public string? ErFecest { get; set; }

    public string? ErTrabaj { get; set; }

    public string? ErDirgen { get; set; }

    public string? ErPriacc { get; set; }

    public string? ErImport { get; set; }

    public string? ErExport { get; set; }

    public string? ErEmail { get; set; }

    public string? ErPercon { get; set; }

    /// <summary>
    /// C-Castellano / I-Ingles
    /// </summary>
    public string? ErIdioma { get; set; }

    /// <summary>
    /// 1- Ya se migro  0- Falta Migrar 2 -Denegado
    /// </summary>
    public int ErActivo { get; set; }

    public sbyte Migra { get; set; }
}
