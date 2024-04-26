using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanySb
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public int? IdOpcionalCommentarySbs { get; set; }

    public string? AditionalCommentaryRiskCenter { get; set; }

    public DateTime? DebtRecordedDate { get; set; }

    public decimal? ExchangeRate { get; set; }

    public string? BankingCommentary { get; set; }

    public string? EndorsementsObservations { get; set; }

    public string? ReferentOrAnalyst { get; set; }

    public DateTime? Date { get; set; }

    public string? LitigationsCommentary { get; set; }

    public string? CreditHistoryCommentary { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public decimal? GuaranteesOfferedNc { get; set; }

    public decimal? GuaranteesOfferedFc { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual OpcionalCommentarySb? IdOpcionalCommentarySbsNavigation { get; set; }
}
