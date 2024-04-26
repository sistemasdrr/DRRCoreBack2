using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MBanco
{
    public string? BanCodigo { get; set; }

    public string? BanNombre { get; set; }

    public sbyte? Migra { get; set; }
}
