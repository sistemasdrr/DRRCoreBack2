using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Ticket
{
    public int Id { get; set; }

    public int Number { get; set; }

    public int? IdSubscriber { get; set; }

    public bool? RevealName { get; set; }

    public string? NameRevealed { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? Language { get; set; }

    public string? QueryCredit { get; set; }

    public string? TimeLimit { get; set; }

    public string? AditionalData { get; set; }

    public string About { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public DateTime RealExpireDate { get; set; }

    public int? IdContinent { get; set; }

    public int? IdCountry { get; set; }

    public string ReportType { get; set; } = null!;

    public string ProcedureType { get; set; } = null!;

    public int? IdCompany { get; set; }

    public int? IdPerson { get; set; }

    public string? BusineesName { get; set; }

    public string? ComercialName { get; set; }

    public string? TaxType { get; set; }

    public string? TaxCode { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Telephone { get; set; }

    public int? Creditrisk { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public DateTime? DispatchtDate { get; set; }

    public string? RequestedName { get; set; }

    public decimal? Price { get; set; }

    public int? IdStatusTicket { get; set; }

    public string? DispatchedName { get; set; }

    public bool? Web { get; set; }

    public string? SubscriberIndications { get; set; }

    public string? Quality { get; set; }

    public bool? Wrong { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Continent? IdContinentNavigation { get; set; }

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }

    public virtual StatusTicket? IdStatusTicketNavigation { get; set; }

    public virtual Subscriber? IdSubscriberNavigation { get; set; }

    public virtual TicketAssignation? TicketAssignation { get; set; }

    public virtual ICollection<TicketFile> TicketFiles { get; set; } = new List<TicketFile>();

    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();

    public virtual ICollection<TicketObservation> TicketObservations { get; set; } = new List<TicketObservation>();

    public virtual TicketQuery? TicketQuery { get; set; }
}
