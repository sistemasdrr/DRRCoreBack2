using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TicketQuery
{
    public int IdTicket { get; set; }

    public DateTime? QueryDate { get; set; }

    public int? IdSubscriber { get; set; }

    public string Language { get; set; } = null!;

    public int? IdEmployee { get; set; }

    public string? Email { get; set; }

    public string? Message { get; set; }

    public string? Response { get; set; }

    public int Status { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual Subscriber? IdSubscriberNavigation { get; set; }

    public virtual Ticket IdTicketNavigation { get; set; } = null!;
}
