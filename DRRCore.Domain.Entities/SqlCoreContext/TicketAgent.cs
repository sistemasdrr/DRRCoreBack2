using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TicketAgent
{
    public int Id { get; set; }

    public int? IdTicket { get; set; }

    public int? IdSpecialAgentBalancePrice { get; set; }

    public bool? HasBalance { get; set; }

    public virtual SpecialAgentBalancePrice? IdSpecialAgentBalancePriceNavigation { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
