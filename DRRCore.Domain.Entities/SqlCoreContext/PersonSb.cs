using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class PersonSb
{
    public int Id { get; set; }

    public int? IdPerson { get; set; }

    public string? AditionalCommentaryRiskCenter { get; set; }

    public string? DebtRecordedDate { get; set; }

    public decimal? ExchangeRate { get; set; }

    public string? BankingCommentary { get; set; }

    public string? ReferentOrAnalyst { get; set; }

    public DateTime? Date { get; set; }

    public string? LitigationsCommentary { get; set; }

    public string? CreditHistoryCommentary { get; set; }

    public decimal? GuaranteesOfferedNc { get; set; }

    public decimal? GuaranteesOfferedFc { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? SbsCommentary { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
