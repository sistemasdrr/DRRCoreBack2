using DRRCore.Application.Interfaces;
using DRRCore.Application.Main;
using DRRCore.Domain.Interfaces;
using DRRCore.Domain.Main;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using DRRCore.Infraestructure.Interfaces.Repository;
using DRRCore.Infraestructure.Repository.MYSQLRepository;
using DRRCore.Infraestructure.Repository.SQLRepository;
using DRRCore.Transversal.Common.Interface;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.JsonReader;
using DRRCore.Transversal.Mapper.Profiles.Web;
using System.Configuration;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Domain.Main.EmailDomain;
using DRRCore.Application.Interfaces.EmailApplication;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<SftpSettings>(builder.Configuration.GetSection("SftpSettings"));



// Add services to the container.
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(DataProfile).Assembly);


//Injection Repository
builder.Services.AddScoped<IMySqlUserRepository, MySqlUserRepository>();
builder.Services.AddScoped<IMySqlWebRepository, MySqlWebRepository>();
builder.Services.AddScoped<IWebQueryRepository, WebQueryRepository>();
builder.Services.AddScoped<IAttachmentsNotSendRepository, AttachmentsNotSendRepository>();
builder.Services.AddScoped<IEmailConfigurationRepository, EmailConfigurationRepository>();
builder.Services.AddScoped<IEmailHistoryRepository, EmailHistoryRepository>();


//Injection Domain
builder.Services.AddScoped<IWebDataDomain, WebDataDomain>();
builder.Services.AddScoped<IAttachmentsNotSendDomain, AttachmentsNotSendDomain>();
builder.Services.AddScoped<IEmailConfigurationDomain, EmailConfigurationDomain>();
builder.Services.AddScoped<IEmailHistoryDomain, EmailHistoryDomain>();

//Injection Application

builder.Services.AddScoped<IWebDataApplication, WebDataApplication>();
builder.Services.AddScoped<IEmailApplication, EmailApplication>();
//Injection Common
builder.Services.AddScoped<IMailSender, MailSender>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IMailFormatter, MailFormatter>();
builder.Services.AddScoped<DRRCore.Transversal.Common.Interface.ILogger, LoggerManager>();
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
