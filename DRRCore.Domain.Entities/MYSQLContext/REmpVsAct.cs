using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsAct
{
    public string? EmCodigo { get; set; }

    public string? SecCodigo { get; set; }

    public string? RamCodigo { get; set; }

    public uint? RamBCodigo { get; set; }

    public byte? Migra { get; set; }
}
