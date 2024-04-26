using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class REmpVsAspLeg
{
    public string EmCodigo { get; set; } = null!;

    public string? EmFecest { get; set; }

    public string? EmIniope { get; set; }

    public string? EmRegen { get; set; }

    public string? EmRegenIng { get; set; }

    public string? EmNotari { get; set; }

    public string? EmRegist { get; set; }

    public string? EmRegistIng { get; set; }

    public string? EmDuraci { get; set; }

    public string? EmDuraciIng { get; set; }

    public string? EmCapini { get; set; }

    public string? EmCapiniIng { get; set; }

    public string? EmCapact { get; set; }

    public string? EmCapac1 { get; set; }

    public string? EmCapac1Ing { get; set; }

    public string? EmFecaum { get; set; }

    public string? EmFecaumIng { get; set; }

    public string? EmTipfecaum { get; set; }

    public string? EmTipfecaumIng { get; set; }

    public double? EmPatrim { get; set; }

    public string? EmPatri1 { get; set; }

    public string? EmPatri1Ing { get; set; }

    public double? EmVentas { get; set; }

    public string? EmVtamon { get; set; }

    public double? EmVtatipcam { get; set; }

    public string? EmTipacc { get; set; }

    public string? EmTipaccIng { get; set; }

    public string? EmValacc { get; set; }

    public string? EmValaccIng { get; set; }

    public string? EmMonacc { get; set; }

    public string? EmTipcam { get; set; }

    public string? EmTipcamIng { get; set; }

    public string? EmCotbol { get; set; }

    public string? EmAfilia { get; set; }

    public string? EmAntece { get; set; }

    public string? EmAnteceIng { get; set; }

    public string? EmEmprel { get; set; }

    public string? EmEmprelIng { get; set; }

    public string? EmComent { get; set; }

    public string? EmComentIng { get; set; }

    public string? PaiMone { get; set; }

    public string? EmRrppFecha { get; set; }

    public string? EmRrppPor { get; set; }

    public string? EmOrigen { get; set; }

    public string? EmOrigenIng { get; set; }

    public string? EmCapactComent { get; set; }

    public sbyte? Migra { get; set; }
}
