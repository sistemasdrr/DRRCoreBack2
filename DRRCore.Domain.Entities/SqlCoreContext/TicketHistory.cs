using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TicketHistory
{
    public int Id { get; set; }

    public int? IdTicket { get; set; }

    public string? UserFrom { get; set; }

    public string? UserTo { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public int? IdStatusTicket { get; set; }

    public string? AsignedTo { get; set; }

    public bool? Flag { get; set; }

    public int? NumberAssign { get; set; }

    public bool? Balance { get; set; }

    public bool? References { get; set; }

    public string? Observations { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual StatusTicket? IdStatusTicketNavigation { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
