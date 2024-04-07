using UpGaming.Domain.Entities;

namespace UpGaming.Domain.Repositories
{
    public interface IScoresRepository
    {
        Task<List<ScoreData>> GetScoresByDayAsync(DateTime day);
        Task<List<ScoreData>> GetScoresByMonthAsync(DateTime day);
        Task<List<UserScoresDto>> GetAllDataAsync();
        Task<StatsResult> GetStatsAsync();

        Task UploadUserScoresAsync(List<UserScores> userScores);
    }
}
