using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class PersonalPrice
{
    public int Id { get; set; }

    public int? IdPersonal { get; set; }

    public string? Quality { get; set; }

    public string? Language { get; set; }

    public string? ReportType { get; set; }

    public decimal? Price { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Personal? IdPersonalNavigation { get; set; }
}
