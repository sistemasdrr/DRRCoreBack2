using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class StatusTicket
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Abrev { get; set; } = null!;

    public string Color { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
