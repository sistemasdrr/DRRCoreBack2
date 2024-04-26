using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TControlAsignacione
{
    public int? Codigo { get; set; }

    public string? Usuario { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Acceso { get; set; }

    public int? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
