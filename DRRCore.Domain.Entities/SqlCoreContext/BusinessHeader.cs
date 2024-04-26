using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class BusinessHeader
{
    public int Id { get; set; }

    public string? OldCode { get; set; }

    public string Name { get; set; } = null!;

    public string? SocialName { get; set; }

    public DateTime? LastSearched { get; set; }

    public string Language { get; set; } = null!;

    public string? TypeRegister { get; set; }

    public string? YearFundation { get; set; }

    public DateTime? ConstitutionDate { get; set; }

    public string? Quality { get; set; }

    public int? IdLegalPersonType { get; set; }

    public string? TaxTypeName { get; set; }

    public string? TaxTypeCode { get; set; }

    public int? IdLegalRegisterSituation { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual LegalPersonType? IdLegalPersonTypeNavigation { get; set; }

    public virtual LegalRegisterSituation? IdLegalRegisterSituationNavigation { get; set; }
}
