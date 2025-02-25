using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class ProductionClosure
{
    public int Id { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Code { get; set; }

    public string? Observations { get; set; }

    public string? Title { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }
}
