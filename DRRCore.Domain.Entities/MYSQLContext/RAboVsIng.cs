using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RAboVsIng
{
    public int AiCodigo { get; set; }

    public string AboCodigo { get; set; } = null!;

    public DateTime AiFecing { get; set; }

    public DateTime AiFecsal { get; set; }

    public sbyte Migra { get; set; }
}
