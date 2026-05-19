using Mini_Social_API.Models;

namespace Mini_Social_API.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
    }
}