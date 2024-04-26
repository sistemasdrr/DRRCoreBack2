using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MySqlContextFotos;

public partial class REmpVsFoto
{
    public string? EmCodigo { get; set; }

    public byte[]? EfLocal { get; set; }

    public string? EfLocaltxt { get; set; }

    public string? EfLocaltxtIng { get; set; }

    public byte[]? EfLocal2 { get; set; }

    public string? EfLocal2txt { get; set; }

    public string? EfLocal2txtIng { get; set; }

    public byte[]? EfLocal3 { get; set; }

    public string? EfLocal3txt { get; set; }

    public string? EfLocal3txtIng { get; set; }

    public string? EfLocalGnralTxt { get; set; }

    public string? EfLocalGnralTxtIng { get; set; }

    public byte[]? EfLocal4 { get; set; }

    public string? EfLocal4txt { get; set; }

    public string? EfLocal4txtIng { get; set; }
    public int Migra { get; set; }
}
