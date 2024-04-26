using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCampoValidacion
{
    public string CamCodigo { get; set; } = null!;

    public string? CamDescripcion { get; set; }

    public int? CamEstado { get; set; }

    public sbyte? Migra { get; set; }
}
