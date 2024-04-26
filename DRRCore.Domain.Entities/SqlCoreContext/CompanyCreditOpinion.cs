using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyCreditOpinion
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public bool? CreditRequest { get; set; }

    public string? ConsultedCredit { get; set; }

    public string? SuggestedCredit { get; set; }

    public string? CurrentCommentary { get; set; }

    public string? PreviousCommentary { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }
}
