using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsProv
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? ProvNombre { get; set; }

    public string? ProvPais { get; set; }

    public string? ProvTelefo { get; set; }

    public string? ProvLinCre { get; set; }

    public string? ProvDeuAct { get; set; }

    public string? ProvVenden { get; set; }

    public string? ProvTiempo { get; set; }

    public string? ProvPlazos { get; set; }

    public string? ProvCumple { get; set; }

    public string? ProvComent { get; set; }

    public string? ProvMensual { get; set; }

    public string? ProvEstado { get; set; }

    public int? ProvOrden { get; set; }
}
