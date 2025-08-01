using MediatR;
using System.Collections.Generic;

namespace BankApp.Application.Transactions.Queries
{
    public record GetAllTransactionsQuery() : IRequest<List<TransactionDto>>;
}
