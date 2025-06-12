using Data.SqlServer.KursSystem;
using Kurs.System.Services;
using Kurs.SystemAPI.EndPoints;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", _ =>
    {
        _.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddDataDependencies(builder.Configuration);
builder.Services.AddServiceDependencies(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");

app.ConfigureDataSourceEndPoints();
app.ConfigureUserEndPoints();

app.Run();
