using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyBackground
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public DateTime? ConstitutionDate { get; set; }

    public string? StartFunctionYear { get; set; }

    public string? OperationDuration { get; set; }

    public string? RegisterPlace { get; set; }

    public string? NotaryRegister { get; set; }

    public string? PublicRegister { get; set; }

    public decimal? CurrentPaidCapital { get; set; }

    public int? CurrentPaidCapitalCurrency { get; set; }

    public string? CurrentPaidCapitalComentary { get; set; }

    public string? Origin { get; set; }

    public string? IncreaceDateCapital { get; set; }

    public int? Currency { get; set; }

    public string? Traded { get; set; }

    public string? TradedBy { get; set; }

    public string? CurrentExchangeRate { get; set; }

    public DateTime? LastQueryRrpp { get; set; }

    public string? LastQueryRrppBy { get; set; }

    public string? Background { get; set; }

    public string? History { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? TradedByEng { get; set; }

    public virtual Currency? CurrencyNavigation { get; set; }

    public virtual Currency? CurrentPaidCapitalCurrencyNavigation { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }
}
