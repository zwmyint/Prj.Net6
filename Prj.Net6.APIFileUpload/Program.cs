using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Prj.Net6.APIFileUpload;
using Prj.Net6.APIFileUpload.Data;
using Prj.Net6.APIFileUpload.Entities;
using Prj.Net6.APIFileUpload.Services;
using Serilog;
using Serilog.Formatting.Json;

var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json");

var config = configuration.Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string logPath = "./logs/webapi-.log";
var logger = new LoggerConfiguration()
    //.WriteTo.Console()
    .WriteTo.File(new JsonFormatter(), logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

logger.Information("Args: {Args}", args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IFileService, FileService>();

// using DP FileUpload
builder.Services.Configure<ReaderModel>(config.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IUploadService, FileUploadService>();

// userpwd
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Static File Setup
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
    RequestPath = "/StaticFiles",
    EnableDefaultFiles = true
});
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
