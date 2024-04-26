using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TProfesion
{
    public string PfCodigo { get; set; } = null!;

    public string? PfNombre { get; set; }

    public string? PfObserv { get; set; }

    public string? PfCodigoIng { get; set; }

    public string? PfNombreIng { get; set; }

    public string? PfObservIng { get; set; }

    public sbyte? Migra { get; set; }
}
