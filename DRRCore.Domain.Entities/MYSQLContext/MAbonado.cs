using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Tabla De Abonados
/// </summary>
public partial class MAbonado
{
    public string AboCodigo { get; set; } = null!;

    public string AboNombre { get; set; } = null!;

    public string? AboSiglas { get; set; }

    public string? AboFeccre { get; set; }

    public string? AboDirecc { get; set; }

    public string? AboCiudad { get; set; }

    public string? AboTelefo { get; set; }

    public string? AboFax { get; set; }

    public string? AboWww { get; set; }

    public string? AboRegtrib { get; set; }

    public string? AboTipfac { get; set; }

    public string? AboEmail { get; set; }

    public string? AboContac { get; set; }

    public string? AboTipo { get; set; }

    public string? AboObserv { get; set; }

    public string? RubCodigo { get; set; }

    public string? PaiCodigo { get; set; }

    public string? IdiCodigo { get; set; }

    public string? AboInfpara { get; set; }

    public string? AboFacpara { get; set; }

    public string? AboDescri { get; set; }

    public string? MonCodigo { get; set; }

    public string? AboEmailci { get; set; }

    public string? AboTelefoci { get; set; }

    public string? AboContac2 { get; set; }

    public string? AboEmailc2 { get; set; }

    public string? AboTelefoc2 { get; set; }

    public string? AboEmailfact { get; set; }

    public string? AboTelefofact { get; set; }

    public string? AboPrftel { get; set; }

    public string? AboPrffax { get; set; }

    /// <summary>
    /// Talonario.... Si o No
    /// </summary>
    public string? AboCupone { get; set; }

    public string? AboTalona { get; set; }

    public string? AboLogin { get; set; }

    public string? AboPwd { get; set; }

    public DateTime? AboFecult { get; set; }

    public string? AboPublic { get; set; }

    public string? AboActivo { get; set; }

    public string? AboIndica { get; set; }

    public string? AboCremax { get; set; }

    public string AboRevnom { get; set; } = null!;

    /// <summary>
    /// Si - Precio Online 
    /// </summary>
    public string? AboPnonli { get; set; }

    public sbyte? Migra { get; set; }
}
