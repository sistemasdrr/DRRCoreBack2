using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// 0 - No Imprime
/// 1 - Si Imprime
/// </summary>
public partial class TUsuario
{
    public string UsCodigo { get; set; } = null!;

    public string? UsLogin { get; set; }

    public string? UsPassword { get; set; }

    public string? UsNombre { get; set; }

    public string? IdPersonal { get; set; }

    /// <summary>
    /// Tipo de Empleado: AD=Administrativo  PR=Produccion
    /// </summary>
    public string? UsTipemp { get; set; }

    public bool? UsEstado { get; set; }

    public string? UsSistema { get; set; }

    public int? UsTodReg { get; set; }

    public string? UsIp { get; set; }

    public string? UsTipo { get; set; }

    /// <summary>
    /// Si-&gt;Seguir Mostrando/// No-&gt;No Volver a Mostrar
    /// </summary>
    public string? UsNoveda { get; set; }

    /// <summary>
    /// Si-&gt;Seguir Mostrando/// No-&gt;No Volver a Mostrar
    /// </summary>
    public string? UsCargo { get; set; }

    /// <summary>
    /// Si-&gt;Seguir Mostrando/// No-&gt;No Volver a Mostrar
    /// </summary>
    public string? UsEmail { get; set; }

    public int? UsIngsis { get; set; }

    public int? UsProces { get; set; }

    public int? UsBasdat { get; set; }

    public int? UsFactur { get; set; }

    public int? UsConsul { get; set; }

    public int UsCuadro { get; set; }

    public int? UsAnalis { get; set; }

    public int? UsImprime { get; set; }

    public int? UsWord { get; set; }

    public byte[]? UsFoto { get; set; }

    public sbyte? Migra { get; set; }
}
