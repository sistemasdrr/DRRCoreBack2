using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyRelation
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public int? IdCompanyRelation { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public string? Relation { get; set; }

    public string? RelationEng { get; set; }

    public string? Participation { get; set; }

    public string? Commentary { get; set; }

    public string? CommentaryEng { get; set; }

    public string? StartDateStr { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Company? IdCompanyRelationNavigation { get; set; }
}
