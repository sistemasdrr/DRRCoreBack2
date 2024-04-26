using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class DetailsTicketObservation
{
    public int Id { get; set; }

    public string? AssignedTo { get; set; }

    public int? IdTicketObservations { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual TicketObservation? IdTicketObservationsNavigation { get; set; }
}
