using Common.Repositories;
using Data.SqlServer.KursSystem;
using Data.SqlServer.KursSystem.Entities;
using Kurs.System.Services;
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

app.MapGet("/datasource", GetDataSource);

static async Task<IEnumerable<DataSource>> GetDataSource(IBaseRepository<DataSource> rep)
{
    var data = await rep.GetAllAsync();
    return data;
}


app.Run();
