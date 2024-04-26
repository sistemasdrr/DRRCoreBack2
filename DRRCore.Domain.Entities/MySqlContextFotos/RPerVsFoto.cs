using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MySqlContextFotos;

public partial class RPerVsFoto
{
    public string PeCodigo { get; set; } = null!;

    public byte[]? PfFoto { get; set; }

    public string? PfFotoTxt { get; set; }

    public string? PfFotoTxtIng { get; set; }

    public byte[]? PfFoto2 { get; set; }

    public string? PfFoto2Txt { get; set; }

    public string? PfFoto2TxtIng { get; set; }

    public byte[]? PfFoto3 { get; set; }

    public string? PfFoto3Txt { get; set; }

    public string? PfFoto3TxtIng { get; set; }

    public string? PfImprimir { get; set; }
}
