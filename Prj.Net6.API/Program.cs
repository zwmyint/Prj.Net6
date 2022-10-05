using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Prj.Net6.API.Sinks;
using Prj.Net6.Core.Interfaces;
using Prj.Net6.Infrastructure;
using Prj.Net6.Infrastructure.Repositories;
using Prj.Net6.API.Middleware;
using Serilog;
using Microsoft.AspNetCore.HttpLogging;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Mvc.Filters;
using static Dapper.SqlMapper;
using Prj.Net6.API;

var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json");

var config = configuration.Build();
//var connectionString = config.GetConnectionString("HangfireConnection");


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// added (Zaw)
var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.CustomSink()
        .Enrich.FromLogContext()
        .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// added for AppSettingConnection // Dependency Injection
builder.Services.AddPersistence(builder.Configuration);

//
//builder.Services.AddSendGrid(options => options.ApiKey = builder.Configuration["SendGridApiKey"]);

//Hangfire
builder.Services.AddHangfire(x => x
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(config.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

builder.Services.AddHangfireServer();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp-API", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "XApiKey",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
    c.ResolveConflictingActions(x => x.First());
});

// added for MemoryCache
builder.Services.AddMemoryCache();

// added for logging
builder.Services.AddHttpLogging(logging =>
{
    // Customize HTTP logging here.
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("My-Request-Header"); //logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("My-Response-Header");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

//
// Get values from the config, given their key and their target type.
AppSettings settings = config.GetRequiredSection("Settings").Get<AppSettings>();
var k1 = settings.KeyOne;
var k2 = settings.KeyTwo;
var k3 = settings.KeyThree.Message;
var k = config.GetRequiredSection("Settings").Get<AppSettings>().KeyOne;

var app = builder.Build();

//-------------------------------------
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// added for Hangfire
//app.UseHangfireDashboard();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "Hangfire Dashboard - Prj.Net6.API",
    Authorization = new[] { new MyAuthorizationFilter() }
});

// added (Zaw)
app.UseMiddleware<ApiKeyMiddleware>();

// added logging Middleware
app.UseHttpLogging();

// added (Zaw)
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
// configure exception middleware
app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
// 
//app.UseMiddleware<ExceptionHandlingMiddleware2>();


app.UseHttpsRedirection();

//app.UseAuthentication(); // added (Zaw)
app.UseAuthorization();

app.MapControllers();

app.Run();

//
public class MyAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}