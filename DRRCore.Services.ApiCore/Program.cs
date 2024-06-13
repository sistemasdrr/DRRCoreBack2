using DRRCore.Application.Interfaces;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Interfaces.EmailApplication;
using DRRCore.Application.Main;
using DRRCore.Application.Main.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Domain.Main;
using DRRCore.Domain.Main.CoreDomain;
using DRRCore.Domain.Main.EmailDomain;
using DRRCore.Domain.Main.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using DRRCore.Infraestructure.Interfaces.Repository;
using DRRCore.Infraestructure.Repository.CoreRepository;
using DRRCore.Infraestructure.Repository.MYSQLRepository;
using DRRCore.Infraestructure.Repository.SQLRepository;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using DRRCore.Transversal.Common.JsonReader;
using DRRCore.Transversal.Mapper.Profiles.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SftpSettings>(builder.Configuration.GetSection("SftpSettings"));
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100 MB
});
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<List<SpecialPriceAgent>>(builder.Configuration.GetSection("SpecialPricesAgent"));
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(EmployeeProfile).Assembly);
builder.Services.AddAutoMapper(typeof(SubscriberProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ComboProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CompanyProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PersonProfile).Assembly);
builder.Services.AddAutoMapper(typeof(AnniversaryProfile).Assembly);
builder.Services.AddAutoMapper(typeof(TicketProfile).Assembly);
builder.Services.AddAutoMapper(typeof(InvoiceProfile).Assembly);
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<IWebQueryRepository, WebQueryRepository>();
builder.Services.AddScoped<IMySqlWebRepository, MySqlWebRepository>();
builder.Services.AddScoped<IApiUserRepository, ApiUserRepository>();


builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IJobDepartmentRepository, JobDepartmentRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IProcessRepository, ProcessRepository>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
builder.Services.AddScoped<IUserProcessRepository, UserProcessRepository>();
builder.Services.AddScoped<ICivilStatusRepository, CivilStatusRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IFamilyBondTypeRepository, FamilyBondyTypeRepository>();
builder.Services.AddScoped<IBankAccountTypeRepository, BankAccountTypeRepository>();
builder.Services.AddScoped<ILegalPersonTypeRepository, LegalPersonTypeRepository>();
builder.Services.AddScoped<ICreditRiskRepository, CreditRiskRepository>();
builder.Services.AddScoped<IReputationRepository, ReputationRepository>();
builder.Services.AddScoped<IPaymentPolicyRepository, PaymentPolicyRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ILegalRegisterSituationRepository, LegalRegisterSituationRepository>();
builder.Services.AddScoped<ICompanyBackgroundRepository, CompanyBackgroundRepository>();
builder.Services.AddScoped<ICompanyBranchRepository, CompanyBranchRepository>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddScoped<IAnniversaryRepository, AnniversaryRepository>();
builder.Services.AddScoped<ISubscriberPriceRepository, SubscriberPriceRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IAgentPriceRepository, AgentPriceRepository>();
builder.Services.AddScoped<ICouponBillingSubscriberRepository, CouponBillingSubscriberRepository>();
builder.Services.AddScoped<ICouponBillingSubscriberHistoryRepository, CouponBillingSubscriberHistoryRepository>();
builder.Services.AddScoped<ISubscriberCategoryRepository, SubscriberCategoryRepository>();
builder.Services.AddScoped<IFinancialSituacionRepository, FinancialSituacionRepository>();
builder.Services.AddScoped<ICollaborationDegreeRepository, CollaborationDegreeRepository>();
builder.Services.AddScoped<ICompanyFinancialInformationRepository, CompanyFinancialInformationRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketHistoryRepository, TicketHistoryRepository>();
builder.Services.AddScoped<INumerationRepository, NumerationRepository>();
builder.Services.AddScoped<IFinancialSalesHistoryRepository, FinancialSalesHistoryRepository>();
builder.Services.AddScoped<IFinancialBalanceRepository, FinancialBalanceRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IComercialLatePaymentRepository, ComercialLatePaymentRepository>();
builder.Services.AddScoped<IBankDebtRepository, BankDebtRepository>();
builder.Services.AddScoped<ICompanySBSRepository, CompanySBSRepository>();
builder.Services.AddScoped<IOpcionalCommentarySbsRepository, OpcionalCommentarySbsRepository>();
builder.Services.AddScoped<IEndorsementsRepository, EndorsementsRepository>();
builder.Services.AddScoped<ICompanyCreditOpinionRepository, CompanyCreditOpinionRepository>();
builder.Services.AddScoped<ICompanyGeneralInformationRepository, CompanyGeneralInformationRepository>();
builder.Services.AddScoped<ICompanyImagesRepository, CompanyImagesRepository>();
builder.Services.AddScoped<ICompanyImageRepository, CompanyImageRepository>();
builder.Services.AddScoped<IBranchSectorRepository, BranchSectorRepository>();
builder.Services.AddScoped<IBusinessBranchRepository, BusinessBranchRepository>();
builder.Services.AddScoped<IBusinessActivityRepository, BusinessActivityRepository>();
builder.Services.AddScoped<ILandOwnershipRepository, LandOwnershipRepository>();
builder.Services.AddScoped<ITCuponRepository, TCuponRepository>();
builder.Services.AddScoped<IImportsAndExportsRepository, ImportsAndExportsRepository>();
builder.Services.AddScoped<ITicketReceptorRepository, TicketReceptorRepository>();
builder.Services.AddScoped<IPersonSituationRepository, PersonSituationRepository>();
builder.Services.AddScoped<IProfessionRepository, ProfessionRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonHomeRepository, PersonHomeRepository>();
builder.Services.AddScoped<IPersonJobRepository, PersonJobRepository>();
builder.Services.AddScoped<IPersonActivitiesRepository, PersonActivitiesRepository>();
builder.Services.AddScoped<IPersonPropertiesRepository, PersonPropertiesRepository>();
builder.Services.AddScoped<IPersonHistoryRepository, PersonHistoryRepository>();
builder.Services.AddScoped<IPersonGeneralInfoRepository, PersonGeneralInfoRepository>();
builder.Services.AddScoped<IPersonImagesRepository, PersonImagesRepository>();
builder.Services.AddScoped<IPersonSBSRepository, PersonSBSRepository>();
builder.Services.AddScoped<ICompanyPartnersRepository, CompanyPartnersRepository>();
builder.Services.AddScoped<ICompanyShareHolderRepository, CompanyShareHolderRepository>();
builder.Services.AddScoped<IWorkerHistoryRepository, WorkerHistoryRepository>();
builder.Services.AddScoped<ICompanyRelationRepository, CompanyRelationRepository>();
builder.Services.AddScoped<IPersonPhotoRepository, PersonPhotoRepository>();
builder.Services.AddScoped<ITicketAssignationRepository, TicketAssignationRepository>();
builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();


builder.Services.AddScoped<IEmailConfigurationRepository, EmailConfigurationRepository>();
builder.Services.AddScoped<IEmailHistoryRepository, EmailHistoryRepository>();
builder.Services.AddScoped<IAttachmentsNotSendRepository, AttachmentsNotSendRepository>();

builder.Services.AddScoped<IWebDataDomain, WebDataDomain>();
builder.Services.AddScoped<IApiUserDomain, ApiUserDomain>();


builder.Services.AddScoped<ICountryDomain, CountryDomain>();
builder.Services.AddScoped<IDocumentTypeDomain, DocumentTypeDomain>();
builder.Services.AddScoped<IEmployeeDomain, EmployeeDomain>();
builder.Services.AddScoped<IJobDepartmentDomain, JobDepartmentDomain>();
builder.Services.AddScoped<IJobDomain, JobDomain>();
builder.Services.AddScoped<IProcessDomain, ProcessDomain>();
builder.Services.AddScoped<IUserLoginDomain, UserLoginDomain>();
builder.Services.AddScoped<IUserProcessDomain, UserProcessDomain>();
builder.Services.AddScoped<ICivilStatusDomain, CivilStatusDomain>();
builder.Services.AddScoped<IBankAccountTypeDomain, BankAccountTypeDomain>();
builder.Services.AddScoped<IFamilyBondyTypeDomain, FamilyBondyTypeDomain>();
builder.Services.AddScoped<ICurrencyDomain, CurrencyDomain>();
builder.Services.AddScoped<ILegalPersonTypeDomain, LegalPersonTypeDomain>();
builder.Services.AddScoped<ICreditRiskDomain, CreditRiskDomain>();
builder.Services.AddScoped<IReputationDomain, ReputationDomain>();
builder.Services.AddScoped<IPaymentPolicyDomain, PaymentPolicyDomain>();
builder.Services.AddScoped<ICompanyDomain, CompanyDomain>();
builder.Services.AddScoped<ILegalRegisterSituationDomain, LegalRegisterSituationDomain>();
builder.Services.AddScoped<ICompanyBackgroundDomain, CompanyBackgroundDomain>();
builder.Services.AddScoped<ICompanyBranchDomain, CompanyBranchDomain>();
builder.Services.AddScoped<ISubscriberDomain, SubscriberDomain>();
builder.Services.AddScoped<IAnniversaryDomain, AnniversaryDomain>();
builder.Services.AddScoped<ISubscriberPriceDomain, SubscriberPriceDomain>();
builder.Services.AddScoped<IAgentDomain, AgentDomain>();
builder.Services.AddScoped<IAgentPriceDomain, AgentPriceDomain>();
builder.Services.AddScoped<ICouponBillingSubscriberDomain, CouponBillingSubscriberDomain>();
builder.Services.AddScoped<ICouponBillingSubscriberHistoryDomain, CouponBillingSubscriberHistoryDomain>();
builder.Services.AddScoped<ISubscriberCategoryDomain, SubscriberCategoryDomain>();
builder.Services.AddScoped<IFinancialSituacionDomain, FinancialSituacionDomain>();
builder.Services.AddScoped<ICollaborationDegreeDomain, CollaborationDegreeDomain>();
builder.Services.AddScoped<ICompanyFinancialInformationDomain, CompanyFinancialInformationDomain>();
builder.Services.AddScoped<IFinancialSalesHistoryDomain, FinancialSalesHistoryDomain>();
builder.Services.AddScoped<IFinancialBalanceDomain, FinancialBalanceDomain>();
builder.Services.AddScoped<IProviderDomain, ProviderDomain>();
builder.Services.AddScoped<IComercialLatePaymentDomain, ComercialLatePaymentDomain>();
builder.Services.AddScoped<IBankDebtDomain, BankDebtDomain>();
builder.Services.AddScoped<ITicketDomain, TicketDomain>();
builder.Services.AddScoped<ITicketHistoryDomain, TicketHistoryDomain>();
builder.Services.AddScoped<INumerationDomain, NumerationDomain>();
builder.Services.AddScoped<ICompanySBSDomain, CompanySBSDomain>();
builder.Services.AddScoped<IOpcionalCommentarySbsDomain, OpcionalCommentarySbsDomain>();
builder.Services.AddScoped<IEndorsementsDomain, EndorsementsDomain>();
builder.Services.AddScoped<ICompanyCreditOpinionDomain, CompanyCreditOpinionDomain>();
builder.Services.AddScoped<ICompanyGeneralInformationDomain, CompanyGeneralInformationDomain>();
builder.Services.AddScoped<ICompanyImagesDomain, CompanyImagesDomain>();
builder.Services.AddScoped<ICompanyImageDomain, CompanyImageDomain>();
builder.Services.AddScoped<IBranchSectorDomain, BranchSectorDomain>();
builder.Services.AddScoped<IBusinessBranchDomain, BusinessBranchDomain>();
builder.Services.AddScoped<IBusinessActivityDomain, BusinessActivityDomain>();
builder.Services.AddScoped<ILandOwnershipDomain, LandOwnershipDomain>();
builder.Services.AddScoped<ITCuponDomain, TCuponDomain>();
builder.Services.AddScoped<IImportsAndExportsDomain, ImportsAndExportsDomain>();
builder.Services.AddScoped<ITicketReceptorDomain, TicketReceptorDomain>();
builder.Services.AddScoped<IPersonSituationDomain, PersonSituationDomain>();
builder.Services.AddScoped<IProfessionDomain, ProfessionDomain>();
builder.Services.AddScoped<IPersonDomain, PersonDomain>();
builder.Services.AddScoped<IPersonHomeDomain, PersonHomeDomain>();
builder.Services.AddScoped<IPersonJobDomain, PersonJobDomain>();
builder.Services.AddScoped<IPersonActivitiesDomain, PersonActivitiesDomain>();
builder.Services.AddScoped<IPersonPropertyDomain, PersonPropertyDomain>();
builder.Services.AddScoped<IPersonHistoryDomain, PersonHistoryDomain>();
builder.Services.AddScoped<IPersonGeneralInfoDomain, PersonGeneralInfoDomain>();
builder.Services.AddScoped<IPersonImagesDomain, PersonImagesDomain>();
builder.Services.AddScoped<IPersonSBSDomain, PersonSBSDomain>();
builder.Services.AddScoped<ICompanyPartnersDomain, CompanyPartnersDomain>();
builder.Services.AddScoped<ICompanyShareHolderDomain, CompanyShareHolderDomain>();
builder.Services.AddScoped<IWorkerHistoryDomain, WorkerHistoryDomain>();
builder.Services.AddScoped<ICompanyRelationDomain, CompanyRelationDomain>();
builder.Services.AddScoped<IPersonPhotoDomain, PersonPhotoDomain>();
builder.Services.AddScoped<ITicketAssignationDomain, TicketAssignationDomain>();
builder.Services.AddScoped<IPersonalDomain, PersonalDomain>();

builder.Services.AddScoped<IEmailHistoryDomain, EmailHistoryDomain>();
builder.Services.AddScoped<IAttachmentsNotSendDomain, AttachmentsNotSendDomain>();
builder.Services.AddScoped<IEmailConfigurationDomain, EmailConfigurationDomain>();

builder.Services.AddScoped<IComboboxApplication, ComboboxApplication>();
builder.Services.AddScoped<IEmployeeApplication, EmployeeAplication>();
builder.Services.AddScoped<ICompanyApplication, CompanyApplication>();
builder.Services.AddScoped<ICompanyImagesApplication, CompanyImagesApplication>();
builder.Services.AddScoped<ISubscriberApplication, SubscriberApplication>();
builder.Services.AddScoped<ISubscriberPriceApplication, SubscriberPriceApplication>();
builder.Services.AddScoped<IAnniversaryApplication, AnniversayApplication>();
builder.Services.AddScoped<IAgentApplication, AgentApplication>();
builder.Services.AddScoped<IAgentPriceApplication, AgentPriceApplication>();
builder.Services.AddScoped<ICouponBillingSubscriberApplication, CouponBillingSubscriberApplication>();
builder.Services.AddScoped<ITicketApplication, TicketApplication>();
builder.Services.AddScoped<IPersonApplication, PersonApplication>();
builder.Services.AddScoped<IPersonImagesApplication, PersonImagesApplication>();
builder.Services.AddScoped<IApiApplication, ApiApplication>();
builder.Services.AddScoped<ITokenValidationApplication, TokenValidationApplication>();
builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IXmlApplication, XmlApplication>();

builder.Services.AddScoped<IEmailApplication, EmailApplication>();
builder.Services.AddScoped<IInvoiceApplication, InvoiceApplication>();
builder.Services.AddScoped<IDashboardApplication, DashboardApplication>();
builder.Services.AddScoped<IQueryApplication, QueryApplication>();
builder.Services.AddScoped<IChartApplication, ChartApplication>();

builder.Services.AddScoped<IMailSender, MailSender>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IMailFormatter, MailFormatter>();
builder.Services.AddScoped<IReportingDownload, ReportingDownload>();
builder.Services.AddScoped<IFunction, Functions>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<DRRCore.Transversal.Common.Interface.ILogger, LoggerManager>();

/*
 * JWT
 */


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
/*
 * //JWT
 */

var app = builder.Build();

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
