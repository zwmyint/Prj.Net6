using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prj.Net6.Core.Interfaces;
using Prj.Net6.Infrastructure;
using Prj.Net6.Infrastructure.Repositories;
using Prj.Net6.WebApp_API.Middleware;
using Prj.Net6.WebApp_API.Sinks;
using Serilog;

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


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// added (Zaw)
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

// added (Zaw)
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

app.UseAuthentication(); // added (Zaw)
app.UseAuthorization();

app.MapControllers();

app.Run();
