using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TicketAssignation
{
    public int IdTicket { get; set; }

    public string? Commentary { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public int? IdUserLogin { get; set; }

    public int? IdEmployee { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual Ticket IdTicketNavigation { get; set; } = null!;
}
