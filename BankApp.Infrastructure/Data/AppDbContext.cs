using Microsoft.EntityFrameworkCore;
using BankApp.Domain.Entities;

namespace BankApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Transaction> Transactions => Set<Transaction>();
    }
}
