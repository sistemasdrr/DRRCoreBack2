using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class Tempo
{
    public string? EmEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Rfc { get; set; }

    public string? Proceso { get; set; }
}
