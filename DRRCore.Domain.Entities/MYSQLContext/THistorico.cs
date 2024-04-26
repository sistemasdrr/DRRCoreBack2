using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class THistorico
{
    public int HisCodigo { get; set; }

    public string? AboCodigo { get; set; }

    public DateTime? AboFecing { get; set; }

    public string LblIpaddress { get; set; } = null!;

    public string LblHostName { get; set; } = null!;

    public string LblIpbehindProxy { get; set; } = null!;

    public sbyte Migra { get; set; }
}
