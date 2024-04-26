using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsProv
{
    public string EmCodigo { get; set; } = null!;

    public int? ProvOrden { get; set; }

    public int ProvCorrelativo { get; set; }

    public string? ProvNombre { get; set; }

    public string? ProvTelefo { get; set; }

    public string? ProvPais { get; set; }

    public string? PaiCodigo { get; set; }

    public string? ProvMnLiCr { get; set; }

    public string? ProvLinCre { get; set; }

    public string? ProvLinCreIng { get; set; }

    public double? ProvNLinCre { get; set; }

    public string? ProvMnPrMe { get; set; }

    public string? ProvPrmMen { get; set; }

    public string? ProvPrmMenIng { get; set; }

    public double? ProvNPrmMen { get; set; }

    public string? ProvPlazos { get; set; }

    public string? ProvPlazosIng { get; set; }

    public string? ProvCumple { get; set; }

    public string? CumCodigo { get; set; }

    public string? ProvTiempo { get; set; }

    public string? ProvTiempoIng { get; set; }

    public string? ProvVenden { get; set; }

    public string? ProvVendenIng { get; set; }

    public string? ProvDeuAct { get; set; }

    public string? ProvEstado { get; set; }

    public string? ProvEstadoIng { get; set; }

    public string? ProvComen { get; set; }

    public string? ProvComenIng { get; set; }

    public string? ProvAtendio { get; set; }

    public DateTime? ProvFecha { get; set; }

    public string? ProvLlamo { get; set; }

    public string? ProvTexto { get; set; }

    public string? AudUsuario { get; set; }

    public DateTime? AudFecha { get; set; }

    public string? AudAccion { get; set; }

    public sbyte? Migra { get; set; }
}
