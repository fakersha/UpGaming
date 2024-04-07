using MediatR;
using Microsoft.Extensions.Logging;
using UpGaming.Application.Services;

namespace UpGaming.Application.Commands.UploadUserScores
{
    public class UploadUserScoresCommandHandler : IRequestHandler<UploadUserScoresCommand>
    {
        private readonly IUpGamingScoreService _scoreService;
        private readonly ILogger<UploadUserScoresCommandHandler> _logger;

        public UploadUserScoresCommandHandler(IUpGamingScoreService scoreService, ILogger<UploadUserScoresCommandHandler> logger)
        {
            _scoreService = scoreService;
            _logger = logger;
        }

        async Task<Unit> IRequestHandler<UploadUserScoresCommand, Unit>.Handle(UploadUserScoresCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await _scoreService.UploadUserScoresAsync(request.UserScores);

                return Unit.Value;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }

        }
    }
}
