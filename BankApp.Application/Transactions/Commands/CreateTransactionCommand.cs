using MediatR;

namespace BankApp.Application.Transactions.Commands;

public record CreateTransactionCommand(
    int AccountId,
    int UserId,
    decimal Amount,
    string Type,
    string Description = ""
) : IRequest<int>;