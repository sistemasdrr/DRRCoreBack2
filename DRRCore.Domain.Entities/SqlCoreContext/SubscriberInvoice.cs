using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SubscriberInvoice
{
    public int Id { get; set; }

    public int? IdInvoiceState { get; set; }

    public string? InvoiceCode { get; set; }

    public DateTime? InvoiceEmitDate { get; set; }

    public DateTime? InvoiceCancelDate { get; set; }

    public int? IdSubscriber { get; set; }

    public string? SubscriberCode { get; set; }

    public int? IdCurrency { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Type { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public bool? IgvFlag { get; set; }

    public decimal? IgvAmount { get; set; }

    public virtual Currency? IdCurrencyNavigation { get; set; }

    public virtual InvoiceState? IdInvoiceStateNavigation { get; set; }

    public virtual Subscriber? IdSubscriberNavigation { get; set; }

    public virtual ICollection<InvoiceFile> InvoiceFiles { get; set; } = new List<InvoiceFile>();

    public virtual ICollection<SubscriberInvoiceDetail> SubscriberInvoiceDetails { get; set; } = new List<SubscriberInvoiceDetail>();
}
