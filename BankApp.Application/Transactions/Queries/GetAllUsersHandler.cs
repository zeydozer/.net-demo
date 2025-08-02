using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace BankApp.Application.Users.Queries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly string _connectionString;

        public GetAllUsersHandler(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection") ?? "Data Source=bank.db";
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery req, CancellationToken ct)
        {
            using var connection = new SqliteConnection(_connectionString);
            
            const string sql = """
                SELECT 
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.CreatedAt
                FROM Users u
                ORDER BY u.CreatedAt DESC
            """;

            var result = await connection.QueryAsync<UserDto>(sql);
            return result.ToList();
        }
    }
}