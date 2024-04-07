using MediatR;
using UpGaming.Application.Services;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUpGamingUserService _userService;

        public GetUsersQueryHandler( IUpGamingUserService userService)
        {
            _userService = userService;
        }
        public Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetUsersAsync();
        }
    }
}
