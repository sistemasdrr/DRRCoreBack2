using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RUsuVsIng
{
    public int UiCodigo { get; set; }

    public DateTime? UiFecing { get; set; }

    public DateTime? UiFecsal { get; set; }

    public string? UsCodigo { get; set; }

    public sbyte? Migra { get; set; }
}
