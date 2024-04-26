using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MEmpresaNoWeb
{
    public int? Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string? EmCodigo { get; set; }

    public string? Usuario { get; set; }

    public string? Correo { get; set; }

    public string? Descripcion { get; set; }

    public sbyte? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
