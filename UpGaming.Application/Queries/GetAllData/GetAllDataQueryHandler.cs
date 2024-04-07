using MediatR;
using UpGaming.Application.Exceptions;
using UpGaming.Application.Services;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetAllData
{
    public class GetAllDataQueryHandler : IRequestHandler<GetAllDataQuery, List<UserScoresDto>>
    {
        private readonly IUpGamingScoreService _scoreService;

        public GetAllDataQueryHandler(IUpGamingScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public async Task<List<UserScoresDto>> Handle(GetAllDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _scoreService.GetAllDataAsync();

            if (result is null)
            {
                throw new NotFoundException("Data was not found");
            }

            return result;
        }
    }
}
