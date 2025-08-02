using Dapper;
using MediatR;
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
            
            const string sql = """
                SELECT 
                    t.Id,
                    t.AccountId,
                    t.UserId,
                    COALESCE(u.FirstName || ' ' || u.LastName, '') as UserFullName,
                    CAST(t.Amount AS REAL) as Amount,
                    t.Type,
                    t.CreatedAt,
                    COALESCE(t.Description, '') as Description
                FROM Transactions t
                LEFT JOIN Users u ON t.UserId = u.Id
                ORDER BY t.CreatedAt DESC
            """;
            
            var result = await connection.QueryAsync<TransactionDto>(sql);
            return result.ToList();
        }
    }
}
