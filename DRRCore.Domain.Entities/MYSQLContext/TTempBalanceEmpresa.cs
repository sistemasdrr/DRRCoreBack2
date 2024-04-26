using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTempBalanceEmpresa
{
    public string EmCodigo { get; set; } = null!;

    public string UsCodigo { get; set; } = null!;

    public string? BaFecbal { get; set; }

    public string? BaAnobal { get; set; }

    public double? BaVentas { get; set; }

    public double? BaTotcor { get; set; }

    public double? BaTotcrr { get; set; }

    public double? BaTotpat { get; set; }
}
