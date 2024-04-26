using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class RPerVsRep
{
    public string PeCodigo { get; set; } = null!;

    /// <summary>
    /// Codigo de la Reputacion Comercial
    /// </summary>
    public string RcCodigo { get; set; } = null!;

    public sbyte? Migra { get; set; }
}
