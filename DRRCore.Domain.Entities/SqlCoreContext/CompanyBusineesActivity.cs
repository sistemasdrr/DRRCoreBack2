using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyBusineesActivity
{
    public int Id { get; set; }

    public int? IdCompanyBranch { get; set; }

    public int? IdCountry { get; set; }

    public string ImportOrExport { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual CompanyBranch? IdCompanyBranchNavigation { get; set; }
}
