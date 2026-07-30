using Mini_Social_API.Application.Dtos;

namespace Mini_Social_API.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto> CreateAsync(CreateUserDto dto);
    }
}
