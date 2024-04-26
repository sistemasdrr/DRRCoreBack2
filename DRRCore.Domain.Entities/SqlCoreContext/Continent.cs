using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Continent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string EnglishName { get; set; } = null!;

    public bool? Flag { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<AgentPrice> AgentPrices { get; set; } = new List<AgentPrice>();

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

    public virtual ICollection<SubscriberPrice> SubscriberPrices { get; set; } = new List<SubscriberPrice>();

    public virtual ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
