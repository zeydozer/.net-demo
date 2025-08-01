using BankApp.Infrastructure.Data;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void SeedDatabase(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            if (!db.Transactions.Any())
            {
                db.Transactions.AddRange(new[]
                {
                    new Transaction { AccountId = 1, Amount = 1000, Type = "credit", CreatedAt = DateTime.UtcNow.AddDays(-2) },
                    new Transaction { AccountId = 1, Amount = -200, Type = "debit", CreatedAt = DateTime.UtcNow.AddDays(-1) },
                    new Transaction { AccountId = 2, Amount = 500, Type = "credit", CreatedAt = DateTime.UtcNow },
                });
                db.SaveChanges();
            }
        }
    }
}
