using Dapper;
using MediatR;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace BankApp.Application.Transactions.Queries
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
    {
        private readonly IDbConnection _db;

        public GetAllTransactionsHandler(IConfiguration config)
        {
            // Bağlantı dizesi: appsettings.json veya env'den alınabilir
            _db = new SqliteConnection("Data Source=bank.db"); // veya SqlConnection
        }

        public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery req, CancellationToken ct)
        {
            var sql = "SELECT Id, AccountId, Amount, Type, CreatedAt FROM Transactions ORDER BY CreatedAt DESC";
            var result = await _db.QueryAsync<TransactionDto>(sql);
            return result.ToList();
        }
    }
}
