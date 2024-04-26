using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MUsuarioRegistrado
{
    public string UrCodigo { get; set; } = null!;

    public string UrNombre { get; set; } = null!;

    public string? UrUsuario { get; set; }

    public string? UrPasswo { get; set; }

    public string? UrEmail { get; set; }

    public int? UrCantid { get; set; }

    /// <summary>
    /// 1- Inactivo
    /// </summary>
    public int? UrActivo { get; set; }

    public sbyte? Migra { get; set; }
}
