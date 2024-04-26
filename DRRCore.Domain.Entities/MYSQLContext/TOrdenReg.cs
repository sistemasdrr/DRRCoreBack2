using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class TOrdenReg
{
    public string? OrdTabla { get; set; }

    public int? OrdNumero { get; set; }

    public string? OrdValor1 { get; set; }

    public string? OrdValor2 { get; set; }

    public double? OrdValor3 { get; set; }

    public double? OrdValor4 { get; set; }

    public sbyte? Migra { get; set; }
}
