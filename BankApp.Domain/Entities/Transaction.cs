namespace BankApp.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;

        // Navigation property
        public User User { get; set; } = null!;

        // Domain methods
        public bool IsCredit => Type.Equals("credit", StringComparison.OrdinalIgnoreCase);
        public bool IsDebit => Type.Equals("debit", StringComparison.OrdinalIgnoreCase);
    }
}
