using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class BillinPersonal
{
    public int Id { get; set; }

    public int? IdEmployee { get; set; }

    public string? Code { get; set; }

    public bool? Commission { get; set; }

    public string? ReportType { get; set; }

    public string? Quality { get; set; }

    public bool? IsComplement { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }
}
