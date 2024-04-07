using Microsoft.AspNetCore.Mvc;
using UpGaming.Application.Commands.UploadUserData;
using UpGaming.Application.Queries.GetUserInfo;
using UpGaming.Application.Queries.GetUsers;
using UpGaming.Application.Services;
using UpGaming.Domain.Entities;

namespace UpGaming.API.Controllers
{
    public class UserController : ApiControllerBase
    {

        [HttpPost("upload-user-datas")]
        public async Task UploadUserDatas([FromBody] UploadUserDataCommand request) => await Mediator.Send(request);

        [HttpGet("get-user-info")]
        public async Task<List<UserInfo>> GetUserInfo(GetUserInfoQuery request) => await Mediator.Send(request);

        [HttpGet("get-all-users")]
        public async Task<List<UserDto>> GetAllUsers(GetUsersQuery request) => await Mediator.Send(request);

    }
}
