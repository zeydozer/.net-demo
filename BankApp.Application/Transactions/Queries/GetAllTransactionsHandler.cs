using Dapper;
using MediatR;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace BankApp.Application.Transactions.Queries
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
    {
        private readonly string _connectionString;

        public GetAllTransactionsHandler(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection") ?? "Data Source=bank.db";
        }

        public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery req, CancellationToken ct)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT Id, AccountId, Amount, Type, CreatedAt FROM Transactions ORDER BY CreatedAt DESC";
            var result = await connection.QueryAsync<TransactionDto>(sql);
            return result.ToList();
        }
    }
}
