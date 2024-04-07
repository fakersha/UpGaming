using UpGaming.Domain.Entities;

namespace UpGaming.Application.Services
{
    public interface IUpGamingScoreService
    {
        Task<List<ScoreData>> GetScoresByDayAsync(DateTime day);
        Task<List<ScoreData>> GetScoresByMonthAsync(DateTime day);
        Task<List<UserScoresDto>> GetAllDataAsync();
        Task<StatsResult> GetStatsAsync();
        Task UploadUserScoresAsync(List<UserScores> userScores);

    }
}
