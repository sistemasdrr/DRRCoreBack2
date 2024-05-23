using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class InvoiceState
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnglishName { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<AgentInvoice> AgentInvoices { get; set; } = new List<AgentInvoice>();

    public virtual ICollection<SubscriberInvoice> SubscriberInvoices { get; set; } = new List<SubscriberInvoice>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
