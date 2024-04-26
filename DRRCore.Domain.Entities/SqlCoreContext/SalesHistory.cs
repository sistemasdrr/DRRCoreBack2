using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SalesHistory
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public DateTime? Date { get; set; }

    public int? IdCurrency { get; set; }

    public decimal? Amount { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? EquivalentToDollars { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Currency? IdCurrencyNavigation { get; set; }
}
