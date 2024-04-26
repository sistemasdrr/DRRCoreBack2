using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TCupon3
{
    public long CupCodigo { get; set; }

    public DateTime? CupFecped { get; set; }

    public DateTime? CupFecdes { get; set; }

    public string? AboCodigo { get; set; }

    public string? IdiCodigo { get; set; }

    public DateTime? CupFecvcto { get; set; }

    public string? CupRevnom { get; set; }

    public string? CupOpicred { get; set; }

    public string? CupPlazos { get; set; }

    public string CupNroord { get; set; } = null!;

    public string? CupMoncon { get; set; }

    public string CupRefabo { get; set; } = null!;

    public string? CupNomsol { get; set; }

    public string? CupNomdes { get; set; }

    public string? CupDirecc { get; set; }

    public string? CupCiudad { get; set; }

    public string? CupDepart { get; set; }

    public string? CupCodpos { get; set; }

    public string? CupRefere { get; set; }

    public string? CupTipinf { get; set; }

    public string? CupRegtrib { get; set; }

    public string? CupTraduc { get; set; }

    public string? CupContac { get; set; }

    public string? TramCodigo { get; set; }

    /// <summary>
    /// Tipo de informe (Tipo A,B, Rubro 1, Rubro 2, 3,4)
    /// </summary>
    public string? CupTipdes { get; set; }

    public string? PerCodigo { get; set; }

    public string? EpCodigo { get; set; }

    public string? PaiCodigo { get; set; }

    public string? CupTelefo { get; set; }

    public string? CupFax { get; set; }

    public string? CupObserv { get; set; }

    public string? CupRecome { get; set; }

    public double? CupMonto { get; set; }

    public string? CupMoteli { get; set; }

    /// <summary>
    /// Usuario que elimina
    /// </summary>
    public string? CupUsueli { get; set; }

    public string? CupEstado { get; set; }

    public string? CupSiglas { get; set; }

    public string? CalCodigo { get; set; }

    public double? CupGasadm { get; set; }

    public string? CupObtbal { get; set; }

    /// <summary>
    /// Prefijo del REG. TRIB
    /// </summary>
    public string? PreRegtrib { get; set; }

    public string? EmpPer { get; set; }

    public int? CupActivo { get; set; }

    public double? PrecioAgente { get; set; }

    public double? PrecioReportero { get; set; }

    public double? PrecioTraductora { get; set; }

    public double? PrecioDigitadora { get; set; }

    public string? Rep { get; set; }

    public string? Dig { get; set; }

    public string? Tra { get; set; }

    public string? Age { get; set; }

    public string? Balance { get; set; }

    public string? CalRep { get; set; }

    public string? CalDig { get; set; }

    public string? CalTra { get; set; }

    public string? CalAge { get; set; }

    public string? Flag { get; set; }

    public sbyte? Migra { get; set; }
}
