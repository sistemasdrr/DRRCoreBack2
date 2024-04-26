using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class BusinessBranch
{
    public int Id { get; set; }

    public string? EnglishName { get; set; }

    public string? Name { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? ApiCode { get; set; }

    public virtual ICollection<BusineesActivity> BusineesActivities { get; set; } = new List<BusineesActivity>();

    public virtual ICollection<CompanyBranch> CompanyBranches { get; set; } = new List<CompanyBranch>();
}
