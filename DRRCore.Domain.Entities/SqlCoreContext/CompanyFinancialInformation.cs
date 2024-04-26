using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyFinancialInformation
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? Interviewed { get; set; }

    public string? WorkPosition { get; set; }

    public int? IdCollaborationDegree { get; set; }

    public string? InterviewCommentary { get; set; }

    public string? Auditors { get; set; }

    public int? IdFinancialSituacion { get; set; }

    public string? ReportCommentWithBalance { get; set; }

    public string? ReportCommentWithoutBalance { get; set; }

    public string? FinancialCommentarySelected { get; set; }

    public string? MainFixedAssets { get; set; }

    public string? AnalystCommentary { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public string? TabCommentary { get; set; }

    public virtual CollaborationDegree? IdCollaborationDegreeNavigation { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual FinancialSituacion? IdFinancialSituacionNavigation { get; set; }
}
