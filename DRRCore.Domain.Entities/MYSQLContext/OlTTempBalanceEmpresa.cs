using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlTTempBalanceEmpresa
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? BaFecbal { get; set; }

    public string? BaAnobal { get; set; }

    public double? BaVentas { get; set; }

    public double? BaTotcor { get; set; }

    public double? BaTotcrr { get; set; }

    public double? BaTotpat { get; set; }
}
