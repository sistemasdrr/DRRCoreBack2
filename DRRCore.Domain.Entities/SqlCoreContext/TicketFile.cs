using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TicketFile
{
    public int Id { get; set; }

    public int? IdTicket { get; set; }

    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
