using Mini_Social_API.Models;

namespace Mini_Social_API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> CreateAsync(User user);
    }
}