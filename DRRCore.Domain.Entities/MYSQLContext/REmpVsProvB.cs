using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsProvB
{
    public int ProvCodigo { get; set; }

    public string? EmCodigo { get; set; }

    public int? ProvOrden { get; set; }

    public string? ProvNombre { get; set; }

    public string? PaiCodigo { get; set; }

    public string? ProvMnLiCr { get; set; }

    public string? ProvLinCre { get; set; }

    public string? ProvPlazos { get; set; }

    public string? ProvCumple { get; set; }

    public string? ProvCumpleIng { get; set; }

    public string? ProvTiempo { get; set; }

    public string? ProvPais { get; set; }

    public string? ProvLinCreIng { get; set; }

    public string? ProvPlazosIng { get; set; }

    public string? ProvTiempoIng { get; set; }

    public sbyte? Migra { get; set; }
}
