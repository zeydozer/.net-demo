namespace BankApp.Application.Transactions.Commands
{
    using MediatR;
    using BankApp.Domain.Entities;
    using BankApp.Infrastructure.Data;

    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly AppDbContext _db;
        public CreateTransactionHandler(AppDbContext db) => _db = db;

        public async Task<int> Handle(CreateTransactionCommand req, CancellationToken ct)
        {
            var tx = new Transaction
            {
                AccountId = req.AccountId,
                UserId = req.UserId,
                Amount = req.Amount,
                Type = req.Type,
                Description = req.Description,
                CreatedAt = DateTime.UtcNow
            };
            _db.Transactions.Add(tx);
            await _db.SaveChangesAsync(ct);
            return tx.Id;
        }
    }
}
