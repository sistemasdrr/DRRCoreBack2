using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TVirtual
{
    public int ViCodigo { get; set; }

    public string? ViCadena { get; set; }

    public int ViFlag { get; set; }

    public DateTime ViFecreg { get; set; }

    public string? ViUsuario { get; set; }

    public string? EmCodigo { get; set; }

    public string? EmNombre { get; set; }

    public string? EmCiudad { get; set; }

    public sbyte? Migra { get; set; }
}
