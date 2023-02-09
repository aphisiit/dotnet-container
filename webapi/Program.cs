using LogConfigure;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;
using webapi;
using webapi.PostgreSQL;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();

builder.Services.AddHealthChecks()
    .AddCheck<HealthCheck>(nameof(HealthCheck))
    .ForwardToPrometheus();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoService, TodoService>();

var logConfigure = new LogConfigure.LogConfigure();
builder.Host.UseSerilog();

string conStrPostgreSQL = builder.Configuration.GetConnectionString("PostgreSQL"); 

builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseNpgsql(conStrPostgreSQL, npgsqlOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }).UseSnakeCaseNamingConvention();
}, ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthz");

app.UseAuthorization();

app.MapControllers();

app.Run();
