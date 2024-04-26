using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MUsuVsEmp
{
    public int UeCodigo { get; set; }

    public string? UrCodigo { get; set; }

    public string? EmCodigo { get; set; }

    public DateTime? UeFecdes { get; set; }

    public sbyte? Migra { get; set; }
}
