using Mini_Social_API.Application.Dtos;
using Mini_Social_API.Application.Interfaces;
using Mini_Social_API.Domain.Entities;

namespace Mini_Social_API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                CreatedAt = user.CreatedAt
            }).ToList();
        }

        public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
            {
                throw new Exception("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                throw new Exception("Password is required.");
            }

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                AvatarUrl = dto.AvatarUrl,
                CreatedAt = DateTime.UtcNow
            };

            var createdUser = await _userRepository.CreateAsync(user);

            return new UserResponseDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email,
                AvatarUrl = createdUser.AvatarUrl,
                CreatedAt = createdUser.CreatedAt
            };
        }
    }
}
