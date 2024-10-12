using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SpecialPriceAgent
{
    public int Id { get; set; }

    public int? IdAgent { get; set; }

    public string? Code { get; set; }

    public string? Quality { get; set; }

    public decimal? PriceT1 { get; set; }

    public decimal? PriceT2 { get; set; }

    public decimal? PriceT3 { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Agent? IdAgentNavigation { get; set; }
}
