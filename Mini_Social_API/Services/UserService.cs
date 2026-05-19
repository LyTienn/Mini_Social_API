using Mini_Social_API.Models;
using Mini_Social_API.Repositories;

namespace Mini_Social_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new Exception("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new Exception("Email is required.");
            }

            user.CreatedAt = DateTime.UtcNow;

            return await _userRepository.CreateAsync(user);
        }
    }
}