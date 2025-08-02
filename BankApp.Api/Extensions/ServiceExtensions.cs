using BankApp.Infrastructure.Data;
using BankApp.Domain.Entities;

namespace BankApp.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void SeedDatabase(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.Database.EnsureCreated();

            if (!db.Users.Any())
            {
                var users = new[]
                {
                    new User { FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                    new User { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" },
                    new User { FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com" }
                };
                db.Users.AddRange(users);
                db.SaveChanges();
            }

            if (!db.Transactions.Any())
            {
                var users = db.Users.ToList();
                var transactions = new[]
                {
                    new Transaction { AccountId = 1001, UserId = users[0].Id, Amount = 1500.00m, Type = "credit", Description = "Salary deposit" },
                    new Transaction { AccountId = 1001, UserId = users[0].Id, Amount = -250.75m, Type = "debit", Description = "Grocery shopping" },
                    new Transaction { AccountId = 1002, UserId = users[1].Id, Amount = 2000.00m, Type = "credit", Description = "Freelance payment" },
                    new Transaction { AccountId = 1002, UserId = users[1].Id, Amount = -89.99m, Type = "debit", Description = "Online subscription" },
                    new Transaction { AccountId = 1003, UserId = users[2].Id, Amount = 500.00m, Type = "credit", Description = "Gift money" }
                };
                db.Transactions.AddRange(transactions);
                db.SaveChanges();
            }
        }
    }
}
