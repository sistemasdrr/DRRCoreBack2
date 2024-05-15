using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class AgentInvoiceDetail
{
    public int Id { get; set; }

    public int? IdAgentInvoice { get; set; }

    public int? IdTicketHistory { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual AgentInvoice? IdAgentInvoiceNavigation { get; set; }

    public virtual TicketHistory? IdTicketHistoryNavigation { get; set; }
}
