using Microsoft.EntityFrameworkCore;
using BankApp.Infrastructure.Data;
using MediatR;
using BankApp.Application;
using BankApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
app.Services.SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
