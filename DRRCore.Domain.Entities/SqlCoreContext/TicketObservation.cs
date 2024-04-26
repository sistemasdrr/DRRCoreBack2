using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TicketObservation
{
    public int Id { get; set; }

    public string? About { get; set; }

    public int? IdCompany { get; set; }

    public int? IdPerson { get; set; }

    public int? IdSubscriber { get; set; }

    public int? IdReason { get; set; }

    public string? Message { get; set; }

    public string? Conclusion { get; set; }

    public int? IdStatusTicketObservations { get; set; }

    public string? Cc { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public DateTime? AsignedDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? SolutionDate { get; set; }

    public int? IdTicket { get; set; }

    public bool? RespDrr { get; set; }

    public bool? RespAg { get; set; }

    public bool? RespCl { get; set; }

    public virtual ICollection<DetailsTicketObservation> DetailsTicketObservations { get; set; } = new List<DetailsTicketObservation>();

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }

    public virtual Reason? IdReasonNavigation { get; set; }

    public virtual StatusTicketObservation? IdStatusTicketObservationsNavigation { get; set; }

    public virtual Subscriber? IdSubscriberNavigation { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
