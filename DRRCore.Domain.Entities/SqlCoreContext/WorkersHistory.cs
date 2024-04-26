using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class WorkersHistory
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public int? NumberWorker { get; set; }

    public int? NumberYear { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? Observations { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }
}
