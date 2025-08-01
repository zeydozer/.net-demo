namespace BankApp.Application.Transactions.Queries
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
