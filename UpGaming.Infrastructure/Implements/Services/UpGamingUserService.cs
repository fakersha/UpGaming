using UpGaming.Application.Services;
using UpGaming.Domain.Entities;
using UpGaming.Domain.Repositories;

namespace UpGaming.Infrastructure.Implements.Services
{
    public class UpGamingUserService : IUpGamingUserService
    {
        private readonly IUserRepository _userRepository;
        public UpGamingUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<List<UserInfo>> GetUserInfosAsync(int userId)
        {
            return await _userRepository.GetUserInfosAsync(userId);
        }

        public async Task UploadUserDataAsync(List<UserData> users)
        {
            await _userRepository.UploadUserDataAsync(users);
        }
    }
}
