using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Endorsement
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? EndorsementName { get; set; }

    public string? Ruc { get; set; }

    public decimal? AmountUs { get; set; }

    public decimal? AmountNc { get; set; }

    public DateTime? Date { get; set; }

    public string? ReceivingEntity { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }
}
