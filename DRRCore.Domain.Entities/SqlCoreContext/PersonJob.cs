using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class PersonJob
{
    public int Id { get; set; }

    public int? IdPerson { get; set; }

    public int? IdCompany { get; set; }

    public string? CurrentJob { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? MonthlyIncome { get; set; }

    public string? AnnualIncome { get; set; }

    public string? JobDetails { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? OldCode { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
