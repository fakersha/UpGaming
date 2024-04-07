using MediatR;
using Microsoft.Extensions.Logging;
using UpGaming.Application.Exceptions;
using UpGaming.Application.Services;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetScoresByDay
{
    public class GetScoresByDayQueryHandler : IRequestHandler<GetScoresByDayQuery, List<ScoreData>>
    {
        private readonly IUpGamingScoreService _scoreService;
        private readonly ILogger<GetScoresByDayQueryHandler> _logger;


        public GetScoresByDayQueryHandler(IUpGamingScoreService scoreService, ILogger<GetScoresByDayQueryHandler> logger)
        {
            _scoreService = scoreService;
            _logger = logger;
        }
        public async Task<List<ScoreData>> Handle(GetScoresByDayQuery request, CancellationToken cancellationToken)
        {
            var result = await _scoreService.GetScoresByDayAsync(request.Day);

            if (result is null)
            {
                _logger.LogInformation("No data was found for this day");
                throw new NotFoundException("No data was found for this day");
            }

            return result;
        }
    }
}
