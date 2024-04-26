using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyWorker
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public int? Year { get; set; }

    public int? Number { get; set; }

    public string? Observation { get; set; }

    public string? ObservationEng { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }
}
