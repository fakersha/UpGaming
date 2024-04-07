using UpGaming.Domain.Entities;

namespace UpGaming.Application.Services
{
    public interface IUpGamingUserService
    {
        Task UploadUserDataAsync(List<UserData> users);
        Task<List<UserDto>> GetUsersAsync();
        Task<List<UserInfo>> GetUserInfosAsync(int userId);

    }
}
