namespace BankApp.Application.Transactions.Commands
{
    using MediatR;

    public record CreateTransactionCommand(int AccountId, decimal Amount, string Type) : IRequest<int>;
}
