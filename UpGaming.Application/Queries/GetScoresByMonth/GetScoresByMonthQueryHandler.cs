using MediatR;
using Microsoft.Extensions.Logging;
using UpGaming.Application.Exceptions;
using UpGaming.Application.Services;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetScoresByMonth
{
    public class GetScoresByMonthQueryHandler : IRequestHandler<GetScoresByMonthQuery, List<ScoreData>>
    {
        private readonly IUpGamingScoreService _scoreService;
        private readonly ILogger<GetScoresByMonthQueryHandler> _logger;


        public GetScoresByMonthQueryHandler(IUpGamingScoreService scoreService, ILogger<GetScoresByMonthQueryHandler> logger)
        {
            _scoreService = scoreService;
            _logger = logger;
        }
        public async Task<List<ScoreData>> Handle(GetScoresByMonthQuery request, CancellationToken cancellationToken)
        {
            var result = await _scoreService.GetScoresByDayAsync(request.Month);

            if (result is null)
            {
                _logger.LogInformation("No data was found for this month");
                throw new NotFoundException("No data was found for this month");
            }

            return result;
        }
    }
}
