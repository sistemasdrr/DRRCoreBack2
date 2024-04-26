using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsFoto
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public byte[]? EfLocal { get; set; }

    public string? EfLocalTxt { get; set; }

    public byte[]? EfLocal2 { get; set; }

    public string? EfLocal2Txt { get; set; }

    public byte[]? EfLocal3 { get; set; }

    public string? EfLocal3Txt { get; set; }

    public string? EfLocalGnralTxt { get; set; }

    public byte[]? EfLocal4 { get; set; }

    public string? EfLocal4Txt { get; set; }
}
