using System;
using System.Collections.Generic;
using DRRCore.Application.DTO.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SqlCoreContext : DbContext
{
    public SqlCoreContext()
    {
    }

    public SqlCoreContext(DbContextOptions<SqlCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<AgentInvoice> AgentInvoices { get; set; }

    public virtual DbSet<AgentInvoiceDetail> AgentInvoiceDetails { get; set; }

    public virtual DbSet<AgentPrice> AgentPrices { get; set; }

    public virtual DbSet<Anniversary> Anniversaries { get; set; }

    public virtual DbSet<BankAccountType> BankAccountTypes { get; set; }

    public virtual DbSet<BankDebt> BankDebts { get; set; }

    public virtual DbSet<BillinPersonal> BillinPersonals { get; set; }

    public virtual DbSet<BranchSector> BranchSectors { get; set; }

    public virtual DbSet<BusineesActivity> BusineesActivities { get; set; }

    public virtual DbSet<BusinessBranch> BusinessBranches { get; set; }

    public virtual DbSet<CivilStatus> CivilStatuses { get; set; }

    public virtual DbSet<CollaborationDegree> CollaborationDegrees { get; set; }

    public virtual DbSet<ComercialLatePayment> ComercialLatePayments { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyBackground> CompanyBackgrounds { get; set; }

    public virtual DbSet<CompanyBranch> CompanyBranches { get; set; }

    public virtual DbSet<CompanyBusineesActivity> CompanyBusineesActivities { get; set; }

    public virtual DbSet<CompanyCreditOpinion> CompanyCreditOpinions { get; set; }

    public virtual DbSet<CompanyFinancialInformation> CompanyFinancialInformations { get; set; }

    public virtual DbSet<CompanyGeneralInformation> CompanyGeneralInformations { get; set; }

    public virtual DbSet<CompanyImage> CompanyImages { get; set; }

    public virtual DbSet<CompanyPartner> CompanyPartners { get; set; }

    public virtual DbSet<CompanyRelation> CompanyRelations { get; set; }

    public virtual DbSet<CompanySb> CompanySbs { get; set; }

    public virtual DbSet<CompanyShareHolder> CompanyShareHolders { get; set; }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CouponBillingSubscriber> CouponBillingSubscribers { get; set; }

    public virtual DbSet<CouponBillingSubscriberHistory> CouponBillingSubscriberHistories { get; set; }

    public virtual DbSet<CreditRisk> CreditRisks { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrentPersonJob> CurrentPersonJobs { get; set; }

    public virtual DbSet<DetailsTicketObservation> DetailsTicketObservations { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Endorsement> Endorsements { get; set; }

    public virtual DbSet<FamilyBondType> FamilyBondTypes { get; set; }

    public virtual DbSet<FinancialBalance> FinancialBalances { get; set; }

    public virtual DbSet<FinancialSituacion> FinancialSituacions { get; set; }

    public virtual DbSet<HealthInsurance> HealthInsurances { get; set; }

    public virtual DbSet<HistoryInfoChange> HistoryInfoChanges { get; set; }

    public virtual DbSet<ImportsAndExport> ImportsAndExports { get; set; }

    public virtual DbSet<InternalInvoice> InternalInvoices { get; set; }

    public virtual DbSet<InternalInvoiceDetail> InternalInvoiceDetails { get; set; }

    public virtual DbSet<InvoiceFile> InvoiceFiles { get; set; }

    public virtual DbSet<InvoiceState> InvoiceStates { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobDepartment> JobDepartments { get; set; }

    public virtual DbSet<LandOwnership> LandOwnerships { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LegalPersonType> LegalPersonTypes { get; set; }

    public virtual DbSet<LegalRegisterSituation> LegalRegisterSituations { get; set; }

    public virtual DbSet<Numeration> Numerations { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<OldTicket> OldTickets { get; set; }

    public virtual DbSet<OpcionalCommentarySb> OpcionalCommentarySbs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<PaymentPolicy> PaymentPolicies { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonActivity> PersonActivities { get; set; }

    public virtual DbSet<PersonGeneralInformation> PersonGeneralInformations { get; set; }

    public virtual DbSet<PersonHistory> PersonHistories { get; set; }

    public virtual DbSet<PersonHome> PersonHomes { get; set; }

    public virtual DbSet<PersonImage> PersonImages { get; set; }

    public virtual DbSet<PersonJob> PersonJobs { get; set; }

    public virtual DbSet<PersonProperty> PersonProperties { get; set; }

    public virtual DbSet<PersonSb> PersonSbs { get; set; }

    public virtual DbSet<PersonSituation> PersonSituations { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<PersonalPrice> PersonalPrices { get; set; }

    public virtual DbSet<PhotoPerson> PhotoPeople { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<ProductionClosure> ProductionClosures { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Reason> Reasons { get; set; }

    public virtual DbSet<ReferencesHistory> ReferencesHistories { get; set; }

    public virtual DbSet<Reputation> Reputations { get; set; }

    public virtual DbSet<SalesHistory> SalesHistories { get; set; }

    public virtual DbSet<SearchedName> SearchedNames { get; set; }

    public virtual DbSet<SpecialAgentBalancePrice> SpecialAgentBalancePrices { get; set; }

    public virtual DbSet<SpecialPriceAgent> SpecialPriceAgents { get; set; }

    public virtual DbSet<StatusTicket> StatusTickets { get; set; }

    public virtual DbSet<StatusTicketObservation> StatusTicketObservations { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<SubscriberCategory> SubscriberCategories { get; set; }

    public virtual DbSet<SubscriberInvoice> SubscriberInvoices { get; set; }

    public virtual DbSet<SubscriberInvoiceDetail> SubscriberInvoiceDetails { get; set; }

    public virtual DbSet<SubscriberPrice> SubscriberPrices { get; set; }

    public virtual DbSet<Supervisor> Supervisors { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketAssignation> TicketAssignations { get; set; }

    public virtual DbSet<TicketFile> TicketFiles { get; set; }

    public virtual DbSet<TicketHistory> TicketHistories { get; set; }

    public virtual DbSet<TicketObservation> TicketObservations { get; set; }

    public virtual DbSet<TicketQuery> TicketQueries { get; set; }

    public virtual DbSet<TicketReceptor> TicketReceptors { get; set; }

    public virtual DbSet<TraductionCompany> TraductionCompanies { get; set; }

    public virtual DbSet<TraductionPerson> TraductionPeople { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserProcess> UserProcesses { get; set; }

    public virtual DbSet<WorkersHistory> WorkersHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
           // "Data Source=200.58.123.184,14331;Initial Catalog=eecore;User ID=drfero2024x;Password=7KoHVN3ig7mZx;TrustServerCertificate=True"
         "Data Source=localhost\\DRRSQLSERVER;Initial Catalog=eecore;User ID=drfero2024x;Password=7KoHVN3ig7mZx;TrustServerCertificate=True"
            //   "Data Source=SD-4154134-W;Initial Catalog=eecore;User ID=drfero2024x;Password=7KoHVN3ig7mZx;TrustServerCertificate=True"
            , sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 18,
                maxRetryDelay: TimeSpan.FromSeconds(60),
                errorNumbersToAdd: null)
            );
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyXmlData>().ToSqlQuery("EXEC DataCompanyCredendo").HasNoKey();
        modelBuilder.Entity<CompanyBalanceData>().ToSqlQuery("EXEC BalanceCompanyCredendo").HasNoKey();
        modelBuilder.Entity<CompanyFunctionData>().ToSqlQuery("EXEC FunctionCompanyCredendo").HasNoKey();
        modelBuilder.Entity<CompanyLegalEventsData>().ToSqlQuery("EXEC LegalEventsCompanyCredendo").HasNoKey();
        modelBuilder.Entity<CompanyRelatedData>().ToSqlQuery("EXEC RelatedCompanyCredendo").HasNoKey();
        modelBuilder.Entity<WhoIsWhoSP>().ToSqlQuery("EXEC WhoIsWho");
        modelBuilder.Entity<TicketsInCurrentMonthSP>().ToSqlQuery("EXEC SP_TicketsInCurrentMonth").HasNoKey();
        modelBuilder.Entity<CompanyShareholderSP>().ToSqlQuery("EXEC ShareholderCompany").HasNoKey();
        modelBuilder.Entity<StaticsByCountry>().ToSqlQuery("EXEC SP_STATICS_BY_COUNTRY").HasNoKey();
        modelBuilder.Entity<GetAgentInvoice>().ToSqlQuery("EXEC GetAgentInvoice").HasNoKey();
        modelBuilder.Entity<GetListCompanyQuery>().ToSqlQuery("EXEC SP_COMPANY_QUERY").HasNoKey();
        modelBuilder.Entity<PriceResult>().ToSqlQuery("EXEC GetAgentPrice").HasNoKey();
        modelBuilder.Entity<Report7_10_1>().ToSqlQuery("EXEC SP_REPORTES_7_10_1").HasNoKey();
        modelBuilder.Entity<Report7_10_2_Main>().ToSqlQuery("EXEC SP_REPORTES_7_10_2").HasNoKey();
        modelBuilder.Entity<Report7_10_2_Details>().ToSqlQuery("EXEC SP_REPORTES_7_10_2_Details").HasNoKey();
        modelBuilder.Entity<GetInternalInvoice>().ToSqlQuery("EXEC GetInternalInvoice").HasNoKey();

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agent__3213E83F2D01908B");

            entity.ToTable("Agent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AgentSubscriber).HasColumnName("agentSubscriber");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.Internal)
                .HasDefaultValueSql("((1))")
                .HasColumnName("internal");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.SpecialCase).HasColumnName("specialCase");
            entity.Property(e => e.SpecialPrice).HasColumnName("specialPrice");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.State)
                .HasDefaultValueSql("((1))")
                .HasColumnName("state");
            entity.Property(e => e.Supervisor)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("supervisor");
            entity.Property(e => e.Telephone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Agents)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Agent__idCountry__4C8B54C9");
        });

        modelBuilder.Entity<AgentInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentInv__3213E83F0C549A17");

            entity.ToTable("AgentInvoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgentCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("agentCode");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdAgent).HasColumnName("idAgent");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.IdInvoiceState).HasColumnName("idInvoiceState");
            entity.Property(e => e.InvoiceCancelDate)
                .HasColumnType("datetime")
                .HasColumnName("invoiceCancelDate");
            entity.Property(e => e.InvoiceCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("invoiceCode");
            entity.Property(e => e.InvoiceEmitDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("invoiceEmitDate");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.AgentInvoices)
                .HasForeignKey(d => d.IdAgent)
                .HasConstraintName("FK__AgentInvo__idAge__4D7F7902");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.AgentInvoices)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__AgentInvo__idCur__4E739D3B");

            entity.HasOne(d => d.IdInvoiceStateNavigation).WithMany(p => p.AgentInvoices)
                .HasForeignKey(d => d.IdInvoiceState)
                .HasConstraintName("FK__AgentInvo__idInv__4F67C174");
        });

        modelBuilder.Entity<AgentInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentInv__3213E83FC71F8436");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdAgentInvoice).HasColumnName("idAgentInvoice");
            entity.Property(e => e.IdTicketHistory).HasColumnName("idTicketHistory");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdAgentInvoiceNavigation).WithMany(p => p.AgentInvoiceDetails)
                .HasForeignKey(d => d.IdAgentInvoice)
                .HasConstraintName("FK__AgentInvo__idAge__505BE5AD");

            entity.HasOne(d => d.IdTicketHistoryNavigation).WithMany(p => p.AgentInvoiceDetails)
                .HasForeignKey(d => d.IdTicketHistory)
                .HasConstraintName("FK__AgentInvo__idTic__515009E6");
        });

        modelBuilder.Entity<AgentPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentPri__3213E83F1FEC9EDB");

            entity.ToTable("AgentPrice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DayBd).HasColumnName("dayBD");
            entity.Property(e => e.DayCr).HasColumnName("dayCR");
            entity.Property(e => e.DayPn).HasColumnName("dayPN");
            entity.Property(e => e.DayRp).HasColumnName("dayRP");
            entity.Property(e => e.DayT1).HasColumnName("dayT1");
            entity.Property(e => e.DayT2).HasColumnName("dayT2");
            entity.Property(e => e.DayT3).HasColumnName("dayT3");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdAgent).HasColumnName("idAgent");
            entity.Property(e => e.IdContinent).HasColumnName("idContinent");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.PriceBd)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceBD");
            entity.Property(e => e.PriceCr)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceCR");
            entity.Property(e => e.PricePn)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("pricePN");
            entity.Property(e => e.PriceRp)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceRP");
            entity.Property(e => e.PriceT1)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceT1");
            entity.Property(e => e.PriceT2)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceT2");
            entity.Property(e => e.PriceT3)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceT3");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.AgentPrices)
                .HasForeignKey(d => d.IdAgent)
                .HasConstraintName("FK__AgentPric__idAge__52442E1F");

            entity.HasOne(d => d.IdContinentNavigation).WithMany(p => p.AgentPrices)
                .HasForeignKey(d => d.IdContinent)
                .HasConstraintName("FK__AgentPric__idCon__53385258");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.AgentPrices)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__AgentPric__idCou__542C7691");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.AgentPrices)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__AgentPric__idCur__55209ACA");
        });

        modelBuilder.Entity<Anniversary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Annivers__3213E83FE9431109");

            entity.ToTable("Anniversary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("className");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Type)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<BankAccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BankAcco__3213E83F22A40BFC");

            entity.ToTable("BankAccountType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<BankDebt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BankDebt__3213E83F9A2BC1D4");

            entity.ToTable("BankDebt");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bankName");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DebtDate)
                .HasColumnType("datetime")
                .HasColumnName("debtDate");
            entity.Property(e => e.DebtFc)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("debtFC");
            entity.Property(e => e.DebtNc)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("debtNC");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Memo)
                .IsUnicode(false)
                .HasColumnName("memo");
            entity.Property(e => e.MemoEng)
                .IsUnicode(false)
                .HasColumnName("memoEng");
            entity.Property(e => e.Qualification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("qualification");
            entity.Property(e => e.QualificationEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("qualificationEng");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.BankDebts)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__BankDebt__idComp__5614BF03");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.BankDebts)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK_BankDebt_Person");
        });

        modelBuilder.Entity<BillinPersonal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillinPe__3213E83F4DF4EC48");

            entity.ToTable("BillinPersonal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Commission).HasColumnName("commission");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.DirectTranslate).HasColumnName("directTranslate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IsComplement).HasColumnName("isComplement");
            entity.Property(e => e.Quality)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quality");
            entity.Property(e => e.ReportType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("reportType");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.BillinPersonals)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK__BillinPer__idEmp__5708E33C");
        });

        modelBuilder.Entity<BranchSector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BranchSe__3213E83FE5398429");

            entity.ToTable("BranchSector");

            entity.HasIndex(e => e.Name, "UQ__BranchSe__72E12F1B6C4FC8D6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OldCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("oldCode");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<BusineesActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Businees__3213E83F75654C2E");

            entity.ToTable("BusineesActivity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.IdBusinessBranch).HasColumnName("idBusinessBranch");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdBusinessBranchNavigation).WithMany(p => p.BusineesActivities)
                .HasForeignKey(d => d.IdBusinessBranch)
                .HasConstraintName("FK__BusineesA__idBus__57FD0775");
        });

        modelBuilder.Entity<BusinessBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Business__3213E83F969D05A7");

            entity.ToTable("BusinessBranch");

            entity.HasIndex(e => e.Name, "UQ__Business__72E12F1BCB3FB442").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OldCode).HasColumnName("oldCode");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<CivilStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CivilSta__3213E83FA2DF4444");

            entity.ToTable("CivilStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<CollaborationDegree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Collabor__3213E83FF98A5673");

            entity.ToTable("CollaborationDegree");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<ComercialLatePayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comercia__3213E83F4F3C941A");

            entity.ToTable("ComercialLatePayment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountFc)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("amountFC");
            entity.Property(e => e.AmountNc)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("amountNC");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CreditorOrSupplier)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("creditorOrSupplier");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.DaysLate).HasColumnName("daysLate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("documentType");
            entity.Property(e => e.DocumentTypeEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("documentTypeEng");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.PendingPaymentDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pendingPaymentDate");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.ComercialLatePayments)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Comercial__idCom__58F12BAE");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.ComercialLatePayments)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK_ComercialLatePayment_Person");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3213E83F25E57F5A");

            entity.ToTable("Company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Cellphone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cellphone");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Duration)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.HaveReport).HasColumnName("haveReport");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdCreditRisk).HasColumnName("idCreditRisk");
            entity.Property(e => e.IdLegalPersonType).HasColumnName("idLegalPersonType");
            entity.Property(e => e.IdLegalRegisterSituation).HasColumnName("idLegalRegisterSituation");
            entity.Property(e => e.IdPaymentPolicy).HasColumnName("idPaymentPolicy");
            entity.Property(e => e.IdReputation).HasColumnName("idReputation");
            entity.Property(e => e.IdentificacionCommentary)
                .IsUnicode(false)
                .HasColumnName("identificacionCommentary");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.LastSearched)
                .HasColumnType("datetime")
                .HasColumnName("lastSearched");
            entity.Property(e => e.LastUpdaterUser).HasColumnName("lastUpdaterUser");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("((0))")
                .HasColumnName("migra");
            entity.Property(e => e.MigrateCompanyPerson)
                .HasDefaultValueSql("((0))")
                .HasColumnName("migrateCompanyPerson");
            entity.Property(e => e.MigrateCompanyRelation)
                .HasDefaultValueSql("((0))")
                .HasColumnName("migrateCompanyRelation");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NewsComentary)
                .IsUnicode(false)
                .HasColumnName("newsComentary");
            entity.Property(e => e.OldCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("oldCode");
            entity.Property(e => e.OnWeb)
                .HasDefaultValueSql("((1))")
                .HasColumnName("onWeb");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("place");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("postalCode");
            entity.Property(e => e.Print).HasColumnName("print");
            entity.Property(e => e.Quality)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quality");
            entity.Property(e => e.ReputationComentary)
                .IsUnicode(false)
                .HasColumnName("reputationComentary");
            entity.Property(e => e.Since)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("since");
            entity.Property(e => e.SocialName)
                .IsUnicode(false)
                .HasColumnName("socialName");
            entity.Property(e => e.SubTelephone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("subTelephone");
            entity.Property(e => e.TaxTypeCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("taxTypeCode");
            entity.Property(e => e.TaxTypeName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("taxTypeName");
            entity.Property(e => e.Telephone)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.TypeRegister)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typeRegister");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.WebPage)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("webPage");
            entity.Property(e => e.WhatsappPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("whatsappPhone");
            entity.Property(e => e.YearFundation)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("yearFundation");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Company__idCount__59E54FE7");

            entity.HasOne(d => d.IdCreditRiskNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.IdCreditRisk)
                .HasConstraintName("FK__Company__idCredi__5AD97420");

            entity.HasOne(d => d.IdLegalPersonTypeNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.IdLegalPersonType)
                .HasConstraintName("FK__Company__idLegal__5BCD9859");

            entity.HasOne(d => d.IdLegalRegisterSituationNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.IdLegalRegisterSituation)
                .HasConstraintName("FK__Company__idLegal__5CC1BC92");

            entity.HasOne(d => d.IdPaymentPolicyNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.IdPaymentPolicy)
                .HasConstraintName("FK__Company__idPayme__5DB5E0CB");

            entity.HasOne(d => d.IdReputationNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.IdReputation)
                .HasConstraintName("FK__Company__idReput__5EAA0504");
        });

        modelBuilder.Entity<CompanyBackground>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyB__3213E83F16204A37");

            entity.ToTable("CompanyBackground");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Background)
                .IsUnicode(false)
                .HasColumnName("background");
            entity.Property(e => e.ConstitutionDate)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("constitutionDate");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Currency).HasColumnName("currency");
            entity.Property(e => e.CurrentExchangeRate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("currentExchangeRate");
            entity.Property(e => e.CurrentPaidCapital)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("currentPaidCapital");
            entity.Property(e => e.CurrentPaidCapitalComentary)
                .IsUnicode(false)
                .HasColumnName("currentPaidCapitalComentary");
            entity.Property(e => e.CurrentPaidCapitalCurrency).HasColumnName("currentPaidCapitalCurrency");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.History)
                .IsUnicode(false)
                .HasColumnName("history");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IncreaceDateCapital)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("increaceDateCapital");
            entity.Property(e => e.LastQueryRrpp)
                .HasColumnType("datetime")
                .HasColumnName("lastQueryRrpp");
            entity.Property(e => e.LastQueryRrppBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastQueryRrppBy");
            entity.Property(e => e.NotaryRegister)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("notaryRegister");
            entity.Property(e => e.OperationDuration)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("operationDuration");
            entity.Property(e => e.Origin)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("origin");
            entity.Property(e => e.PublicRegister)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("publicRegister");
            entity.Property(e => e.RegisterPlace)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("registerPlace");
            entity.Property(e => e.StartFunctionYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("startFunctionYear");
            entity.Property(e => e.Traded)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("traded");
            entity.Property(e => e.TradedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tradedBy");
            entity.Property(e => e.TradedByEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tradedByEng");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.CurrencyNavigation).WithMany(p => p.CompanyBackgroundCurrencyNavigations)
                .HasForeignKey(d => d.Currency)
                .HasConstraintName("FK_CompanyBackground_CurrentPaidCapitalCurrency2");

            entity.HasOne(d => d.CurrentPaidCapitalCurrencyNavigation).WithMany(p => p.CompanyBackgroundCurrentPaidCapitalCurrencyNavigations)
                .HasForeignKey(d => d.CurrentPaidCapitalCurrency)
                .HasConstraintName("FK_CompanyBackground_CurrentPaidCapitalCurrency1");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyBackgrounds)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyBa__idCom__5F9E293D");
        });

        modelBuilder.Entity<CompanyBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyB__3213E83F3A295E9B");

            entity.ToTable("CompanyBranch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbroadSaleComentary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abroadSaleComentary");
            entity.Property(e => e.AbroadSalePercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("abroadSalePercentage");
            entity.Property(e => e.ActivityDetailCommentary)
                .IsUnicode(false)
                .HasColumnName("activityDetailCommentary");
            entity.Property(e => e.AditionalCommentary)
                .IsUnicode(false)
                .HasColumnName("aditionalCommentary");
            entity.Property(e => e.CashSaleComentary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cashSaleComentary");
            entity.Property(e => e.CashSalePercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cashSalePercentage");
            entity.Property(e => e.CountriesExport)
                .IsUnicode(false)
                .HasColumnName("countriesExport");
            entity.Property(e => e.CountriesExportEng)
                .IsUnicode(false)
                .HasColumnName("countriesExportEng");
            entity.Property(e => e.CountriesImport)
                .IsUnicode(false)
                .HasColumnName("countriesImport");
            entity.Property(e => e.CountriesImportEng)
                .IsUnicode(false)
                .HasColumnName("countriesImportEng");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CreditSaleComentary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("creditSaleComentary");
            entity.Property(e => e.CreditSalePercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("creditSalePercentage");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Export).HasColumnName("export");
            entity.Property(e => e.IdBranchSector).HasColumnName("idBranchSector");
            entity.Property(e => e.IdBusinessBranch).HasColumnName("idBusinessBranch");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdLandOwnership).HasColumnName("idLandOwnership");
            entity.Property(e => e.Import).HasColumnName("import");
            entity.Property(e => e.InternationalPurchasesComentary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("internationalPurchasesComentary");
            entity.Property(e => e.InternationalPurchasesPercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("internationalPurchasesPercentage");
            entity.Property(e => e.MainAddress)
                .IsUnicode(false)
                .HasColumnName("mainAddress");
            entity.Property(e => e.NationalPurchasesComentary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nationalPurchasesComentary");
            entity.Property(e => e.NationalPurchasesPercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("nationalPurchasesPercentage");
            entity.Property(e => e.OtherLocations)
                .IsUnicode(false)
                .HasColumnName("otherLocations");
            entity.Property(e => e.PreviousAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("previousAddress");
            entity.Property(e => e.SpecificActivities)
                .IsUnicode(false)
                .HasColumnName("specificActivities");
            entity.Property(e => e.SpecificActivitiesEng)
                .IsUnicode(false)
                .HasColumnName("specificActivitiesEng");
            entity.Property(e => e.TabCommentary)
                .IsUnicode(false)
                .HasColumnName("tabCommentary");
            entity.Property(e => e.TerritorySaleComentary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("territorySaleComentary");
            entity.Property(e => e.TerritorySalePercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("territorySalePercentage");
            entity.Property(e => e.TotalArea)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("totalArea");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.WorkerNumber).HasColumnName("workerNumber");

            entity.HasOne(d => d.IdBranchSectorNavigation).WithMany(p => p.CompanyBranches)
                .HasForeignKey(d => d.IdBranchSector)
                .HasConstraintName("FK__CompanyBr__idBra__60924D76");

            entity.HasOne(d => d.IdBusinessBranchNavigation).WithMany(p => p.CompanyBranches)
                .HasForeignKey(d => d.IdBusinessBranch)
                .HasConstraintName("FK__CompanyBr__idBus__618671AF");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyBranches)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyBr__idCom__627A95E8");

            entity.HasOne(d => d.IdLandOwnershipNavigation).WithMany(p => p.CompanyBranches)
                .HasForeignKey(d => d.IdLandOwnership)
                .HasConstraintName("FK__CompanyBr__idLan__636EBA21");
        });

        modelBuilder.Entity<CompanyBusineesActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyB__3213E83F4BF31B6F");

            entity.ToTable("CompanyBusineesActivity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompanyBranch).HasColumnName("idCompanyBranch");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.ImportOrExport)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("importOrExport");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyBranchNavigation).WithMany(p => p.CompanyBusineesActivities)
                .HasForeignKey(d => d.IdCompanyBranch)
                .HasConstraintName("FK__CompanyBu__idCom__6462DE5A");
        });

        modelBuilder.Entity<CompanyCreditOpinion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyC__3213E83F2A0E499E");

            entity.ToTable("CompanyCreditOpinion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConsultedCredit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("consultedCredit");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CreditRequest).HasColumnName("creditRequest");
            entity.Property(e => e.CurrentCommentary)
                .IsUnicode(false)
                .HasColumnName("currentCommentary");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.PreviousCommentary)
                .IsUnicode(false)
                .HasColumnName("previousCommentary");
            entity.Property(e => e.SuggestedCredit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("suggestedCredit");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyCreditOpinions)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyCr__idCom__00750D23");
        });

        modelBuilder.Entity<CompanyFinancialInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyF__3213E83F97814C1E");

            entity.ToTable("CompanyFinancialInformation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnalystCommentary)
                .IsUnicode(false)
                .HasColumnName("analystCommentary");
            entity.Property(e => e.Auditors)
                .IsUnicode(false)
                .HasColumnName("auditors");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.FinancialCommentarySelected)
                .IsUnicode(false)
                .HasColumnName("financialCommentarySelected");
            entity.Property(e => e.IdCollaborationDegree).HasColumnName("idCollaborationDegree");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdFinancialSituacion).HasColumnName("idFinancialSituacion");
            entity.Property(e => e.InterviewCommentary)
                .IsUnicode(false)
                .HasColumnName("interviewCommentary");
            entity.Property(e => e.Interviewed)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("interviewed");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.MainFixedAssets)
                .IsUnicode(false)
                .HasColumnName("mainFixedAssets");
            entity.Property(e => e.ReportCommentWithBalance)
                .IsUnicode(false)
                .HasColumnName("reportCommentWithBalance");
            entity.Property(e => e.ReportCommentWithoutBalance)
                .IsUnicode(false)
                .HasColumnName("reportCommentWithoutBalance");
            entity.Property(e => e.TabCommentary)
                .IsUnicode(false)
                .HasColumnName("tabCommentary");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.WorkPosition)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("workPosition");

            entity.HasOne(d => d.IdCollaborationDegreeNavigation).WithMany(p => p.CompanyFinancialInformations)
                .HasForeignKey(d => d.IdCollaborationDegree)
                .HasConstraintName("FK__CompanyFi__idCol__0169315C");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyFinancialInformations)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyFi__idCom__025D5595");

            entity.HasOne(d => d.IdFinancialSituacionNavigation).WithMany(p => p.CompanyFinancialInformations)
                .HasForeignKey(d => d.IdFinancialSituacion)
                .HasConstraintName("FK__CompanyFi__idFin__035179CE");
        });

        modelBuilder.Entity<CompanyGeneralInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyG__3213E83F1F4AFEF9");

            entity.ToTable("CompanyGeneralInformation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.GeneralInfo)
                .IsUnicode(false)
                .HasColumnName("generalInfo");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyGeneralInformations)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyGe__idCom__04459E07");
        });

        modelBuilder.Entity<CompanyImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyI__3213E83F5E66C5DE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.Img1)
                .IsUnicode(false)
                .HasColumnName("img1");
            entity.Property(e => e.Img2)
                .IsUnicode(false)
                .HasColumnName("img2");
            entity.Property(e => e.Img3)
                .IsUnicode(false)
                .HasColumnName("img3");
            entity.Property(e => e.Img4)
                .IsUnicode(false)
                .HasColumnName("img4");
            entity.Property(e => e.ImgDesc1)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDesc1");
            entity.Property(e => e.ImgDesc2)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDesc2");
            entity.Property(e => e.ImgDesc3)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDesc3");
            entity.Property(e => e.ImgDesc4)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDesc4");
            entity.Property(e => e.ImgDescEng1)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDescEng1");
            entity.Property(e => e.ImgDescEng2)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDescEng2");
            entity.Property(e => e.ImgDescEng3)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDescEng3");
            entity.Property(e => e.ImgDescEng4)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imgDescEng4");
            entity.Property(e => e.ImgPrint1).HasColumnName("imgPrint1");
            entity.Property(e => e.ImgPrint2).HasColumnName("imgPrint2");
            entity.Property(e => e.ImgPrint3).HasColumnName("imgPrint3");
            entity.Property(e => e.ImgPrint4).HasColumnName("imgPrint4");
            entity.Property(e => e.LastUserUpdate).HasColumnName("lastUserUpdate");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyImages)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyIm__idCom__0539C240");
        });

        modelBuilder.Entity<CompanyPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyP__3213E83F4085FD3C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.MainExecutive).HasColumnName("mainExecutive");
            entity.Property(e => e.Numeration).HasColumnName("numeration");
            entity.Property(e => e.Participation)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("participation");
            entity.Property(e => e.ParticipationStr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("participationStr");
            entity.Property(e => e.Print).HasColumnName("print");
            entity.Property(e => e.Profession)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("profession");
            entity.Property(e => e.ProfessionEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("professionEng");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.StartDateStr)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("startDateStr");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyPartners)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyPa__idCom__062DE679");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.CompanyPartners)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__CompanyPa__idPer__07220AB2");
        });

        modelBuilder.Entity<CompanyRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyR__3213E83F4B3CFBD3");

            entity.ToTable("CompanyRelation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Commentary)
                .IsUnicode(false)
                .HasColumnName("commentary");
            entity.Property(e => e.CommentaryEng)
                .IsUnicode(false)
                .HasColumnName("commentaryEng");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdCompanyRelation).HasColumnName("idCompanyRelation");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Participation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("participation");
            entity.Property(e => e.Relation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Empresa Relacionada')")
                .HasColumnName("relation");
            entity.Property(e => e.RelationEng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Related Company')")
                .HasColumnName("relationEng");
            entity.Property(e => e.StartDateStr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("startDateStr");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyRelationIdCompanyNavigations)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanyRe__idCom__08162EEB");

            entity.HasOne(d => d.IdCompanyRelationNavigation).WithMany(p => p.CompanyRelationIdCompanyRelationNavigations)
                .HasForeignKey(d => d.IdCompanyRelation)
                .HasConstraintName("FK__CompanyRe__idCom__090A5324");
        });

        modelBuilder.Entity<CompanySb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyS__3213E83F61DC745B");

            entity.ToTable("CompanySBS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AditionalCommentaryRiskCenter)
                .IsUnicode(false)
                .HasColumnName("aditionalCommentaryRiskCenter");
            entity.Property(e => e.BankingCommentary)
                .IsUnicode(false)
                .HasColumnName("bankingCommentary");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CreditHistoryCommentary)
                .IsUnicode(false)
                .HasColumnName("creditHistoryCommentary");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DebtRecordedDate)
                .HasColumnType("datetime")
                .HasColumnName("debtRecordedDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndorsementsObservations)
                .IsUnicode(false)
                .HasColumnName("endorsementsObservations");
            entity.Property(e => e.ExchangeRate)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("exchangeRate");
            entity.Property(e => e.GuaranteesOfferedFc)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("guaranteesOfferedFC");
            entity.Property(e => e.GuaranteesOfferedNc)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("guaranteesOfferedNC");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdOpcionalCommentarySbs).HasColumnName("idOpcionalCommentarySBS");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.LitigationsCommentary)
                .IsUnicode(false)
                .HasColumnName("litigationsCommentary");
            entity.Property(e => e.ReferentOrAnalyst)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("referentOrAnalyst");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanySbs)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanySB__idCom__09FE775D");

            entity.HasOne(d => d.IdOpcionalCommentarySbsNavigation).WithMany(p => p.CompanySbs)
                .HasForeignKey(d => d.IdOpcionalCommentarySbs)
                .HasConstraintName("FK__CompanySB__idOpc__0AF29B96");
        });

        modelBuilder.Entity<CompanyShareHolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyS__3213E83F22A39EB7");

            entity.ToTable("CompanyShareHolder");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Commentary)
                .IsUnicode(false)
                .HasColumnName("commentary");
            entity.Property(e => e.CommentaryEng)
                .IsUnicode(false)
                .HasColumnName("commentaryEng");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdCompanyShareHolder).HasColumnName("idCompanyShareHolder");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.ParticipacionStr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("participacionStr");
            entity.Property(e => e.Participation)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("participation");
            entity.Property(e => e.Relation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("relation");
            entity.Property(e => e.RelationEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("relationEng");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.StartDateStr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("startDateStr");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.CompanyShareHolderIdCompanyNavigations)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__CompanySh__idCom__0BE6BFCF");

            entity.HasOne(d => d.IdCompanyShareHolderNavigation).WithMany(p => p.CompanyShareHolderIdCompanyShareHolderNavigations)
                .HasForeignKey(d => d.IdCompanyShareHolder)
                .HasConstraintName("FK__CompanySh__idCom__0CDAE408");
        });

        modelBuilder.Entity<Continent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Continen__3213E83F1AA10E01");

            entity.ToTable("Continent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3213E83F82E90AC5");

            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodePhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codePhone");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.FlagIso)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("flagIso");
            entity.Property(e => e.IdContinent).HasColumnName("idContinent");
            entity.Property(e => e.Iso)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("iso");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OldCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("oldCode");
            entity.Property(e => e.TaxTypeName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("taxTypeName");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdContinentNavigation).WithMany(p => p.Countries)
                .HasForeignKey(d => d.IdContinent)
                .HasConstraintName("FK__Country__idConti__0DCF0841");
        });

        modelBuilder.Entity<CouponBillingSubscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CouponBi__3213E83FB4F506DB");

            entity.ToTable("CouponBillingSubscriber");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdSubscriber).HasColumnName("idSubscriber");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.NumCoupon)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("numCoupon");
            entity.Property(e => e.PriceT0)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("priceT0");
            entity.Property(e => e.PriceT1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("priceT1");
            entity.Property(e => e.PriceT2)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("priceT2");
            entity.Property(e => e.PriceT3)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("priceT3");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.CouponBillingSubscribers)
                .HasForeignKey(d => d.IdSubscriber)
                .HasConstraintName("FK__CouponBil__idSub__0EC32C7A");
        });

        modelBuilder.Entity<CouponBillingSubscriberHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CouponBi__3213E83FA8EDC74F");

            entity.ToTable("CouponBillingSubscriberHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CouponAmount)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("couponAmount");
            entity.Property(e => e.CouponUnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("couponUnitPrice");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCouponBilling).HasColumnName("idCouponBilling");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchaseDate");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCouponBillingNavigation).WithMany(p => p.CouponBillingSubscriberHistories)
                .HasForeignKey(d => d.IdCouponBilling)
                .HasConstraintName("FK__CouponBil__idCou__0FB750B3");
        });

        modelBuilder.Entity<CreditRisk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CreditRi__3213E83FD39B886C");

            entity.ToTable("CreditRisk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("abreviation");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.Color)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.Identifier)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("identifier");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currency__3213E83F817715DE");

            entity.ToTable("Currency");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abreviation");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("symbol");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<CurrentPersonJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CurrentP__3213E83F491E6D12");

            entity.ToTable("CurrentPersonJob");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<DetailsTicketObservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetailsT__3213E83FD6420A61");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("assignedTo");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdTicketObservations).HasColumnName("idTicketObservations");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdTicketObservationsNavigation).WithMany(p => p.DetailsTicketObservations)
                .HasForeignKey(d => d.IdTicketObservations)
                .HasConstraintName("FK__DetailsTi__idTic__10AB74EC");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3213E83F2C3E5B30");

            entity.ToTable("DocumentType");

            entity.HasIndex(e => e.Name, "UQ__Document__72E12F1B66525C64").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("abreviation");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Flag1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag1");
            entity.Property(e => e.Flag2)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag2");
            entity.Property(e => e.Flag3)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag3");
            entity.Property(e => e.IsLegal)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isLegal");
            entity.Property(e => e.IsNational)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isNational");
            entity.Property(e => e.IsNatural)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isNatural");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F337E8E01");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("birthday");
            entity.Property(e => e.BloodType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bloodType");
            entity.Property(e => e.Cellphone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cellphone");
            entity.Property(e => e.ChildrenNumber).HasColumnName("childrenNumber");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CtsBank)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ctsBank");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Distrit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("distrit");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("documentNumber");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmergencyPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emergencyPhone");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.IdBankAccountTypeCts).HasColumnName("idBankAccountTypeCts");
            entity.Property(e => e.IdBankAccountTypeSalary).HasColumnName("idBankAccountTypeSalary");
            entity.Property(e => e.IdCivilStatus).HasColumnName("idCivilStatus");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdCurrencyCts).HasColumnName("idCurrencyCts");
            entity.Property(e => e.IdCurrencySalary).HasColumnName("idCurrencySalary");
            entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");
            entity.Property(e => e.IdJob).HasColumnName("idJob");
            entity.Property(e => e.IdJobDepartment).HasColumnName("idJobDepartment");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.NumberAccountCts)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("numberAccountCts");
            entity.Property(e => e.NumberAccountSalary)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("numberAccountSalary");
            entity.Property(e => e.PhotoPath)
                .IsUnicode(false)
                .HasColumnName("photoPath");
            entity.Property(e => e.Province)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("province");
            entity.Property(e => e.SalaryBank)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salaryBank");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.WorkModality)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("workModality");

            entity.HasOne(d => d.IdDocumentTypeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDocumentType)
                .HasConstraintName("FK__Employee__idDocu__119F9925");

            entity.HasOne(d => d.IdJobNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdJob)
                .HasConstraintName("FK__Employee__idJob__1293BD5E");

            entity.HasOne(d => d.IdJobDepartmentNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdJobDepartment)
                .HasConstraintName("FK__Employee__idJobD__1387E197");
        });

        modelBuilder.Entity<Endorsement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Endorsem__3213E83FF6B7A88B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountNc)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amountNC");
            entity.Property(e => e.AmountUs)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amountUS");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndorsementName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endorsementName");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.ReceivingEntity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("receivingEntity");
            entity.Property(e => e.Ruc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Endorsements)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Endorseme__idCom__147C05D0");
        });

        modelBuilder.Entity<FamilyBondType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FamilyBo__3213E83F518CF3B0");

            entity.ToTable("FamilyBondType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<FinancialBalance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Financia__3213E83FCEC3DAC8");

            entity.ToTable("FinancialBalance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ACashBoxBank)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("aCashBoxBank");
            entity.Property(e => e.AFixed)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("aFixed");
            entity.Property(e => e.AInventory)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("aInventory");
            entity.Property(e => e.AOtherCurrentAssets)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("aOtherCurrentAssets");
            entity.Property(e => e.AOtherNonCurrentAssets)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("aOtherNonCurrentAssets");
            entity.Property(e => e.AToCollect)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("aToCollect");
            entity.Property(e => e.BalanceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("balanceType");
            entity.Property(e => e.BalanceTypeEng)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("balanceTypeEng");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DebtRatio)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("debtRatio");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.DurationEng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("durationEng");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.ExchangeRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("exchangeRate");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.LCashBoxBank)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("lCashBoxBank");
            entity.Property(e => e.LLongTerm)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("lLongTerm");
            entity.Property(e => e.LOtherCurrentLiabilities)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("lOtherCurrentLiabilities");
            entity.Property(e => e.LOtherNonCurrentLiabilities)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("lOtherNonCurrentLiabilities");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.LiquidityRatio)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("liquidityRatio");
            entity.Property(e => e.PCapital)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("pCapital");
            entity.Property(e => e.POther)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("pOther");
            entity.Property(e => e.PStockPile)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("pStockPile");
            entity.Property(e => e.PUtilities)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("pUtilities");
            entity.Property(e => e.ProfitabilityRatio)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("profitabilityRatio");
            entity.Property(e => e.Sales)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("sales");
            entity.Property(e => e.TotalAssets)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalAssets");
            entity.Property(e => e.TotalCurrentAssets)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalCurrentAssets");
            entity.Property(e => e.TotalCurrentLiabilities)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalCurrentLiabilities");
            entity.Property(e => e.TotalLiabilitiesPatrimony)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalLiabilitiesPatrimony");
            entity.Property(e => e.TotalLliabilities)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalLliabilities");
            entity.Property(e => e.TotalNonCurrentAssets)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalNonCurrentAssets");
            entity.Property(e => e.TotalNonCurrentLiabilities)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalNonCurrentLiabilities");
            entity.Property(e => e.TotalPatrimony)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalPatrimony");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.Utilities)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("utilities");
            entity.Property(e => e.WorkingCapital)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("workingCapital");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.FinancialBalances)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Financial__idCom__15702A09");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.FinancialBalances)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__Financial__idCur__16644E42");
        });

        modelBuilder.Entity<FinancialSituacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Financia__3213E83F49E679D4");

            entity.ToTable("FinancialSituacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abreviation");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.ReportCommentWithBalance)
                .IsUnicode(false)
                .HasColumnName("reportCommentWithBalance");
            entity.Property(e => e.ReportCommentWithoutBalance)
                .IsUnicode(false)
                .HasColumnName("reportCommentWithoutBalance");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HealthIn__3213E83F24E84593");

            entity.ToTable("HealthInsurance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documentNumber");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdFamilyBondType).HasColumnName("idFamilyBondType");
            entity.Property(e => e.NameHolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nameHolder");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.HealthInsurances)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK__HealthIns__idEmp__1758727B");

            entity.HasOne(d => d.IdFamilyBondTypeNavigation).WithMany(p => p.HealthInsurances)
                .HasForeignKey(d => d.IdFamilyBondType)
                .HasConstraintName("FK__HealthIns__idFam__184C96B4");
        });

        modelBuilder.Entity<HistoryInfoChange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HistoryI__3213E83F36082371");

            entity.ToTable("HistoryInfoChange");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("action");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.IdentifierTraduction)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("identifierTraduction");
            entity.Property(e => e.LastUser).HasColumnName("lastUser");
            entity.Property(e => e.Module)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("module");
        });

        modelBuilder.Entity<ImportsAndExport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImportsA__3213E83F26C3215F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("amount");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Observation)
                .IsUnicode(false)
                .HasColumnName("observation");
            entity.Property(e => e.ObservationEng)
                .IsUnicode(false)
                .HasColumnName("observationEng");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.ImportsAndExports)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__ImportsAn__idCom__1940BAED");
        });

        modelBuilder.Entity<InternalInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Internal__3213E83FCD8E15CF");

            entity.ToTable("InternalInvoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Cycle)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cycle");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Sended)
                .HasDefaultValueSql("((1))")
                .HasColumnName("sended");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.Type)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<InternalInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Internal__3213E83F548B02D6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdInternalInvoice).HasColumnName("idInternalInvoice");
            entity.Property(e => e.IdTicketHistory).HasColumnName("idTicketHistory");
            entity.Property(e => e.IsComplement).HasColumnName("isComplement");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quality)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("quality");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdInternalInvoiceNavigation).WithMany(p => p.InternalInvoiceDetails)
                .HasForeignKey(d => d.IdInternalInvoice)
                .HasConstraintName("FK__InternalI__idInt__1A34DF26");

            entity.HasOne(d => d.IdTicketHistoryNavigation).WithMany(p => p.InternalInvoiceDetails)
                .HasForeignKey(d => d.IdTicketHistory)
                .HasConstraintName("FK__InternalI__idTic__538D5813");
        });

        modelBuilder.Entity<InvoiceFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceF__3213E83F7DB206D6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("extension");
            entity.Property(e => e.IdSubscriberInvoice).HasColumnName("idSubscriberInvoice");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .IsUnicode(false)
                .HasColumnName("path");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdSubscriberInvoiceNavigation).WithMany(p => p.InvoiceFiles)
                .HasForeignKey(d => d.IdSubscriberInvoice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceFi__idSub__1C0818FF");
        });

        modelBuilder.Entity<InvoiceState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceS__3213E83F6905FCD9");

            entity.ToTable("InvoiceState");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job__3213E83F00D82A5A");

            entity.ToTable("Job");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdJobDepartment).HasColumnName("idJobDepartment");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdJobDepartmentNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.IdJobDepartment)
                .HasConstraintName("FK__Job__idJobDepart__00FF1D08");
        });

        modelBuilder.Entity<JobDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobDepar__3213E83FEBBE7FB3");

            entity.ToTable("JobDepartment");

            entity.HasIndex(e => e.Name, "UQ__JobDepar__72E12F1B6DCC8D28").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<LandOwnership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LandOwne__3213E83F54F4823C");

            entity.ToTable("LandOwnership");

            entity.HasIndex(e => e.Name, "UQ__LandOwne__72E12F1BBE281873").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3213E83FDF56A955");

            entity.ToTable("Language");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.FlagIso)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("flagIso");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<LegalPersonType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LegalPer__3213E83FE218A60A");

            entity.ToTable("LegalPersonType");

            entity.HasIndex(e => e.Name, "UQ__LegalPer__72E12F1B1F5C2735").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sigla)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sigla");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<LegalRegisterSituation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LegalReg__3213E83FEC211711");

            entity.ToTable("LegalRegisterSituation");

            entity.HasIndex(e => e.Name, "UQ__LegalReg__72E12F1BAA1E695F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("abreviation");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Since).HasColumnName("since");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Numeration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Numerati__3213E83FADD8DFC0");

            entity.ToTable("Numeration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.InvoiceNumber).HasColumnName("invoiceNumber");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Number2).HasColumnName("number2");
            entity.Property(e => e.Number3).HasColumnName("number3");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Occupati__3213E83F6D5B157E");

            entity.ToTable("Occupation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<OldTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OldTicke__3213E83F2C8784FC");

            entity.ToTable("OldTicket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abonado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("abonado");
            entity.Property(e => e.Cupcodigo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cupcodigo");
            entity.Property(e => e.Empresa)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("empresa");
            entity.Property(e => e.EmpresaPersona)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("empresaPersona");
            entity.Property(e => e.FechaDespacho)
                .HasColumnType("datetime")
                .HasColumnName("fechaDespacho");
            entity.Property(e => e.FechaPedido)
                .HasColumnType("datetime")
                .HasColumnName("fechaPedido");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaVencimiento");
            entity.Property(e => e.Idioma)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("idioma");
            entity.Property(e => e.NombreDespachado)
                .IsUnicode(false)
                .HasColumnName("nombreDespachado");
            entity.Property(e => e.NombreSolicitado)
                .IsUnicode(false)
                .HasColumnName("nombreSolicitado");
            entity.Property(e => e.TipoInforme)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tipoInforme");
            entity.Property(e => e.Tramite)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tramite");
        });

        modelBuilder.Entity<OpcionalCommentarySb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Opcional__3213E83F44975801");

            entity.ToTable("OpcionalCommentarySBS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83FF49EE72D");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CreditAmount)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("creditAmount");
            entity.Property(e => e.DateReport)
                .HasColumnType("datetime")
                .HasColumnName("dateReport");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expirationDate");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdSubscriber).HasColumnName("idSubscriber");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.RealExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("realExpirationDate");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("referenceNumber");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Terms)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("terms");
            entity.Property(e => e.TypeOrder)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typeOrder");
            entity.Property(e => e.TypeReport)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typeReport");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Order__idCompany__01F34141");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__Order__idPerson__02E7657A");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdSubscriber)
                .HasConstraintName("FK__Order__idSubscri__03DB89B3");
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paramete__3213E83FC10CB7C6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Flag).HasColumnName("flag");
            entity.Property(e => e.Key)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("key");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        modelBuilder.Entity<PaymentPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentP__3213E83FD310C01A");

            entity.ToTable("PaymentPolicy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("apiCode");
            entity.Property(e => e.Color)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Person_Id");

            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("birthDate");
            entity.Property(e => e.BirthPlace)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("birthPlace");
            entity.Property(e => e.Cellphone)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cellphone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.ClubMember)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clubMember");
            entity.Property(e => e.CodeDocumentType)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("codeDocumentType");
            entity.Property(e => e.CodePhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codePhone");
            entity.Property(e => e.Cp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cp");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.FatherName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fatherName");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.HaveReport).HasColumnName("haveReport");
            entity.Property(e => e.IdCivilStatus).HasColumnName("idCivilStatus");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdCreditRisk).HasColumnName("idCreditRisk");
            entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");
            entity.Property(e => e.IdLegalRegisterSituation).HasColumnName("idLegalRegisterSituation");
            entity.Property(e => e.IdPaymentPolicy).HasColumnName("idPaymentPolicy");
            entity.Property(e => e.IdPersonSituation).HasColumnName("idPersonSituation");
            entity.Property(e => e.IdReputation).HasColumnName("idReputation");
            entity.Property(e => e.Insurance)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("insurance");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.LastSearched)
                .HasColumnType("datetime")
                .HasColumnName("lastSearched");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.MigratePersonCompany)
                .HasDefaultValueSql("((0))")
                .HasColumnName("migratePersonCompany");
            entity.Property(e => e.MigratePersonRelation)
                .HasDefaultValueSql("((0))")
                .HasColumnName("migratePersonRelation");
            entity.Property(e => e.MotherName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("motherName");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nationality");
            entity.Property(e => e.NewsCommentary)
                .IsUnicode(false)
                .HasColumnName("newsCommentary");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("numberPhone");
            entity.Property(e => e.OldCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("oldCode");
            entity.Property(e => e.OnWeb)
                .HasDefaultValueSql("((1))")
                .HasColumnName("onWeb");
            entity.Property(e => e.OtherDirecctions)
                .IsUnicode(false)
                .HasColumnName("otherDirecctions");
            entity.Property(e => e.Print).HasColumnName("print");
            entity.Property(e => e.PrintNewsCommentary).HasColumnName("printNewsCommentary");
            entity.Property(e => e.PrivateCommentary)
                .IsUnicode(false)
                .HasColumnName("privateCommentary");
            entity.Property(e => e.Profession)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("profession");
            entity.Property(e => e.Quality)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quality");
            entity.Property(e => e.RelationshipCodeDocument)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("relationshipCodeDocument");
            entity.Property(e => e.RelationshipDocumentType).HasColumnName("relationshipDocumentType");
            entity.Property(e => e.RelationshipWith)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("relationshipWith");
            entity.Property(e => e.ReputationCommentary)
                .IsUnicode(false)
                .HasColumnName("reputationCommentary");
            entity.Property(e => e.TaxTypeCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("taxTypeCode");
            entity.Property(e => e.TaxTypeName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("taxTypeName");
            entity.Property(e => e.TradeName)
                .IsUnicode(false)
                .HasColumnName("tradeName");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCivilStatusNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCivilStatus)
                .HasConstraintName("FK__Person__idCivilS__04CFADEC");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Person__idCountr__05C3D225");

            entity.HasOne(d => d.IdCreditRiskNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCreditRisk)
                .HasConstraintName("FK__Person__idCredit__06B7F65E");

            entity.HasOne(d => d.IdDocumentTypeNavigation).WithMany(p => p.PersonIdDocumentTypeNavigations)
                .HasForeignKey(d => d.IdDocumentType)
                .HasConstraintName("FK__Person__idDocume__07AC1A97");

            entity.HasOne(d => d.IdLegalRegisterSituationNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdLegalRegisterSituation)
                .HasConstraintName("FK__Person__idLegalR__08A03ED0");

            entity.HasOne(d => d.IdPaymentPolicyNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdPaymentPolicy)
                .HasConstraintName("FK__Person__idPaymen__09946309");

            entity.HasOne(d => d.IdPersonSituationNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdPersonSituation)
                .HasConstraintName("FK_Person_PersonSituation01");

            entity.HasOne(d => d.IdReputationNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdReputation)
                .HasConstraintName("FK__Person__idReputa__0A888742");

            entity.HasOne(d => d.RelationshipDocumentTypeNavigation).WithMany(p => p.PersonRelationshipDocumentTypeNavigations)
                .HasForeignKey(d => d.RelationshipDocumentType)
                .HasConstraintName("FK__Person__relation__0B7CAB7B");
        });

        modelBuilder.Entity<PersonActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonAc__3213E83F9423D1E1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivitiesCommentary)
                .IsUnicode(false)
                .HasColumnName("activitiesCommentary");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonActivities)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonAct__idPer__0C70CFB4");
        });

        modelBuilder.Entity<PersonGeneralInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonGe__3213E83F86C33615");

            entity.ToTable("PersonGeneralInformation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.GeneralInformation)
                .IsUnicode(false)
                .HasColumnName("generalInformation");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonGeneralInformations)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonGen__idPer__0F4D3C5F");
        });

        modelBuilder.Entity<PersonHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonHi__3213E83F828FB1D7");

            entity.ToTable("PersonHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.HistoryCommentary)
                .IsUnicode(false)
                .HasColumnName("historyCommentary");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonHistories)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonHis__idPer__10416098");
        });

        modelBuilder.Entity<PersonHome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonHo__3213E83FAF839382");

            entity.ToTable("PersonHome");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.HomeCommentary)
                .IsUnicode(false)
                .HasColumnName("homeCommentary");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.OwnHome).HasColumnName("ownHome");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonHomes)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonHom__idPer__113584D1");
        });

        modelBuilder.Entity<PersonImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonIm__3213E83F333463D5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.ImgDesc1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("imgDesc1");
            entity.Property(e => e.ImgDesc2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("imgDesc2");
            entity.Property(e => e.ImgDesc3)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("imgDesc3");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Path1)
                .IsUnicode(false)
                .HasColumnName("path1");
            entity.Property(e => e.Path2)
                .IsUnicode(false)
                .HasColumnName("path2");
            entity.Property(e => e.Path3)
                .IsUnicode(false)
                .HasColumnName("path3");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonImages)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonIma__idPer__1229A90A");
        });

        modelBuilder.Entity<PersonJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonJo__3213E83F197BA9AD");

            entity.ToTable("PersonJob");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnnualIncome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("annualIncome");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CurrentJob)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("currentJob");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndDate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("endDate");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.JobDetails)
                .IsUnicode(false)
                .HasColumnName("jobDetails");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.MonthlyIncome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("monthlyIncome");
            entity.Property(e => e.OldCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("oldCode");
            entity.Property(e => e.StartDate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("startDate");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.PersonJobs)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__PersonJob__idCom__131DCD43");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonJobs)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonJob__idPer__1411F17C");
        });

        modelBuilder.Entity<PersonProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonPr__3213E83F887EF818");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.PropertiesCommentary)
                .IsUnicode(false)
                .HasColumnName("propertiesCommentary");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonProperties)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonPro__idPer__150615B5");
        });

        modelBuilder.Entity<PersonSb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonSB__3213E83F06B19523");

            entity.ToTable("PersonSBS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AditionalCommentaryRiskCenter)
                .IsUnicode(false)
                .HasColumnName("aditionalCommentaryRiskCenter");
            entity.Property(e => e.BankingCommentary)
                .IsUnicode(false)
                .HasColumnName("bankingCommentary");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.CreditHistoryCommentary)
                .IsUnicode(false)
                .HasColumnName("creditHistoryCommentary");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DebtRecordedDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("debtRecordedDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.ExchangeRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("exchangeRate");
            entity.Property(e => e.GuaranteesOfferedFc)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("guaranteesOfferedFC");
            entity.Property(e => e.GuaranteesOfferedNc)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("guaranteesOfferedNC");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.LitigationsCommentary)
                .IsUnicode(false)
                .HasColumnName("litigationsCommentary");
            entity.Property(e => e.ReferentOrAnalyst)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("referentOrAnalyst");
            entity.Property(e => e.SbsCommentary)
                .IsUnicode(false)
                .HasColumnName("sbsCommentary");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonSbs)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PersonSBS__idPer__15FA39EE");
        });

        modelBuilder.Entity<PersonSituation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonSi__3213E83FA8B9D2C1");

            entity.ToTable("PersonSituation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3213E83F775D145A");

            entity.ToTable("Personal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.Internal)
                .HasDefaultValueSql("((1))")
                .HasColumnName("internal");
            entity.Property(e => e.Type)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK__Personal__idEmpl__0D64F3ED");
        });

        modelBuilder.Entity<PersonalPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3213E83F87313BC3");

            entity.ToTable("PersonalPrice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdPersonal).HasColumnName("idPersonal");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quality)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quality");
            entity.Property(e => e.ReportType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reportType");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.PersonalPrices)
                .HasForeignKey(d => d.IdPersonal)
                .HasConstraintName("FK__PersonalP__idPer__0E591826");
        });

        modelBuilder.Entity<PhotoPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhotoPer__3213E83FEA89F98D");

            entity.ToTable("PhotoPerson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Base64)
                .IsUnicode(false)
                .HasColumnName("base64");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DescriptionEng)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descriptionEng");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.NumImg).HasColumnName("numImg");
            entity.Property(e => e.PrintImg)
                .HasDefaultValueSql("((1))")
                .HasColumnName("printImg");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PhotoPeople)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__PhotoPers__idPer__16EE5E27");
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Process__3213E83F1C8653B3");

            entity.ToTable("Process");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Father).HasColumnName("father");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icon");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Menu)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("menu");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OrderItem).HasColumnName("orderItem");
            entity.Property(e => e.Path)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("path");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.FatherNavigation).WithMany(p => p.InverseFatherNavigation)
                .HasForeignKey(d => d.Father)
                .HasConstraintName("FK__Process__father__17E28260");
        });

        modelBuilder.Entity<ProductionClosure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producti__3213E83FAB72F5FE");

            entity.ToTable("ProductionClosure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3213E83FA099D61B");

            entity.ToTable("Profession");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provider__3213E83FFE92BBA1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalCommentary)
                .IsUnicode(false)
                .HasColumnName("additionalCommentary");
            entity.Property(e => e.AdditionalCommentaryEng)
                .IsUnicode(false)
                .HasColumnName("additionalCommentaryEng");
            entity.Property(e => e.AttendedBy)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("attendedBy");
            entity.Property(e => e.ClientSince)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clientSince");
            entity.Property(e => e.ClientSinceEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clientSinceEng");
            entity.Property(e => e.Compliance)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("compliance");
            entity.Property(e => e.ComplianceEng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("complianceEng");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateReferent)
                .HasColumnType("datetime")
                .HasColumnName("dateReferent");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Flag).HasColumnName("flag");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.MaximumAmount)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("maximumAmount");
            entity.Property(e => e.MaximumAmountEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("maximumAmountEng");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProductsTheySell)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productsTheySell");
            entity.Property(e => e.ProductsTheySellEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productsTheySellEng");
            entity.Property(e => e.Qualification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("qualification");
            entity.Property(e => e.QualificationEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("qualificationEng");
            entity.Property(e => e.ReferentCommentary)
                .IsUnicode(false)
                .HasColumnName("referentCommentary");
            entity.Property(e => e.ReferentName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("referentName");
            entity.Property(e => e.Telephone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.Ticket)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ticket");
            entity.Property(e => e.TimeLimit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("timeLimit");
            entity.Property(e => e.TimeLimitEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("timeLimitEng");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Providers__idCom__18D6A699");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Providers__idCou__19CACAD2");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__Providers__idCur__1ABEEF0B");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK_Providers_Person");
        });

        modelBuilder.Entity<Reason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reason__3213E83F04F90785");

            entity.ToTable("Reason");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<ReferencesHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Referenc__3213E83F05815CEE");

            entity.ToTable("ReferencesHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Cycle)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cycle");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IsComplement)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isComplement");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.ValidReferences).HasColumnName("validReferences");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.ReferencesHistories)
                .HasForeignKey(d => d.IdTicket)
                .HasConstraintName("FK__Reference__idTic__1BB31344");
        });

        modelBuilder.Entity<Reputation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reputati__3213E83F0B48D062");

            entity.ToTable("Reputation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OldCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("oldCode");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<SalesHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalesHis__3213E83FAEA2DF94");

            entity.ToTable("SalesHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EquivalentToDollars)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("equivalentToDollars");
            entity.Property(e => e.ExchangeRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("exchangeRate");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.SalesHistories)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__SalesHist__idCom__1CA7377D");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.SalesHistories)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__SalesHist__idCur__1D9B5BB6");
        });

        modelBuilder.Entity<SearchedName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Searched__3213E83F209E3E99");

            entity.ToTable("SearchedName");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.NameSearched)
                .IsUnicode(false)
                .HasColumnName("nameSearched");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.SearchedNames)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__SearchedN__idCom__1E8F7FEF");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.SearchedNames)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__SearchedN__idPer__1F83A428");
        });

        modelBuilder.Entity<SpecialAgentBalancePrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialA__3213E83F27828F21");

            entity.ToTable("SpecialAgentBalancePrice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Description)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdAgent).HasColumnName("idAgent");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quality)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quality");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.SpecialAgentBalancePrices)
                .HasForeignKey(d => d.IdAgent)
                .HasConstraintName("FK__SpecialAg__idAge__2077C861");
        });

        modelBuilder.Entity<SpecialPriceAgent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialP__3213E83F47155ECA");

            entity.ToTable("SpecialPriceAgent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdAgent).HasColumnName("idAgent");
            entity.Property(e => e.PriceT1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("priceT1");
            entity.Property(e => e.PriceT2)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("priceT2");
            entity.Property(e => e.PriceT3)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("priceT3");
            entity.Property(e => e.Quality)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quality");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.SpecialPriceAgents)
                .HasForeignKey(d => d.IdAgent)
                .HasConstraintName("FK__SpecialPr__idAge__216BEC9A");
        });

        modelBuilder.Entity<StatusTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusTi__3213E83F32A0646E");

            entity.ToTable("StatusTicket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abrev)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("abrev");
            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<StatusTicketObservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusTi__3213E83F6B12F718");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3213E83FBC08A881");

            entity.ToTable("Subscriber");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acronym)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("acronym");
            entity.Property(e => e.AdditionalContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("additionalContactEmail");
            entity.Property(e => e.AdditionalContactName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("additionalContactName");
            entity.Property(e => e.AdditionalContactTelephone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("additionalContactTelephone");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.FacturationType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("facturationType");
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.IdAgent).HasColumnName("idAgent");
            entity.Property(e => e.IdContinent).HasColumnName("idContinent");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.IdSubscriberCategory).HasColumnName("idSubscriberCategory");
            entity.Property(e => e.Indications)
                .IsUnicode(false)
                .HasColumnName("indications");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.MaximumCredit).HasColumnName("maximumCredit");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NormalPrice).HasColumnName("normalPrice");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.PrefFax)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("prefFax");
            entity.Property(e => e.PrefTelef)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("prefTelef");
            entity.Property(e => e.PrincipalContact)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("principalContact");
            entity.Property(e => e.Psw)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("psw");
            entity.Property(e => e.ReportInExcel).HasColumnName("reportInExcel");
            entity.Property(e => e.ReportInPdf).HasColumnName("reportInPDF");
            entity.Property(e => e.ReportInWord).HasColumnName("reportInWord");
            entity.Property(e => e.ReportInXml).HasColumnName("reportInXml");
            entity.Property(e => e.ReportInXmlCredendo).HasColumnName("reportInXmlCredendo");
            entity.Property(e => e.RevealName).HasColumnName("revealName");
            entity.Property(e => e.SendInvoiceToEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sendInvoiceToEmail");
            entity.Property(e => e.SendInvoiceToName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sendInvoiceToName");
            entity.Property(e => e.SendInvoiceToTelephone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sendInvoiceToTelephone");
            entity.Property(e => e.SendReportToEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sendReportToEmail");
            entity.Property(e => e.SendReportToName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sendReportToName");
            entity.Property(e => e.SendReportToTelephone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sendReportToTelephone");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.SubscriberType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subscriberType");
            entity.Property(e => e.TaxRegistration)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("taxRegistration");
            entity.Property(e => e.Telephone)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.Usr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usr");
            entity.Property(e => e.WebPage)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("webPage");

            entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.Subscribers)
                .HasForeignKey(d => d.IdAgent)
                .HasConstraintName("FK_subscriber_idAgent");

            entity.HasOne(d => d.IdContinentNavigation).WithMany(p => p.Subscribers)
                .HasForeignKey(d => d.IdContinent)
                .HasConstraintName("FK__Subscribe__idCon__226010D3");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Subscribers)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Subscribe__idCou__2354350C");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.Subscribers)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__Subscribe__idCur__24485945");

            entity.HasOne(d => d.IdSubscriberCategoryNavigation).WithMany(p => p.Subscribers)
                .HasForeignKey(d => d.IdSubscriberCategory)
                .HasConstraintName("FK__Subscribe__idSub__253C7D7E");
        });

        modelBuilder.Entity<SubscriberCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3213E83FDAC63659");

            entity.ToTable("SubscriberCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abreviation");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("englishName");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.OldCode).HasColumnName("oldCode");
            entity.Property(e => e.RubCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("rubCodigo");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<SubscriberInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3213E83F6F748802");

            entity.ToTable("SubscriberInvoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.IdInvoiceState).HasColumnName("idInvoiceState");
            entity.Property(e => e.IdSubscriber).HasColumnName("idSubscriber");
            entity.Property(e => e.IgvAmount)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("igvAmount");
            entity.Property(e => e.IgvFlag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("igvFlag");
            entity.Property(e => e.InvoiceCancelDate)
                .HasColumnType("datetime")
                .HasColumnName("invoiceCancelDate");
            entity.Property(e => e.InvoiceCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("invoiceCode");
            entity.Property(e => e.InvoiceEmitDate)
                .HasColumnType("datetime")
                .HasColumnName("invoiceEmitDate");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SubscriberCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("subscriberCode");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.Type)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.SubscriberInvoices)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__Subscribe__idCur__2630A1B7");

            entity.HasOne(d => d.IdInvoiceStateNavigation).WithMany(p => p.SubscriberInvoices)
                .HasForeignKey(d => d.IdInvoiceState)
                .HasConstraintName("FK__Subscribe__idInv__2724C5F0");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.SubscriberInvoices)
                .HasForeignKey(d => d.IdSubscriber)
                .HasConstraintName("FK__Subscribe__idSub__2818EA29");
        });

        modelBuilder.Entity<SubscriberInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3213E83F6C07727C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdSubscriberInvoice).HasColumnName("idSubscriberInvoice");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdSubscriberInvoiceNavigation).WithMany(p => p.SubscriberInvoiceDetails)
                .HasForeignKey(d => d.IdSubscriberInvoice)
                .HasConstraintName("FK__Subscribe__idSub__290D0E62");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.SubscriberInvoiceDetails)
                .HasForeignKey(d => d.IdTicket)
                .HasConstraintName("FK__Subscribe__idTic__2A01329B");
        });

        modelBuilder.Entity<SubscriberPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3213E83F64B6711A");

            entity.ToTable("SubscriberPrice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DayT1).HasColumnName("dayT1");
            entity.Property(e => e.DayT2).HasColumnName("dayT2");
            entity.Property(e => e.DayT3).HasColumnName("dayT3");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdContinent).HasColumnName("idContinent");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdCurrency).HasColumnName("idCurrency");
            entity.Property(e => e.IdSubscriber).HasColumnName("idSubscriber");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.PriceB)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceB");
            entity.Property(e => e.PriceT1)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceT1");
            entity.Property(e => e.PriceT2)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceT2");
            entity.Property(e => e.PriceT3)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("priceT3");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdContinentNavigation).WithMany(p => p.SubscriberPrices)
                .HasForeignKey(d => d.IdContinent)
                .HasConstraintName("FK__Subscribe__idCon__2AF556D4");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.SubscriberPrices)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Subscribe__idCou__2BE97B0D");

            entity.HasOne(d => d.IdCurrencyNavigation).WithMany(p => p.SubscriberPrices)
                .HasForeignKey(d => d.IdCurrency)
                .HasConstraintName("FK__Subscribe__idCur__2CDD9F46");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.SubscriberPrices)
                .HasForeignKey(d => d.IdSubscriber)
                .HasConstraintName("FK__Subscribe__idSub__2DD1C37F");
        });

        modelBuilder.Entity<Supervisor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supervis__3213E83F3D3E72A2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AsignedTo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("asignedTo");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.IdUserLogin).HasColumnName("idUserLogin");
            entity.Property(e => e.Type)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdUserLoginNavigation).WithMany(p => p.Supervisors)
                .HasForeignKey(d => d.IdUserLogin)
                .HasConstraintName("FK__Superviso__idUse__2EC5E7B8");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3213E83F72B1CB45");

            entity.ToTable("Ticket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.About)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("about");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AditionalData)
                .IsUnicode(false)
                .HasColumnName("aditionalData");
            entity.Property(e => e.BusineesName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("busineesName");
            entity.Property(e => e.City)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.ComercialName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("comercialName");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Creditrisk).HasColumnName("creditrisk");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.DispatchedName)
                .IsUnicode(false)
                .HasColumnName("dispatchedName");
            entity.Property(e => e.DispatchtDate)
                .HasColumnType("datetime")
                .HasColumnName("dispatchtDate");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.ExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("expireDate");
            entity.Property(e => e.HasBalance).HasColumnName("hasBalance");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdContinent).HasColumnName("idContinent");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdInvoiceState)
                .HasDefaultValueSql("((1))")
                .HasColumnName("idInvoiceState");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdSpecialAgentBalancePrice).HasColumnName("idSpecialAgentBalancePrice");
            entity.Property(e => e.IdStatusTicket).HasColumnName("idStatusTicket");
            entity.Property(e => e.IdSubscriber).HasColumnName("idSubscriber");
            entity.Property(e => e.IdTicketComplement).HasColumnName("idTicketComplement");
            entity.Property(e => e.IsComplement)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isComplement");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.NameRevealed)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nameRevealed");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.NumberTicketComplement)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numberTicketComplement");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProcedureType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("procedureType");
            entity.Property(e => e.ProcedureTypeAgent)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("procedureTypeAgent");
            entity.Property(e => e.Quality)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quality");
            entity.Property(e => e.QualityTranslator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("qualityTranslator");
            entity.Property(e => e.QualityTypist)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("qualityTypist");
            entity.Property(e => e.QueryCredit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("queryCredit");
            entity.Property(e => e.RealExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("realExpireDate");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("referenceNumber");
            entity.Property(e => e.ReportType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reportType");
            entity.Property(e => e.RequestedName)
                .IsUnicode(false)
                .HasColumnName("requestedName");
            entity.Property(e => e.RevealName)
                .HasDefaultValueSql("((0))")
                .HasColumnName("revealName");
            entity.Property(e => e.SubscriberIndications)
                .IsUnicode(false)
                .HasColumnName("subscriberIndications");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("taxCode");
            entity.Property(e => e.TaxType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("taxType");
            entity.Property(e => e.Telephone)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.TimeLimit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("timeLimit");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.Web)
                .HasDefaultValueSql("((0))")
                .HasColumnName("web");
            entity.Property(e => e.WebPage)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("webPage");
            entity.Property(e => e.Wrong)
                .HasDefaultValueSql("((0))")
                .HasColumnName("wrong");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Ticket__idCompan__2FBA0BF1");

            entity.HasOne(d => d.IdContinentNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdContinent)
                .HasConstraintName("FK__Ticket__idContin__30AE302A");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Ticket__idCountr__31A25463");

            entity.HasOne(d => d.IdInvoiceStateNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdInvoiceState)
                .HasConstraintName("FK_Ticket_InvoiceState");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__Ticket__idPerson__3296789C");

            entity.HasOne(d => d.IdSpecialAgentBalancePriceNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdSpecialAgentBalancePrice)
                .HasConstraintName("FK__Ticket__idSpecia__338A9CD5");

            entity.HasOne(d => d.IdStatusTicketNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdStatusTicket)
                .HasConstraintName("FK__Ticket__idStatus__347EC10E");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdSubscriber)
                .HasConstraintName("FK__Ticket__idSubscr__3572E547");

            entity.HasOne(d => d.IdTicketComplementNavigation).WithMany(p => p.InverseIdTicketComplementNavigation)
                .HasForeignKey(d => d.IdTicketComplement)
                .HasConstraintName("FK__Ticket__idTicket__36670980");
        });

        modelBuilder.Entity<TicketAssignation>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__TicketAs__22B1456F56CC7D3F");

            entity.ToTable("TicketAssignation");

            entity.Property(e => e.IdTicket)
                .ValueGeneratedNever()
                .HasColumnName("idTicket");
            entity.Property(e => e.Commentary)
                .IsUnicode(false)
                .HasColumnName("commentary");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdUserLogin).HasColumnName("idUserLogin");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.TicketAssignations)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_TicketAssignation_Employee");

            entity.HasOne(d => d.IdTicketNavigation).WithOne(p => p.TicketAssignation)
                .HasForeignKey<TicketAssignation>(d => d.IdTicket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TicketAss__idTic__375B2DB9");
        });

        modelBuilder.Entity<TicketFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TicketFi__3213E83FD5858985");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("extension");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .IsUnicode(false)
                .HasColumnName("path");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.TicketFiles)
                .HasForeignKey(d => d.IdTicket)
                .HasConstraintName("FK__TicketFil__idTic__384F51F2");
        });

        modelBuilder.Entity<TicketHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TicketHi__3213E83F4CC876F7");

            entity.ToTable("TicketHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AsignationType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("asignationType");
            entity.Property(e => e.AsignedTo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("asignedTo");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.Cycle)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cycle");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.DirectTranslation).HasColumnName("directTranslation");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((1))")
                .HasColumnName("flag");
            entity.Property(e => e.FlagInvoice)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flagInvoice");
            entity.Property(e => e.IdStatusTicket).HasColumnName("idStatusTicket");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.NumberAssign).HasColumnName("numberAssign");
            entity.Property(e => e.Observations)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.References).HasColumnName("references");
            entity.Property(e => e.ReturnMessage)
                .IsUnicode(false)
                .HasColumnName("returnMessage");
            entity.Property(e => e.ShippingDate)
                .HasColumnType("datetime")
                .HasColumnName("shippingDate");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.UserFrom)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userFrom");
            entity.Property(e => e.UserTo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userTo");

            entity.HasOne(d => d.IdStatusTicketNavigation).WithMany(p => p.TicketHistories)
                .HasForeignKey(d => d.IdStatusTicket)
                .HasConstraintName("FK__TicketHis__idSta__3943762B");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.TicketHistories)
                .HasForeignKey(d => d.IdTicket)
                .HasConstraintName("FK__TicketHis__idTic__3A379A64");
        });

        modelBuilder.Entity<TicketObservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TicketOb__3213E83F115182AE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.About)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("about");
            entity.Property(e => e.AsignedDate)
                .HasColumnType("datetime")
                .HasColumnName("asignedDate");
            entity.Property(e => e.Cc)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("cc");
            entity.Property(e => e.Conclusion)
                .IsUnicode(false)
                .HasColumnName("conclusion");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdReason).HasColumnName("idReason");
            entity.Property(e => e.IdStatusTicketObservations).HasColumnName("idStatusTicketObservations");
            entity.Property(e => e.IdSubscriber).HasColumnName("idSubscriber");
            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.Message)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.RespAg)
                .HasDefaultValueSql("((0))")
                .HasColumnName("respAg");
            entity.Property(e => e.RespCl)
                .HasDefaultValueSql("((0))")
                .HasColumnName("respCl");
            entity.Property(e => e.RespDrr)
                .HasDefaultValueSql("((0))")
                .HasColumnName("respDRR");
            entity.Property(e => e.SolutionDate)
                .HasColumnType("datetime")
                .HasColumnName("solutionDate");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.TicketObservations)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__TicketObs__idCom__3B2BBE9D");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.TicketObservations)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__TicketObs__idPer__3C1FE2D6");

            entity.HasOne(d => d.IdReasonNavigation).WithMany(p => p.TicketObservations)
                .HasForeignKey(d => d.IdReason)
                .HasConstraintName("FK__TicketObs__idRea__3D14070F");

            entity.HasOne(d => d.IdStatusTicketObservationsNavigation).WithMany(p => p.TicketObservations)
                .HasForeignKey(d => d.IdStatusTicketObservations)
                .HasConstraintName("FK__TicketObs__idSta__3E082B48");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.TicketObservations)
                .HasForeignKey(d => d.IdSubscriber)
                .HasConstraintName("FK__TicketObs__idSub__3EFC4F81");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.TicketObservations)
                .HasForeignKey(d => d.IdTicket)
                .HasConstraintName("FK_TicketObservations_Ticket_id");
        });

        modelBuilder.Entity<TicketQuery>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__TicketQu__22B1456F3C893AD2");

            entity.ToTable("TicketQuery");

            entity.Property(e => e.IdTicket)
                .ValueGeneratedNever()
                .HasColumnName("idTicket");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdSubscriber).HasColumnName("idSubscriber");
            entity.Property(e => e.Language)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("language");
            entity.Property(e => e.Message)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.QueryDate)
                .HasColumnType("datetime")
                .HasColumnName("queryDate");
            entity.Property(e => e.Response)
                .IsUnicode(false)
                .HasColumnName("response");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.TicketQueries)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK__TicketQue__idEmp__3FF073BA");

            entity.HasOne(d => d.IdSubscriberNavigation).WithMany(p => p.TicketQueries)
                .HasForeignKey(d => d.IdSubscriber)
                .HasConstraintName("FK__TicketQue__idSub__40E497F3");

            entity.HasOne(d => d.IdTicketNavigation).WithOne(p => p.TicketQuery)
                .HasForeignKey<TicketQuery>(d => d.IdTicket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TicketQue__idTic__41D8BC2C");
        });

        modelBuilder.Entity<TicketReceptor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TicketRe__3213E83F55541613");

            entity.ToTable("TicketReceptor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IsDobleFecha)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDobleFecha");
            entity.Property(e => e.IsEnFecha)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isEnFecha");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.TicketReceptors)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK__TicketRec__idEmp__42CCE065");
        });

        modelBuilder.Entity<TraductionCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Traducti__3213E83F15423EFF");

            entity.ToTable("TraductionCompany");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.TBduration)
                .IsUnicode(false)
                .HasColumnName("tBDuration");
            entity.Property(e => e.TBhistory)
                .IsUnicode(false)
                .HasColumnName("tBHistory");
            entity.Property(e => e.TBincreaseDate)
                .IsUnicode(false)
                .HasColumnName("tBIncreaseDate");
            entity.Property(e => e.TBlegalBack)
                .IsUnicode(false)
                .HasColumnName("tBLegalBack");
            entity.Property(e => e.TBpaidCapital)
                .IsUnicode(false)
                .HasColumnName("tBPaidCapital");
            entity.Property(e => e.TBpublicRegis)
                .IsUnicode(false)
                .HasColumnName("tBPublicRegis");
            entity.Property(e => e.TBregisterIn)
                .IsUnicode(false)
                .HasColumnName("tBRegisterIn");
            entity.Property(e => e.TBtacRate)
                .IsUnicode(false)
                .HasColumnName("tBTacRate");
            entity.Property(e => e.TEcomide)
                .IsUnicode(false)
                .HasColumnName("tEComide");
            entity.Property(e => e.TEduration)
                .IsUnicode(false)
                .HasColumnName("tEDuration");
            entity.Property(e => e.TEnew)
                .IsUnicode(false)
                .HasColumnName("tENew");
            entity.Property(e => e.TEreputation)
                .IsUnicode(false)
                .HasColumnName("tEReputation");
            entity.Property(e => e.TFanalistCom)
                .IsUnicode(false)
                .HasColumnName("tFAnalistCom");
            entity.Property(e => e.TFcomment)
                .IsUnicode(false)
                .HasColumnName("tFComment");
            entity.Property(e => e.TFjob)
                .IsUnicode(false)
                .HasColumnName("tFJob");
            entity.Property(e => e.TFprincActiv)
                .IsUnicode(false)
                .HasColumnName("tFPrincActiv");
            entity.Property(e => e.TFselectFin)
                .IsUnicode(false)
                .HasColumnName("tFSelectFin");
            entity.Property(e => e.TFtabComm)
                .IsUnicode(false)
                .HasColumnName("tFTabComm");
            entity.Property(e => e.TIgeneral)
                .IsUnicode(false)
                .HasColumnName("tIGeneral");
            entity.Property(e => e.TOcommentary)
                .IsUnicode(false)
                .HasColumnName("tOCommentary");
            entity.Property(e => e.TOqueryCredit)
                .IsUnicode(false)
                .HasColumnName("tOQueryCredit");
            entity.Property(e => e.TOsugCredit)
                .IsUnicode(false)
                .HasColumnName("tOSugCredit");
            entity.Property(e => e.TRadiBus)
                .IsUnicode(false)
                .HasColumnName("tRAdiBus");
            entity.Property(e => e.TRcreditPer)
                .IsUnicode(false)
                .HasColumnName("tRCreditPer");
            entity.Property(e => e.TRextSales)
                .IsUnicode(false)
                .HasColumnName("tRExtSales");
            entity.Property(e => e.TRinterBuy)
                .IsUnicode(false)
                .HasColumnName("tRInterBuy");
            entity.Property(e => e.TRmainAddress)
                .IsUnicode(false)
                .HasColumnName("tRMainAddress");
            entity.Property(e => e.TRnatiBuy)
                .IsUnicode(false)
                .HasColumnName("tRNatiBuy");
            entity.Property(e => e.TRotherLocals)
                .IsUnicode(false)
                .HasColumnName("tROtherLocals");
            entity.Property(e => e.TRprincAct)
                .IsUnicode(false)
                .HasColumnName("tRPrincAct");
            entity.Property(e => e.TRsalePer)
                .IsUnicode(false)
                .HasColumnName("tRSalePer");
            entity.Property(e => e.TRterritory)
                .IsUnicode(false)
                .HasColumnName("tRTerritory");
            entity.Property(e => e.TRtotalArea)
                .IsUnicode(false)
                .HasColumnName("tRTotalArea");
            entity.Property(e => e.TSavales)
                .IsUnicode(false)
                .HasColumnName("tSAvales");
            entity.Property(e => e.TSbancarios)
                .IsUnicode(false)
                .HasColumnName("tSBancarios");
            entity.Property(e => e.TScommentary)
                .IsUnicode(false)
                .HasColumnName("tSCommentary");
            entity.Property(e => e.TScredHis)
                .IsUnicode(false)
                .HasColumnName("tSCredHis");
            entity.Property(e => e.TSlitig)
                .IsUnicode(false)
                .HasColumnName("tSLitig");
            entity.Property(e => e.UploadDate)
                .HasColumnType("datetime")
                .HasColumnName("uploadDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.TraductionCompanies)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Traductio__idCom__43C1049E");
        });

        modelBuilder.Entity<TraductionPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Traducti__3213E83FCFA26F1F");

            entity.ToTable("TraductionPerson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.TAotherAct)
                .IsUnicode(false)
                .HasColumnName("tAOtherAct");
            entity.Property(e => e.TCcurjob)
                .IsUnicode(false)
                .HasColumnName("tCCurjob");
            entity.Property(e => e.TCdetails)
                .IsUnicode(false)
                .HasColumnName("tCDetails");
            entity.Property(e => e.TCenddt)
                .IsUnicode(false)
                .HasColumnName("tCEnddt");
            entity.Property(e => e.TCincome)
                .IsUnicode(false)
                .HasColumnName("tCIncome");
            entity.Property(e => e.TCstartDate)
                .IsUnicode(false)
                .HasColumnName("tCStartDate");
            entity.Property(e => e.TDresidence)
                .IsUnicode(false)
                .HasColumnName("tDResidence");
            entity.Property(e => e.TDvalue)
                .IsUnicode(false)
                .HasColumnName("tDValue");
            entity.Property(e => e.THdetails)
                .IsUnicode(false)
                .HasColumnName("tHDetails");
            entity.Property(e => e.TIgdetails)
                .IsUnicode(false)
                .HasColumnName("tIGDetails");
            entity.Property(e => e.TPbirthPlace)
                .IsUnicode(false)
                .HasColumnName("tPBirthPlace");
            entity.Property(e => e.TPmarriedTo)
                .IsUnicode(false)
                .HasColumnName("tPMarriedTo");
            entity.Property(e => e.TPnacionality)
                .IsUnicode(false)
                .HasColumnName("tPNacionality");
            entity.Property(e => e.TPnewcomm)
                .IsUnicode(false)
                .HasColumnName("tPNewcomm");
            entity.Property(e => e.TPprofession)
                .IsUnicode(false)
                .HasColumnName("tPProfession");
            entity.Property(e => e.TPrdetails)
                .IsUnicode(false)
                .HasColumnName("tPRDetails");
            entity.Property(e => e.TPreputation)
                .IsUnicode(false)
                .HasColumnName("tPReputation");
            entity.Property(e => e.TSbsantecedente)
                .IsUnicode(false)
                .HasColumnName("tSBSAntecedente");
            entity.Property(e => e.TSbscommentBank)
                .IsUnicode(false)
                .HasColumnName("tSBSCommentBank");
            entity.Property(e => e.TSbscommentSbs)
                .IsUnicode(false)
                .HasColumnName("tSBSCommentSBS");
            entity.Property(e => e.TSbslitig)
                .IsUnicode(false)
                .HasColumnName("tSBSLitig");
            entity.Property(e => e.TSbsrickCnt)
                .IsUnicode(false)
                .HasColumnName("tSBSRickCnt");
            entity.Property(e => e.UploadDate)
                .HasColumnType("datetime")
                .HasColumnName("uploadDate");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.TraductionPeople)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__Traductio__idPer__44B528D7");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3213E83F8222B22C");

            entity.ToTable("UserLogin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.EmailPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("emailPassword");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.HasHolder).HasColumnName("hasHolder");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdHolder).HasColumnName("idHolder");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.UserLogin1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("userLogin");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK__UserLogin__idEmp__45A94D10");
        });

        modelBuilder.Entity<UserProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserProc__3213E83FACC42523");

            entity.ToTable("UserProcess");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdProcess).HasColumnName("idProcess");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdProcessNavigation).WithMany(p => p.UserProcesses)
                .HasForeignKey(d => d.IdProcess)
                .HasConstraintName("FK__UserProce__idPro__469D7149");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserProcesses)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__UserProce__idUse__47919582");
        });

        modelBuilder.Entity<WorkersHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkersH__3213E83F2DB44BA9");

            entity.ToTable("WorkersHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.LastUpdateUser).HasColumnName("lastUpdateUser");
            entity.Property(e => e.NumberWorker).HasColumnName("numberWorker");
            entity.Property(e => e.NumberYear).HasColumnName("numberYear");
            entity.Property(e => e.Observations).IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.WorkersHistories)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__WorkersHi__idCom__4885B9BB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
