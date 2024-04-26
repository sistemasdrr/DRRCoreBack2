using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

/// <summary>
/// Tabla De Clientes Web
/// </summary>
public partial class MCliente
{
    public string CliCodigo { get; set; } = null!;

    public string? CliNombre { get; set; }

    public string? CliSiglas { get; set; }

    public string? CliFeccre { get; set; }

    public string? CliDirecc { get; set; }

    public string? CliCiudad { get; set; }

    public string? CliTelefo { get; set; }

    public string? CliFax { get; set; }

    public string? CliWww { get; set; }

    public string? CliRegtrib { get; set; }

    public string? CliTipfac { get; set; }

    public string? CliEmail { get; set; }

    public string? CliContac { get; set; }

    public string? CliTipo { get; set; }

    public string? CliObserv { get; set; }

    public string? RubCodigo { get; set; }

    public string? PaiCodigo { get; set; }

    public string? IdiCodigo { get; set; }

    public string? CliInfpara { get; set; }

    public string? CliFacpara { get; set; }

    public string? CliDescri { get; set; }

    public string? MonCodigo { get; set; }

    public string? CliEmailci { get; set; }

    public string? CliTelefoci { get; set; }

    public string? CliContac2 { get; set; }

    public string? CliEmailc2 { get; set; }

    public string? CliTelefoc2 { get; set; }

    public string? CliEmailfact { get; set; }

    public string? CliTelefofact { get; set; }

    public string? CliPrftel { get; set; }

    public string? CliPrffax { get; set; }

    /// <summary>
    /// Talonario.... Si o No
    /// </summary>
    public string? CliCupone { get; set; }

    public string? CliTalona { get; set; }

    public string? CliLogin { get; set; }

    public string? CliPwd { get; set; }

    public DateTime? CliFecult { get; set; }

    public string? CliPublic { get; set; }

    public string? CliActivo { get; set; }

    public string? CliIndica { get; set; }

    public string? CliCremax { get; set; }

    public string? CliRevnom { get; set; }

    /// <summary>
    /// Si - Precio Online 
    /// </summary>
    public string? CliPnonli { get; set; }

    public sbyte? Migra { get; set; }
}
