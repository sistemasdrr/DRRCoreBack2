using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class ReferencesHistory
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public string? Code { get; set; }

    public int? ValidReferences { get; set; }

    public int? IdTicket { get; set; }

    public string? Cycle { get; set; }

    public bool? IsComplement { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
