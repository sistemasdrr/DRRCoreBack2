using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Abreviation { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public int? Level { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<AgentPrice> AgentPrices { get; set; } = new List<AgentPrice>();

    public virtual ICollection<CompanyBackground> CompanyBackgroundCurrencyNavigations { get; set; } = new List<CompanyBackground>();

    public virtual ICollection<CompanyBackground> CompanyBackgroundCurrentPaidCapitalCurrencyNavigations { get; set; } = new List<CompanyBackground>();

    public virtual ICollection<FinancialBalance> FinancialBalances { get; set; } = new List<FinancialBalance>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();

    public virtual ICollection<SalesHistory> SalesHistories { get; set; } = new List<SalesHistory>();

    public virtual ICollection<SubscriberPrice> SubscriberPrices { get; set; } = new List<SubscriberPrice>();

    public virtual ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();
}
