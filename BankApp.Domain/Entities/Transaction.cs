namespace BankApp.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = default!; // e.g., "credit", "debit"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
