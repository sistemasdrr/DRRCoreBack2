using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TNovedade
{
    public int NovNumero { get; set; }

    public DateTime? NovFecha { get; set; }

    public string? NovDescrip { get; set; }

    public string? NovVersion { get; set; }

    public sbyte? Migra { get; set; }
}
