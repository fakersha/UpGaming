using Dapper;
using System.Data.SqlClient;
using UpGaming.Domain.Entities;
using UpGaming.Domain.Repositories;
using UpGaming.Infrastructure.Models;

namespace UpGaming.Infrastructure.Implements.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(DbConnectionString dbConnectionString)
        {
            _connectionString = dbConnectionString.ConnectionString;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string sql = "SELECT * FROM [User]";
                return (await connection.QueryAsync<UserDto>(sql)).ToList();
            }
        }

        public async Task<List<UserInfo>> GetUserInfosAsync(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

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


                var userInfo = await connection.QueryAsync<UserInfo>(sql, new { UserId = userId });

                return userInfo.ToList();
            }
        }

        public async Task UploadUserDataAsync(List<UserData> users)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                foreach (var user in users)
                {
                    string sql = @"
                    INSERT INTO [User] (FirstName, LastName, UserName)
                    VALUES (@FirstName, @LastName, @UserName)";

                    await connection.ExecuteAsync(sql, user);
                }
            }
        }
    }
}
