using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TConsulta
{
    public int? ConId { get; set; }

    public sbyte? ConTipo { get; set; }

    public string? ConPersonal { get; set; }

    public DateTime? ConFecha1 { get; set; }

    public string? ConUsuario1 { get; set; }

    public string? ConMensaje1 { get; set; }

    public DateTime? ConFecha2 { get; set; }

    public string? ConMensaje2 { get; set; }

    public DateTime? ConFecha3 { get; set; }

    public string? ConUsuario3 { get; set; }

    public string? ConMensaje3 { get; set; }

    public sbyte? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
