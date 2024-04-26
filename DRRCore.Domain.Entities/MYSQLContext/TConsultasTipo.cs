using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TConsultasTipo
{
    public sbyte? ConTipo { get; set; }

    public string? ConNombre { get; set; }

    public sbyte? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
