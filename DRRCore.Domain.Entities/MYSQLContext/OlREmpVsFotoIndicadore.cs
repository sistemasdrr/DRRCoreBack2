using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsFotoIndicadore
{
    public string? Codigo { get; set; }

    public byte[]? CrCodigoImg { get; set; }

    public string? UsCodigo { get; set; }
}
