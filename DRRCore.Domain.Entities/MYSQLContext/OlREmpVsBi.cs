using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class OlREmpVsBi
{
    public string? EmCodigo { get; set; }

    public string? UsCodigo { get; set; }

    public string? BiTipo { get; set; }

    public string? BiNombre { get; set; }

    public double? BiValor { get; set; }
}
