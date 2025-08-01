using Microsoft.EntityFrameworkCore;
using BankApp.Domain.Entities;

namespace BankApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Type).HasMaxLength(50);
                entity.HasIndex(e => e.AccountId);
                entity.HasIndex(e => e.CreatedAt);
            });
        }
    }
}
