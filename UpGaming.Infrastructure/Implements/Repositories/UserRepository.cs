using Dapper;
using System.Data.SqlClient;
using UpGaming.Domain.Entities;
using UpGaming.Domain.Repositories;
using UpGaming.Infrastructure.Models;

namespace UpGaming.Infrastructure.Implements.Repositories
{
    public class UserRepository : IUserRepository, IAsyncDisposable
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public UserRepository(DbConnectionString dbConnectionString)
        {
            _connectionString = dbConnectionString.ConnectionString;
            _connection = new SqlConnection(_connectionString);

        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            string sql = "SELECT * FROM [User]";
            return (await _connection.QueryAsync<UserDto>(sql)).ToList();
        }

        public async Task<List<UserInfo>> GetUserInfosAsync(int userId)
        {

            string sql = @"
                WITH UserMonthScores AS (
                    SELECT
                        MONTH(s.CreateDate) AS Month,
                        UserId,
                        SUM(s.Score) AS TotalPoints
                    FROM Scores s
                    GROUP BY MONTH(s.CreateDate), UserId
                ), RankedUsers AS (
                    SELECT
                        Month,
                        UserId,
                        TotalPoints,
                        RANK() OVER (PARTITION BY Month ORDER BY TotalPoints DESC) AS Position
                    FROM UserMonthScores
                )
                SELECT
                    Month,
                    Position,
                    TotalPoints
                FROM RankedUsers
                WHERE UserId = @UserId";


            var userInfo = await _connection.QueryAsync<UserInfo>(sql, new { UserId = userId });

            return userInfo.ToList();

        }

        public async Task UploadUserDataAsync(List<UserData> users)
        {
            foreach (var user in users)
            {
                string sql = @"
                    INSERT INTO [User] (FirstName, LastName, UserName)
                    VALUES (@FirstName, @LastName, @UserName)";

                await _connection.ExecuteAsync(sql, user);
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _connection.CloseAsync();
            await _connection.DisposeAsync();
        }
    }
}
