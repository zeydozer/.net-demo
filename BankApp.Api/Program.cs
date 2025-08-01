using Microsoft.EntityFrameworkCore;
using BankApp.Infrastructure.Data;
using MediatR;
using BankApp.Application;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<BankApp.Application.Transactions.Commands.CreateTransactionHandler>());

builder.Services.AddCors(o =>
    o.AddPolicy("AllowFrontend", p => p.WithOrigins("http://localhost:5173")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod()));

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Transactions.Any())
    {
        db.Transactions.AddRange(new[]
        {
            new BankApp.Domain.Entities.Transaction { AccountId = 1, Amount = 1000, Type = "credit", CreatedAt = DateTime.UtcNow.AddDays(-2) },
            new BankApp.Domain.Entities.Transaction { AccountId = 1, Amount = -200, Type = "debit", CreatedAt = DateTime.UtcNow.AddDays(-1) },
            new BankApp.Domain.Entities.Transaction { AccountId = 2, Amount = 500, Type = "credit", CreatedAt = DateTime.UtcNow },
        });
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
