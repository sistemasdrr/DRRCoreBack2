using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Agent
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public string? Language { get; set; }

    public bool? State { get; set; }

    public bool? SpecialCase { get; set; }

    public bool? AgentSubscriber { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? IdCountry { get; set; }

    public string? Address { get; set; }

    public string? Supervisor { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public string? Fax { get; set; }

    public string? Observations { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public bool? Internal { get; set; }

    public bool? SpecialPrice { get; set; }

    public virtual ICollection<AgentInvoice> AgentInvoices { get; set; } = new List<AgentInvoice>();

    public virtual ICollection<AgentPrice> AgentPrices { get; set; } = new List<AgentPrice>();

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual ICollection<SpecialAgentBalancePrice> SpecialAgentBalancePrices { get; set; } = new List<SpecialAgentBalancePrice>();

    public virtual ICollection<SpecialPriceAgent> SpecialPriceAgents { get; set; } = new List<SpecialPriceAgent>();

    public virtual ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();
}
