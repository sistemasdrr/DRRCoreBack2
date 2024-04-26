using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MAuditorium
{
    public DateTime? Fecha { get; set; }

    public string? UsLogin { get; set; }

    public string? Accion { get; set; }

    public string? Valor1 { get; set; }

    public string? Valor2 { get; set; }

    public string? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
