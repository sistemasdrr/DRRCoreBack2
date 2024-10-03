using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class SubscriberInvoiceDetail
{
    public int Id { get; set; }

    public int? IdSubscriberInvoice { get; set; }

    public int? IdTicket { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual SubscriberInvoice? IdSubscriberInvoiceNavigation { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
