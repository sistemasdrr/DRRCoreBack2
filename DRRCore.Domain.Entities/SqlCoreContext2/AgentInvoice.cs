using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class AgentInvoice
{
    public int Id { get; set; }

    public int? IdInvoiceState { get; set; }

    public string? InvoiceCode { get; set; }

    public DateTime? InvoiceEmitDate { get; set; }

    public DateTime? InvoiceCancelDate { get; set; }

    public int? IdAgent { get; set; }

    public string? AgentCode { get; set; }

    public int? IdCurrency { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<AgentInvoiceDetail> AgentInvoiceDetails { get; set; } = new List<AgentInvoiceDetail>();

    public virtual Agent? IdAgentNavigation { get; set; }

    public virtual Currency? IdCurrencyNavigation { get; set; }

    public virtual InvoiceState? IdInvoiceStateNavigation { get; set; }
}
