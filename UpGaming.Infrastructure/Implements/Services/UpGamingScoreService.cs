using UpGaming.Application.Services;
using UpGaming.Domain.Entities;
using UpGaming.Domain.Repositories;

namespace UpGaming.Infrastructure.Implements.Services
{
    public class UpGamingScoreService : IUpGamingScoreService
    {
        private readonly IScoresRepository _repository;

        public UpGamingScoreService(IScoresRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserScoresDto>> GetAllDataAsync()
        {
            return await _repository.GetAllDataAsync().ConfigureAwait(false);
        }

        public async Task<List<ScoreData>> GetScoresByDayAsync(DateTime day)
        {
            return await _repository.GetScoresByDayAsync(day).ConfigureAwait(false);
        }

        public async Task<List<ScoreData>> GetScoresByMonthAsync(DateTime month)
        {
            return await _repository.GetScoresByMonthAsync(month).ConfigureAwait(false);
        }

        public async Task<StatsResult> GetStatsAsync()
        {
            return await _repository.GetStatsAsync().ConfigureAwait(false);
        }

        public async Task UploadUserScoresAsync(List<UserScores> userScores)
        {
            await _repository.UploadUserScoresAsync(userScores).ConfigureAwait(false);
        }

    }
}
