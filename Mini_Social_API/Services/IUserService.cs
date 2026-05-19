using Mini_Social_API.Dtos;

namespace Mini_Social_API.Services
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto> CreateAsync(CreateUserDto dto);
    }
}