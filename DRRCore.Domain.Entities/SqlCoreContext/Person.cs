using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Person
{
    public int Id { get; set; }

    public string? OldCode { get; set; }

    public string Fullname { get; set; } = null!;

    public DateTime? LastSearched { get; set; }

    public string? Language { get; set; }

    public string? Nationality { get; set; }

    public string? BirthDate { get; set; }

    public string? BirthPlace { get; set; }

    public int? IdDocumentType { get; set; }

    public string? CodeDocumentType { get; set; }

    public string? TaxTypeName { get; set; }

    public string? TaxTypeCode { get; set; }

    public int? IdLegalRegisterSituation { get; set; }

    public string? Address { get; set; }

    public string? Cp { get; set; }

    public string? City { get; set; }

    public string? OtherDirecctions { get; set; }

    public string? TradeName { get; set; }

    public int? IdCountry { get; set; }

    public string? CodePhone { get; set; }

    public string? NumberPhone { get; set; }

    public int? IdCivilStatus { get; set; }

    public string? RelationshipWith { get; set; }

    public int? RelationshipDocumentType { get; set; }

    public string? RelationshipCodeDocument { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? Email { get; set; }

    public string? Cellphone { get; set; }

    public string? ClubMember { get; set; }

    public string? Insurance { get; set; }

    public string? NewsCommentary { get; set; }

    public bool? PrintNewsCommentary { get; set; }

    public string? PrivateCommentary { get; set; }

    public string? ReputationCommentary { get; set; }

    public int? IdCreditRisk { get; set; }

    public int? IdPaymentPolicy { get; set; }

    public int? IdReputation { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public bool? OnWeb { get; set; }

    public int? IdPersonSituation { get; set; }

    public string? Profession { get; set; }

    public string? Quality { get; set; }

    public bool? Print { get; set; }

    public bool? HaveReport { get; set; }

    public virtual ICollection<BankDebt> BankDebts { get; set; } = new List<BankDebt>();

    public virtual ICollection<ComercialLatePayment> ComercialLatePayments { get; set; } = new List<ComercialLatePayment>();

    public virtual ICollection<CompanyPartner> CompanyPartners { get; set; } = new List<CompanyPartner>();

    public virtual CivilStatus? IdCivilStatusNavigation { get; set; }

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual CreditRisk? IdCreditRiskNavigation { get; set; }

    public virtual DocumentType? IdDocumentTypeNavigation { get; set; }

    public virtual LegalRegisterSituation? IdLegalRegisterSituationNavigation { get; set; }

    public virtual PaymentPolicy? IdPaymentPolicyNavigation { get; set; }

    public virtual PersonSituation? IdPersonSituationNavigation { get; set; }

    public virtual Reputation? IdReputationNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PersonActivity> PersonActivities { get; set; } = new List<PersonActivity>();

    public virtual ICollection<PersonGeneralInformation> PersonGeneralInformations { get; set; } = new List<PersonGeneralInformation>();

    public virtual ICollection<PersonHistory> PersonHistories { get; set; } = new List<PersonHistory>();

    public virtual ICollection<PersonHome> PersonHomes { get; set; } = new List<PersonHome>();

    public virtual ICollection<PersonImage> PersonImages { get; set; } = new List<PersonImage>();

    public virtual ICollection<PersonJob> PersonJobs { get; set; } = new List<PersonJob>();

    public virtual ICollection<PersonProperty> PersonProperties { get; set; } = new List<PersonProperty>();

    public virtual ICollection<PersonSb> PersonSbs { get; set; } = new List<PersonSb>();

    public virtual ICollection<PhotoPerson> PhotoPeople { get; set; } = new List<PhotoPerson>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();

    public virtual DocumentType? RelationshipDocumentTypeNavigation { get; set; }

    public virtual ICollection<SearchedName> SearchedNames { get; set; } = new List<SearchedName>();

    public virtual ICollection<TicketObservation> TicketObservations { get; set; } = new List<TicketObservation>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Traduction> Traductions { get; set; } = new List<Traduction>();
}
