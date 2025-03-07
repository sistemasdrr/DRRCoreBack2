﻿using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class FinancialSituacion
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnglishName { get; set; }

    public string? Abreviation { get; set; }

    public string? Color { get; set; }

    public string? ReportCommentWithBalance { get; set; }

    public string? ReportCommentWithoutBalance { get; set; }

    public string? Observations { get; set; }

    public string? ApiCode { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<CompanyFinancialInformation> CompanyFinancialInformations { get; set; } = new List<CompanyFinancialInformation>();
}
