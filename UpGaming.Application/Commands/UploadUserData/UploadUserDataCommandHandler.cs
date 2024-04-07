using MediatR;
using Microsoft.Extensions.Logging;
using UpGaming.Application.Queries.GetUserInfo;
using UpGaming.Application.Services;

namespace UpGaming.Application.Commands.UploadUserData
{
    public sealed class UploadUserDataCommandHandler : IRequestHandler<UploadUserDataCommand>
    {
        private readonly IUpGamingUserService _userService;
        private readonly ILogger<UploadUserDataCommandHandler> _logger;

        public UploadUserDataCommandHandler(IUpGamingUserService userService, ILogger<UploadUserDataCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task<Unit> Handle(UploadUserDataCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await _userService.UploadUserDataAsync(request.Users);

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
