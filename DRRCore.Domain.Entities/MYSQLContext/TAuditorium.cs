using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TAuditorium
{
    public int AudCodigo { get; set; }

    public DateTime? AudFecha { get; set; }

    public string? AudAccion { get; set; }

    public string? AudTabla { get; set; }

    public string? PerCodigo { get; set; }

    public string? AudValor1 { get; set; }

    public string? AudValor2 { get; set; }

    public string? AudComentario { get; set; }

    public string? AudFlag { get; set; }

    public sbyte? Migra { get; set; }
}
