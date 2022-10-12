using Prj.Net6.APIDPWithSP.Models;
using Prj.Net6.APIDPWithSP.Services;

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

// using DP 
builder.Services.Configure<ReaderModel>(config.GetSection("ConnectionStrings"));
builder.Services.AddSingleton<IAuthManager, AuthManager>();
builder.Services.AddScoped<IDapperRepository, DapperRepository>();


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
