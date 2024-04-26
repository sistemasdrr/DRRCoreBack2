using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MPersona
{
    public string PeCodigo { get; set; } = null!;

    /// <summary>
    /// 1 Si existe y 2 si se elimina
    /// </summary>
    public int? PeActivo { get; set; }

    public string? PeNombre { get; set; }

    public int? CsoCodigo { get; set; }

    public string? PeNomsol { get; set; }

    public DateTime? PeFecinf { get; set; }

    public int? IdiCodigo { get; set; }

    public string? PeUsuario { get; set; }

    public string? EsCodigo { get; set; }

    public string? PeFecest { get; set; }

    public string? PeLogico { get; set; }

    public string? PeDirecc { get; set; }

    public string? PeTipvia { get; set; }

    public string? PeNomvia { get; set; }

    public string? PePiso { get; set; }

    public string? PeDistri { get; set; }

    public string? PeCiudad { get; set; }

    public string? PeDepart { get; set; }

    public string? PeCodpos { get; set; }

    public string? PeRegtri { get; set; }

    public string? PaiCodigo { get; set; }

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

    public string? PeGrains { get; set; }

    public string? PeGrainsIng { get; set; }

    public string? PaiDocide { get; set; }

    /// <summary>
    /// Comentario Privado, No se imprime
    /// </summary>
    public string? PeCompri { get; set; }

    public string? TiCodigo { get; set; }

    public string? PeDocide { get; set; }

    public string? EcCodigo { get; set; }

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

    /// <summary>
    /// Condicion de Prensa
    /// </summary>
    public int? PeLogpre { get; set; }

    /// <summary>
    /// Condicion de Prensa
    /// </summary>
    public string? PeTipdom { get; set; }

    /// <summary>
    /// Condicion de Prensa
    /// </summary>
    public string? PeTipdomIng { get; set; }

    /// <summary>
    /// Condicion de Prensa
    /// </summary>
    public string? PeValdom { get; set; }

    /// <summary>
    /// Condicion de Prensa
    /// </summary>
    public string? PeValdomIng { get; set; }

    /// <summary>
    /// Condiciones Domiciliarias
    /// </summary>
    public string? PeCondoc { get; set; }

    public string? PeCondocIng { get; set; }

    public string? PeObsdom { get; set; }

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

    public string? PeAntcua { get; set; }

    public string? PeAntCuaIng { get; set; }

    public string? PeObserv { get; set; }

    public string? PeObservIng { get; set; }

    /// <summary>
    /// Comentario de Bienes
    /// </summary>
    public string? PeCombie { get; set; }

    public string? PeCombieIng { get; set; }

    public string? CrCodigo { get; set; }

    public string? PaCodigo { get; set; }

    public string? RcCodigo { get; set; }

    public string? CoCodigo { get; set; }

    public string? PeComRep { get; set; }

    public string? PeComRepIng { get; set; }

    public int? PeFoto { get; set; }

    /// <summary>
    /// Indicador de Referencias
    /// </summary>
    public sbyte? PeLrefer { get; set; }

    /// <summary>
    /// Indicador de Bienes/Propiedades
    /// </summary>
    public sbyte? PeLbienes { get; set; }

    /// <summary>
    /// Indicador de Relacionados
    /// </summary>
    public sbyte? PeLrelac { get; set; }

    /// <summary>
    /// Indicador de Refiere(Participado)
    /// </summary>
    public sbyte? PeLrefier { get; set; }

    public string? PerCodrep { get; set; }

    public string? PerCodage { get; set; }

    public string? PerCodtra { get; set; }

    public string? PerCoddig { get; set; }

    public string? PerCodref { get; set; }

    public string? PeFecref { get; set; }

    public string? CupTipinf { get; set; }

    public string? PerCodsup { get; set; }

    public string? CupNomsol { get; set; }

    public string? CupCodigo { get; set; }

    public string? CupFecped { get; set; }

    public string? CupNroref { get; set; }

    public string? AboCodigo { get; set; }

    public string? ErCodigo { get; set; }

    public string? TramNombre { get; set; }

    public string? PeComprov { get; set; }

    public string? PeComprovIng { get; set; }

    public string? PeSupban { get; set; }

    public string? PeSupbanIng { get; set; }

    public string? PeSubacu { get; set; }

    public string? PeSubacuIng { get; set; }

    public string? PeComlit { get; set; }

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

    public int? PeLogdomici { get; set; }

    public int? PeLogcentra { get; set; }

    public int? PeLogactivi { get; set; }

    public int? PeLogpropi { get; set; }

    public int? PeLogrefere { get; set; }

    public int? PeLogantece { get; set; }

    public int? PeLogfoto { get; set; }

    public int? PeLogrelaci { get; set; }

    public double? PeTcsbs { get; set; }

    public string? PeAlias { get; set; }

    public string? PeRelcivDni { get; set; }

    public string? PeSer { get; set; }

    public string? PeCorrecto { get; set; }

    public string? PeParainfo { get; set; }

    public string? PeDireccCome { get; set; }

    public string? PeNombreCome { get; set; }

    public string? CalCodigoPer { get; set; }

    public sbyte? Migra { get; set; }
}
