using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class OldTicket
{
    public int Id { get; set; }

    public string? Cupcodigo { get; set; }

    public DateTime? FechaPedido { get; set; }

    public DateTime? FechaDespacho { get; set; }

    public string? Abonado { get; set; }

    public string? Idioma { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public string? NombreSolicitado { get; set; }

    public string? NombreDespachado { get; set; }

    public string? TipoInforme { get; set; }

    public string? Tramite { get; set; }

    public string? Empresa { get; set; }

    public string? EmpresaPersona { get; set; }
}
