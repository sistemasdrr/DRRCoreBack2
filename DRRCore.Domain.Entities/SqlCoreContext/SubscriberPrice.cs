using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SubscriberPrice
{
    public int Id { get; set; }

    public int? IdSubscriber { get; set; }

    public DateTime? Date { get; set; }

    public int? IdContinent { get; set; }

    public int? IdCountry { get; set; }

    public int? IdCurrency { get; set; }

    public decimal? PriceT1 { get; set; }

    public int? DayT1 { get; set; }

    public decimal? PriceT2 { get; set; }

    public int? DayT2 { get; set; }

    public decimal? PriceT3 { get; set; }

    public int? DayT3 { get; set; }

    public decimal? PriceB { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual Continent? IdContinentNavigation { get; set; }

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Currency? IdCurrencyNavigation { get; set; }

    public virtual Subscriber? IdSubscriberNavigation { get; set; }
}
