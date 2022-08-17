using LoggingWithSerilog_Demo.CustomExceptions;
using LoggingWithSerilog_Demo.DataServices;
using LoggingWithSerilog_Demo.ExtentionExceptionMiddlewareHandler;
using LoggingWithSerilog_Demo.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//Serilog/////////////////////////////
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//End Serilog

// Add services to the container.
builder.Services.AddSingleton<EmployeeServices>();

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
/// <Exceptionmiddleware>
//var loggerExtention = app.Services.GetRequiredService<ILogger<ErrorViewModel>>();
app.ApplyCustomException();

/// </summary>
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
