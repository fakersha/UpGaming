using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using UpGaming.Domain.Entities;
using UpGaming.Domain.Repositories;
using UpGaming.Infrastructure.Models;

namespace UpGaming.Infrastructure.Implements.Repositories
{
    public class ScoresRepository : IScoresRepository
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public ScoresRepository(DbConnectionString dbConnectionString)
        {
            _connectionString = dbConnectionString.ConnectionString;
            _connection = new SqlConnection(_connectionString);

        }

        public async Task<List<UserScoresDto>> GetAllDataAsync()
        {
            string sql = @"
                SELECT u.Id AS Id, u.UserName, s.Score
                FROM [User] u
                INNER JOIN Scores s ON u.Id = s.UserId";

            var scoresWithUserData = await _connection.QueryAsync<UserScoresDto>(sql);

            return scoresWithUserData.ToList();
        }

        public async Task<List<ScoreData>> GetScoresByDayAsync(DateTime day)
        {
            string sql = @"
                SELECT u.Id, u.FirstName, u.LastName, SUM(s.Score) AS Score
                FROM [User] u
                INNER JOIN Scores s ON u.Id = s.UserId
                WHERE CONVERT(DATE, s.CreateDate) = @Day
                GROUP BY u.Id, u.FirstName, u.LastName";

            var userScores = await _connection.QueryAsync<ScoreData>(sql, new { Day = day });

            return userScores.ToList();
        }

        public async Task<List<ScoreData>> GetScoresByMonthAsync(DateTime month)
        {
            string sql = @"
                SELECT u.Id, u.FirstName, u.LastName, SUM(s.Score) AS Score
                FROM [User] u
                INNER JOIN Scores s ON u.Id = s.UserId
                WHERE MONTH(s.CreateDate) = MONTH(@Month) AND YEAR(s.CreateDate) = YEAR(@Month)
                GROUP BY u.Id, u.FirstName, u.LastName";

            var userScores = await _connection.QueryAsync<ScoreData>(sql, new { Month = new DateTime(month.Year, month.Month, 1) });

            return userScores.ToList();
        }

        public async Task<StatsResult> GetStatsAsync()
        {
            var sql = @"
                SELECT 
                    AVG(s.Score) AS DailyAverage,
                    AVG(s.Score) AS MonthlyAverage,
                    MAX(s.Score) AS MaxDailyScore,
                    MAX(s.Score) AS MaxMonthlyScore,
                    MAX(s.Score) AS MaxMonthlyScoreResponseType
                FROM Scores s";

            return await _connection.QueryFirstAsync<StatsResult>(sql);
        }

        public async Task UploadUserScoresAsync(List<UserScores> userSCores)
        {
            foreach (var userPoint in userSCores)
            {
                string sql = @"
                    INSERT INTO Scores (UserId, CreateDate, Score)
                    VALUES (@UserId, GETDATE(), @Score)";

                await _connection.ExecuteAsync(sql, userPoint);
            }
        }
    }
}
