using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
    }
}
