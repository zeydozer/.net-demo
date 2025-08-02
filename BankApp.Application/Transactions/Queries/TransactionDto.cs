namespace BankApp.Application.Transactions.Queries
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; } = default!;
        public double Amount { get; set; }
        public string Type { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; } = default!;
    }
}
