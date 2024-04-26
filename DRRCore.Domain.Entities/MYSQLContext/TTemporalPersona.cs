using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TTemporalPersona
{
    public string PeCodigo { get; set; } = null!;

    /// <summary>
    /// PARA EL REPORTE
    /// </summary>
    public string? PeTitulo1 { get; set; }

    public string? PeTitulo2 { get; set; }

    public string? PeTitulo3 { get; set; }

    public string? PeTitulo4 { get; set; }

    public string? PeTitulo5 { get; set; }

    public string? PeTitulo6 { get; set; }

    public string? PeTitulo7 { get; set; }

    public string? PeTitulo8 { get; set; }

    /// <summary>
    /// PARA EL REPORTE
    /// </summary>
    public string? PeCampo1 { get; set; }

    public string? PeCampo2 { get; set; }

    public string? PeCampo3 { get; set; }

    public string? PeCampo4 { get; set; }

    public string? PeCampo5 { get; set; }

    public string? PeCampo6 { get; set; }

    public string? PeCampo7 { get; set; }

    public string? PeCampo8 { get; set; }

    public string? UsCodigo { get; set; }

    public string? PeLogico { get; set; }

    public string? PeNombre { get; set; }

    public int? CsoCodigo { get; set; }

    public string? CsoNombre { get; set; }

    public DateTime? PeFecinf { get; set; }

    public string? PeVer { get; set; }

    public sbyte? IdiCodigo { get; set; }

    public string? CupTipinf { get; set; }

    public string? CupCodigo { get; set; }

    public string? CupFecped { get; set; }

    public string? CupNomsol { get; set; }

    public string? CupNroref { get; set; }

    public string? AboCodigo { get; set; }

    public string? ErCodigo { get; set; }

    public string? ErNombre { get; set; }

    public string? ErNombreIng { get; set; }

    public string? TramCodigo { get; set; }

    public string? TramNombre { get; set; }

    public string? PerCodage { get; set; }

    public string? PerCodrep { get; set; }

    public string? PerCoddig { get; set; }

    public string? PerCodtra { get; set; }

    public string? PerCodref { get; set; }

    /// <summary>
    /// &apos;Fecha de devolucion de la Traductora
    /// </summary>
    public DateTime? AtFecdev { get; set; }

    /// <summary>
    /// &apos;Fecha de devolucion de la Traductora
    /// </summary>
    public DateTime? PeFecref { get; set; }

    /// <summary>
    /// &apos;Fecha de devolucion de la Traductora
    /// </summary>
    public string? PerCodsup { get; set; }

    public string? EsCodigo { get; set; }

    public string? EsNombre { get; set; }

    public string? PeFecest { get; set; }

    public string? PeRefere { get; set; }

    public string? PePedido { get; set; }

    public string? PeDirecc { get; set; }

    public string? PeTipvia { get; set; }

    public string? PeNomvia { get; set; }

    public string? PePiso { get; set; }

    public string? PeDistri { get; set; }

    public string? PeCiudad { get; set; }

    public string? PeDepart { get; set; }

    public string? PeCodpos { get; set; }

    public string? PaiDoctrb { get; set; }

    public string? PeRegtri { get; set; }

    public string? PaiCodigo { get; set; }

    public string? PaiNombreCas { get; set; }

    public string? PePrftlf { get; set; }

    public string? PeTelefo { get; set; }

    public string? PeCelula { get; set; }

    public string? PeEmail { get; set; }

    public string? PeNacion { get; set; }

    public string? PeNacionIng { get; set; }

    public string? PeFecnac { get; set; }

    public string? PeFecnacIng { get; set; }

    public string? PeLugnac { get; set; }

    public string? SexCodigo { get; set; }

    public string? SexDescri { get; set; }

    public string? SexDescriIng { get; set; }

    public string? PeGrains { get; set; }

    public string? PeGrainsIng { get; set; }

    public string? PaiDocide { get; set; }

    public string? PeCompri { get; set; }

    public string? PeDocide { get; set; }

    /// <summary>
    /// Estado Civil
    /// </summary>
    public string? EcCodigo { get; set; }

    public string? EcNombre { get; set; }

    public string? PeRelciv { get; set; }

    public string? PeRelcivIng { get; set; }

    public string? PeHijos { get; set; }

    public string? PeHijosIng { get; set; }

    public string? PePadre { get; set; }

    public string? PePadreVive { get; set; }

    public string? PeMadre { get; set; }

    public string? PeMadreVive { get; set; }

    public string? PeColegio { get; set; }

    public string? PeColegioAnno { get; set; }

    public string? PeClub { get; set; }

    public string? PeAsegur { get; set; }

    public int? PpCodigo { get; set; }

    public string? PpAbrevi { get; set; }

    public string? PePerRel { get; set; }

    public string? PePerRelIng { get; set; }

    public string? PfCodigo { get; set; }

    public string? PfNombre { get; set; }

    public string? PfNombreIng { get; set; }

    /// <summary>
    /// Comentario de Identificacion
    /// </summary>
    public string? PeComide { get; set; }

    public string? PeComideIng { get; set; }

    /// <summary>
    /// Comentario de Prensa
    /// </summary>
    public string? PePrensa { get; set; }

    public string? PePrensasel { get; set; }

    public string? PePrensaIng { get; set; }

    public string? PePrensaselIng { get; set; }

    public int? PeLogpre { get; set; }

    public string? PeTipdom { get; set; }

    public string? PeTipdomIng { get; set; }

    public string? PeValdom { get; set; }

    public string? PeValdomIng { get; set; }

    /// <summary>
    /// Condiciones Domiciliarias
    /// </summary>
    public string? PeCondoc { get; set; }

    public string? PeCondocIng { get; set; }

    public string? PeObsdom { get; set; }

    public string? PeIngMe2Ing { get; set; }

    public string? PeOtrrec { get; set; }

    public string? PeOtrRecIng { get; set; }

    public string? PeObscen { get; set; }

    public string? PeBanco { get; set; }

    public string? PeBancoIng { get; set; }

    public string? PeComer { get; set; }

    public string? PeComerIng { get; set; }

    public string? PeAntcred { get; set; }

    public string? PeAntcredIng { get; set; }

    public string? PeCenrie { get; set; }

    public string? PeCenRieIng { get; set; }

    public string? PeAntece { get; set; }

    public string? PeAnteceIng { get; set; }

    public string? PeAntCua { get; set; }

    public string? PeAntCuaIng { get; set; }

    public string? PeObserv { get; set; }

    public string? PeObservIng { get; set; }

    public string? CrCodigo { get; set; }

    public string? CrNombre { get; set; }

    public string? PaCodigo { get; set; }

    public string? PaNombre { get; set; }

    public string? RcCodigo { get; set; }

    public string? RcNombre { get; set; }

    public string? CoCodigo { get; set; }

    public string? CoNombre { get; set; }

    public string? PeComRep { get; set; }

    public string? PeComRepIng { get; set; }

    public string? PeCombie { get; set; }

    public string? PeCombieIng { get; set; }

    public int? PeFoto { get; set; }

    /// <summary>
    /// Indicador de Referencias
    /// </summary>
    public int? PeLrefer { get; set; }

    public int? PeLbienes { get; set; }

    /// <summary>
    /// Indicador de Relacionados
    /// </summary>
    public int? PeLrelac { get; set; }

    /// <summary>
    /// Indicador Refiere
    /// </summary>
    public int? PeLrefier { get; set; }

    public string? PeUsuario { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PaiNombreTrab { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeComprov { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeComprovIng { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeSupban { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeSupbanIng { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeSubacu { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeSubacuIng { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeComlit { get; set; }

    /// <summary>
    /// Pais del Centro de Trabajo
    /// </summary>
    public string? PeComlitIng { get; set; }

    public string? PeFecreg { get; set; }

    public string? PeCalsbs { get; set; }

    public string? PeCalsbsIng { get; set; }

    public double? PeGaomn { get; set; }

    public double? PeGaome { get; set; }

    public string? PeNument { get; set; }

    public string? PeFecsbs { get; set; }

    public string? PePresta { get; set; }

    public string? PePrestaMe { get; set; }

    public string? PeDescue { get; set; }

    public string? PeDescueMe { get; set; }

    public string? PeArrfin { get; set; }

    public string? PeArrfinMe { get; set; }

    public string? PeComexte { get; set; }

    public string? PeComexteMe { get; set; }

    public string? PeCtacte { get; set; }

    public string? PeCtacteMe { get; set; }

    public string? PeFactor { get; set; }

    public string? PeFactorMe { get; set; }

    public string? PeTarcred { get; set; }

    public string? PeTarcredMe { get; set; }

    public string? PeOtrdeu { get; set; }

    public string? PeOtrdeuMe { get; set; }

    public string? PeOtros { get; set; }

    public string? PeOtrosIng { get; set; }

    public string? PeTototr { get; set; }

    public string? PeTototrMe { get; set; }

    public string? PeTotdeu { get; set; }

    public string? PeTotdeuMe { get; set; }

    public string? PeOtros2 { get; set; }

    public string? PeOtros2Ing { get; set; }

    public string? PeTototr2 { get; set; }

    public string? PeTototr2Me { get; set; }

    public string? TiCodigo { get; set; }

    public string? TiNombre { get; set; }

    public string? TiNombreIng { get; set; }

    public string? TiAbrevia { get; set; }

    public string? TiAbreviaIng { get; set; }

    public double? PeTcsbs { get; set; }

    public string? PeAlias { get; set; }

    public string? PeRelcivDni { get; set; }

    public string? PeSer { get; set; }

    public string? PeCorrecto { get; set; }

    public string? PeDireccCome { get; set; }

    public string? PeNombreCome { get; set; }

    public string? CalCodigoPer { get; set; }
}
