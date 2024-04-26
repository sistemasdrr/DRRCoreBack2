using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class IntranetValore
{
    public int? ValCodigo { get; set; }

    public int? ValGrupo { get; set; }

    public uint? ValItem { get; set; }

    public string? ValNombre { get; set; }

    public string? ValImagen { get; set; }

    public int? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
