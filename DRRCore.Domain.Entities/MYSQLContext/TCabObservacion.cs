using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCabObservacion
{
    public long ObCodigo { get; set; }

    public long CupCodigo { get; set; }

    public sbyte? ObMotivo { get; set; }

    public DateTime? ObFecreg { get; set; }

    public DateTime? ObFecsol { get; set; }

    public DateTime? ObFecasig { get; set; }

    public DateTime? ObFecvcto { get; set; }

    public string? ObMensaje { get; set; }

    public int? ObEstado { get; set; }

    public string? ObResDrr { get; set; }

    public string? ObResAge { get; set; }

    public string? ObResAbo { get; set; }

    public string? ObResNinguno { get; set; }

    public string? ObCampo { get; set; }

    public string? ObConclusion { get; set; }

    public string? AboCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
