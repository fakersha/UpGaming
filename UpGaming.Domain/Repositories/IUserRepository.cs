using UpGaming.Domain.Entities;

namespace UpGaming.Domain.Repositories
{
    public interface IUserRepository
    {
        Task UploadUserDataAsync(List<UserData> users);
        Task<List<UserDto>> GetAllUsersAsync();

        Task<List<UserInfo>> GetUserInfosAsync(int userId);
    }
}
