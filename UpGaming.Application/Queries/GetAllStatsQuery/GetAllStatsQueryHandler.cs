using MediatR;
using Microsoft.Extensions.Logging;
using UpGaming.Application.Exceptions;
using UpGaming.Application.Services;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetAllStatsQuery
{
    public class GetAllStatsQueryHandler : IRequestHandler<GetAllStatsQuery, StatsResult>
    {
        private readonly IUpGamingScoreService _scoreService;
        private readonly ILogger<GetAllStatsQueryHandler> _logger;

        public GetAllStatsQueryHandler(IUpGamingScoreService scoreService, ILogger<GetAllStatsQueryHandler> logger)
        {
            _scoreService = scoreService;
            _logger = logger;   
        }
        public async Task<StatsResult> Handle(GetAllStatsQuery request, CancellationToken cancellationToken)
        {
            var result = await _scoreService.GetStatsAsync();

            if (result is null)
            {
                _logger.LogWarning("No data found");
                throw new NotFoundException("No data found");
            }

            return result!;  
        }
    }
}
