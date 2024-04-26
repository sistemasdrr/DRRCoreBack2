using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MPivot
{
    public string? Tabla { get; set; }

    public string? Campo { get; set; }

    public string? EmCodigo { get; set; }

    public int? EmDatoInt { get; set; }

    public decimal? EmDatoDec { get; set; }

    public string? EmDatoCad1 { get; set; }

    public string? EmDatoCad2 { get; set; }

    public sbyte? Migra { get; set; }
}
