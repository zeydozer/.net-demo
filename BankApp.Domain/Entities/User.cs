namespace BankApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        // Domain methods
        public string FullName => $"{FirstName} {LastName}";
    }
}