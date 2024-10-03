using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class InternalInvoiceDetail
{
    public int Id { get; set; }

    public int? IdInternalInvoice { get; set; }

    public int? IdTicket { get; set; }

    public bool? IsComplement { get; set; }

    public string? Quality { get; set; }

    public decimal? Price { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual InternalInvoice? IdInternalInvoiceNavigation { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
