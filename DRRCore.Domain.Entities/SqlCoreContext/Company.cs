using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Company
{
    public int Id { get; set; }

    public string? OldCode { get; set; }

    public string Name { get; set; } = null!;

    public string? SocialName { get; set; }

    public DateTime? LastSearched { get; set; }

    public string? Language { get; set; }

    public string? TypeRegister { get; set; }

    public string? YearFundation { get; set; }

    public string? Quality { get; set; }

    public int? IdLegalPersonType { get; set; }

    public string? TaxTypeName { get; set; }

    public string? TaxTypeCode { get; set; }

    public int? IdLegalRegisterSituation { get; set; }

    public string? Address { get; set; }

    public string? Duration { get; set; }

    public string? Place { get; set; }

    public int? IdCountry { get; set; }

    public string? SubTelephone { get; set; }

    public string? Cellphone { get; set; }

    public string? Telephone { get; set; }

    public string? PostalCode { get; set; }

    public string? WhatsappPhone { get; set; }

    public string? Email { get; set; }

    public string? WebPage { get; set; }

    public int? IdCreditRisk { get; set; }

    public int? IdPaymentPolicy { get; set; }

    public int? IdReputation { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdaterUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? ReputationComentary { get; set; }

    public string? NewsComentary { get; set; }

    public string? IdentificacionCommentary { get; set; }

    public bool? OnWeb { get; set; }

    public bool? Print { get; set; }

    public bool? HaveReport { get; set; }

    public int? Migra { get; set; }

    public string? Since { get; set; }

    public bool? MigrateCompanyRelation { get; set; }

    public bool? MigrateCompanyPerson { get; set; }

    public virtual ICollection<Traduction> Traductions { get; set; } = new List<Traduction>();
    public virtual ICollection<BankDebt> BankDebts { get; set; } = new List<BankDebt>();

    public virtual ICollection<ComercialLatePayment> ComercialLatePayments { get; set; } = new List<ComercialLatePayment>();

    public virtual ICollection<CompanyBackground> CompanyBackgrounds { get; set; } = new List<CompanyBackground>();

    public virtual ICollection<CompanyBranch> CompanyBranches { get; set; } = new List<CompanyBranch>();

    public virtual ICollection<CompanyCreditOpinion> CompanyCreditOpinions { get; set; } = new List<CompanyCreditOpinion>();

    public virtual ICollection<CompanyFinancialInformation> CompanyFinancialInformations { get; set; } = new List<CompanyFinancialInformation>();

    public virtual ICollection<CompanyGeneralInformation> CompanyGeneralInformations { get; set; } = new List<CompanyGeneralInformation>();

    public virtual ICollection<CompanyImage> CompanyImages { get; set; } = new List<CompanyImage>();

    public virtual ICollection<CompanyPartner> CompanyPartners { get; set; } = new List<CompanyPartner>();

    public virtual ICollection<CompanyRelation> CompanyRelationIdCompanyNavigations { get; set; } = new List<CompanyRelation>();

    public virtual ICollection<CompanyRelation> CompanyRelationIdCompanyRelationNavigations { get; set; } = new List<CompanyRelation>();

    public virtual ICollection<CompanySb> CompanySbs { get; set; } = new List<CompanySb>();

    public virtual ICollection<CompanyShareHolder> CompanyShareHolderIdCompanyNavigations { get; set; } = new List<CompanyShareHolder>();

    public virtual ICollection<CompanyShareHolder> CompanyShareHolderIdCompanyShareHolderNavigations { get; set; } = new List<CompanyShareHolder>();

    public virtual ICollection<Endorsement> Endorsements { get; set; } = new List<Endorsement>();

    public virtual ICollection<FinancialBalance> FinancialBalances { get; set; } = new List<FinancialBalance>();

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual CreditRisk? IdCreditRiskNavigation { get; set; }

    public virtual LegalPersonType? IdLegalPersonTypeNavigation { get; set; }

    public virtual LegalRegisterSituation? IdLegalRegisterSituationNavigation { get; set; }

    public virtual PaymentPolicy? IdPaymentPolicyNavigation { get; set; }

    public virtual Reputation? IdReputationNavigation { get; set; }

    public virtual ICollection<ImportsAndExport> ImportsAndExports { get; set; } = new List<ImportsAndExport>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PersonJob> PersonJobs { get; set; } = new List<PersonJob>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();

    public virtual ICollection<SalesHistory> SalesHistories { get; set; } = new List<SalesHistory>();

    public virtual ICollection<SearchedName> SearchedNames { get; set; } = new List<SearchedName>();

    public virtual ICollection<TicketObservation> TicketObservations { get; set; } = new List<TicketObservation>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<TraductionCompany> TraductionCompanies { get; set; } = new List<TraductionCompany>();

    public virtual ICollection<WorkersHistory> WorkersHistories { get; set; } = new List<WorkersHistory>();
}
