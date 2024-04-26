using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RAboBan
{
    public string? AboCodigo { get; set; }

    public string? BanCodigo { get; set; }

    public string? MonCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
