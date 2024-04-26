using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Provider
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? Name { get; set; }

    public int? IdCountry { get; set; }

    public string? Qualification { get; set; }

    public DateTime? Date { get; set; }

    public string? Telephone { get; set; }

    public string? AttendedBy { get; set; }

    public int? IdCurrency { get; set; }

    public string? MaximumAmount { get; set; }

    public string? MaximumAmountEng { get; set; }

    public string? TimeLimit { get; set; }

    public string? TimeLimitEng { get; set; }

    public string? Compliance { get; set; }

    public string? ClientSince { get; set; }

    public string? ClientSinceEng { get; set; }

    public string? ProductsTheySell { get; set; }

    public string? ProductsTheySellEng { get; set; }

    public string? AdditionalCommentary { get; set; }

    public string? AdditionalCommentaryEng { get; set; }

    public string? ReferentCommentary { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public string? QualificationEng { get; set; }

    public int? IdPerson { get; set; }

    public string? ComplianceEng { get; set; }

    public int? IdTicket { get; set; }

    public string? ReferentName { get; set; }

    public bool? Flag { get; set; }

    public DateTime? DateReferent { get; set; }

    public string? Ticket { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Currency? IdCurrencyNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
