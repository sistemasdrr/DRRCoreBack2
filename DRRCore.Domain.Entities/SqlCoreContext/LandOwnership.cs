using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class LandOwnership
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? EnglishName { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<CompanyBranch> CompanyBranches { get; set; } = new List<CompanyBranch>();
}
