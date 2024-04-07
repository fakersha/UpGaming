using MediatR;
using Microsoft.Extensions.Logging;
using UpGaming.Application.Exceptions;
using UpGaming.Application.Services;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetUserInfo
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, List<UserInfo>>
    {
        private readonly IUpGamingUserService _userService;
        private readonly ILogger<GetUserInfoQueryHandler> _logger;

        public GetUserInfoQueryHandler(IUpGamingUserService userService, ILogger<GetUserInfoQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task<List<UserInfo>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserInfosAsync(request.UserId);

            if (result == null)
            {
                _logger.LogInformation("Data was not found");
                throw new NotFoundException("Data was not found");
            }

            return result;
        }
    }
}
