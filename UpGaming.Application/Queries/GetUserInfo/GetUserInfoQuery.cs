using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<List<UserInfo>>
    {
        public int UserId { get; set; }
    }
}
