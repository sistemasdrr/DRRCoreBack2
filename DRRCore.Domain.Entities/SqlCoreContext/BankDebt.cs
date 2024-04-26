using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class BankDebt
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? BankName { get; set; }

    public string? Qualification { get; set; }

    public DateTime? DebtDate { get; set; }

    public decimal? DebtNc { get; set; }

    public decimal? DebtFc { get; set; }

    public string? Memo { get; set; }

    public string? MemoEng { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public int? IdPerson { get; set; }

    public string? QualificationEng { get; set; }

    public string? ApiCode { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
