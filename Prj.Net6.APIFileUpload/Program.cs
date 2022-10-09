using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prj.Net6.APIFileUpload;
using Prj.Net6.APIFileUpload.Data;
using Prj.Net6.APIFileUpload.Entities;
using Prj.Net6.APIFileUpload.Services;

var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json");

var config = configuration.Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IFileService, FileService>();

// using DP FileUpload
builder.Services.Configure<ReaderModel>(config.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IUploadService, FileUploadService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
