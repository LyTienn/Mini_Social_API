using Mini_Social_API.Domain.Entities;

namespace Mini_Social_API.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
    }
}
