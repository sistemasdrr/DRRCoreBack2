using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SpecialAgentBalancePrice
{
    public int Id { get; set; }

    public int? IdAgent { get; set; }

    public string Description { get; set; } = null!;

    public string? Quality { get; set; }

    public decimal Price { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Agent? IdAgentNavigation { get; set; }
}
