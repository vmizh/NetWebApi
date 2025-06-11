using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});
var message = builder.Configuration.GetValue<string>("message");
app.MapGet("/message", () => $"Что-то - {message}");
app.MapPost("/post_msg/{s:alpha}", PostMsg);

app.Run();

async Task<IResult> PostMsg([FromBody] Test item_dto, string s)
{
    return Results.Ok(item_dto.Message + $" - {s}");
}

internal class Test
{
    public string Message { set; get; }
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
