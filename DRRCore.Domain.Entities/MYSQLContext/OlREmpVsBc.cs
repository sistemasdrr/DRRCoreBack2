using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsBc
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? BcNombre { get; set; }

    public string? BcSector { get; set; }

    public string? BcTelefo { get; set; }

    public string? BcNroCta { get; set; }

    public string? BcMonNac { get; set; }

    public string? BcMonExt { get; set; }
}
